# New ports collection makefile for:		ikvm
# Date created:					20040907
# Whom:				Tom McLaughlin <tmclaugh@sdf.lonestar.org>
#
# $FreeBSD$
#   $Id: Makefile,v 1.11 2006/02/01 23:32:56 tmclau02 Exp $
#

PORTNAME=	ikvm
PORTVERSION=	0.40.0.1
CATEGORIES=	devel java
MASTER_SITES=	${MASTER_SITE_SOURCEFORGE}
MASTER_SITE_SUBDIR=	${PORTNAME}
DISTFILES=	${PORTNAME}bin-${PORTVERSION}${EXTRACT_SUFX}

MAINTAINER=	mono@FreeBSD.org
COMMENT=	Java for Mono and the Microsoft .NET Framework

BUILD_DEPENDS=	${LOCALBASE}/bin/mono:${PORTSDIR}/lang/mono
RUN_DEPENDS=	${BUILD_DEPENDS}

USE_ZIP=	yes
USE_GNOME=	gnometarget
NO_BUILD=	yes

.include <bsd.port.pre.mk>

do-install:
	${MKDIR} ${PREFIX}/lib/${PORTNAME}
	@(cd ${WRKSRC}/bin/ && ${COPYTREE_SHARE} \* ${PREFIX}/lib/${PORTNAME})
.if ${ARCH} != "amd64"
	@(cd ${WRKSRC}/bin-x64/ && ${COPYTREE_SHARE} JVM.DLL ikvm-native.dll ${PREFIX}/lib/${PORTNAME})
.endif
.for f in ikvm ikvmc ikvmstub
	@${ECHO_CMD} "#!/bin/sh\n${PREFIX}/bin/mono ${PREFIX}/lib/${PORTNAME}/$f.exe \"\$$@\"" > ${PREFIX}/bin/$f
	${CHMOD} 755 ${PREFIX}/bin/$f
.endfor

.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include <bsd.port.post.mk>
