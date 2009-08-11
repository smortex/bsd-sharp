# New ports collection makefile for:	galaxium
# Date created:		2008-09-01
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	galaxium
PORTVERSION=	0.7.4.1
PORTREVISION=	1
CATEGORIES=	net-im
MASTER_SITES=	${MASTER_SITE_GOOGLE_CODE}
DISTNAME=	${PORTNAME}_${PORTVERSION}

MAINTAINER=	mono@FreeBSD.org
COMMENT=	Multi-Protocol Instant Messenger

BUILD_DEPENDS=	${LOCALBASE}/libdata/pkgconfig/anculus-core.pc:${PORTSDIR}/misc/libanculus-sharp \
		${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-glib-1.0.pc:${PORTSDIR}/devel/ndesk-dbus-glib \
		${LOCALBASE}/libdata/pkgconfig/webkit-sharp-1.0.pc:${PORTSDIR}/www/webkit-sharp \
		mautil:${PORTSDIR}/devel/mono-addins
RUN_DEPENDS=	${BUILD_DEPENDS}

WRKSRC=		${WRKDIR}/${PORTNAME}-${PORTVERSION}
USE_AUTOTOOLS=	libtool:22 aclocal:110 autoconf:262 automake:110
GNU_CONFIGURE=	yes
USE_GMAKE=	yes
AUTOMAKE_ARGS=	--add-missing --gnu
ACLOCAL_ARGS=	-I .
USE_GSTREAMER=	yes
USE_LDCONFIG=	yes

MAN1=		galaxium.1
MANCOMPRESSED=	yes

.include <bsd.port.mk>
