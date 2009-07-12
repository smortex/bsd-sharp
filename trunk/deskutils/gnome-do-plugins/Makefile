# New ports collection makefile for:	gnome-do-plugins
# Date created:		2009-07-12
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	gnome-do-plugins
PORTVERSION=	0.8.1
PORTREVISION?=	0
CATEGORIES?=	deskutils
MASTER_SITES=	https://launchpadlibrarian.net/23832017/
PKGNAMESUFFIX=  ${DO_PLUGIN_SUFFIX}

MAINTAINER=     mono@FreeBSD.org
COMMENT?=	gnome-do collection of plugins

BUILD_DEPENDS+=	gnome-do:${PORTSDIR}/deskutils/gnome-do \
		${LOCALBASE}/libdata/pkgconfig/banshee-1-collection-indexer.pc:${PORTSDIR}/multimedia/banshee \
		${LOCALBASE}/libdata/pkgconfig/evolution-sharp.pc:${PORTSDIR}/mail/evolution-sharp \
		${LOCALBASE}/libdata/pkgconfig/flickrnet.pc:${PORTSDIR}/devel/flickrnet
RUN_DEPENDS+=	gnome-do:${PORTSDIR}/deskutils/gnome-do

WANT_GNOME=	yes

.include <bsd.port.pre.mk>

.include "${MASTERDIR}/Makefile.common"

.include <bsd.port.post.mk>
