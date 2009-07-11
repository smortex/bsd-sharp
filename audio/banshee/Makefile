# Ports collection makefile for:	banshee
# Date Created:				24 mar 2008
# Whom:					pneumann@gmail.com
#
# $FreeBSD$
#

PORTNAME=	banshee
PORTVERSION=	1.2.1
CATEGORIES=	audio multimedia
MASTER_SITES=	http://download.banshee-project.org/${PORTNAME}/
DISTNAME=	${PORTNAME}-1-${PORTVERSION}

MAINTAINER=	bsd-sharp-list@forge.novell.com
COMMENT=	Music Managment and Playback for Gnome

LIB_DEPENDS=	musicbrainz.4:${PORTSDIR}/audio/libmusicbrainz \
		mtp.8:${PORTSDIR}/audio/libmtp
BUILD_DEPENDS=	${LOCALBASE}/bin/mono:${PORTSDIR}/lang/mono \
		${LOCALBASE}/libdata/pkgconfig/notify-sharp.pc:${PORTSDIR}/devel/notify-sharp \
		${LOCALBASE}/libdata/pkgconfig/taglib-sharp.pc:${PORTSDIR}/multimedia/taglib-sharp \
		${LOCALBASE}/libdata/pkgconfig/mono-zeroconf.pc:${PORTSDIR}/net/mono-zeroconf \
		mautil:${PORTSDIR}/devel/mono-addins
RUN_DEPENDS=	${LOCALBASE}/bin/mono:${PORTSDIR}/lang/mono \
		${LOCALBASE}/sbin/hald:${PORTSDIR}/sysutils/hal \
		${LOCALBASE}/libdata/pkgconfig/notify-sharp.pc:${PORTSDIR}/devel/notify-sharp \
		${LOCALBASE}/libdata/pkgconfig/taglib-sharp.pc:${PORTSDIR}/multimedia/taglib-sharp \
		${LOCALBASE}/libdata/pkgconfig/mono-zeroconf.pc:${PORTSDIR}/net/mono-zeroconf \
		mautil:${PORTSDIR}/devel/mono-addins

USE_BZIP2=	yes
USE_GMAKE=	yes
USE_GNOME=	gnomeprefix gnomehier gnomehack nautiluscdburner gnomesharp20
GNU_CONFIGURE=	yes
CONFIGURE_ARGS=	--program-transform-name=''
CONFIGURE_ENV+= CPPFLAGS="-I${LOCALBASE}/include" \
                LDFLAGS="-L${LOCALBASE}/lib"
USE_GSTREAMER=	cdparanoia gconf gnomevfs mad vorbis
USE_SQLITE=	yes

OPTIONS=	BOO	"Boo scripting"		on \
		FAAD	"AAC support"		off \
		FLAC	"FLAC support"		off \
		MTP	"MTP support"		on \
		IPOD	"iPod support"		on

.include <bsd.port.pre.mk>

.if defined(WITH_BOO) && !defined(WITHOUT_BOO)
CONFIGURE_ARGS+=	--enable-boo
BUILD_DEPENDS+=	booc:${PORTSDIR}/lang/boo
RUN_DEPENDS+=	booc:${PORTSDIR}/lang/boo
PLIST_SUB+=	BOO=""
.else
CONFIGURE_ARGS+=	--disable-boo
PLIST_SUB+=	BOO="@comment "
.endif


.if defined (WITH_FAAD)
USE_GSTREAMER+=	faad
.endif

.if defined (WITH_FLAC)
USE_GSTREAMER+= flac
.endif

.if defined(WITH_IPOD) && !defined(WITHOUT_IPOD)
CONFIGURE_ARGS+=	--enable-ipod
BUILD_DEPENDS+=	${LOCALBASE}/libdata/pkgconfig/ipod-sharp.pc:${PORTSDIR}/misc/ipod-sharp
RUN_DEPENDS+=	${LOCALBASE}/libdata/pkgconfig/ipod-sharp.pc:${PORTSDIR}/misc/ipod-sharp
PLIST_SUB+=	IPOD=""
.else
CONFIGURE_ARGS+=	--disable-ipod
PLIST_SUB+=	IPOD="@comment "
.endif

.if defined(WITH_MTP) && !defined(WITHOUT_MTP)
CONFIGURE_ARGS+=	--enable-mtp
PLIST_SUB+=	MTP=""
.else
CONFIGURE_ARGS+=	--disable-mtp
PLIST_SUB+=	MTP="@comment "
.endif

.if defined(WITHOUT_NLS)
CONFIGURE_ARGS+=	--disable-nls
PLIST_SUB+=	WITH_NLS="@comment "
.else
USE_GETTEXT=	yes
PLIST_SUB+=	WITH_NLS=""
.endif

.include <bsd.port.post.mk>
