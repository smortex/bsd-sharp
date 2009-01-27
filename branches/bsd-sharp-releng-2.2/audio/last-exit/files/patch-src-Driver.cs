--- src/Driver.cs.orig	Mon Jan  8 21:19:05 2007
+++ src/Driver.cs	Mon Mar 26 19:34:51 2007
@@ -200,17 +200,11 @@
 		}
 
 		[DllImport ("libc")]
-			private static extern int prctl (int option,  
-					byte[] arg2,
-					ulong arg3,
-					ulong arg4,
-					ulong arg5);
+		private static extern void setproctitle(byte [] fmt, byte [] str_arg);
 
 		private static void SetProcessName (string name)
 		{
-			if (prctl (15, Encoding.ASCII.GetBytes (name + "\0"), 0, 0, 0) != 0) {
-				throw new ApplicationException ("Error setting process name: " + Mono.Unix.Native.Stdlib.GetLastError ());
-			}
+			setproctitle(Encoding.ASCII.GetBytes("%s\0"), Encoding.ASCII.GetBytes(name + "\0"));
 		}
 
 		private static void SetUpConfigDirectory ()
