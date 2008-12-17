--- glue/thread-glue.c.orig	Mon Jun 19 13:54:26 2006
+++ glue/thread-glue.c	Thu Sep 14 23:14:37 2006
@@ -1,6 +1,8 @@
 #include <sys/types.h>
 #include <unistd.h>
+#if defined(__linux__)
 #include <linux/unistd.h>
+#endif
 #include <errno.h>
 
 #ifdef __NR_gettid
