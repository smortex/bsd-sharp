
$FreeBSD$

--- src/gui/plugins/HistoryPlugin.cs.orig
+++ src/gui/plugins/HistoryPlugin.cs
@@ -61,7 +61,7 @@
 		// clear previous list
 		uiManager.RemoveUi(mergeId);
 		uiManager.RemoveActionGroup(historyActionGroup);
-		foreach(Action action in historyActionGroup.ListActions()) {
+		foreach(Gtk.Action action in historyActionGroup.ListActions()) {
 			historyActionGroup.Remove(action);
 		}
 
