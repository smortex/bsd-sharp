
$FreeBSD$

--- MPD/src/MPD.cs.orig
+++ MPD/src/MPD.cs
@@ -122,7 +122,7 @@
 					// Song list is not cached. Load songs from database.
 					try { 
 						Process proc = new Process();
-						proc.StartInfo.FileName = "/usr/bin/mpc"; 
+						proc.StartInfo.FileName = "mpc"; 
 						proc.StartInfo.Arguments =@"playlist --format "":%title%:%artist%:%album%:%file%""";
 						proc.StartInfo.UseShellExecute=false;
 						proc.StartInfo.RedirectStandardOutput = true;
