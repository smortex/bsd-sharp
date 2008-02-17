# New ports collection makefile for:    fsharp
# Date created:		2006 10 10
# Whom:			Phillip Neumann <pneumann@gmail.com>
#
# $FreeBSD$
#

PORTNAME=	fsharp
PORTVERSION=	1.1.12.5
CATEGORIES=	lang
MASTER_SITES=	ftp://ftp.research.microsoft.com/downloads/a4aee11a-3154-466e-9f89-e1e8d3d40a56/

MAINTAINER=	bsd-sharp-list@forge.novell.com
COMMENT=	An advanced .NET programming language

BUILD_DEPENDS=	mono:${PORTSDIR}/lang/mono\
		${LOCALBASE}/lib/libgdiplus.a:${PORTSDIR}/x11-toolkits/libgdiplus
RUN_DEPENDS=	mono:${PORTSDIR}/lang/mono\
		${LOCALBASE}/lib/libgdiplus.a:${PORTSDIR}/x11-toolkits/libgdiplus

WRKSRC=	${WRKDIR}/FSharp-${PORTVERSION}
USE_ZIP=	yes
RESTRICTED=	I am not really sure about the license

AOT=	fslib10.dll \
	mllib10.dll \
	FSharp.Compiler10.dll \
	fsc.exe \
	fsi.exe

BIN_FILES=	mllib10* \
	fslib10* \
	fsi* \
	fsc* \
	FSharp.Compiler.Server.Shared10* \
	FSharp.Interactive.Settings10*

post-extract:
	@(${ECHO} '#!${SH}' > ${WRKDIR}/fsc)
	@(${ECHO} '#!${SH}' > ${WRKDIR}/fsi)
	@(${ECHO} '${LOCALBASE}/bin/mono ${PREFIX}/lib/${PORTNAME}/fsc.exe -I ${PREFIX}/lib/${PORTNAME}/ $$*' \
		>> ${WRKDIR}/fsc)
	@(${ECHO} '${LOCALBASE}/bin/mono ${PREFIX}/lib/${PORTNAME}/fsi.exe -I ${PREFIX}/lib/${PORTNAME}/ $$*' \
		>> ${WRKDIR}/fsi)

do-build:
	@${CP} ${WRKSRC}/bin/fscp10.exe ${WRKSRC}/bin/fsc.exe
	@${CP} ${WRKSRC}/bin/fsi10.exe ${WRKSRC}/bin/fsi.exe
	@${RM} ${WRKSRC}/bin/fsi10.exe ${WRKSRC}/bin/fscp10.exe
#	for i in ${AOT}; do \
#		mono --aot ${WRKSRC}/bin/$$i ;\
#	done

do-install:
	${MKDIR} ${LOCALBASE}/lib/${PORTNAME}
	@for i in ${BIN_FILES}; do \
		${INSTALL_DATA} ${WRKSRC}/bin/$$i ${PREFIX}/lib/${PORTNAME} ;\
	done
	${INSTALL_SCRIPT} ${WRKDIR}/fsi ${PREFIX}/bin/
	${INSTALL_SCRIPT} ${WRKDIR}/fsc ${PREFIX}/bin/

.include "${.CURDIR}/../../lang/mono/bsd.mono.mk"
.include <bsd.port.mk>
