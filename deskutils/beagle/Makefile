# New ports collection makefile for:		beagle
# Date created:					20041016
# Whom:				Tom McLaughlin <tmclaugh@sdf.lonestar.org>
#
# $FreeBSD$
#   $Id: Makefile,v 1.48 2007/05/19 21:41:43 killfill Exp $
#

PORTNAME=	beagle
PORTVERSION=	0.3.9
PORTREVISION?=	1
CATEGORIES?=	deskutils gnome
MASTER_SITES=	GNOME
DIST_SUBDIR=	gnome2

MAINTAINER=	mono@FreeBSD.org
COMMENT?=	Index and search local files

BUILD_DEPENDS?=	${LOCALBASE}/libdata/pkgconfig/gecko-sharp-2.0.pc:${PORTSDIR}/www/gecko-sharp20 \
		${LOCALBASE}/libdata/pkgconfig/gmime-sharp-2.4.pc:${PORTSDIR}/mail/gmime24-sharp \
		${LOCALBASE}/lib/mono/evolution-sharp/evolution-sharp.dll:${PORTSDIR}/mail/evolution-sharp \
		${LOCALBASE}/libdata/pkgconfig/taglib-sharp.pc:${PORTSDIR}/audio/taglib-sharp \
		${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-glib-1.0.pc:${PORTSDIR}/devel/ndesk-dbus-glib \
		zip:${PORTSDIR}/archivers/zip \
		xdg-open:${PORTSDIR}/devel/xdg-utils
LIB_DEPENDS?=	exif.12:${PORTSDIR}/graphics/libexif
RUN_DEPENDS?=	bash:${PORTSDIR}/shells/bash \
		${LOCALBASE}/libdata/pkgconfig/gecko-sharp-2.0.pc:${PORTSDIR}/www/gecko-sharp20 \
		${LOCALBASE}/lib/mono/gmime-sharp/gmime-sharp.dll:${PORTSDIR}/mail/gmime2-sharp \
		${LOCALBASE}/lib/mono/evolution-sharp/evolution-sharp.dll:${PORTSDIR}/mail/evolution-sharp \
		${LOCALBASE}/libdata/pkgconfig/taglib-sharp.pc:${PORTSDIR}/audio/taglib-sharp \
		${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-glib-1.0.pc:${PORTSDIR}/devel/ndesk-dbus-glib \
		xdg-open:${PORTSDIR}/devel/xdg-utils

CONFLICTS=	open-beagle-[0-9]*

USE_BZIP2=	yes
USE_GMAKE=	yes
USE_GECKO=	firefox mozilla
USE_GETTEXT=	yes
USE_GNOME?=	gnomehack gnometarget gnomesharp20 intlhack
USE_SQLITE=	yes
USE_AUTOTOOLS=	libtool:22
USE_LDCONFIG=	yes
CONFIGURE_ENV?=	CPPFLAGS="-I${LOCALBASE}/include" \
		LDFLAGS="-L${LOCALBASE}/lib"
#CONFIGURE_ARGS+=--mandir=${PREFIX}/man \
#		--disable-gtk-doc \
#		--with-html-dir=${PREFIX}/share/doc \
#		--with-mozilla=${GECKO}
CONFIGURE_ARGS+=--disable-gtk-doc \
		--with-html-dir=${PREFIX}/share/doc \
		--with-mozilla=${GECKO}

.if !defined(PY_BEAGLE)
CONFIGURE_ARGS+=--disable-python
.endif

.include <bsd.port.pre.mk>

.if !defined(BEAGLE_SLAVE)

MAN1=		beagle-config.1 beagle-info.1 beagle-ping.1 beagle-query.1 \
		beagle-search.1 beagle-settings.1 beagle-shutdown.1 \
		beagle-status.1 beagled.1

MAN8=		beagle-build-index.8 beagle-doc-extractor.8 \
		beagle-dump-index.8 beagle-extract-content.8 \
		beagle-imlogviewer.8 beagle-index-info.8 beagle-manage-index.8

SUB_FILES=	pkg-message
PKGMESSAGE=	${WRKDIR}/pkg-message

EPHY_PATH=	${LOCALBASE}/share/gnome/epiphany-extensions/ephy-gestures.xml

.if ((exists(${EPHY_PATH}) || defined(WITH_EPIPHANY)) && !defined(WITHOUT_EPIPHANY))
BUILD_DEPENDS+=		${EPHY_PATH}:${PORTSDIR}/www/epiphany-extensions
RUN_DEPENDS+=		${EPHY_PATH}:${PORTSDIR}/www/epiphany-extensions
CONFIGURE_ARGS+=	--enable-epiphany-extension \
			--enable-epiphany-extension-install
PLIST_SUB+=		EPIPHANY:=""
.else
CONFIGURE_ARGS+=	--disable-epiphany-extension
PLIST_SUB+=		EPIPHANY:="@comment "
.endif

.if ((exists(${LOCALBASE}/lib/libwv-1.0.so) || defined(WITH_WV)) && !defined(WITHOUT_WV))
LIB_DEPENDS+=		wv-1.0.0:${PORTSDIR}/textproc/wv
PLIST_SUB+=		WV:=""
.else
PLIST_SUB+=		WV:="@comment "
WV_DISABLE=		yes
.endif

post-patch:
.if defined(WV_DISABLE)
	@${REINPLACE_CMD} -e 's|enable_wv1=yes|enable_wv1=no|g' \
		${WRKSRC}/configure
.endif
	@${REINPLACE_CMD} -e 's|/bin/bash|/usr/bin/env bash|g' \
		${WRKSRC}/tools/beagle-crawl-system.in \
		${WRKSRC}/tools/beagle-index-info \
		${WRKSRC}/tools/beagle-ping

post-install:
	@${MKDIR} ${DATADIR}
	@${INSTALL} -m 644 ${WRKSRC}/thunderbird-extension/beagle.xpi ${DATADIR}
	@${CAT} ${PKGMESSAGE}
.endif

.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include "${.CURDIR}/../../www/mozilla/bsd.gecko.mk"
.include <bsd.port.post.mk>
