using System;
using System.Collections.Specialized;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Xsl;

using Gnome.Do;

namespace FreeBSD.Ports
{
	public class Port
	{
		private string name = "";
		private string comment = "";
		private string description = "";
		private string[] categories = {"deskutils"};
		private string build_wrksrc = "";
		
		private const string PORTSDIR = "";
		
		protected string makefile;
		//private StringCollection pkg_plist_files = new StringCollection();
		private PkgPlist pkg_plist = new PkgPlist();
			
		private const string PORT_NAME_PREFIX = "gnome-do-plugin-";
		private const string ASSEMBLY_ROOT = "share/gnome-do/plugins/";
		
		public string Origin {
			get { return categories[0] + "/" + name; }
		}
		
		public string Name {
			get { return name ; }
			set { name = NormalizePortName(value); }
		}
		
		public string Comment {
			get { return comment; }
		}
		
		public string Description {
			get { return description; }
		}
		
		public string Makefile
		{
			get { return makefile; }
		}
		
		public PkgPlist PkgPlist {
			get { return pkg_plist; }
		}
		
		public string BuildWrksrc {
			get { return build_wrksrc; }
		}
		
		/// <summary>
		/// Creates a new port in the FreeBSD ports collection.
		/// </summary>
		/// <param name="name">
		/// A <see cref="System.String"/>
		/// </param>
		/// <param name="description">
		/// A <see cref="System.String"/>
		/// </param>
		public Port(string name, string comment)
		{
			this.name = name;
			this.comment = comment;
		}

		public Port(string name, string comment, string description)
		{
			this.name = name;
			this.comment = comment;
			this.description = description;
		}
		
		public Port(Plugin plugin)
		{
			this.name = NormalizePortName(PORT_NAME_PREFIX + plugin.Name);
			this.comment = plugin.Description;
			this.build_wrksrc = plugin.Name;
			foreach (string file in plugin.Assemblies) {
				pkg_plist.AddFile(ASSEMBLY_ROOT + file);
			}
			pkg_plist.AddFile(ASSEMBLY_ROOT + plugin.MPack);
		}
		
		protected string NormalizePortName(string name)
		{
			string s = Regex.Replace(name, "([a-z]+)([A-Z]+)", "$1-$2");
			return Regex.Replace(s.ToLower(), "[^a-z-]", "-");
		}
		
		public void CreatePort()
		{
			if (!Directory.Exists(Origin))
				Directory.CreateDirectory(Origin);
			
			using (StreamWriter file = new StreamWriter(Path.Combine(Origin, "Makefile"))) {
				file.WriteLine(Makefile);
			}
		
			string descr_file = Path.Combine(Origin, "pkg-descr");
			if (description != "") {
				using (StreamWriter file = new StreamWriter(descr_file)) {
					file.WriteLine(Description);
				}
			} else {
				if (File.Exists(descr_file)) {
					File.Delete(descr_file);
				}
			}
			string plist_file = Path.Combine(Origin, "pkg-plist");
			if (pkg_plist.RecommandedType == PkgPlistType.File) {
				using (StreamWriter file = new StreamWriter(plist_file)) {
					file.WriteLine(pkg_plist);
				}
			} else {
				if (File.Exists(plist_file))
					File.Delete(plist_file);
				
			}
		}
	}
}