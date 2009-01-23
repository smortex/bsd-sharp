# New ports collection makefile for:    incollector
# Date created:                         30 11 2006
# Whom:                                 pneumann@gmail.com
#
# $FreeBSD$
#

PORTNAME=	incollector
PORTVERSION=	1.1
CATEGORIES=	deskutils
MASTER_SITES=	http://www.incollector.devnull.pl/download/sources/

MAINTAINER=	freebsd-mono@freebsd.org
COMMENT=	An application to collect various kinds of information

RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono
BUILD_DEPENDS=	mono:${PORTSDIR}/lang/mono

USE_GNOME=	gnomeprefix gtksharp20
USE_GMAKE=	yes
GNU_CONFIGURE=	yes

.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include <bsd.port.mk>
