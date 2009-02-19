# New ports collection makefile for:		gecko-sharp
# Date created:					20040825
# Whom:				Tom McLaughlin <tmclaugh@sdf.lonestar.org>
#
# $FreeBSD: ports/www/gecko-sharp20/Makefile,v 1.18 2009/02/09 08:59:59 flz Exp $
#   $Id: Makefile,v 1.19 2007/02/07 15:49:20 killfill Exp $
#

PORTNAME=	gecko-sharp
PORTVERSION=	0.13
CATEGORIES=	www
MASTER_SITES=	http://mono.ximian.com/monobuild/preview/sources/${PORTNAME}2/
DISTNAME=	${PORTNAME}-2.0-${PORTVERSION}

MAINTAINER=	mono@FreeBSD.org
COMMENT=	Mono bindings for embeding mozilla

USE_GECKO=	firefox mozilla
USE_GNOME=	gnometarget gtksharp20
LATEST_LINK=	gecko-sharp20
GNU_CONFIGURE=	yes
USE_GMAKE=	yes
USE_BZIP2=	yes

post-patch:
	@${REINPLACE_CMD} -e 's|[(]prefix[)]/lib/pkgconfig|(prefix)/libdata/pkgconfig|g' ${WRKSRC}/Makefile.in

.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include <bsd.port.pre.mk>
.include "${.CURDIR}/../../www/mozilla/bsd.gecko.mk"
.include <bsd.port.post.mk>
