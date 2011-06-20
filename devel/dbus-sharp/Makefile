# New ports collection makefile for:	dbus-sharp
# Date created:		2011-06-20
# Whom:			Romain Tartiere <romain@FreeBSD.org>
#
# $FreeBSD$
#

PORTNAME=	dbus-sharp
PORTVERSION=	0.7.0
PORTEPOCH=	1
CATEGORIES=	devel
MASTER_SITES=	http://cloud.github.com/downloads/mono/${PORTNAME}/

MAINTAINER=	romain@FreeBSD.org
COMMENT=	D-Bus for .NET

BUILD_DEPENDS=	mono:${PORTSDIR}/lang/mono
RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono

GNU_CONFIGURE=	yes
USE_GMAKE=	yes
USE_GNOME=	gnomehack

.include <bsd.port.mk>
