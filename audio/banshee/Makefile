# Ports collection makefile for:	banshee
# Date Created:				24 mar 2008
# Whom:					pneumann@gmail.com
#
# $FreeBSD$
#

PORTNAME=	banshee
PORTVERSION=	0.98.1
CATEGORIES=	audio multimedia
MASTER_SITES=	http://banshee-project.org/files/banshee/
DISTNAME=	${PORTNAME}-1-${PORTVERSION}

MAINTAINER=	bsd-sharp-list@forge.novell.com
COMMENT=	Music Managment and Playback for Gnome

LIB_DEPENDS=	musicbrainz.4:${PORTSDIR}/audio/libmusicbrainz
BUILD_DEPENDS=	${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-glib-1.0.pc:${PORTSDIR}/devel/ndesk-dbus-glib \
		${LOCALBASE}/bin/mono:${PORTSDIR}/lang/mono \
		${LOCALBASE}/libdata/pkgconfig/taglib-sharp.pc:${PORTSDIR}/devel/taglib-sharp
RUN_DEPENDS=	${LOCALBASE}/bin/mono:${PORTSDIR}/lang/mono \
		${LOCALBASE}/sbin/hald:${PORTSDIR}/sysutils/hal \
		${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-glib-1.0.pc:${PORTSDIR}/devel/ndesk-dbus-glib \
		${LOCALBASE}/libdata/pkgconfig/taglib-sharp.pc:${PORTSDIR}/devel/taglib-sharp

USE_GMAKE=	yes
USE_GNOME=	gnomeprefix gnomehier gnomehack nautiluscdburner gnomesharp20
GNU_CONFIGURE=	yes
CONFIGURE_ARGS=	--program-transform-name=''
CONFIGURE_ENV+= CPPFLAGS="-I${LOCALBASE}/include" \
                LDFLAGS="-L${LOCALBASE}/lib"
USE_GSTREAMER=	cdparanoia gconf gnomevfs mad vorbis
USE_SQLITE=	yes

OPTIONS=	FAAD	"AAC support"		off \
		FLAC	"FLAC support"		off

.include <bsd.port.pre.mk>

.if defined (WITH_FAAD)
USE_GSTREAMER+=	faad
.endif

.if defined (WITH_FLAC)
USE_GSTREAMER+= flac
.endif

.if defined(WITHOUT_NLS)
CONFIGURE_ARGS+=	--disable-nls
PLIST_SUB+=	WITH_NLS="@comment "
.else
USE_GETTEXT=	yes
PLIST_SUB+=	WITH_NLS=""
.endif

.include <bsd.port.post.mk>
