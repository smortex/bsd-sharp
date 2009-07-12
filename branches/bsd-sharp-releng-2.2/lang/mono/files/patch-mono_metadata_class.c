
$FreeBSD$

--- mono/metadata/class.c.orig
+++ mono/metadata/class.c
@@ -7522,7 +7522,10 @@
 gboolean
 mono_class_generic_sharing_enabled (MonoClass *class)
 {
-#if defined(__i386__) || defined(__x86_64__) || defined(__arm__) || defined(__ppc__) || defined(__powerpc__)
+#if defined(__FreeBSD__) && defined(__x86_64__)
+	/* https://bugzilla.novell.com/show_bug.cgi?id=434457 */
+	static gboolean supported = FALSE;
+#elif defined(__i386__) || defined(__x86_64__) || defined(__arm__) || defined(__ppc__) || defined(__powerpc__)
 	static gboolean supported = TRUE;
 #else
 	/* Not supported by the JIT backends */