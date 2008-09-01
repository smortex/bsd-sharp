# New ports collection makefile for:    	mono-zeroconf
# Date created:         			20080817
# Whom:				pneumann@gmail.com
#
# $FreeBSD$
#   $Id$
#

PORTNAME=	mono-zeroconf
PORTVERSION=	0.7.6
CATEGORIES=	net
MASTER_SITES=	http://download.banshee-project.org/${PORTNAME}/

MAINTAINER=	bsd-sharp@googlegroups.com
COMMENT=	A cross platform Zero Configuration Networking library for Mono and .NET

BUILD_DEPENDS=	mono:${PORTSDIR}/lang/mono \
		${LOCALBASE}/lib/mono/avahi-sharp/avahi-sharp.dll:${PORTSDIR}/net/avahi-sharp
RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono \
		${LOCALBASE}/lib/mono/avahi-sharp/avahi-sharp.dll:${PORTSDIR}/net/avahi-sharp

USE_GMAKE=	yes
USE_BZIP2=	yes
USE_AUTOTOOLS=	libtool:15
USE_GNOME=	gnomehack

.if !defined(NOPORTDOCS)
BUILD_DEPENDS+=	monodocer:${PORTSDIR}/devel/monodoc
.endif

.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include <bsd.port.mk>
