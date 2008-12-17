# New ports collection makefile for:	beagle
# Date created:				20041016
# Whom:					Tom McLaughlin <tmclaugh@FreeBSD.org>
#
# $FreeBSD$
#   $Id: Makefile,v 1.2 2007/04/26 04:03:49 killfill Exp $
#

PORTREVISION=	1
CATEGORIES=	deskutils gnome python
PKGNAMEPREFIX=	${PYTHON_PKGNAMEPREFIX}

MAINTAINER=	bsd-sharp@googlegroups.com

LIB_DEPENDS=	beagle:${PORTSDIR}/deskutils/beagle

MASTERDIR=	${.CURDIR}/../beagle
INSTALL_WRKSRC=	${WRKSRC}/wrappers/python
DESCR=		${.CURDIR}/pkg-descr
PLIST=		${.CURDIR}/pkg-plist
# We want the master port's patches but also want to patch out unnecessary
# building in this port.
EXTRA_PATCHES=	${.CURDIR}/files/patch-Makefile.in

BEAGLE_SLAVE=	yes
PY_BEAGLE=	yes
USE_GNOME+=	pygtk2

CONFIGURE_ARGS=	--enable-python

USE_PYTHON=	yes

.include "${MASTERDIR}/Makefile"
