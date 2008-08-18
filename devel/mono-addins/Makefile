# New ports collection makefile for:    	mono-addins
# Date created:         			20070316
# Whom:				Phillip N. <pneumann@gmail.com>
#
# $FreeBSD$
#   $Id$
#

PORTNAME=	mono-addins
PORTVERSION=	0.3.1
CATEGORIES=	devel
MASTER_SITES=	http://ftp.novell.com/pub/mono/sources/${PORTNAME}/

MAINTAINER=	bsd-sharp@googlegroups.com
COMMENT=	Framework for creating extensible applications on mono

BUILD_DEPENDS=	mono:${PORTSDIR}/lang/mono
RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono

USE_GNOME=	gnometarget gnomehack gtksharp20
USE_GMAKE=	yes
USE_AUTOTOOLS=	libtool:15
USE_BZIP2=	yes

.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include <bsd.port.mk>
