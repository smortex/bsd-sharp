--- src/core/MonoDevelop.Core/MonoDevelop.Core/SystemAssemblyService.cs.orig	Fri Feb 23 21:20:47 2007
+++ src/core/MonoDevelop.Core/MonoDevelop.Core/SystemAssemblyService.cs	Fri Feb 23 21:21:31 2007
@@ -272,9 +272,9 @@
 				foreach (string pathdir in path_dirs.Split (Path.PathSeparator)) {
 					if (pathdir == null)
 						continue;
-					if (File.Exists (pathdir + Path.DirectorySeparatorChar + "pkg-config")) {
+					if (Directory.Exists (pathdir + Path.DirectorySeparatorChar + "../libdata/pkgconfig")) {
 						libpath = Path.Combine(pathdir,"..");
-						libpath = Path.Combine(libpath,"lib");
+						libpath = Path.Combine(libpath,"libdata");
 						libpath = Path.Combine(libpath,"pkgconfig");
 						break;
 					}
