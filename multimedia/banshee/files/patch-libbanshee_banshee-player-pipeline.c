
$FreeBSD$

--- libbanshee/banshee-player-pipeline.c.orig
+++ libbanshee/banshee-player-pipeline.c
@@ -241,6 +241,7 @@
 #ifdef ENABLE_GAPLESS
 static void bp_about_to_finish_callback (GstElement *playbin, BansheePlayer *player)
 {
+    return;
     g_return_if_fail (IS_BANSHEE_PLAYER (player));
     g_return_if_fail (GST_IS_ELEMENT (playbin));
 
@@ -260,6 +261,7 @@
 
 static void bp_volume_changed_callback (GstElement *playbin, GParamSpec *spec, BansheePlayer *player)
 {
+    return;
     gdouble volume;
 
     g_return_if_fail (IS_BANSHEE_PLAYER (player));
