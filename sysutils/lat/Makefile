# New ports collection makefile for:	lat
# Date created:		5 Mar 2006
# Whom:			Phillip Neumann <pneumann@gmail.com>
#
# $FreeBSD$
#

PORTNAME=	lat
PORTVERSION=	1.2.3
CATEGORIES=	x11 gnome sysutils
MASTER_SITES=	http://www.lbtechservices.com/downloads/lat/1.2/

MAINTAINER=	mono@FreeBSD.org
COMMENT=	A Gtk# LDAP Administration Tool

BUILD_DEPENDS=	mono:${PORTSDIR}/lang/mono \
		gnome-keyring-daemon:${PORTSDIR}/security/gnome-keyring
RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono \
		gnome-keyring-daemon:${PORTSDIR}/security/gnome-keyring

MAN1=	lat.1

USE_GNOME=	intltool gnomeprefix gnomehack gnomesharp20
INSTALLS_OMF=	yes
GNU_CONFIGURE=	yes
USE_GMAKE=	yes
CONFIGURE_ENV=	CPPFLAGS="-I${LOCALBASE}/include" \
		LDFLAGS="-L${LOCALBASE}/lib"
# Configure checks for dbus to determine if we need NetWork Manager support
# but we don't even have NetworkManager.
CONFIGURE_ARGS=	--mandir=${PREFIX}/man \
		--enable-networkmanager=no

.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include <bsd.port.mk>
