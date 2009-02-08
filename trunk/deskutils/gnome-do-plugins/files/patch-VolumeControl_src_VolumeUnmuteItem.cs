
$FreeBSD$

--- VolumeControl/src/VolumeUnmuteItem.cs.orig
+++ VolumeControl/src/VolumeUnmuteItem.cs
@@ -42,7 +42,7 @@
 		
 		public void Run ()
 		{
-			System.Diagnostics.Process.Start ("amixer set Master 50% > /dev/null");
+			System.Diagnostics.Process.Start ("mixer vol 50");
 		}
 	}
-}
\ No newline at end of file
+}
