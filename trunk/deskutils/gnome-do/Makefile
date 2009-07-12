# New ports collection makefile for:	gnome-do
# Date created:		2008-03-24
# Whom:			pneumann@gmail.com
#
# $FreeBSD$
#

PORTNAME=	gnome-do
PORTVERSION=	0.8.1
CATEGORIES=	deskutils
MASTER_SITES=	https://launchpadlibrarian.net/23831275/

MAINTAINER=	mono@FreeBSD.org
COMMENT=	Powerful, speedy, and sexy remote control for your GNOME Desktop

BUILD_DEPENDS=	${LOCALBASE}/bin/mono:${PORTSDIR}/lang/mono \
		${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-glib-1.0.pc:${PORTSDIR}/devel/ndesk-dbus-glib \
		${LOCALBASE}/libdata/pkgconfig/gnome-keyring-sharp-1.0.pc:${PORTSDIR}/security/gnome-keyring-sharp \
		mautil:${PORTSDIR}/devel/mono-addins \
		${LOCALBASE}/libdata/pkgconfig/notify-sharp.pc:${PORTSDIR}/devel/notify-sharp
RUN_DEPENDS=	${LOCALBASE}/bin/mono:${PORTSDIR}/lang/mono \
		${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-glib-1.0.pc:${PORTSDIR}/devel/ndesk-dbus-glib \
		${LOCALBASE}/libdata/pkgconfig/gnome-keyring-sharp-1.0.pc:${PORTSDIR}/security/gnome-keyring-sharp \
		mautil:${PORTSDIR}/devel/mono-addins \
		${LOCALBASE}/libdata/pkgconfig/notify-sharp.pc:${PORTSDIR}/devel/notify-sharp \
		xdg-open:${PORTSDIR}/devel/xdg-utils

USE_GNOME=	gnomehack gnomeprefix gnomedesktopsharp20
USE_GMAKE=	yes
GNU_CONFIGURE=	yes
CONFIGURE_ENV+=	CPPFLAGS="-I${LOCALBASE}/include" \
		LDFLAGS="-L${LOCALBASE}/lib"
USE_LDCONFIG=	yes
GCONF_SCHEMAS=	gnome-do.schemas
INSTALLS_ICONS=	yes

.if !defined(WITHOUT_NLS)
USE_GETTEXT=	yes
PLIST_SUB+=	NLS=""
.else
CONFIGURE_ARGS+=	--disable-nls
PLIST_SUB+=	NLS="@comment "
.endif

.include <bsd.port.mk>
