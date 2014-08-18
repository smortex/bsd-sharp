# $FreeBSD$

PORTNAME=	gtk-sharp
PORTVERSION=	2.99.3
CATEGORIES=	x11-toolkits
MASTER_SITES=	GNOME
PKGNAMESUFFIX=	30

MAINTAINER=	romain@FreeBSD.org
COMMENT=	GTK+ and GNOME interfaces for the .NET runtime

BUILD_DEPENDS=	mono:${PORTSDIR}/lang/mono
RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono
LIB_DEPENDS=	libgtk-3.so:${PORTSDIR}/x11-toolkits/gtk30

MAKE_ENV=       INSTALL_STRIP_FLAG=${STRIP}
USE_XZ=		yes
GNU_CONFIGURE=	yes
USES=		gmake pathfix perl5 pkgconfig

post-patch:
	@${REINPLACE_CMD} -e 's|^#!/usr/bin/perl|#!${PERL}|' \
		${WRKSRC}/parser/gapi2xml.pl \
		${WRKSRC}/parser/gapi_pp.pl

.include <bsd.port.mk>
