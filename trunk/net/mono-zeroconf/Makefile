# $FreeBSD: head/net/mono-zeroconf/Makefile 355327 2014-05-26 13:08:57Z bapt $

PORTNAME=	mono-zeroconf
PORTVERSION=	0.9.0
PORTREVISION=	1
CATEGORIES=	net
MASTER_SITES=	http://download.banshee.fm/${PORTNAME}/

MAINTAINER=	mono@FreeBSD.org
COMMENT=	Cross platform Zero Configuration Networking library for Mono

BUILD_DEPENDS=	mono:${PORTSDIR}/lang/mono \
		${LOCALBASE}/libdata/pkgconfig/avahi-sharp.pc:${PORTSDIR}/net/avahi-sharp
RUN_DEPENDS:=	${BUILD_DEPENDS}

OPTIONS_DEFINE=	DOCS

GNU_CONFIGURE=	yes
USES=		gmake mono pathfix pkgconfig shebangfix
bash_CMD=	${SH}
SHEBANG_FILES=	src/MZClient/mzclient.in
CONFIGURE_ARGS+=	--program-transform-name="" \
			--disable-mdnsresponder
MAKE_JOBS_UNSAFE=	yes
DOCS_CONFIGURE_ENABLE=	docs

.include <bsd.port.mk>
