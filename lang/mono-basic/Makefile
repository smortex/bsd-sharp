# New ports collection makefile for:	mono-basic
# Date created:		2008-12-20
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	mono-basic
PORTVERSION=	2.2
CATEGORIES=	lang
MASTER_SITES=	http://mono.ximian.com/monobuild/preview/sources/${PORTNAME}/

MAINTAINER=	bsd-sharp@googlegroups.com
COMMENT=	VisualBasic.NET support for Mono

BUILD_DEPENDS=	mono:${PORTSDIR}/lang/mono
RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono

USE_BZIP2=	yes
GNU_CONFIGURE=	yes
USE_GMAKE=	yes

.include <bsd.port.mk>
