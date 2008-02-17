# New ports collection makefile for:   	moma
# Date created:    	28 Nov 2006
# Whom:			Phillip Neumann <pneumann@gmail.com>
#
# $FreeBSD$
#

PORTNAME=	moma
PORTVERSION=	1.1.1
CATEGORIES=	devel
MASTER_SITES=	http://www.go-mono.com/archive/${PORTNAME}/
DISTNAME=	Moma1-1-1

MAINTAINER=	bsd-sharp-list@forge.novell.com
COMMENT=	Identify issues you may have when porting a .Net application

RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono\
		${LOCALBASE}/lib/libgdiplus.a:${PORTSDIR}/x11-toolkits/libgdiplus

WRKSRC=	${WRKDIR}/MoMA
NO_BUILD=	yes
USE_ZIP=	yes

do-install:
	@${MKDIR} ${LOCALBASE}/lib/${PORTNAME}/Reports
	@${CHMOD} 777 ${LOCALBASE}/lib/${PORTNAME}/Reports
	@cd ${WRKSRC} ; ${FIND} . | ${CPIO} -pdmv ${LOCALBASE}/lib/${PORTNAME}
	@${INSTALL} ${FILESDIR}/moma ${LOCALBASE}/bin/

.include <bsd.port.pre.mk>
.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include <bsd.port.post.mk>
