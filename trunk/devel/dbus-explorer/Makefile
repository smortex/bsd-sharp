# New ports collection makefile for:	dbus-explorer
# Date created:		2008-12-22
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	dbus-explorer
PORTVERSION=	0.5
CATEGORIES=	devel
MASTER_SITES=	http://www.ndesk.org/archive/${PORTNAME}/

MAINTAINER=	mono@FreeBSD.org
COMMENT=	A GTK+ interface for viewing D-Bus service APIs

BUILD_DEPENDS=	${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-glib-1.0.pc:${PORTSDIR}/devel/ndesk-dbus-glib
RUN_DEPENDS=	${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-glib-1.0.pc:${PORTSDIR}/devel/ndesk-dbus-glib

GNU_CONFIGURE=	yes
USE_GMAKE=	yes
USE_GNOME=	gtksharp20
USE_GETTEXT=	yes

.include <bsd.port.mk>
