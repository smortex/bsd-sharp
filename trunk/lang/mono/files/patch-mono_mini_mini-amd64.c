
$FreeBSD$

Workaround for MONO_MMAP_32BIT.  This does not exist on FreeBSD so try to set
fixed maps with addresses that fit in 32 bits.

--- mono/mini/mini-amd64.c.orig
+++ mono/mini/mini-amd64.c
@@ -12,6 +12,7 @@
  * (C) 2003 Ximian, Inc.
  */
 #include "mini.h"
+#include <err.h>
 #include <string.h>
 #include <math.h>
 #ifdef HAVE_UNISTD_H
@@ -910,10 +911,28 @@
 void
 mono_arch_init (void)
 {
+	void *ss_addr = NULL;
+	void *bp_addr = NULL;
+	int flags = MONO_MMAP_READ;
+
 	InitializeCriticalSection (&mini_arch_mutex);
+#if defined(__x86_64__)
+#if !defined(__FreeBSD__)
+	flags |= MONO_MMAP_32BIT;
+#else
+	flags = MONO_MMAP_FIXED;
+	ss_addr = (void*)(0x40000000);
+	bp_addr = (void *)((char *)ss_addr + mono_pagesize());
+#endif /* __FreeBSD__ */
+#endif /* __x86_64__ */
 
-	ss_trigger_page = mono_valloc (NULL, mono_pagesize (), MONO_MMAP_READ|MONO_MMAP_32BIT);
-	bp_trigger_page = mono_valloc (NULL, mono_pagesize (), MONO_MMAP_READ|MONO_MMAP_32BIT);
+	ss_trigger_page = mono_valloc (ss_addr, mono_pagesize (), flags);
+	bp_trigger_page = mono_valloc (bp_addr, mono_pagesize (), flags);
+
+	if ((ss_trigger_page < 0) ||
+		(bp_trigger_page < 0)) {
+	    err (1, "mmap failed");
+	}
 	mono_mprotect (bp_trigger_page, mono_pagesize (), 0);
 }
 
