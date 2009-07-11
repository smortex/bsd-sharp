# New ports collection makefile for:	libanculus-sharp
# Date created:		2008-09-01
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	libanculus-sharp
PORTVERSION=	0.3.1
CATEGORIES=	misc
MASTER_SITES=	${MASTER_SITE_GOOGLE_CODE}

MAINTAINER=	bsd-sharp@googlegroups.com
COMMENT=	Reusable utility library for Mono and MS.Net

BUILD_DEPENDS=	${LOCALBASE}/bin/mono:${PORTSDIR}/lang/mono
RUN_DEPENDS=	${LOCALBASE}/bin/mono:${PORTSDIR}/lang/mono

USE_BZIP2=	yes
USE_AUTOTOOLS=	aclocal:110 automake:110 autoconf:262
AUTOMAKE_ARGS=	--add-missing --gnu
ACLOCAL_ARGS=	-I .
GNU_CONFIGURE=	yes
USE_GMAKE=	yes
USE_GNOME=	gnomehack gtksharp20

.include <bsd.port.mk>
