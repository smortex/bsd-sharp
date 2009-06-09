# New ports collection makefile for:	gbrainy
# Date created:		2008-09-02
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	gbrainy
PORTVERSION=	1.00
CATEGORIES=	games
MASTER_SITES=	http://www.softcatala.org/~jmas/${PORTNAME}/

MAINTAINER=	mono@FreeBSD.org
COMMENT=	A brain teaser and trainer

GNU_CONFIGURE=	yes
USE_GMAKE=	yes
USE_GNOME=	intltool gnomesharp20
CONFIGURE_ENV=	GMSGFMT=msgfmt
USE_GETTEXT=	yes
INSTALLS_ICONS=	yes

MAN6=		gbrainy.6

.include <bsd.port.mk>
