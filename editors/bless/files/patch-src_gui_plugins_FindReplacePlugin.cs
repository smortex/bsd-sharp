
$FreeBSD$

--- src/gui/plugins/FindReplacePlugin.cs.orig
+++ src/gui/plugins/FindReplacePlugin.cs
@@ -38,10 +38,10 @@
 	DataBook dataBook;
 	FindReplaceWidget widget;
 
-	Action FindAction;
-	Action FindNextAction;
-	Action FindPreviousAction;
-	Action ReplaceAction;
+	Gtk.Action FindAction;
+	Gtk.Action FindNextAction;
+	Gtk.Action FindPreviousAction;
+	Gtk.Action ReplaceAction;
 
 	IFinder finder;
 	Window mainWindow;
@@ -162,10 +162,10 @@
 		uim.InsertActionGroup(group, 0);
 		uim.AddUiFromString(uiXml);
 
-		FindAction = (Action)uim.GetAction("/menubar/Search/Find");
-		FindNextAction = (Action)uim.GetAction("/menubar/Search/FindNext");
-		FindPreviousAction = (Action)uim.GetAction("/menubar/Search/FindPrevious");
-		ReplaceAction = (Action)uim.GetAction("/menubar/Search/Replace");
+		FindAction = (Gtk.Action)uim.GetAction("/menubar/Search/Find");
+		FindNextAction = (Gtk.Action)uim.GetAction("/menubar/Search/FindNext");
+		FindPreviousAction = (Gtk.Action)uim.GetAction("/menubar/Search/FindPrevious");
+		ReplaceAction = (Gtk.Action)uim.GetAction("/menubar/Search/Replace");
 
 		uim.EnsureUpdate();
 
