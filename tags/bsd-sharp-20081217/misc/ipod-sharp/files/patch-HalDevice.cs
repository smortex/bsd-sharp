--- src/Hal/HalDevice.cs.orig	2008-08-17 18:04:13.000000000 -0400
+++ src/Hal/HalDevice.cs	2008-08-17 18:05:21.000000000 -0400
@@ -187,7 +187,8 @@
                 int size;
                 PixelFormat pformat;
 
-                correlationId = width = height = rotation = size = 0;
+                correlationId = width = height = rotation = 0;
+		size = 0;
                 usage = ArtworkUsage.Unknown;
                 pformat = PixelFormat.Unknown;
 
