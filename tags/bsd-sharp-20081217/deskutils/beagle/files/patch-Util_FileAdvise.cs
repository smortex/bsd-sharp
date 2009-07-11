--- Util/FileAdvise.cs.orig	Thu Mar 15 18:31:16 2007
+++ Util/FileAdvise.cs	Thu Mar 15 18:35:14 2007
@@ -39,8 +39,6 @@
 
 		// FIXME: On 64-bit architectures, we need to use "long" not "int" here for
 		// "offset" and "len"
-		[DllImport ("libc", SetLastError=true)]
-		static extern int posix_fadvise (int fd, int offset, int len, int advice);
 
 		// The following are from /usr/include/linux/fadvise.h and will not change
 		private const int AdviseNormal = 0;	// POSIX_FADV_NORMAL
@@ -52,8 +50,7 @@
 
 		static private int GiveAdvice (FileStream file, int advice)
 		{
-			int fd = file.Handle.ToInt32 ();
-			return posix_fadvise (fd, 0, 0, advice);
+			return 0;
 		}
 
 		static public void FlushCache (FileStream file)
