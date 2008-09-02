# New ports collection makefile for:	gbrainy
# Date created:		2008-09-02
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	gbrainy
PORTVERSION=	1.00
#PORTREVISION=	0
#PORTEPOCH=	0
CATEGORIES=	games
MASTER_SITES=	http://www.softcatala.org/~jmas/${PORTNAME}/
#MASTER_SITE_SUBDIR=
#PKGNAMEPREFIX=
#PKGNAMESUFFIX=
#DISTNAME=
#EXTRACT_SUFX=
#DISTFILES=
#DIST_SUBDIR=	${PORTNAME}
#EXTRACT_ONLY=

MAINTAINER=	romain@blogreen.org
COMMENT=	A brain teaser and trainer

GNU_CONFIGURE=	yes
USE_GMAKE=	yes
USE_GNOME=	intltool gnomesharp20
CONFIGURE_ENV=	GMSGFMT=msgfmt
USE_GETTEXT=	yes
INSTALLS_ICONS=	yes

MAN6=		gbrainy.6

.include <bsd.port.mk>
