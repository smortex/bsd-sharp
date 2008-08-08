# New ports collection makefile for:	taglib-sharp
# Date created:		24 mar 2008
# Whom:				pneumann@gmail.com
#
# $FreeBSD$
#

PORTNAME=	taglib-sharp
PORTVERSION=	2.0.3.0
CATEGORIES=	audio
MASTER_SITES=	http://www.taglib-sharp.com/Download/

MAINTAINER=	bsd-sharp-list@forge.novell.com
COMMENT=	Tag your software with as much or as little detail as you like

BUILD_DEPENDS=	${LOCALBASE}/bin/mono:${PORTSDIR}/lang/mono \
		monodocer:${PORTSDIR}/devel/monodoc
RUN_DEPENDS=	${LOCALBASE}/bin/mono:${PORTSDIR}/lang/mono \
		monodocer:${PORTSDIR}/devel/monodoc

GNU_CONFIGURE=	yes
USE_GMAKE=	yes
USE_GNOME=	gnomehack
# Building doc fails with mono>=1.2.6
CONFIGURE_ARGS=	--disable-docs

.include <bsd.port.mk>
