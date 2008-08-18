# New ports collection makefile for:	greent
# Date created:		23 Feb 2006
# Whom:			Phillip Neumann <pneumann@gmail.com>
#
# $FreeBSD$
#

PORTNAME=	greent
PORTVERSION=	0.9.1
PORTREVISION=	5
CATEGORIES=	x11 gnome
MASTER_SITES=	http://forgeftp.novell.com/greent/releases/${PORTVERSION}/

MAINTAINER=	bsd-sharp@googlegroups.com
COMMENT=	A Quake-style terminal emulator written in C#

BUILD_DEPENDS=	xmlto:${PORTSDIR}/textproc/xmlto \

RUN_DEPENDS=	xmlto:${PORTSDIR}/textproc/xmlto \
		tomboy:${PORTSDIR}/deskutils/tomboy \

USE_NANT=	yes
USE_GNOME=	gnomesharp20

.include <bsd.port.pre.mk>
.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include <bsd.port.post.mk>
