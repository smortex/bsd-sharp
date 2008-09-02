--- Tomboy/Utils.cs.orig	2008-04-12 18:32:48.000000000 -0400
+++ Tomboy/Utils.cs	2008-04-12 18:32:51.000000000 -0400
@@ -882,23 +882,12 @@
 		}
 
 		[DllImport("libc")]
-		private static extern int prctl (int option,
-			                                 byte [] arg2,
-			                                 IntPtr arg3,
-			                                 IntPtr arg4,
-			                                 IntPtr arg5);
+		private static extern void setproctitle(byte [] fmt, byte [] str_arg);
 
 		// From Banshee: Banshee.Base/Utilities.cs
 		public static void SetProcessName (string name)
 		{
-			if (prctl (15 /* PR_SET_NAME */,
-			                Encoding.ASCII.GetBytes (name + "\0"),
-			                IntPtr.Zero,
-			                IntPtr.Zero,
-			                IntPtr.Zero) != 0)
-				throw new ApplicationException (
-				        "Error setting process name: " +
-				        Mono.Unix.Native.Stdlib.GetLastError ());
+			setproctitle(Encoding.ASCII.GetBytes("%s\0"), Encoding.ASCII.GetBytes(name + "\0"));
 		}
 
 		static void RegisterSignalHandlers ()
