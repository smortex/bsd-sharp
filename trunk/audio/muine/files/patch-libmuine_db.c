
$FreeBSD$

--- libmuine/db.c.orig
+++ libmuine/db.c
@@ -58,7 +58,7 @@
 	}
 
 	if (db == NULL) {
-		*error_message_return = gdbm_strerror (gdbm_errno);
+		*error_message_return = (char *)gdbm_strerror (gdbm_errno);
 	} else {
 		*error_message_return = NULL;
 	}
