--- src/addins/VersionControl/MonoDevelop.VersionControl.Subversion/MonoDevelop.VersionControl.Subversion/LibSvnClient.cs.orig	2008-12-22 19:04:35.000000000 -0300
+++ src/addins/VersionControl/MonoDevelop.VersionControl.Subversion/MonoDevelop.VersionControl.Subversion/LibSvnClient.cs	2008-12-22 19:06:01.000000000 -0300
@@ -845,7 +845,7 @@
 		
 		[DllImport(svnclientlib)] static extern void svn_config_ensure (string config_dir, IntPtr pool);
 		[DllImport(svnclientlib)] static extern void svn_config_get_config (ref IntPtr cfg_hash, string config_dir, IntPtr pool);
-		[DllImport(svnclientlib)] static extern void svn_auth_open (out IntPtr auth_baton, IntPtr providers, IntPtr pool);
+		[DllImport("libsvn_subr-1.so.0")] static extern void svn_auth_open (out IntPtr auth_baton, IntPtr providers, IntPtr pool);
 		[DllImport(svnclientlib)] static extern void svn_auth_set_parameter (IntPtr auth_baton, string name, IntPtr value);
 		[DllImport(svnclientlib)] static extern IntPtr svn_auth_get_parameter (IntPtr auth_baton, string name);
 		[DllImport(svnclientlib)] static extern void svn_client_get_simple_provider (IntPtr item, IntPtr pool);
