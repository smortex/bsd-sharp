# New ports collection makefile for:	coco-cs
# Date created:		2009-01-11
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	coco-cs
PORTVERSION=	1.0.20081108
CATEGORIES=	devel
MASTER_SITES=	http://www.ssw.uni-linz.ac.at/Research/Projects/Coco/packages/ \
		http://romain.blogreen.org/distfiles/

MAINTAINER=	bsd-sharp@googlegroups.com
COMMENT=	Compiler Generator

BUILD_DEPENDS=	gmcs:${PORTSDIR}/lang/mono
RUN_DEPENDS=	${BUILD_DEPENDS}

GNU_CONFIGURE=	yes
USE_GMAKE=	yes

.include <bsd.port.pre.mk>
.include <bsd.port.post.mk>
