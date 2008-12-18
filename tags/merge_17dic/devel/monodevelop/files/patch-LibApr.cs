--- src/addins/VersionControl/MonoDevelop.VersionControl.Subversion/MonoDevelop.VersionControl.Subversion/LibApr.cs.orig	Sun Feb 25 17:59:17 2007
+++ src/addins/VersionControl/MonoDevelop.VersionControl.Subversion/MonoDevelop.VersionControl.Subversion/LibApr.cs	Sun Feb 25 17:59:48 2007
@@ -64,7 +64,7 @@
 
 	public class LibApr1: LibApr
 	{
-		private const string aprlib = "libapr-1.so.0";
+		private const string aprlib = "libapr-1.so.2";
 		
 		public override void initialize() { apr_initialize (); }
 		public override IntPtr pool_create_ex (out IntPtr pool, IntPtr parent, IntPtr abort, IntPtr allocator) { return apr_pool_create_ex(out pool, parent, abort, allocator); }
