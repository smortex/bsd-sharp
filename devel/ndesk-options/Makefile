# New ports collection makefile for:	ndesk-options
# Date created:		2008-08-06
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	ndesk-options
PORTVERSION=	0.2.0
CATEGORIES=	devel
MASTER_SITES=	http://www.ndesk.org/archive/${PORTNAME}/

MAINTAINER=	romain@blogreen.org
COMMENT=	Callback-based program option parser for C\#

BUILD_DEPENDS=	mono:${PORTSDIR}/lang/mono
RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono

GNU_CONFIGURE=	yes
USE_GMAKE=	yes

post-patch:
	@${reinplace_cmd} -e 's|[(]libdir[)]/pkgconfig|(prefix)/libdata/pkgconfig|g' \
		${wrksrc}/makefile.in

.include <bsd.port.mk>
