
$FreeBSD$

--- src/GUI/StatsDialog.cs.orig
+++ src/GUI/StatsDialog.cs
@@ -94,8 +94,9 @@
 				i = 0;
 				foreach (dtype type in list) {
 					if (type.name == ent.data.Title) {
-						type.count++;
-						list [i] = type;
+						dtype t = type;
+						t.count++;
+						list [i] = t;
 						all++;
 						goto ok;
 					}
