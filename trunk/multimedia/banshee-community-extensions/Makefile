# New ports collection makefile for:	banshee-community-extensions
# Date created:		2010-03-12
# Whom:			Romain Tartiere <romain@FreeBSD.org>
#
# $FreeBSD$
#

PORTNAME=	banshee-community-extensions
PORTVERSION=	1.8.0
CATEGORIES=	multimedia
MASTER_SITES=	http://download.banshee.fm/${PORTNAME}/${PORTVERSION}/

MAINTAINER=	romain@FreeBSD.org
COMMENT=	Banshee Community Extensions

BUILD_DEPENDS=	banshee-1:${PORTSDIR}/multimedia/banshee
RUN_DEPENDS=	${BUILD_DEPENDS}

OPTIONS=	ALARMCLOCK	"Build the AlarmClock extension" on \
		AWN		"Build the Awn extension" on \
		COVERWALLPAPER	"Build the CoverWallpaper extension" on \
		LCD		"Build the LCD extension" on \
		LIRC		"Build the Lirc extension" on \
		LIVERADIO	"Build the LiveRadio extension" on \
		LYRICS		"Build the Lyrics extension" on \
		MAGNATUNE	"Build the Magnatune extension" on \
		MIRAGE		"Build the Mirage extension" on \
		RADIOFETCH	"Build the RadioStationFetcher extension" on \
		STREAMRECORDER	"Build the StreamRecorder extension" on\
		TELEPATHY	"Build the Telepathy extension" on

GNU_CONFIGURE=	yes
USE_BZIP2=	yes
USE_GETTEXT=	yes
USE_GMAKE=	yes
USE_GNOME=	gnomehack intltool
USE_LDCONFIG=	yes
CONFIGURE_ARGS=--disable-appindicator \
	       --disable-clutterflow \
	       --disable-ubuntuonemusicstore

.include <bsd.port.options.mk>

.if !defined(WITHOUT_ALARMCLOCK)
CONFIGURE_ARGS+=--enable-alarmclock
PLIST_SUB+=	ALARMCLOCK=""
.else
CONFIGURE_ARGS+=--disable-alarmclock
PLIST_SUB+=	ALARMCLOCK="@comment "
.endif

.if !defined(WITHOUT_AWN)
CONFIGURE_ARGS+=--enable-awn
PLIST_SUB+=	AWN=""
.else
CONFIGURE_ARGS+=--disable-awn
PLIST_SUB+=	AWN="@comment "
.endif

.if !defined(WITHOUT_COVERWALLPAPER)
CONFIGURE_ARGS+=--enable-coverwallpaper
PLIST_SUB+=	COVERWALLPAPER=""
.else
CONFIGURE_ARGS+=--disable-coverwallpaper
PLIST_SUB+=	COVERWALLPAPER="@comment "
.endif

.if !defined(WITHOUT_LCD)
CONFIGURE_ARGS+=--enable-lcd
PLIST_SUB+=	LCD=""
.else
CONFIGURE_ARGS+=--disable-lcd
PLIST_SUB+=	LCD="@comment "
.endif

.if !defined(WITHOUT_LIRC)
CONFIGURE_ARGS+=--enable-lirc
CONFIGURE_ENV+=	CPPFLAGS="-I${LOCALBASE}/include" LDFLAGS="-L${LOCALBASE}/lib"
LIB_DEPENDS+=	lirc_client:${PORTSDIR}/comms/lirc
PLIST_SUB+=	LIRC=""
.else
CONFIGURE_ARGS+=--disable-lirc
PLIST_SUB+=	LIRC="@comment "
.endif

.if !defined(WITHOUT_LIVERADIO)
CONFIGURE_ARGS+=--enable-liveradio
PLIST_SUB+=	LIVERADIO=""
.else
CONFIGURE_ARGS+=--disable-liveradio
PLIST_SUB+=	LIVERADIO="@comment "
.endif

.if !defined(WITHOUT_LYRICS)
CONFIGURE_ARGS+=--enable-lyrics
PLIST_SUB+=	LYRICS=""
BUILD_DEPENDS+=	${LOCALBASE}/libdata/pkgconfig/webkit-sharp-1.0.pc:${PORTSDIR}/www/webkit-sharp
RUN_DEPENDS+=	${LOCALBASE}/libdata/pkgconfig/webkit-sharp-1.0.pc:${PORTSDIR}/www/webkit-sharp
.else
CONFIGURE_ARGS+=--disable-lyrics
PLIST_SUB+=	LYRICS="@comment "
.endif

.if !defined(WITHOUT_MAGNATUNE)
CONFIGURE_ARGS+=--enable-magnatune
PLIST_SUB+=	MAGNATUNE=""
.else
CONFIGURE_ARGS+=--disable-magnatune
PLIST_SUB+=	MAGNATUNE="@comment "
.endif

.if !defined(WITHOUT_MIRAGE)
CONFIGURE_ARGS+=--enable-mirage
LIB_DEPENDS+=	fftw3f:${PORTSDIR}/math/fftw3-float \
		samplerate.1:${PORTSDIR}/audio/libsamplerate
PLIST_SUB+=	MIRAGE=""
.else
CONFIGURE_ARGS+=--disable-mirage
PLIST_SUB+=	MIRAGE="@comment "
.endif

.if !defined(WITHOUT_RADIOFETCH)
CONFIGURE_ARGS+=--enable-radiostationfetcher
PLIST_SUB+=	RADIOFETCH=""
.else
CONFIGURE_ARGS+=--disable-radiostationfetcher
PLIST_SUB+=	RADIOFETCH="@comment "
.endif

.if !defined(WITHOUT_STREAMRECORDER)
CONFIGURE_ARGS+=--enable-streamrecorder
PLIST_SUB+=	STREAMRECORDER=""
.else
CONFIGURE_ARGS+=--disable-streamrecorder
PLIST_SUB+=	STREAMRECORDER="@comment "
.endif

.if !defined(WITHOUT_TELEPATHY)
CONFIGURE_ARGS+=--enable-telepathy
BUILD_DEPENDS+=	${LOCALBASE}/libdata/pkgconfig/notify-sharp.pc:${PORTSDIR}/devel/notify-sharp
RUN_DEPENDS+=	${LOCALBASE}/libdata/pkgconfig/notify-sharp.pc:${PORTSDIR}/devel/notify-sharp
PLIST_SUB+=	TELEPATHY=""
.else
CONFIGURE_ARGS+=--disable-telepathy
PLIST_SUB+=	TELEPATHY="@comment "
.endif

.include <bsd.port.mk>
