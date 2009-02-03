# New ports collection makefile for:	monsoon
# Date created:				20090202
# Whom:					pneumann@gmail.com
#
# $FreeBSD$
#

PORTNAME=	monsoon
PORTVERSION=	0.20
CATEGORIES=	net-p2p
MASTER_SITES=	http://monotorrent.com/Files/

MAINTAINER=	mono@FreeBSD.org
COMMENT=	Gtk+ BitTorrent client

BUILD_DEPENDS=	mono:${PORTSDIR}/lang/mono \
		${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-glib-1.0.pc:${PORTSDIR}/devel/ndesk-dbus-glib \
		${LOCALBASE}/lib/mono-nat/Mono.Nat.dll:${PORTSDIR}/net/mono-nat \
		${LOCALBASE}/lib/monotorrent/MonoTorrent.dll:${PORTSDIR}/net-p2p/monotorrent
RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono \
		${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-glib-1.0.pc:${PORTSDIR}/devel/ndesk-dbus-glib \
		${LOCALBASE}/lib/mono-nat/Mono.Nat.dll:${PORTSDIR}/net/mono-nat \
		${LOCALBASE}/lib/monotorrent/MonoTorrent.dll:${PORTSDIR}/net-p2p/monotorrent

GNU_CONFIGURE=	yes
USE_GMAKE=	yes
CONFIGURE_ENV+=	CPPFLAGS="-I${LOCALBASE}/include" \
		LDFLAGS="-L${LOCALBASE}/lib"

USE_GNOME=	gnomesharp20
USE_GETTEXT=	yes
INSTALLS_ICONS=	yes

.include <bsd.port.mk>
