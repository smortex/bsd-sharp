# New ports collection makefile for:		gmime2-sharp
# Date Created:					20050513
# Whom:				Tom McLaughlin <tmclaugh@sdf.lonestar.org>
#
# $FreeBSD: ports/mail/gmime2-sharp/Makefile,v 1.14 2008/07/25 22:46:14 miwi Exp $
#   $Id: Makefile,v 1.17 2006/10/26 18:37:29 tmclau02 Exp $
#

PORTNAME=	gmime
PORTVERSION=	2.2.23
PORTREVISION?=	0
CATEGORIES=	mail
MASTER_SITES=	GNOME
PKGNAMESUFFIX=	-sharp20

MAINTAINER=	bsd-sharp@googlegroups.com
COMMENT=	Mono bindings for gmime

LIB_DEPENDS=	gmime-2.4:${PORTSDIR}/mail/gmime2

BUILD_WRKSRC=	${WRKSRC}/mono
INSTALL_WRKSRC=	${BUILD_WRKSRC}
DESCR=		${.CURDIR}/pkg-descr
PLIST=		${.CURDIR}/pkg-plist

USE_GMAKE=	yes
USE_LDCONFIG=	yes
GNU_CONFIGURE=	yes
USE_GNOME=	gnomehack gnometarget glib20 gtksharp20
CONFIGURE_ARGS=	--enable-mono=yes
CONFIGURE_ENV=	CPPFLAGS="-I${LOCALBASE}/include ${PTHREAD_CFLAGS}" \
		LIBS="-L${LOCALBASE}/lib"

# Else we conflict with mail/gmime2
NOPORTDOCS=	yes

# Done in pre-configure because master port has a post-patch target already.
pre-configure:
	@${REINPLACE_CMD} -e 's|.@GMIME_VERSION@||g' \
		${WRKSRC}/mono/gmime-sharp.dll.config.in

post-patch:
	cd ${WRKSRC}/mono && uudecode gmime-sharp.snk.uu

.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include <bsd.port.mk>
