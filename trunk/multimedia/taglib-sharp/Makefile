# New ports collection makefile for:    	taglib-sharp
# Date created:         			20080817
# Whom:				pneumann@gmail.com
#
# $FreeBSD$
#   $Id$
#

PORTNAME=	taglib-sharp
PORTVERSION=	2.0.3.0
CATEGORIES=	multimedia
MASTER_SITES=	http://www.taglib-sharp.com/Download/

MAINTAINER=	bsd-sharp@googlegroups.com
COMMENT=	A free library for reading and writing tags to multimedia files

BUILD_DEPENDS=	mono:${PORTSDIR}/lang/mono
RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono

USE_GMAKE=	yes
USE_AUTOTOOLS=	libtool:15
CONFIGURE_ARGS=	--disable-docs

.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include <bsd.port.mk>
