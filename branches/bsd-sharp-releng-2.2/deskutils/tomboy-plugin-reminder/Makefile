# New ports collection makefile for:	tomboy-plugin-reminder
# Date created:		2008-12-21
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	tomboy-plugin-reminder
PORTVERSION=	0.9.1
CATEGORIES=	deskutils
MASTER_SITES=	http://flukkost.nu/
DISTNAME=	tomboy-reminder-${PORTVERSION}

MAINTAINER=	freebsd-mono@freebsd.org
COMMENT=	Automatically open notes at a given date and time

BUILD_DEPENDS=	tomboy:${PORTSDIR}/deskutils/tomboy
RUN_DEPENDS=	tomboy:${PORTSDIR}/deskutils/tomboy

USE_BZIP2=	yes
GNU_CONFIGURE=	yes
USE_GMAKE=	yes

.include <bsd.port.mk>
