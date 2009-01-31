
$FreeBSD$

--- src/addins/MonoDevelop.GtkCore/lib/stetic/libstetic/editor/ResponseId.cs.orig
+++ src/addins/MonoDevelop.GtkCore/lib/stetic/libstetic/editor/ResponseId.cs
@@ -14,7 +14,7 @@
 			int val = (int) Value;
 			EnumDescriptor enm = Registry.LookupEnum ("Gtk.ResponseType");
 			foreach (Enum value in enm.Values) {
-				if ((int) enm[value].Value == val) {
+				if (Convert.ToInt32(enm[value].Value) == val) {
 					return enm[value].Label;
 				}
 			}
@@ -49,7 +49,7 @@
 			foreach (Enum value in enm.Values) {
 				if (enm[value].Label != "") {
 					combo.AppendText (enm[value].Label);
-					values.Add ((int)enm[value].Value);
+					values.Add (Convert.ToInt32(enm[value].Value));
 				}
 			}
 		}
