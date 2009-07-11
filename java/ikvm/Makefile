# New ports collection makefile for:		ikvm
# Date created:					20040907
# Whom:				Tom McLaughlin <tmclaugh@sdf.lonestar.org>
#
# $FreeBSD$
#   $Id: Makefile,v 1.11 2006/02/01 23:32:56 tmclau02 Exp $
#

PORTNAME=	ikvm
PORTVERSION=	0.36.0.11
CATEGORIES=	java
MASTER_SITES=	${MASTER_SITE_SOURCEFORGE}
MASTER_SITE_SUBDIR=	${PORTNAME}
DISTFILES=	${PORTNAME}bin-${PORTVERSION}${EXTRACT_SUFX}

MAINTAINER=	bsd-sharp@googlegroups.com
COMMENT=	Java for Mono and the Microsoft .NET Framework

BUILD_DEPENDS=	${LOCALBASE}/bin/mono:${PORTSDIR}/lang/mono
RUN_DEPENDS=	${BUILD_DEPENDS}

USE_ZIP=	yes
USE_GNOME=	gnometarget
NO_BUILD=	yes

do-install:
	${MKDIR} ${PREFIX}/lib/${PORTNAME}
.for f in ICSharpCode.SharpZipLib.dll ikvm-native.dll IKVM.AWT.WinForms.dll ikvm.exe IKVM.OpenJDK.ClassLibrary.dll IKVM.Runtime.dll ikvmc.exe ikvmstub.exe JVM.DLL
	@${INSTALL_DATA} ${WRKSRC}/bin/$f ${PREFIX}/lib/${PORTNAME}
.endfor
.for f in ikvm ikvmc ikvmstub
	@echo -e "#!/bin/sh\n${PREFIX}/bin/mono ${PREFIX}/lib/${PORTNAME}/$f.exe \"\$$@\"" > ${PREFIX}/bin/$f
	${CHMOD} 755 ${PREFIX}/bin/$f
.endfor

.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include <bsd.port.mk>
