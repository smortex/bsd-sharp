--- src/TaskTreeView.cs.orig	2008-08-06 12:15:57.000000000 -0400
+++ src/TaskTreeView.cs	2008-10-02 08:40:23.000000000 -0400
@@ -147,6 +147,22 @@
 			
 			AppendColumn (column);
 			
+
+			//
+			// Category Name Column
+			//
+			column = new Gtk.TreeViewColumn ();
+			// Title for Task Name Column
+			column.Title = Catalog.GetString ("Category Name");
+			column.Sizing = Gtk.TreeViewColumnSizing.Fixed;
+			column.FixedWidth = 80;
+			renderer = new Gtk.CellRendererText ();
+			column.PackStart (renderer, true);
+			column.SetCellDataFunc (renderer,
+				new Gtk.TreeCellDataFunc (CategoryNameTextCellDataFunc));
+			AppendColumn (column);
+
+
 			
 			//
 			// Due Date Column
@@ -395,6 +411,25 @@
 			crt.Markup = string.Format (formatString,
 				GLib.Markup.EscapeText (task.Name));
 		}
+
+
+		private void CategoryNameTextCellDataFunc (Gtk.TreeViewColumn treeColumn,
+				Gtk.CellRenderer renderer, Gtk.TreeModel model,
+				Gtk.TreeIter iter)
+		{
+			Gtk.CellRendererText crt = renderer as Gtk.CellRendererText;
+			crt.Ellipsize = Pango.EllipsizeMode.End;
+			ITask task = model.GetValue (iter, 0) as ITask;
+			if (task == null) {
+				crt.Text = string.Empty;
+				return;
+			}
+			
+			string formatString = "<span foreground=\"#AAAAAA\">{0}</span>";
+			
+			crt.Markup = string.Format (formatString,
+				GLib.Markup.EscapeText (task.Category.Name));
+		}
 		
 		protected virtual void DueDateCellDataFunc (Gtk.TreeViewColumn treeColumn,
 				Gtk.CellRenderer renderer, Gtk.TreeModel model,
