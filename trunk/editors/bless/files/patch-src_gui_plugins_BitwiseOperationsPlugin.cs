
$FreeBSD$

--- src/gui/plugins/BitwiseOperationsPlugin.cs.orig
+++ src/gui/plugins/BitwiseOperationsPlugin.cs
@@ -102,7 +102,7 @@
 		uim.InsertActionGroup(group, 0);
 		uim.AddUiFromString(uiXml);
 
-		performAction = (Action)uim.GetAction("/DefaultAreaPopup/ExtraAreaPopupItems/PerformBitwiseOperation");
+		performAction = (Gtk.Action)uim.GetAction("/DefaultAreaPopup/ExtraAreaPopupItems/PerformBitwiseOperation");
 
 		uim.EnsureUpdate();
 
