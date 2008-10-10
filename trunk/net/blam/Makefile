# New ports collection makefile for:	blam
# Date created:		2008-09-17
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	blam
PORTVERSION=	1.8.6
CATEGORIES=	net
MASTER_SITES=	http://www.cmartin.tk/${PORTNAME}/
DISTNAME=	${PORTNAME}_${PORTVERSION}.orig

MAINTAINER=	bsd-sharp@googlegroups.com
COMMENT=	A simple feed reader for GNOME

BUILD_DEPENDS=	msgfmt:${PORTSDIR}/devel/gettext \
		${LOCALBASE}/libdata/pkgconfig/webkit-sharp-1.0.pc:${PORTSDIR}/www/webkit-sharp
RUN_DEPENDS=	${LOCALBASE}/libdata/pkgconfig/webkit-sharp-1.0.pc:${PORTSDIR}/www/webkit-sharp

GNU_CONFIGURE=	yes
USE_GMAKE=	yes
CONFIGURE_ENV=	GMSGFMT="${LOCALBASE}/bin/msgfmt" DATADIRNAME="share"
USE_GNOME=	gnomesharp20
USE_GETTEXT=	yes
INSTALLS_ICONS=	yes
GCONF_SCHEMAS=	blam.schemas
WRKSRC=		${WRKDIR}/${PORTNAME}-${PORTVERSION}

MAN1=		blam.1

.include <bsd.port.pre.mk>
.include <bsd.port.post.mk>
