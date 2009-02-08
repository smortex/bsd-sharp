
$FreeBSD$

--- VolumeControl/src/VolumeDownItem.cs.orig
+++ VolumeControl/src/VolumeDownItem.cs
@@ -41,7 +41,7 @@
 		
 		public void Run ()
 		{
-			System.Diagnostics.Process.Start ("amixer set Master 3%- /dev/null");
+			System.Diagnostics.Process.Start ("mixer vol -3");
 		}
 	}
 }
