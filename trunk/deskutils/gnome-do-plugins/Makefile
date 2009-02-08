# New ports collection makefile for:	gnome-do-plugins
# Date created:		2009-01-30
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	gnome-do-plugins
PORTVERSION=	0.8.0
CATEGORIES=	deskutils gnome
MASTER_SITES=	http://launchpadlibrarian.net/21782250/

MAINTAINER=	romain@blogreen.org
COMMENT=	Plugins for gnome-do

BUILD_DEPENDS=	${LOCALBASE}/libdata/pkgconfig/do.platform.pc:${PORTSDIR}/deskutils/gnome-do \
		${LOCALBASE}/libdata/pkgconfig/banshee-1-collection-indexer.pc:${PORTSDIR}/multimedia/banshee \
		${LOCALBASE}/libdata/pkgconfig/evolution-sharp.pc:${PORTSDIR}/mail/evolution-sharp \
		${LOCALBASE}/libdata/pkgconfig/flickrnet.pc:${PORTSDIR}/devel/flickrnet \
		mdtool:${PORTSDIR}/devel/monodevelop
RUN_DEPENDS=	${LOCALBASE}/libdata/pkgconfig/do.platform.pc:${PORTSDIR}/deskutils/gnome-do \
		${LOCALBASE}/libdata/pkgconfig/banshee-1-collection-indexer.pc:${PORTSDIR}/multimedia/banshee \
		${LOCALBASE}/libdata/pkgconfig/evolution-sharp.pc:${PORTSDIR}/mail/evolution-sharp \
		${LOCALBASE}/libdata/pkgconfig/flickrnet.pc:${PORTSDIR}/devel/flickrnet \
		wnb:${PORTSDIR}/textproc/wordnet \
		wish8.4:${PORTSDIR}/x11-toolkits/tk84

GNU_CONFIGURE=	yes
USE_GMAKE=	yes
USE_GNOME=	intltool

.include <bsd.port.mk>
