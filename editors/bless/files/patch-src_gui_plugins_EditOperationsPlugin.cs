
$FreeBSD$

--- src/gui/plugins/EditOperationsPlugin.cs.orig
+++ src/gui/plugins/EditOperationsPlugin.cs
@@ -151,12 +151,12 @@
 	void ConnectEditAccelerators(bool v)
 	{
 		if (editAccelCount == 0 && v == true) {
-			foreach(Action a in editActionGroup.ListActions())
+			foreach(Gtk.Action a in editActionGroup.ListActions())
 			a.ConnectAccelerator();
 			editAccelCount = 1;
 		}
 		else if (editAccelCount == 1 && v == false) {
-			foreach(Action a in editActionGroup.ListActions())
+			foreach(Gtk.Action a in editActionGroup.ListActions())
 			a.DisconnectAccelerator();
 			editAccelCount = 0;
 		}
@@ -207,15 +207,15 @@
 		uim.InsertActionGroup(miscActionGroup, 0);
 
 		uim.AddUiFromString(uiXml);
-		UndoAction = (Action)uim.GetAction("/menubar/Edit/Undo");
-		RedoAction = (Action)uim.GetAction("/menubar/Edit/Redo");
-		CutAction = (Action)uim.GetAction("/menubar/Edit/Cut");
-		CopyAction = (Action)uim.GetAction("/menubar/Edit/Copy");
-		PasteAction = (Action)uim.GetAction("/menubar/Edit/Paste");
-		DeleteAction = (Action)uim.GetAction("/menubar/Edit/Delete");
+		UndoAction = (Gtk.Action)uim.GetAction("/menubar/Edit/Undo");
+		RedoAction = (Gtk.Action)uim.GetAction("/menubar/Edit/Redo");
+		CutAction = (Gtk.Action)uim.GetAction("/menubar/Edit/Cut");
+		CopyAction = (Gtk.Action)uim.GetAction("/menubar/Edit/Copy");
+		PasteAction = (Gtk.Action)uim.GetAction("/menubar/Edit/Paste");
+		DeleteAction = (Gtk.Action)uim.GetAction("/menubar/Edit/Delete");
 
 
-		foreach (Action a in editActionGroup.ListActions()) {
+		foreach (Gtk.Action a in editActionGroup.ListActions()) {
 			// for some reason the accelerators are connected twice
 			// ... so disconnect them twice
 			for (int i = 0; i < 2; i++)
