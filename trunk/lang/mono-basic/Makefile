# New ports collection makefile for:	mono-basic
# Date created:		2008-12-20
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD: ports/lang/mono-basic/Makefile,v 1.1 2009/06/23 11:46:02 flz Exp $
#

PORTNAME=	mono-basic
PORTVERSION=	2.4.2
CATEGORIES=	lang
MASTER_SITES=	ftp://ftp.novell.com/pub/mono/sources/${PORTNAME}/

MAINTAINER=	mono@FreeBSD.org
COMMENT=	VisualBasic.NET support for Mono

BUILD_DEPENDS=	mono:${PORTSDIR}/lang/mono
RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono

MAN1=		vbnc.1

USE_BZIP2=	yes
HAS_CONFIGURE=	yes
CONFIGURE_ARGS=	--prefix=${PREFIX}
USE_GMAKE=	yes

tests: build
	@${ECHO_MSG} "===> Running ${PORTNAME} regression tests"
	@(cd ${WRKSRC} && ${SETENV} ${MAKE_ENV} ${GMAKE} \
		${MAKE_FLAGS} Makefile ${MAKE_ARGS} test)

.include <bsd.port.mk>
