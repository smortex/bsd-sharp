# $FreeBSD$

PORTNAME=	mono-addins
PORTVERSION=	1.0
CATEGORIES=	devel
MASTER_SITES=	http://romain.blogreen.org/distfiles/

MAINTAINER=	mono@FreeBSD.org
COMMENT=	Mono framework to create extensible applications

LIB_PC_DEPENDS=	${LOCALBASE}/libdata/pkgconfig/mono.pc:${PORTSDIR}/lang/mono

BUILD_DEPENDS+=	${LIB_PC_DEPENDS}
RUN_DEPENDS+=	${LIB_PC_DEPENDS}

GNU_CONFIGURE=	yes
USES=		gmake pathfix pkgconfig
WANT_GNOME=	yes
MAKE_JOBS_UNSAFE=	yes

OPTIONS_DEFINE=	GTK2
OPTIONS_DEFAULT=	GTK2

PLIST_SUB+=	VER=1.0.0

.include <bsd.port.pre.mk>
.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"

.if ${PORT_OPTIONS:MGTK2}
USE_GNOME+=	gtksharp20
CONFIGURE_ARGS+=	--enable-gui
PLIST_SUB+=	OPT_GTK2=""
.else
CONFIGURE_ARGS+=	--disable-gui
PLIST_SUB+=	OPT_GTK2="@comment "
.endif

.include <bsd.port.post.mk>
