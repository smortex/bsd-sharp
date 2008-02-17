# New ports collection makefile for:		Nemerle
# Date created:					June 18, 2005
# Whom:				Christopher Nehren <apeiron@coitusmentis.info>
#
# $FreeBSD$
#   $Id: Makefile,v 1.13 2006/09/18 00:20:53 tmclau02 Exp $
#

PORTNAME=	nemerle
PORTVERSION=	0.9.3
CATEGORIES=	lang
MASTER_SITES=	http://nemerle.org/download/

MAINTAINER=	bsd-sharp-list@forge.novell.com
COMMENT=	A functional, object-oriented, imperative language targeting .NET

BUILD_DEPENDS=	mono:${PORTSDIR}/lang/mono \
		nant:${PORTSDIR}/devel/nant
RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono \
		nant:${PORTSDIR}/devel/nant

USE_BZIP2=	yes
USE_GMAKE=	yes

.include <bsd.port.pre.mk>
.if exists(${LOCALBASE}/bin/antlr) || defined(WITH_ANTLR)
PLIST_SUB+=     ANTLR=""
BUILD_DEPENDS=  antlr:${PORTSDIR}/devel/antlr
RUN_DEPENDS+=   antlr:${PORTSDIR}/devel/antlr
.else
PLIST_SUB+=     ANTLR="@comment "
.endif

post-patch:
	@${REINPLACE_CMD} 	-e 's|#! /bin/bash|#!/bin/sh|' \
				${WRKSRC}/configure
	@${REINPLACE_CMD} 	-e 's|libreadline.so.4|libreadline.so|' \
				${WRKSRC}/tools/nemerlish/nemish.exe.config

do-configure:
	cd ${WRKSRC} && ./configure --prefix=${PREFIX} --pkgconfigdir=${PREFIX}/libdata/pkgconfig

MAN1=		ncc.1

.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include <bsd.port.post.mk>
