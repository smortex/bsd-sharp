--- /dev/null	Thu Mar  3 01:33:00 2005
+++ glue/kqueue-glue.c	Thu Mar  3 01:36:01 2005
@@ -0,0 +1,110 @@
+/*
+ * kqueue-glue.c
+ *
+ * Copyright (C) 2004 Joe Marcus Clarke <marcus@freebsd.org>
+ * (Copyright info added by Tom McLaughlin <tmclaugh@sdf.lonestar.org>)
+ *
+ */
+
+/*
+ * Permission is hereby granted, free of charge, to any person obtaining a
+ * copy of this software and associated documentation files (the "Software"),
+ * to deal in the Software without restriction, including without limitation
+ * the rights to use, copy, modify, merge, publish, distribute, sublicense,
+ * and/or sell copies of the Software, and to permit persons to whom the
+ * Software is furnished to do so, subject to the following conditions:
+ *
+ * The above copyright notice and this permission notice shall be included in
+ * all copies or substantial portions of the Software.
+ *
+ * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
+ * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
+ * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
+ * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
+ * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
+ * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
+ * DEALINGS IN THE SOFTWARE.
+ */
+
+#include <stdio.h>
+#include <stdlib.h>
+#include <string.h>
+#include <fcntl.h>
+#include <errno.h>
+#include <unistd.h>
+#include <sys/types.h>
+#include <sys/event.h>
+#include <sys/time.h>
+
+static int kq;
+static int max_queued_events = 256;
+
+void
+kqueue_glue_init (void)
+{
+	static int initialized = 0;
+	if (initialized)
+		return;
+	initialized = 1;
+
+	kq = kqueue();
+}
+
+int
+kqueue_glue_watch (const char *filename, u_int32_t mask)
+{
+	struct kevent ev;
+	struct timespec nullts = { 0, 0 };
+	int fd;
+
+	fd = open (filename, O_RDONLY);
+	if (fd < 0) {
+		fprintf (stderr, "open(%s, O_RDONLY) failed", filename);
+		perror ("open");
+	}
+
+	EV_SET (&ev, fd, EVFILT_VNODE,
+		EV_ADD | EV_ENABLE | EV_CLEAR,
+		mask, 0, 0);
+	kevent (kq, &ev, 1, NULL, 0, &nullts);
+
+	return fd;
+}
+
+int
+kqueue_glue_ignore (int fd)
+{
+	int ret;
+
+	/* close() will automatically delete the kevent */
+	ret = close (fd);
+
+	return ret;
+}
+
+void
+kqueue_snarf_events (int fd, int timeout_secs, int *num_read_out, void **buffer_out)
+{
+	struct timespec timeout;
+	int n;
+	static struct kevent *ev = NULL;
+	static size_t buffer_size;
+
+	timeout.tv_sec = timeout_secs;
+	timeout.tv_nsec = 0;
+
+	if (ev == NULL) {
+		buffer_size = sizeof (struct kevent) * max_queued_events;
+		ev = malloc (buffer_size);
+		if (!ev) {
+			perror ("malloc");
+		}
+	}
+
+	if ((n = kevent (kq, NULL, 0, ev, max_queued_events, &timeout)) == -1) {
+		return;
+	}
+
+	*num_read_out = n;
+	*buffer_out = ev;
+}
