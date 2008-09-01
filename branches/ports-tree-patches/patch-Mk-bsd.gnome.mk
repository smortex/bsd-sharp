--- Mk/bsd.gnome.mk.orig	2008-08-07 12:45:03.000000000 +0200
+++ Mk/bsd.gnome.mk	2008-08-07 12:45:11.014679000 +0200
@@ -58,15 +58,15 @@
 
 # GNOME 2 components
 _USE_GNOME_ALL+= atk atspi desktopfileutils eel2 evolutiondataserver gail \
-		gal2 gconf2 _glib20 glib20 gnomecontrolcenter2 gnomedesktop gnomedocutils \
-		gnomemenus gnomepanel gnomesharp20 gnomespeech gnomevfs2 gtk20 \
-		gtkhtml3 gtksharp10 gtksharp20 gtksourceview gtksourceview2 gvfs \
-		libartlgpl2 libbonobo libbonoboui libgailgnome libgda2 libgda3 \
-		libglade2 libgnome libgnomecanvas libgnomedb libgnomekbd libgnomeprint \
-		libgnomeprintui libgnomeui libgsf libgsf_gnome libgtkhtml libidl \
-		librsvg2 libwnck libxml2 libxslt libzvt linc metacity nautilus2 \
-		nautiluscdburner orbit2 pango pygnome2 pygnomedesktop pygnomeextras \
-		pygtk2 pygtksourceview vte
+		gal2 gconf2 _glib20 glib20 gnomecontrolcenter2 gnomedesktop \
+		gnomedesktopsharp20 gnomedocutils gnomemenus gnomepanel gnomesharp20 \
+		gnomespeech gnomevfs2 gtk20 gtkhtml3 gtksharp10 gtksharp20 \
+		gtksourceview gtksourceview2 gvfs libartlgpl2 libbonobo libbonoboui \
+		libgailgnome libgda2 libgda3 libglade2 libgnome libgnomecanvas \
+		libgnomedb libgnomekbd libgnomeprint libgnomeprintui libgnomeui libgsf \
+		libgsf_gnome libgtkhtml libidl librsvg2 libwnck libxml2 libxslt libzvt \
+		linc metacity nautilus2 nautiluscdburner orbit2 pango pygnome2 \
+		pygnomedesktop pygnomeextras pygtk2 pygtksourceview vte
 
 GNOME_MAKEFILEIN?=	Makefile.in
 SCROLLKEEPER_DIR=	/var/db/rarian
@@ -358,6 +358,11 @@
 gnomedesktop_USE_GNOME_IMPL=	libgnomeui gnomedocutils
 gnomedesktop_GNOME_DESKTOP_VERSION=2
 
+gnomedesktopsharp20_DETECT=		${LOCALBASE}/libdata/pkgconfig/gnome-desktop-sharp-2.0.pc
+gnomedesktopsharp20_BUILD_DEPENDS=	${gnomedesktopsharp20_DETECT}:${PORTSDIR}/x11-toolkits/gnome-desktop-sharp20
+gnomedesktopsharp20_RUN_DEPENDS=	${gnomedesktopsharp20_DETECT}:${PORTSDIR}/x11-toolkits/gnome-desktop-sharp20
+gnomedesktopsharp20_USE_GNOME_IMPL=	gnomesharp20
+
 libwnck_LIB_DEPENDS=	wnck-1.22:${PORTSDIR}/x11-toolkits/libwnck
 libwnck_DETECT=		${LOCALBASE}/libdata/pkgconfig/libwnck-1.0.pc
 libwnck_USE_GNOME_IMPL=	gtk20
