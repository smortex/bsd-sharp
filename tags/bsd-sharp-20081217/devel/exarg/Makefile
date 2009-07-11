# New ports collection makefile for:   	exarg
# Date created:    	7 Dic 2006
# Whom:			pneumann@gmail.com
#
# $FreeBSD$
#

PORTNAME=	exarg
PORTVERSION=	1.0
CATEGORIES=	devel
MASTER_SITES=	${MASTER_SITE_SOURCEFORGE}
MASTER_SITE_SUBDIR=	aspl-fact
DISTNAME=	exarg-1.0.b2392.g2413

MAINTAINER=	pneumann@gmail.com
COMMENT=	Utility for parsing program arguments

WRKSRC=	${WRKDIR}/exarg-1.0.b2392.g2413

GNU_CONFIGURE=	yes
USE_LDCONFIG=	yes
CONFIGURE_ARGS+=	--disable-exarg-doc

post-patch:
	@${REINPLACE_CMD} -e 's|(libdir)/pkgconfig|(prefix)/libdata/pkgconfig|g' \
		${WRKSRC}/Makefile.in

.include <bsd.port.mk>
