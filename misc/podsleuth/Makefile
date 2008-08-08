# New ports collection makefile for:	podsleuth
# Date created:		2008-07-09
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	podsleuth
PORTVERSION=	0.6.2
CATEGORIES=	misc
MASTER_SITES=	http://download.banshee-project.org/${PORTNAME}/

MAINTAINER=	romain@blogreen.org
COMMENT=	A tool to discover detailed model information about an iPod

LIB_DEPENDS=	sgutils.1:${PORTSDIR}/sysutils/sg3_utils

GNU_CONFIGURE=	yes
CONFIGURE_TARGET=--build=${MACHINE_ARCH}-portbld-freebsd${OSREL}
USE_GMAKE=	yes
USE_GNOME=	gnomehack

CONFIGURE_ENV=	CPPFLAGS="${CXXFLAGS} -I${LOCALBASE}/include" \
		LDFLAGS="-L${LOCALBASE}/lib"

.include <bsd.port.mk>
