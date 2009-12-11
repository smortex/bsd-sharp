
$FreeBSD$

https://bugzilla.novell.com/show_bug.cgi?id=554898

--- mcs/tools/csharp/repl.cs.orig
+++ mcs/tools/csharp/repl.cs
@@ -242,7 +242,7 @@
 
 		public int ReadEvalPrintLoop ()
 		{
-			if (startup_files.Length == 0)
+			if (startup_files == null || startup_files.Length == 0)
 				InitTerminal ();
 
 			InitializeUsing ();
@@ -252,7 +252,7 @@
 			//
 			// Interactive or startup files provided?
 			//
-			if (startup_files.Length != 0)
+			if (startup_files != null && startup_files.Length != 0)
 				ExecuteSources (startup_files, false);
 			else
 				ReadEvalPrintLoopWith (GetLine);
