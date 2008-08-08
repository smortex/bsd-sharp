
$FreeBSD$

--- src/gui/plugins/FileOperationsPlugin.cs.orig
+++ src/gui/plugins/FileOperationsPlugin.cs
@@ -159,11 +159,11 @@
 
 		uim.InsertActionGroup(group, 0);
 		uim.AddUiFromString(uiXml);
-		SaveAction = (Action)uim.GetAction("/menubar/File/Save");
-		SaveAsAction = (Action)uim.GetAction("/menubar/File/SaveAs");
-		CloseAction = (Action)uim.GetAction("/menubar/File/Close");
-		QuitAction = (Action)uim.GetAction("/menubar/File/Quit");
-		RevertAction = (Action)uim.GetAction("/menubar/File/Revert");
+		SaveAction = (Gtk.Action)uim.GetAction("/menubar/File/Save");
+		SaveAsAction = (Gtk.Action)uim.GetAction("/menubar/File/SaveAs");
+		CloseAction = (Gtk.Action)uim.GetAction("/menubar/File/Close");
+		QuitAction = (Gtk.Action)uim.GetAction("/menubar/File/Quit");
+		RevertAction = (Gtk.Action)uim.GetAction("/menubar/File/Revert");
 
 		uim.EnsureUpdate();
 
