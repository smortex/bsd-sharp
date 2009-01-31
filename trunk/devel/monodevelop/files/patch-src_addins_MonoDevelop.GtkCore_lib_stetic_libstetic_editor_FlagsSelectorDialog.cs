
$FreeBSD$

--- src/addins/MonoDevelop.GtkCore/lib/stetic/libstetic/editor/FlagsSelectorDialog.cs.orig
+++ src/addins/MonoDevelop.GtkCore/lib/stetic/libstetic/editor/FlagsSelectorDialog.cs
@@ -39,7 +39,7 @@
 				EnumValue eval = enumDesc[value];
 				if (eval.Label == "")
 					continue;
-				uint val = (uint) (int) eval.Value;
+				uint val = (uint) Convert.ToInt32(eval.Value);
 				store.AppendValues (((flags & val) != 0), eval.Label, val);
 			}
 		}
