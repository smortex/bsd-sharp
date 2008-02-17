# New ports collection makefile for:		ikvm
# Date created:					20040907
# Whom:				Tom McLaughlin <tmclaugh@sdf.lonestar.org>
#
# $FreeBSD$
#   $Id: Makefile,v 1.11 2006/02/01 23:32:56 tmclau02 Exp $
#

PORTNAME=	ikvm
PORTVERSION=	0.22
CATEGORIES=	java
MASTER_SITES=	http://www.go-mono.com/sources/${PORTNAME}/

MAINTAINER=	tmclaugh@sdf.lonestar.org
COMMENT=	Java for Mono and the Microsoft .NET Framework

BUILD_DEPENDS=	${LOCALBASE}/bin/mono:${PORTSDIR}/lang/mono
RUN_DEPENDS=	${BUILD_DEPENDS}

USE_GNOME=	gnometarget
GNU_CONFIGURE=	yes

post-patch:
	@${REINPLACE_CMD} -e 's|[(]prefix[)]/lib/pkgconfig|(prefix)/libdata/pkgconfig|g' ${WRKSRC}/Makefile.in

.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include <bsd.port.mk>
