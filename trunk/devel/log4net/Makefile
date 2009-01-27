# New ports collection makefile for:		log4net
# Date created:					July 8th, 2005
# Whom:				Christopher Nehren <apeiron@coitusmentis.info>
#
# $FreeBSD$
#   $Id: Makefile,v 1.13 2006/10/10 00:26:57 killfill Exp $
#

PORTNAME=	log4net
PORTVERSION=	1.2.10
CATEGORIES=	devel
MASTER_SITES=	http://archive.apache.org/dist/incubator/log4net/${PORTVERSION}/
DISTNAME=	incubating-${PORTNAME}-${PORTVERSION}

MAINTAINER=	mono@FreeBSD.org
COMMENT=	Port for .NET of the Apache Logging Services project

BUILD_DEPENDS=	mono:${PORTSDIR}/lang/mono
RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono

WRKSRC=	${WRKDIR}/${PORTNAME}-${PORTVERSION}

USE_ZIP=	yes
NO_BUILD=	yes

do-install:
	@(cd ${INSTALL_WRKSRC}/bin/mono/1.0/release && ${SETENV} MONO_SHARED_DIR=${WRKDIR} ${LOCALBASE}/bin/gacutil /root ${PREFIX}/lib/ /gacdir ${PREFIX}/lib /package 1.0 /i log4net.dll)

post-install:
.if !defined (NOPORTDOCS)
	@${ECHO_CMD} "Installing documentation..."
	@${MKDIR} ${DOCSDIR}
	@cd ${WRKSRC}/doc; ${FIND} . | ${CPIO} -pdm -R \
	${DOCOWN}:${DOCGRP} ${DOCSDIR}
	@${CHMOD} -R ugo-w,ugo+rX ${DOCSDIR}
	@${ECHO_CMD} "Installing examples..."
	@${MKDIR} ${EXAMPLESDIR}
	@cd ${WRKSRC}/examples; ${FIND} . \
	| ${CPIO} -pdm -R ${DOCOWN}:${DOCGRP} ${EXAMPLESDIR}
	@${CHMOD} -R ugo-w,ugo+rX ${EXAMPLESDIR}
.endif

.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include <bsd.port.mk>
