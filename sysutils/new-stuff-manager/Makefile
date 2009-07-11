# New ports collection makefile for:	new-stuff-manager
# Date created:		7 Jan 2007
# Whom:			Phillip Neumann <pneumann@gmail.com>
#
# $FreeBSD$
#

PORTNAME=	new-stuff-manager
PORTVERSION=	0.2.3
PORTREVISION=	1
CATEGORIES=	sysutils
MASTER_SITES=	http://www.k-d-w.org/NewStuffManager/source/

MAINTAINER=	bsd-sharp@googlegroups.com
COMMENT=	An easy way to upgrade plugins of any application

BUILD_DEPENDS=	mono:${PORTSDIR}/lang/mono \
		gpgv:${PORTSDIR}/security/gnupg1
RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono \
		dbus-daemon:${PORTSDIR}/devel/dbus

USE_GNOME=	gnometarget gnomesharp20
GNU_CONFIGURE=	yes
USE_GMAKE=	yes
CONFIGURE_ARGS=	--program-transform-name=''

post-patch:
	@${REINPLACE_CMD} -e 's|[(]libdir[)]/pkgconfig|(libdir)/../libdata/pkgconfig|g' ${WRKSRC}/Makefile.in

.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include <bsd.port.mk>
