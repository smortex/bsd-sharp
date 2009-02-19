# New ports collection makefile for:    	monodevelop
# Date created:         			20040906
# Whom:				Tom McLaughlin <tmclaugh@sdf.lonestar.org>
#
# $FreeBSD$
#   $Id: Makefile,v 1.48 2007/11/07 20:30:04 killfill Exp $
#

PORTNAME=	monodevelop
PORTVERSION=	1.9.2
CATEGORIES=	devel
MASTER_SITES=	http://ftp.novell.com/pub/mono/sources/${PORTNAME}/

MAINTAINER=	mono@FreeBSD.org
COMMENT=	IDE for the .NET platform

BUILD_DEPENDS=	${LOCALBASE}/libdata/pkgconfig/gtksourceview-sharp-2.0.pc:${PORTSDIR}/x11-toolkits/gtksourceview-sharp \
		mautil:${PORTSDIR}/devel/mono-addins
RUN_DEPENDS=	${LOCALBASE}/libdata/pkgconfig/gtksourceview-sharp-2.0.pc:${PORTSDIR}/x11-toolkits/gtksourceview-sharp \
		${LOCALBASE}/lib/libgdiplus.a:${PORTSDIR}/x11-toolkits/libgdiplus \
		mautil:${PORTSDIR}/devel/mono-addins

USE_GNOME=	gnometarget gnomehack gtksharp20 gnomesharp20
USE_GMAKE=	yes
USE_AUTOTOOLS=	libtool:15
USE_BZIP2=	yes
CONFIGURE_ARGS+=	DATADIRNAME=share GMSGFMT=msgfmt \
			--enable-aspnet --enable-aspnetedit
MAN1=		mdtool.1 monodevelop.1

OPTIONS=	SVN "Enable subversion support" on

.include <bsd.port.pre.mk>

.if !defined(WITHOUT_SVN)
RUN_DEPENDS+=	svn:${PORTSDIR}/devel/subversion
CONFIGURE_ARGS+=	--enable-subversion
PLIST_SUB+=	SVN=""
.else
CONFIGURE_ARGS+=	--disable-subversion
PLIST_SUB+=	SVN="@comment "
.endif

post-patch:
	@${REINPLACE_CMD} -e 's|[(]gnome_data[)]/mime$$|(prefix)/share/mime|g ; \
		s|[(]gnome_data[)]/mime/packages$$|(prefix)/share/mime/packages|g ; \
		s|[(]prefix[)]/lib/pkgconfig|(prefix)/libdata/pkgconfig|g' \
			${WRKSRC}/Makefile.in
	@${REINPLACE_CMD} -e 's|/bin/bash|/usr/bin/env bash|' \
		${WRKSRC}/monodevelop.in

post-install:
	@-update-desktop-database

.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include <bsd.port.post.mk>
