
$FreeBSD$

--- src/PlaylistWindow.cs.orig
+++ src/PlaylistWindow.cs
@@ -176,7 +176,7 @@
 		[Glade.Widget] private Button       add_song_button   ;
 		[Glade.Widget] private Button       add_album_button  ;		
 
-		private VolumeButton volume_button;
+		private Bacon.VolumeButton volume_button;
 
 		// Widgets :: Player
 		[Glade.Widget] private Label song_label;
@@ -869,7 +869,7 @@
 			add_album_button  .Clicked += OnAddAlbumButtonClicked;
 
 			// Volume
-			volume_button = new VolumeButton ();
+			volume_button = new Bacon.VolumeButton ();
 			volume_button_container.Add (volume_button);
 			volume_button.Visible = true;
 			volume_button.VolumeChanged += OnVolumeChanged;
