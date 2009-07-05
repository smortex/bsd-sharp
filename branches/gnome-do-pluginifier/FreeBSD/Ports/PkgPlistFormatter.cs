
using System;
using System.IO;

namespace FreeBSD.Ports
{
	
	/// <summary>
	/// Formats pkg-plist files and PLIST_* entries
	/// </summary>
	public class PkgPlistFormatter
	{
		private PkgPlist pkg_plist;
		private string prefix;
		
		private string files_pad;
		private string directories_pad;
		
		private const string _PLIST_FILES = "PLIST_FILES=";
		private const string _PLIST_DIRS = "PLIST_DIRS=" ;
		
		public PkgPlistFormatter(PkgPlist pkg_plist)
		{
			this.pkg_plist = pkg_plist;
			this.prefix = "";
			this.files_pad = "\t\t";
			this.directories_pad = "\t\t";
		}
		
		public PkgPlistFormatter(PkgPlist pkg_plist, string Prefix)
		{
			this.pkg_plist = pkg_plist;
			this.prefix = Prefix;
			this.files_pad = new string('\t', (prefix + _PLIST_FILES).Length / 8 + 1);
			this.directories_pad = new string('\t', (prefix + _PLIST_DIRS).Length / 8 + 1);
		}

		
		//// <value>
		/// Formats a PLIST_DIRS line.
		/// </value>
		public string PLIST_DIRS {
			get {
				if (pkg_plist.Directories.Length > 0)
					return prefix + _PLIST_DIRS + "	" + String.Join(" \\\n" + directories_pad, pkg_plist.Directories);
				else
					return "";
			}
		}
		
		//// <value>
		/// Fomats a PLIST_FILES line.
		/// </value>
		public string PLIST_FILES {
			get {
				if (pkg_plist.Files.Length > 0)
					return prefix + _PLIST_FILES + "	" + String.Join(" \\\n" + files_pad, pkg_plist.Files);
				else
					return "";
			}
		}
		
		/// <summary>
		/// Writes the pkg-plist as FileName.
		/// </summary>
		/// <param name="FileName">
		/// A <see cref="System.String"/>
		/// </param>
		public void WriteToFile(string FileName)
		{
			using (StreamWriter plist_file = new StreamWriter(FileName)) {
				plist_file.WriteLine("@comment $FReeBSD$");
				
				foreach (string file in pkg_plist.Files) 
					plist_file.WriteLine(file);
				
				foreach (string directory in pkg_plist.Directories) 
					plist_file.WriteLine("@dirrm " + directory);

			}
		}
	}
}
