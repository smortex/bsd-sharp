# New ports collection makefile for:	tasque
# Date created:		2008-06-26
# Whom:			Romain Tartière <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	tasque
PORTVERSION=	0.1.7
PORTREVISION=	1
CATEGORIES=	deskutils
MASTER_SITES=	GNOME

MAINTAINER=	mono@FreeBSD.org
COMMENT=	Simple task management application

BUILD_DEPENDS=	${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-glib-1.0.pc:${PORTSDIR}/devel/ndesk-dbus-glib \
		${LOCALBASE}/libdata/pkgconfig/notify-sharp.pc:${PORTSDIR}/devel/notify-sharp
RUN_DEPENDS=	${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-glib-1.0.pc:${PORTSDIR}/devel/ndesk-dbus-glib \
		${LOCALBASE}/libdata/pkgconfig/notify-sharp.pc:${PORTSDIR}/devel/notify-sharp

OPTIONS=	RTM	"Enable Remember The Milk backend"	on	\
		SQLITE	"Enable SQLite backend"			off	\
		EDS	"Enable Evolution backend"		off

GNU_CONFIGURE=	yes
USE_GETTEXT=	yes
USE_GMAKE=	yes
USE_GNOME=	gnomehack gnomesharp20
CONFIGURE_ENV=	GMSGFMT="${LOCALBASE}/bin/msgfmt"
INSTALLS_ICONS=	yes

post-patch:
	${REINPLACE_CMD} -e 's|/bin/bash|/usr/bin/env bash|' \
		${WRKSRC}/src/tasque.in

.include <bsd.port.pre.mk>

.if defined(WITH_RTM) && !defined(WITHOUT_RTM)
CONFIGURE_ARGS+=	--enable-backend-rtm
PLIST_SUB+=	RTM=""
.else
CONFIGURE_ARGS+=	--disable-backend-rtm
PLIST_SUB+=	RTM="@comment "
.endif

.if defined(WITH_SQLITE) && !defined(WITHOUT_SQLITE)
CONFIGURE_ARGS+=	--enable-backend-sqlite
PLIST_SUB+=	SQLITE=""
.else
CONFIGURE_ARGS+=	--disable-backend-sqlite
PLIST_SUB+=	SQLITE="@comment "
.endif

.if defined(WITH_EDS) && !defined(WITHOUT_EDS)
CONFIGURE_ARGS+=	--enable-backend-eds
PLIST_SUB+=	EDS=""
.else
CONFIGURE_ARGS+=	--disable-backend-eds
PLIST_SUB+=	EDS="@comment "
.endif

.include <bsd.port.post.mk>
