# New ports collection makefile for:    flickrnet
# Date created:         2008-10-09
# Whom:                 Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	flickrnet
PORTVERSION=	3.1.0.0
CATEGORIES=	devel
MASTER_SITES=	http://romain.blogreen.org/distfiles/
DISTNAME=	FlickrNet-77169

MAINTAINER=	mono@FreeBSD.org
COMMENT=	Flickr .Net API Library

BUILD_DEPENDS=	mono:${PORTSDIR}/lang/mono
RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono

USE_ZIP=	yes
WRKSRC=		${WRKDIR}/FlickrNet

do-build:
	cd ${WRKSRC} && xbuild FlickrNet.csproj

do-install:
	${MKDIR} ${PREFIX}/lib/mono/flickrnet
	cd ${WRKSRC}/bin/Debug && ${INSTALL_DATA} FlickrNet.dll FlickrNet.dll.mdb ${PREFIX}/lib/mono/flickrnet
	cd ${WRKSRC} && ${SED} -e 's|@prefix@|${PREFIX}|' < flickrnet.pc.in > flickrnet.pc
	cd ${WRKSRC} && ${INSTALL_DATA} flickrnet.pc ${PREFIX}/libdata/pkgconfig

.include <bsd.port.mk>
