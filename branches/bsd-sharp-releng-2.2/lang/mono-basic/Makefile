# New ports collection makefile for:	mono-basic
# Date created:		2008-12-20
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	mono-basic
PORTVERSION=	2.2
CATEGORIES=	lang
MASTER_SITES=	ftp://ftp.novell.com/pub/mono/sources/${PORTNAME}/

MAINTAINER=	bsd-sharp@googlegroups.com
COMMENT=	VisualBasic.NET support for Mono

BUILD_DEPENDS=	mono:${PORTSDIR}/lang/mono
RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono

MAN1=		vbnc.1

USE_BZIP2=	yes
HAS_CONFIGURE=	yes
USE_GMAKE=	yes

.include <bsd.port.mk>
