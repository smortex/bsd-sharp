--- src/core/MonoDevelop.Core/MonoDevelop.Core/SystemAssemblyService.cs.orig	2008-12-22 20:20:38.000000000 -0300
+++ src/core/MonoDevelop.Core/MonoDevelop.Core/SystemAssemblyService.cs	2008-12-22 20:21:26.000000000 -0300
@@ -359,9 +359,9 @@
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
