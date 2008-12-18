
$FreeBSD$

--- src/Utilities.cs.orig
+++ src/Utilities.cs
@@ -39,17 +39,11 @@
 	internal class Utilities
 	{
 		[DllImport("libc")]
-		private static extern int prctl(int option, byte [] arg2, IntPtr arg3,
-		    IntPtr arg4, IntPtr arg5);
+		private static extern void setproctitle(string fmt);
 
 		public static void SetProcessName(string name)
 		{
-			// 15 = PR_SET_NAME
-		    if(prctl(15, Encoding.ASCII.GetBytes(name + "\0"), IntPtr.Zero, IntPtr.Zero, IntPtr.Zero) != 0)
-		    {
-		        throw new ApplicationException("Error setting process name: " +
-		            Mono.Unix.Native.Stdlib.GetLastError());
-		    }
+			setproctitle(name);
 		}
 		
 		public static string ReplaceString (string originalString, string searchString, string replaceString)
