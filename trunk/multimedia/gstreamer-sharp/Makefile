# $FreeBSD$

PORTNAME=	gstreamer-sharp
PORTVERSION=	0.99.0
CATEGORIES=	multimedia
MASTER_SITES=	http://gstreamer.freedesktop.org/src/gstreamer-sharp/

MAINTAINER=	romain@FreeBSD.org
COMMENT=	C-sharp bindings for GStreamer

LICENSE=	AGPLv3

USE_AUTOTOOLS=	aclocal autoconf automake libtoolize
AUTOMAKE_ARGS+=	--add-missing
GNU_CONFIGURE=	yes
USE_GNOME=	gnomehack
USE_GSTREAMER=	yes
USE_LDCONFIG=	yes
USES=		gmake
MAKE_JOBS_UNSAFE=yes

PLIST_SUB+=	PORTVERSION="${PORTVERSION}"

WRKSRC=		${WRKDIR}

.include <bsd.port.mk>
