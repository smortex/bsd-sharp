
$FreeBSD$

--- src/addins/MonoDevelop.GtkCore/lib/stetic/libstetic/editor/Flags.cs.orig
+++ src/addins/MonoDevelop.GtkCore/lib/stetic/libstetic/editor/Flags.cs
@@ -19,7 +19,7 @@
 				if (eval.Label == "")
 					continue;
 				
-				if ((value & (uint)(int)eval.Value) != 0) {
+				if ((value & (uint) Convert.ToInt32(eval.Value)) != 0) {
 					if (txt.Length > 0) txt += ", ";
 					txt += eval.Label;
 				}
@@ -72,7 +72,7 @@
 
 					Gtk.CheckButton check = new Gtk.CheckButton (eval.Label);
 					tips.SetTip (check, eval.Description, eval.Description);
-					uint uintVal = (uint)(int)eval.Value;
+					uint uintVal = (uint)Convert.ToInt32(eval.Value);
 					flags[check] = uintVal;
 					flags[uintVal] = check;
 					
@@ -123,7 +123,7 @@
 						if (eval.Label == "")
 							continue;
 						
-						if ((newVal & (uint)(int) eval.Value) != 0) {
+						if ((newVal & (uint)Convert.ToInt32(eval.Value)) != 0) {
 							if (txt.Length > 0) txt += ", ";
 							txt += eval.Label;
 						}
