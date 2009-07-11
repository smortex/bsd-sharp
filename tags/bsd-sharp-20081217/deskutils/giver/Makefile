# New ports collection makefile for:	giver
# Date created:		2008-08-05
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	giver
PORTVERSION=	0.1.8
CATEGORIES=	deskutils
MASTER_SITES=	${MASTER_SITE_GOOGLE_CODE}

MAINTAINER=	bsd-sharp@googlegroups.com
COMMENT=	Easy file sharing

BUILD_DEPENDS=	${LOCALBASE}/libdata/pkgconfig/glib-sharp-2.0.pc:${PORTSDIR}/x11-toolkits/gtk-sharp20 \
		${LOCALBASE}/libdata/pkgconfig/gnome-sharp-2.0.pc:${PORTSDIR}/x11-toolkits/gnome-sharp20 \
		${LOCALBASE}/libdata/pkgconfig/gtk-dotnet-2.0.pc:${PORTSDIR}/x11-toolkits/gtk-sharp20 \
		${LOCALBASE}/libdata/pkgconfig/notify-sharp.pc:${PORTSDIR}/devel/notify-sharp \
		${LOCALBASE}/libdata/pkgconfig/avahi-sharp.pc:${PORTSDIR}/net/avahi-sharp
RUN_DEPENDS=	${BUILD_DEPENDS}

CONFIGURE_ENV=	GMSGFMT=msgfmt
GNU_CONFIGURE=	yes
INSTALLS_ICONS=	yes
USE_GETTEXT=	yes
USE_GMAKE=	yes
USE_GNOME=	intltool

.include <bsd.port.mk>
