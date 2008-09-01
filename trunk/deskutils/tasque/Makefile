# New ports collection makefile for:	tasque
# Date created:		2008-06-26
# Whom:			Romain Tartière <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	tasque
PORTVERSION=	0.1.6
CATEGORIES=	deskutils
MASTER_SITES=	${MASTER_SITE_GNOME}
MASTER_SITE_SUBDIR=	sources/${PORTNAME}/${PORTVERSION:C/^([0-9]+\.[0-9]+).*/\1/}

MAINTAINER=	bsd-sharp@googlegroups.com
COMMENT=	Simple task management application

BUILD_DEPENDS=	${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-glib-1.0.pc:${PORTSDIR}/devel/ndesk-dbus-glib
RUN_DEPENDS=	${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-glib-1.0.pc:${PORTSDIR}/devel/ndesk-dbus-glib

GNU_CONFIGURE=	yes
USE_GETTEXT=	yes
USE_GMAKE=	yes
USE_GNOME=	gnomehack gnomesharp20
CONFIGURE_ENV=	GMSGFMT="${LOCALBASE}/bin/msgfmt"
INSTALLS_ICONS=	yes

.include <bsd.port.mk>
