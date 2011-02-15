# New ports collection makefile for:	pinta
# Date created:				2011-02-14
# Whom:					Alexander Kojevnikov <alexander@kojevnikov.com>
#
# $FreeBSD$
#

PORTNAME=	pinta
PORTVERSION=	0.6
CATEGORIES=	graphics
MASTER_SITES=	http://cloud.github.com/downloads/jpobst/Pinta/
# Remove in the next version:
DISTFILES=	${DISTNAME}-1${EXTRACT_SUFX}

MAINTAINER=	mono@FreeBSD.org
COMMENT=	Simple Gtk\# Paint Program

LICENSE=	MIT

LIB_PC_DEPENDS=	${LOCALBASE}/libdata/pkgconfig/mono.pc:${PORTSDIR}/lang/mono

USE_GMAKE=	yes
GNU_CONFIGURE=	yes
USE_GNOME=	gnomehack gtksharp20
INSTALLS_ICONS=	yes
USE_GETTEXT=	yes

MAN1=	pinta.1
MANCOMPRESSED=	yes

.include <bsd.port.pre.mk>
.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include <bsd.port.post.mk>
