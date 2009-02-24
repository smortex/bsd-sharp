
$FreeBSD$

--- mono/mini/decompose.c.orig
+++ mono/mini/decompose.c
@@ -1196,7 +1196,28 @@
 							MONO_EMIT_NEW_STORE_MEMBASE (cfg, OP_STOREI4_MEMBASE_REG, dest->dreg, 0, call2->inst.dreg);
 							break;
 						case 8:
+#if SIZEOF_VOID_P == 4
+							/*
+							FIXME It would be nice to fix the operding of OP_CALL to make it possible to use numbering voodoo
+							FIXME It would be even nicer to be able to leverage the long decompose stuff.
+							*/
+							switch (call2->inst.opcode) {
+							case OP_CALL:
+								call2->inst.opcode = OP_LCALL;
+								break;
+							case OP_CALL_REG:
+								call2->inst.opcode = OP_LCALL_REG;
+								break;
+							case OP_CALL_MEMBASE:
+								call2->inst.opcode = OP_LCALL_MEMBASE;
+								break;
+							}
+							call2->inst.dreg = alloc_lreg (cfg);
+							MONO_EMIT_NEW_STORE_MEMBASE (cfg, OP_STOREI4_MEMBASE_REG, dest->dreg, MINI_MS_WORD_OFFSET, call2->inst.dreg + 2);
+							MONO_EMIT_NEW_STORE_MEMBASE (cfg, OP_STOREI4_MEMBASE_REG, dest->dreg, MINI_LS_WORD_OFFSET, call2->inst.dreg + 1);
+#else
 							MONO_EMIT_NEW_STORE_MEMBASE (cfg, OP_STOREI8_MEMBASE_REG, dest->dreg, 0, call2->inst.dreg);
+#endif
 							break;
 						default:
 							/* This assumes the vtype is sizeof (gpointer) long */
