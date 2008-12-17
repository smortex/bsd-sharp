--- src/addins/MonoDevelop.SourceEditor/MonoDevelop.SourceEditor.Gui/SourceEditorWidget.cs.orig	2008-03-10 23:20:10.000000000 -0300
+++ src/addins/MonoDevelop.SourceEditor/MonoDevelop.SourceEditor.Gui/SourceEditorWidget.cs	2008-11-01 23:48:56.000000000 -0300
@@ -23,8 +23,6 @@
 		public SourceEditorBuffer Buffer;
 		public SourceEditorView View;
 		public SourceEditorDisplayBindingWrapper DisplayBinding;
-		protected Gnome.PrintJob printJob;
-		protected PrintDialog printDialog;
 		Dictionary<string,Gdk.Pixbuf> markers = new Dictionary<string,Gdk.Pixbuf> ();
 		
 		static Gdk.Pixbuf dragIconPixbuf;
@@ -199,84 +197,6 @@
 			return str.Substring (0, leftOffset) + delimiter + str.Substring (rightOffset);
 		}
 		
-		protected void CreatePrintJob ()
-		{
-			if (printDialog == null  || printJob == null)
-			{
-				PrintConfig config = PrintConfig.Default ();
-				SourcePrintJob sourcePrintJob = new SourcePrintJob (config, Buffer);
-				sourcePrintJob.upFromView = View;
-				sourcePrintJob.PrintHeader = true;
-				sourcePrintJob.PrintFooter = true;
-				sourcePrintJob.SetHeaderFormat (GettextCatalog.GetString ("File:") +  " " +
-										  StrMiddleTruncate (IdeApp.Workbench.ActiveDocument.FileName, 60), null, null, true);
-				sourcePrintJob.SetFooterFormat (GettextCatalog.GetString ("MonoDevelop"), null, GettextCatalog.GetString ("Page") + " %N/%Q", true);
-				sourcePrintJob.WrapMode = WrapMode.Word;
-				printJob = sourcePrintJob.Print ();
-			}
-		}
-		
-		[CommandHandler (EditorCommands.PrintDocument)]
-		public void PrintDocument ()
-		{
-			if (printDialog == null)
-			{
-				CreatePrintJob ();
-				printDialog = new PrintDialog (printJob, GettextCatalog.GetString ("Print Source Code"));
-				printDialog.SkipTaskbarHint = true;
-				printDialog.Modal = true;
-//				printDialog.IconName = "gtk-print";
-				printDialog.SetPosition (WindowPosition.CenterOnParent);
-				printDialog.Gravity = Gdk.Gravity.Center;
-				printDialog.TypeHint = Gdk.WindowTypeHint.Dialog;
-				printDialog.TransientFor = IdeApp.Workbench.RootWindow;
-				printDialog.KeepAbove = false;
-				printDialog.Response += new ResponseHandler (OnPrintDialogResponsed);
-				printDialog.Close += new EventHandler (OnPrintDialogClosing);
-				printDialog.Run ();
-			}
-		}
-		
-		protected void OnPrintDialogClosing (object o, EventArgs args)
-		{
-			printDialog = null;
-		}
-		
-		protected void OnPrintDialogResponsed (object o, ResponseArgs args)
-		{			
-			switch ((int)args.ResponseId)
-			{
-				case (int)PrintButtons.Print:
-					int result = printJob.Print ();
-					if (result != 0)
-						IdeApp.Services.MessageService.ShowError (GettextCatalog.GetString ("Print operation failed."));
-					goto default;
-				case (int)PrintButtons.Preview:
-					PrintPreviewDocument ();
-					break;
-				default:
-					printDialog.HideAll ();
-					printDialog.Destroy ();
-					break;
-			}
-		}
-		
-		[CommandHandler (EditorCommands.PrintPreviewDocument)]
-		public void PrintPreviewDocument ()
-		{
-			CreatePrintJob ();
-			PrintJobPreview preview = new PrintJobPreview (printJob, GettextCatalog.GetString ("Print Preview - Source Code"));
-			preview.Modal = true;
-			preview.SetPosition (WindowPosition.CenterOnParent);
-			preview.Gravity = Gdk.Gravity.Center;
-			if (printDialog != null)
-				preview.TransientFor = printDialog;
-			else
-				preview.TransientFor = IdeApp.Workbench.RootWindow;
-//			preview.IconName = "gtk-print-preview";
-			preview.ShowAll ();
-		}
-		
 		[CommandHandler (EditorCommands.GotoMatchingBrace)]
 		public void GotoMatchingBrace ()
 		{
