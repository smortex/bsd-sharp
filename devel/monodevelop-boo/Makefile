# New ports collection makefile for:	monodevelop-boo
# Date created:		2008-03-02
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	monodevelop-boo
PORTVERSION=	1.0
CATEGORIES=	devel
MASTER_SITES=	http://ftp.novell.com/pub/mono/sources/${PORTNAME}/

MAINTAINER=	romain@blogreen.org
COMMENT=	MonoDevelop Boo language support

BUILD_DEPENDS=	bash:${PORTSDIR}/shells/bash \
	${LOCALBASE}/libdata/pkgconfig/monodevelop.pc:${PORTSDIR}/devel/monodevelop \
	booc:${PORTSDIR}/lang/boo
RUN_DEPENDS=	${LOCALBASE}/libdata/pkgconfig/monodevelop.pc:${PORTSDIR}/devel/monodevelop \
	booc:${PORTSDIR}/lang/boo

HAS_CONFIGURE=	yes
USE_GMAKE=	yes
USE_GETTEXT=	yes
CONFIGURE_ARGS=	--prefix=${PREFIX}
USE_GNOME=	gtksharp20

post-patch:
	@${REINPLACE_CMD} -e 's|[(]prefix[)]/lib/pkgconfig|(prefix)/libdata/pkgconfig|g' \
		${WRKSRC}/BooBinding.make ${WRKSRC}/BooShell/Makefile
	@${REINPLACE_CMD} -e 's|@prefix@/lib/pkgconfig|@prefix@/libdata/pkgconfig|g' \
		${WRKSRC}/Makefile.include

.include <bsd.port.pre.mk>
.include <bsd.port.post.mk>
