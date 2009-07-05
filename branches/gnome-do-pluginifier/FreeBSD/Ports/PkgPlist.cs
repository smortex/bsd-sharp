
using System;
using System.Collections;

namespace FreeBSD.Ports
{
	
	/// <summary>
	/// Describes a FreeBSD port's pkg-plist
	/// </summary>
	public class PkgPlist
	{
		private ArrayList files = new ArrayList();
		private ArrayList directories = new ArrayList();
		
		private bool sorted = false;
		
		private const int PLIST_MIN_FILES = 5;
		
		public PkgPlist()
		{
		}
		
		public string MPack {
			get {
				foreach (string s in files) {
					if (s.EndsWith(".mpack"))
					    return s;
				}
				return "";
			}
		}
		
		/// <summary>
		/// Adds the given FileName to the pkg-plist.
		/// </summary>
		/// <param name="FileName">
		/// A <see cref="System.String"/>
		/// </param>
		public void AddFile(string FileName)
		{
			files.Add(FileName);
			sorted = false;
		}
		
		/// <summary>
		/// Adds the diven DirectoryName to the pkg-plist.
		/// </summary>
		/// <param name="DirectoryName">
		/// A <see cref="System.String"/>
		/// </param>
		public void AddDirectory(string DirectoryName)
		{
			directories.Add(DirectoryName);
			sorted = false;
		}
		
		public string [] Directories {
			get {
				if (!sorted) Sort();
				return (string []) directories.ToArray(typeof(string));
			}
		}
		
		public string [] Files {
			get {
				if (!sorted) Sort();
				return (string []) files.ToArray(typeof(string));
			}
		}
		
		//// <value>
		/// Determines the recommanded way to store this pkg-plist.
		/// </value>
		public PkgPlistType RecommandedType {
			get {
				if (Count < PLIST_MIN_FILES)
					return PkgPlistType.Inline;
				else
					return PkgPlistType.File;
			}
		}

		/// <summary>
		/// Returns the pkg-plist contents for storing it as a file.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/>
		/// </returns>
		public override string ToString()
		{
			if (!sorted) Sort();

			string s= "@comment $FreeBSD$\n";
			foreach (string file in files)
				s += file + "\n";
			foreach (string directory in directories)
				s += "@dirrm " + directory + "\n";
			
			return s;
		}
				
		private int Count {
			get { return files.Count + directories.Count; }
		}
		
		/// <summary>
		/// Sorts the files and directory names referenced in the pkg-plist.
		/// </summary>
		private void Sort()
		{
			files.Sort();
			directories.Sort();
			directories.Reverse();
			sorted = true;
		}
		
	}
}
