
$FreeBSD$

--- src/PdfMod/Gui/Client.cs.orig
+++ src/PdfMod/Gui/Client.cs
@@ -415,7 +415,7 @@
         static void OnLogNotify (LogNotifyArgs args)
         {
             ThreadAssist.ProxyToMain (delegate {
-                Gtk.MessageType mtype;
+                Gtk.MessageType mtype = Gtk.MessageType.Info;
                 var entry = args.Entry;
 
                 switch (entry.Type) {
