# New ports collection makefile for:		Boo
# Date created:					June 17, 2005
# Whom:				Christopher Nehren <apeiron@coitusmentis.info>
#
# $FreeBSD$
#

PORTNAME=	boo
PORTVERSION=	0.9.2
CATEGORIES=	lang
MASTER_SITES=	http://dist.codehaus.org/boo/distributions/
DISTNAME=	${PORTNAME}-${PORTVERSION}.3383-src

MAINTAINER=	mono@FreeBSD.org
COMMENT=	A CLI-targeted programming language similar to Python

BUILD_DEPENDS=	${LOCALBASE}/libdata/pkgconfig/shared-mime-info.pc:${PORTSDIR}/misc/shared-mime-info \
		${LOCALBASE}/libdata/pkgconfig/gtksourceview-1.0.pc:${PORTSDIR}/x11-toolkits/gtksourceview
RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono
PATCH_DEPENDS=	iconv:${PORTSDIR}/converters/libiconv

WRKSRC=		${WRKDIR}
USE_ZIP=	yes
USE_NANT=	yes

post-extract:
	@${REINPLACE_CMD} \
	-e 's|"install.prefix" value="/usr/local"|"install.prefix" value="${PREFIX}"|' \
	${WRKSRC}/default.build

post-install:
	${LOCALBASE}/bin/update-mime-database ${LOCALBASE}/share/mime

.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include <bsd.port.mk>
