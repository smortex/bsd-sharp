# New ports collection makefile for:	tomboy-plugin-latex
# Date created:		2008-12-21
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	tomboy-plugin-latex
PORTVERSION=	0.5
CATEGORIES=	deskutils
MASTER_SITES=	http://www.reitwiessner.de/programs/
DISTNAME=	tomboy-latex-${PORTVERSION}

MAINTAINER=	freebsd-mono@freebsd.org
COMMENT=	LaTeX math plugin for Tomboy

BUILD_DEPENDS=	tomboy:${PORTSDIR}/deskutils/tomboy
RUN_DEPENDS=	tomboy:${PORTSDIR}/deskutils/tomboy \
		convert:${PORTSDIR}/graphics/ImageMagick \
		latex:${PORTSDIR}/print/teTeX-base

GNU_CONFIGURE=	yes
USE_GMAKE=	yes

.include <bsd.port.mk>
