# New ports collection makefile for:	monsoon
# Date created:				20090202
# Whom:					pneumann@gmail.com
#
# $FreeBSD$
#

PORTNAME=	monsoon
PORTVERSION=	0.15
CATEGORIES=	net-p2p
MASTER_SITES=	http://www.monsoon-project.org/jaws/data/files/
#DISTNAME=	${PORTNAME}_${PORTVERSION}.orig

MAINTAINER=	mono@FreeBSD.org
COMMENT=	Gtk+ BitTorrent client

BUILD_DEPENDS=	mono:${PORTSDIR}/lang/mono \
		${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-glib-1.0.pc:${PORTSDIR}/devel/ndesk-dbus-glib
RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono \
                ${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-glib-1.0.pc:${PORTSDIR}/devel/ndesk-dbus-glib


GNU_CONFIGURE=	yes
USE_GMAKE=	yes
CONFIGURE_ENV+= CPPFLAGS="-I${LOCALBASE}/include" \
                LDFLAGS="-L${LOCALBASE}/lib"

#USE_GNOME=	gnomesharp20
USE_GETTEXT=	yes
INSTALLS_ICONS=	yes

.include <bsd.port.mk>
