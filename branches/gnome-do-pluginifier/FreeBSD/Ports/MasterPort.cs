using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace FreeBSD.Ports
{
	public class MasterPort: Port
	{
		
		private const string MAKEFILE_TEMPLATE = @"# New ports collection makefile for:	{0}
# Date created:		{1}
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTNAME=	{0}
PORTVERSION=	0.8.1
PORTREVISION?=	0
CATEGORIES?=	deskutils
MASTER_SITES=	https://launchpadlibrarian.net/23832017/
PKGNAMESUFFIX=  ${{DO_PLUGIN_SUFFIX}}

MAINTAINER=     mono@FreeBSD.org
COMMENT?=		gnome-do collection of plugins

BUILD_DEPENDS+=	gnome-do:${{PORTSDIR}}/deskutils/gnome-do
RUN_DEPENDS+=	gnome-do:${{PORTSDIR}}/deskutils/gnome-do

.include <bsd.port.pre.mk>

.include ""${{MASTERDIR}}/Makefile.common""

.include <bsd.port.post.mk>";
		
		private const string MAKEFILE_COMMON_TEMPLATE = @"# $FreeBSD$

.if defined(DO_PLUGIN)
DO_PLUGIN_SUFFIX=	-${{DO_PLUGIN}}

{0}
do_${{DO_PLUGIN}}_BUILD_DEPENDS?=
do_${{DO_PLUGIN}}_LIB_DEPENDS?=
do_${{DO_PLUGIN}}_RUN_DEPENDS?=

GNU_CONFIGURE=	yes
USE_GMAKE=      yes

BUILD_DEPENDS+=	${{do_${{DO_PLUGIN}}_BUILD_DEPENDS}}
LIB_DEPENDS+=	${{do_${{DO_PLUGIN}}_LIB_DEPENDS}}
RUN_DEPENDS+=	${{do_${{DO_PLUGIN}}_RUN_DEPENDS}}
PLIST_FILES=	${{do_${{DO_PLUGIN}}_PLIST_FILES}}
PLIST_DIRS=	${{do_${{DO_PLUGIN}}_PLIST_DIRS}}
BUILD_WRKSRC=	${{WRKSRC}}/${{do_${{DO_PLUGIN}}_BUILD_WRKSRC}}
INSTALL_WRKSRC=	${{BUILD_WRKSRC}}

post-configure:
	cd ${{WRKSRC}}/BundledLibraries && gmake

.else

{1}
EXTRACT_ONLY=
NO_BUILD=	yes

do-patch:		# empty

do-install:     # empty

.endif # NO_DO_PLUGIN
";
		
		public string MakefileCommon {
			get {
				string s = "";
				foreach (SlavePort port in slave_ports) {
					
					PkgPlistFormatter pp = new PkgPlistFormatter(port.PkgPlist, "do_" + port.PluginInternalName + "_");
					
					s += String.Format(@"# {0}
do_{1}_RUN_DEPENDS=	
{2}do_{1}_BUILD_WRKSRC=	{3}

", port.PluginName, port.PluginInternalName, (port.PkgPlist.RecommandedType == PkgPlistType.Inline) ? pp.PLIST_FILES + pp.PLIST_DIRS + "\n": "", port.BuildWrksrc);
				}
				
				string all_plugins_depend = "RUN_DEPENDS+=	";
				 ArrayList all_plugins = new ArrayList();
				foreach (SlavePort port in slave_ports) {
					all_plugins.Add(String.Format("${{LOCALBASE}}/{0}:${{PORTSDIR}}/{1}", port.PkgPlist.MPack, port.Origin));
				}
				all_plugins_depend +=  String.Join(" \\\n\t\t", (string []) all_plugins.ToArray(typeof(string)));
				return String.Format(MAKEFILE_COMMON_TEMPLATE, s, all_plugins_depend);
			}
		}
		
		private List<SlavePort> slave_ports = new List<SlavePort>();
		public List<SlavePort> SlavePorts {
			get { return slave_ports ; }
		}
		
		public MasterPort(string name, string description) : base(name,description)
		{
			makefile = String.Format(MAKEFILE_TEMPLATE, name, DateTime.Now.Date.ToString("yyyy-MM-dd"));
		}
		
		public void AddSlavePort(SlavePort port)
		{
			slave_ports.Add(port);
		}
		
		public new void CreatePort()
		{
			 base.CreatePort();
			using (StreamWriter file = new StreamWriter(Path.Combine(Origin, "Makefile.common"))) {
				file.WriteLine(MakefileCommon);
			}
		}

	}
}