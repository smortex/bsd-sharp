--- Extras/VersionControl/MonoDevelop.VersionControl.Subversion/MonoDevelop.VersionControl.Subversion/LibSvnClient.cs.orig	2007-11-07 18:28:14.000000000 +0000
+++ Extras/VersionControl/MonoDevelop.VersionControl.Subversion/MonoDevelop.VersionControl.Subversion/LibSvnClient.cs	2007-11-07 18:28:39.000000000 +0000
@@ -698,7 +698,7 @@
 		}
 		
 		[DllImport(svnclientlib)] static extern void svn_config_ensure (string config_dir, IntPtr pool);
-		[DllImport(svnclientlib)] static extern void svn_auth_open (out IntPtr auth_baton, IntPtr providers, IntPtr pool);
+		[DllImport("libsvn_subr-1.so.0")] static extern void svn_auth_open (out IntPtr auth_baton, IntPtr providers, IntPtr pool);
 		[DllImport(svnclientlib)] static extern void svn_auth_set_parameter (IntPtr auth_baton, string name, IntPtr value);
 		[DllImport(svnclientlib)] static extern IntPtr svn_auth_get_parameter (IntPtr auth_baton, string name);
 		[DllImport(svnclientlib)] static extern void svn_client_get_simple_provider (IntPtr item, IntPtr pool);
