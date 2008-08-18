# New ports collection makefile for:	gnome-do
# Date created:		2008-03-24
# Whom:			pneumann@gmail.com
#
# $FreeBSD$
#

PORTNAME=	gnome-do
PORTVERSION=	0.4.0.1
CATEGORIES=	deskutils
MASTER_SITES=	https://launchpad.net/do/trunk/0.4/+download/

MAINTAINER=	bsd-sharp@googlegroups.com
COMMENT= Powerful, speedy, and sexy remote control for your GNOME Desktop

BUILD_DEPENDS=  ${LOCALBASE}/bin/mono:${PORTSDIR}/lang/mono \
				${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-glib-1.0.pc:${PORTSDIR}/devel/ndesk-dbus-glib
RUN_DEPENDS=    ${LOCALBASE}/bin/mono:${PORTSDIR}/lang/mono \
				${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-glib-1.0.pc:${PORTSDIR}/devel/ndesk-dbus-glib

USE_GNOME=      gnomehack gnomeprefix gnomesharp20
USE_GMAKE=	yes
GNU_CONFIGURE=	yes
CONFIGURE_ENV+= CPPFLAGS="-I${LOCALBASE}/include" \
                LDFLAGS="-L${LOCALBASE}/lib"

.include <bsd.port.mk>
