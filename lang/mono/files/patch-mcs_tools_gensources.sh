
Fixed in SVN upstream.

--- mcs/tools/gensources.sh.orig	2008-04-03 11:08:16.000000000 -0400
+++ mcs/tools/gensources.sh	2008-04-03 11:08:24.000000000 -0400
@@ -1,4 +1,4 @@
-#!/usr/bin/env bash
+#!/bin/sh
 
 includefile=$1
 excludefile=$2
