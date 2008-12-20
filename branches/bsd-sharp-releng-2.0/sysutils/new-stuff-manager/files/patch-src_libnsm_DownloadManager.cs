--- src/libnsm/DownloadManager.cs.orig	Sun Aug 19 15:01:40 2007
+++ src/libnsm/DownloadManager.cs	Sun Aug 19 15:01:47 2007
@@ -31,7 +31,7 @@
 		
 		public delegate void DownloaderDel(object startPoint);
 		
-	    protected Dictionary<int, Download> Downloads;
+	    Dictionary<int, Download> Downloads;
 	    
 	    private int downloadsIndex;
 	    
