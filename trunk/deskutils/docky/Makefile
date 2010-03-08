# New ports collection makefile for:	docky
# Date created:		2010-03-08
# Whom:			Romain Tartiere <romain@FreeBSD.org>
#
# $FreeBSD$
#

PORTNAME=	docky
PORTVERSION=	2.0.0
CATEGORIES=	deskutils
MASTER_SITES=	http://launchpadlibrarian.net/39282578/

MAINTAINER=	romain@FreeBSD.org
COMMENT=	Dock application for the GNOME desktop

BUILD_DEPENDS=	${LOCALBASE}/libdata/pkgconfig/gnome-keyring-sharp-1.0.pc:${PORTSDIR}/security/gnome-keyring-sharp \
    		${LOCALBASE}/libdata/pkgconfig/mono-addins.pc:${PORTSDIR}/devel/mono-addins \
		${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-glib-1.0.pc:${PORTSDIR}/devel/ndesk-dbus-glib \
		${LOCALBASE}/libdata/pkgconfig/notify-sharp.pc:${PORTSDIR}/devel/notify-sharp
RUN_DEPENDS=	${BUILD_DEPENDS}

GNU_CONFIGURE=	yes
INSTALLS_ICONS=	yes
USE_GETTEXT=	yes
USE_GMAKE=	yes
USE_GNOME=	gnomehack gnomedesktopsharp20
USE_PYTHON=	yes

.include <bsd.port.mk>
