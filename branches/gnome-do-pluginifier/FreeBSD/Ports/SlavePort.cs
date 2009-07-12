using System;
using System.Text.RegularExpressions;

using Gnome.Do;

namespace FreeBSD.Ports
{
	public class SlavePort: Port
	{
		private string plugin_name;
		
		private const string MAKEFILE_TEMPLATE = @"# New ports collection makefile for:	{0}
# Date created:		{1}
# Whom:			Romain Tartiere <romain@blogreen.org>
#
# $FreeBSD$
#

PORTVERSION=	0
CATEGORIES=	deskutils

COMMENT=	{2}

DO_PLUGIN=	{3}

MASTERDIR=	${{.CURDIR}}/../../deskutils/gnome-do-plugins

.include " + "\"${{MASTERDIR}}/Makefile\"";
		

		private MasterPort master_port;
		public MasterPort MasterPort {
			get { return master_port ; }
		}
		
		public string PluginName {
			get { return plugin_name; }
		}
		
		public string PluginInternalName {
			get { return Regex.Replace(plugin_name, "[^a-z]", ""); }
		}
		
		public SlavePort(string name, string description, MasterPort master_port) : base(name, description)
		{
			this.master_port = master_port;
		}
		
		public SlavePort(Plugin plugin, MasterPort master_port) : base(plugin)
		{
			plugin_name = NormalizePortName(plugin.Name);
			this.master_port = master_port;
			makefile = String.Format(MAKEFILE_TEMPLATE, Name, DateTime.Now.Date.ToString("yyyy-MM-dd"), Comment, PluginInternalName);
		}
	}
}