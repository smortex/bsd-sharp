using System;
using System.IO;
using System.Collections.Generic;
using FreeBSD.Ports;

namespace Pluginifier
{
	public class Pluginifier
	{
		/// <summary>
		/// Plugins for which we don't want to build a port.
		/// </summary>
		private string [] exclude = { "AptURL" };
		
		private List<Gnome.Do.Plugin> plugins = new List<Gnome.Do.Plugin>();
		
		public Pluginifier()
		{
		}
		
		public void LoadPlugins(string path)
		{
			foreach (string plugin_path in Directory.GetDirectories(path)) {
				string plugin_name = Path.GetFileName(plugin_path);
				if (File.Exists(Path.Combine(Path.Combine(plugin_path, "Resources"), plugin_name + ".addin.xml"))) {
					if (-1 == Array.IndexOf(exclude, Path.GetFileName(plugin_path)))
						plugins.Add(new Gnome.Do.Plugin(plugin_path));
				}
			}
		}

		public void CreatePorts(MasterPort master_port)
		{
			foreach (Gnome.Do.Plugin p in plugins) {
				master_port.AddSlavePort(new SlavePort(p, master_port));
			}
		}
		 
	}
}