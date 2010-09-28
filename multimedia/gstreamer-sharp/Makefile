# New ports collection makefile for:	gstreamer-sharp
# Date created:		2009-09-06
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	gstreamer-sharp
PORTVERSION=	0.9.2
CATEGORIES=	multimedia
MASTER_SITES=	http://gstreamer.freedesktop.org/src/gstreamer-sharp/

MAINTAINER=	romain@FreeBSD.org
COMMENT=	C-sharp bindings for GStreamer

USE_BZIP2=	yes
GNU_CONFIGURE=	yes
USE_GMAKE=	yes
USE_GNOME=	gnomehack gtksharp20
USE_GSTREAMER=	yes
USE_LDCONFIG=	yes

PLIST_SUB+=	PORTVERSION="${PORTVERSION}"

.include <bsd.port.mk>
