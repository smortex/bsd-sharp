
$FreeBSD: ports/lang/mono/files/patch-mono_tests_libtest.c,v 1.1 2009/02/09 08:59:57 flz Exp $

--- mono/tests/libtest.c.orig
+++ mono/tests/libtest.c
@@ -2943,7 +2943,7 @@
  * mono_method_get_unmanaged_thunk tests
  */
 
-#if defined(__GNUC__) && defined(__i386__) && (defined(__linux__) || defined (__APPLE__))
+#if defined(__GNUC__) && defined(__i386__) && (defined(__linux__) || defined (__APPLE__) || defined (__FreeBSD__))
 #define ALIGN(size) __attribute__ ((aligned(size)))
 #else
 #define ALIGN(size)
