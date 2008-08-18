# New ports collection makefile for:		Boo
# Date created:					June 17, 2005
# Whom:				Christopher Nehren <apeiron@coitusmentis.info>
#
# $FreeBSD$
#   $Id: Makefile,v 1.26 2007/10/27 05:33:27 killfill Exp $
#

PORTNAME=	boo
PORTVERSION=	0.8.2.2960
CATEGORIES=	lang
MASTER_SITES=	http://dist.codehaus.org/boo/distributions/
DISTNAME=	${PORTNAME}-${PORTVERSION}-src

MAINTAINER=	bsd-sharp@googlegroups.com
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
