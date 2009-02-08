
$FreeBSD$

--- VolumeControl/src/VolumeMuteItem.cs.orig
+++ VolumeControl/src/VolumeMuteItem.cs
@@ -41,7 +41,7 @@
 		
 		public void Run ()
 		{
-			System.Diagnostics.Process.Start ("amixer set Master 0% > /dev/null");
+			System.Diagnostics.Process.Start ("mixer vol 0");
 		}
 	}
-}
\ No newline at end of file
+}
