# New ports collection makefile for:	stripes
# Date created:		2006 11 18
# Whom:			Phillip Neumann <pneumann@gmail.com>
#
# $FreeBSD$
#

PORTNAME=	stripes
PORTVERSION=	0.2.1
PORTREVISION=	1
CATEGORIES=	deskutils gnome
MASTER_SITES=	${MASTER_SITE_SOURCEFORGE}
MASTER_SITE_SUBDIR=	${PORTNAME}-barcode

MAINTAINER=	mono@FreeBSD.org
COMMENT=	A barcode generator

BUILD_DEPENDS=	mono:${PORTSDIR}/lang/mono \
		${LOCALBASE}/lib/libexarg.so:${PORTSDIR}/devel/exarg
RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono \
		${LOCALBASE}/lib/libexarg.so:${PORTSDIR}/devel/exarg

USE_GNOME=	gtksharp20
USE_GMAKE=	yes
GNU_CONFIGURE=	yes

post-install:
	${MKDIR} ${DESKTOPDIR}
	${INSTALL_DATA} ${FILESDIR}/stripes.desktop ${DESKTOPDIR}/

.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include <bsd.port.mk>
