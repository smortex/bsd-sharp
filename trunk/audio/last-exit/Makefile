# New ports collection makefile for:	last-exit
# Date created:		2006 10 10
# Whom:			Phillip Neumann <pneumann@gmail.com>
#
# $FreeBSD$
#

PORTNAME=	last-exit
PORTVERSION=	4
CATEGORIES=	audio gnome
MASTER_SITES=	http://folks.o-hand.com/iain/last-exit/

MAINTAINER=	mono@FreeBSD.org
COMMENT=	Mono based Gnome last.fm player

LIB_DEPENDS= 	id3tag.0:${PORTSDIR}/audio/libid3tag \
		gdbm:${PORTSDIR}/databases/gdbm \
		musicbrainz.4:${PORTSDIR}/audio/libmusicbrainz
BUILD_DEPENDS=	mono:${PORTSDIR}/lang/mono \
		dbus-daemon:${PORTSDIR}/devel/dbus \
		dbus-binding-tool:${PORTSDIR}/devel/dbus-glib
RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono \
		dbus-daemon:${PORTSDIR}/devel/dbus \
		dbus-binding-tool:${PORTSDIR}/devel/dbus-glib

USE_GMAKE=	yes
USE_BZIP2=	yes
USE_GNOME=	gnomeprefix gnomehack gnometarget gconf2 gnomesharp20
GNU_CONFIGURE=	yes
CONFIGURE_ARGS+=	DATADIRNAME=share
USE_GSTREAMER=	flac vorbis
GCONF_SCHEMAS=	last-exit.schemas lastfm.schemas
INSTALLS_ICONS=	yes

.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include <bsd.port.mk>
