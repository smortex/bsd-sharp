using System;
using System.IO;
using System.Xml;
using System.Collections.Specialized;

namespace Gnome.Do
{
	/// <summary>
	/// Describes a gnome-do plugin.
	/// </summary>
	public class Plugin
	{
		
		private string name;
		private string description;
		private StringCollection assemblies = new StringCollection();
		private string version;
		private string id;
		
		//// <value>
		/// Plugin name as defined by the plugin directry name.
		/// </value>
		public string Name {
			get { return name ; }
		}
		
		//// <value>
		/// Plugin name as defined as /Addin/@description in the XML file.
		/// </value>
		public string Description {
			get { return description ; }
		}
		
		//// <value>
		/// Plugin name as defined as /Addin/Runtime/Import/@assembly in the XML file.
		/// </value>
		public StringCollection Assemblies {
			get { return assemblies ; }
		}
		
		public string MPack {
			get { return String.Format("Do.{0}_{1}.mpack", id, version); }
		}
		
		public Plugin(string path)
		{
			name = Path.GetFileName(path);
			
			XmlDocument document = new XmlDocument();
			document.Load(Path.Combine(Path.Combine(path, "Resources"), name + ".addin.xml"));
			
			// Get description
			XmlNodeList nodes = document.SelectNodes("/Addin/@description");
			description = nodes[0].Value;
			if (description.EndsWith("."))
				description = description.Trim('.');
			
			// Plugin version
			nodes = document.SelectNodes("Addin/@version");
			version = nodes[0].Value;
			
			// Plugin Id
			nodes = document.SelectNodes("Addin/@id");
			id = nodes[0].Value;
			
			// List assemblies
			nodes = document.SelectNodes("/Addin/Runtime/Import");
			foreach (XmlNode assembly in nodes) {
				// Some Google dll are referenced but not installed.
				if (assembly.Attributes["assembly"].Value.IndexOf("GData") == -1) {
					assemblies.Add(assembly.Attributes["assembly"].Value);
					assemblies.Add(assembly.Attributes["assembly"].Value + ".mdb");
				}
			}
		}
	}
}