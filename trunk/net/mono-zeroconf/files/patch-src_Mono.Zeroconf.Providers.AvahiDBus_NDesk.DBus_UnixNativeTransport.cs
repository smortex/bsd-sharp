
$FreeBSD$

--- src/Mono.Zeroconf.Providers.AvahiDBus/NDesk.DBus/UnixNativeTransport.cs.orig
+++ src/Mono.Zeroconf.Providers.AvahiDBus/NDesk.DBus/UnixNativeTransport.cs
@@ -192,9 +192,13 @@
 			byte[] sa = new byte[2 + 1 + p.Length];
 
 			//we use BitConverter to stay endian-safe
+#if false
 			byte[] afData = BitConverter.GetBytes (UnixSocket.AF_UNIX);
 			sa[0] = afData[0];
 			sa[1] = afData[1];
+#endif
+			sa[0] = (byte) sa.Length;
+			sa[1] = 1;
 
 			sa[2] = 0; //null prefix for abstract domain socket addresses, see unix(7)
 			for (int i = 0 ; i != p.Length ; i++)
@@ -212,10 +216,14 @@
 
 			byte[] sa = new byte[2 + p.Length + 1];
 
+#if false
 			//we use BitConverter to stay endian-safe
 			byte[] afData = BitConverter.GetBytes (UnixSocket.AF_UNIX);
 			sa[0] = afData[0];
 			sa[1] = afData[1];
+#endif
+			sa[0] = (byte) sa.Length;
+			sa[1] = 1;
 
 			for (int i = 0 ; i != p.Length ; i++)
 				sa[2 + i] = p[i];
