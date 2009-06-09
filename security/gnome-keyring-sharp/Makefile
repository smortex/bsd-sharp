# New ports collection makefile for:	gnome-keyring-sharp
# Date created:		2008-10-08
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	gnome-keyring-sharp
PORTVERSION=	1.0.0
#PORTREVISION=	0
#PORTEPOCH=	0
CATEGORIES=	security
MASTER_SITES=	http://ftp.novell.com/pub/mono/sources/${PORTNAME}/
#MASTER_SITE_SUBDIR=
#PKGNAMEPREFIX=
#PKGNAMESUFFIX=
#DISTNAME=
#EXTRACT_SUFX=
#DISTFILES=
#DIST_SUBDIR=	${PORTNAME}
#EXTRACT_ONLY=

MAINTAINER=	mono@FreeBSD.org
COMMENT=	Fully managed implementation of gnome-keyring

BUILD_DEPENDS=	mono:${PORTSDIR}/lang/mono \
		${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-1.0.pc:${PORTSDIR}/devel/ndesk-dbus
RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono \
		${LOCALBASE}/libdata/pkgconfig/ndesk-dbus-1.0.pc:${PORTSDIR}/devel/ndesk-dbus

USE_BZIP2=	yes
GNU_CONFIGURE=	yes
USE_GMAKE=	yes
USE_GNOME=	gnomehack

.include <bsd.port.pre.mk>
.include <bsd.port.post.mk>
