# New ports collection makefile for:		NHibernate
# Date created:					Wednesday, June 22, 2005
# Whom:			Christopher Nehren <apeiron+ports@coitusmentis.info>
#
# $FreeBSD$
#   $Id: Makefile,v 1.17 2006/10/26 02:49:15 tmclau02 Exp $
#

PORTNAME=	nhibernate
DISTVERSION=	1.0.2.0
CATEGORIES=	databases
MASTER_SITES=	${MASTER_SITE_SOURCEFORGE}
MASTER_SITE_SUBDIR=	${PORTNAME}

MAINTAINER=	bsd-sharp@googlegroups.com
COMMENT=	A .NET port of the Java Hibernate relational persistence tool

RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono \
		${LOCALBASE}/lib/mono/1.0/log4net.dll:${PORTSDIR}/devel/log4net

WRKSRC=		${WRKDIR}

NO_BUILD=	yes
USE_ZIP=	yes

RESTRICTED=	"no redistribution in source form"

# XXX: Everything except for NHibernate.dll should be in its own port, but
# NHibernate requires the specific versions with which it's shipped. Grr.
ASSEMBLIES=	Iesi.Collections.dll

do-install:
	@(cd ${WRKDIR}/bin ; ${SETENV} MONO_SHARED_DIR=${WRKDIR} apply "${LOCALBASE}/bin/gacutil /root ${PREFIX}/lib/ /gacdir ${PREFIX}/lib /i \%1" ${ASSEMBLIES})
	@(cd ${WRKDIR}/bin ; ${SETENV} MONO_SHARED_DIR=${WRKDIR} ${LOCALBASE}/bin/gacutil /root ${PREFIX}/lib/ /gacdir ${PREFIX}/lib /package 1.0 /i NHibernate.dll)

post-install:
.if !defined(NOPORTDOCS)
	@${MKDIR} ${DOCSDIR}
	@cd ${WRKSRC}/doc/; ${FIND} html \
	| ${CPIO} -pdmv -R ${DOCOWN}:${DOCGRP} ${DOCSDIR}
	@${CHMOD} -R ugo-w,ugo+rX ${DOCSDIR}
.endif

.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include <bsd.port.mk>
