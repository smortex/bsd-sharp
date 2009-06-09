# New ports collection makefile for:	ipod-sharp
# Date created:		2008-07-09
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	ipod-sharp
PORTVERSION=	0.8.0
PORTREVISION=	2
CATEGORIES=	misc
MASTER_SITES=	http://download.banshee-project.org/${PORTNAME}/

MAINTAINER=	mono@FreeBSD.org
COMMENT=	High level access to iPod

BUILD_DEPENDS=	${LOCALBASE}/libdata/pkgconfig/podsleuth.pc:${PORTSDIR}/misc/podsleuth \
		${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-glib-1.0.pc:${PORTSDIR}/devel/ndesk-dbus-glib
RUN_DEPENDS=	${LOCALBASE}/libdata/pkgconfig/podsleuth.pc:${PORTSDIR}/misc/podsleuth \
		${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-glib-1.0.pc:${PORTSDIR}/devel/ndesk-dbus-glib

GNU_CONFIGURE=	yes
USE_GMAKE=	yes
USE_GNOME=	gnomehack gtksharp20

.include <bsd.port.mk>
