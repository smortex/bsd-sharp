using System;
using System.IO;

using FreeBSD.Ports;

namespace Pluginifier
{
	class MainClass
	{
		public static int Main(string[] args)
		{
			// Check arguments
			if ((args.Length != 1) || (!Directory.Exists(args[0]))) {
				Console.Error.WriteLine("A single argument specifying the location of the gnome-do-plugins directory is required.");
				return 1;
			}
			Pluginifier p = new Pluginifier();
			p.LoadPlugins(args[0]);
			
			MasterPort gnome_do_plugins = new MasterPort("gnome-do-plugins", "All gnome-do Plugins");
			p.CreatePorts(gnome_do_plugins);
			
			gnome_do_plugins.CreatePort();
			
			 foreach (Port slave in gnome_do_plugins.SlavePorts) {
				slave.CreatePort();
			}
			return 0;
		}
	}
}