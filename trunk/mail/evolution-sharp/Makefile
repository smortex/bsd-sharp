# New ports collection makefile for:		evolution-sharp
# Date created:					20041012
# Whom:				Tom McLaughlin <tmclaugh@sdf.lonestar.org>
#
# $FreeBSD: ports/mail/evolution-sharp/Makefile,v 1.16 2008/06/06 13:42:49 edwin Exp $
#   $Id: Makefile,v 1.29 2007/01/26 03:11:38 tmclau02 Exp $
#

PORTNAME=	evolution-sharp
PORTVERSION=	0.17.4
CATEGORIES=	mail gnome
MASTER_SITES=	GNOME

MAINTAINER=	bsd-sharp-list@forge.novell.com
COMMENT=	Mono bindings for evolution

BUILD_DEPENDS=	evolution:${PORTSDIR}/mail/evolution
RUN_DEPENDS=	evolution:${PORTSDIR}/mail/evolution

USE_GNOME=	gnomehack evolutiondataserver gtksharp20
USE_BZIP2=	yes
GNU_CONFIGURE=	yes
USE_GMAKE=	yes
USE_LDCONFIG=	yes

post-patch:
	@${REINPLACE_CMD} 's|.@EBOOK_SOVERSION@||g ; \
		s|.@ECAL_SOVERSION@||g ; \
		s|.@EDS_SOVERSION@||g' \
		${WRKSRC}/evolution/evolution-sharp.dll.config.in

.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include <bsd.port.mk>
