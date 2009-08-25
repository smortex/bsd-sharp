# New ports collection makefile for:	nini
# Date created:		2009-04-27
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	nini
PORTVERSION=	1.1.0
CATEGORIES=	devel
MASTER_SITES=	SF
DISTNAME=	Nini-${PORTVERSION}

MAINTAINER=	mono@FreeBSD.org
COMMENT=	NET configuration library

BUILD_DEPENDS=	mono:${PORTSDIR}/lang/mono
RUN_DEPENDS=	${BUILD_DEPENDS}

USE_ZIP=	yes
NO_BUILD=	yes

WRKSRC=		${WRKDIR}/Nini

do-install:
	@(cd ${INSTALL_WRKSRC}/Bin/Mono/1.1/Release && ${SETENV} MONO_SHARED_DIR=${WRKDIR} ${LOCALBASE}/bin/gacutil /root ${PREFIX}/lib/ /gacdir ${PREFIX}/lib /package 2.0 /i Nini.dll)
	@${SED} -e 's|@PREFIX@|${PREFIX}|' -e 's|@PORTVERSION@|${PORTVERSION}|' < ${FILESDIR}/nini-1.1.pc.in > ${PREFIX}/libdata/pkgconfig/nini-1.1.pc
.if !defined (NOPORTEXAMPLES)
	@${MKDIR} ${EXAMPLESDIR}
	@(cd ${WRKSRC}/Examples/ && ${COPYTREE_SHARE} \* ${EXAMPLESDIR})
.endif
.if !defined (NOPORTDOCS)
	@${MKDIR} ${DOCSDIR}
	@(cd ${WRKSRC}/Docs/ && ${COPYTREE_SHARE} \* ${DOCSDIR})
.endif

.include <bsd.port.mk>
