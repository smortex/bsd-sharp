# BSD# #

The BSD# Project is devoted to porting and maintaining the Mono .NET framework
and applications for FreeBSD.

The repository currently contains FreeBSD ports for the framework, libraries
and third parties applications released, that are not in the main FreeBSD ports
tree, with the intent that they will be intergrated ones they are ready.

The project aims to act as a central testing point for porting new releases for
introducing new applications, and for testing framework wide changes that will
affect all applications that rely on Mono before they reach the FreeBSD ports
tree.

## How to use

The BSD# team use `ports-mgmt/portshaker`.  The following configuration may
help you to configure the system according to your needs:

~~~sh
ports_trees="main p_mono"

use_zfs="yes"
poudriere_dataset="zroot/poudriere"
poudriere_ports_mountpoint="/usr/local/poudriere/ports"

main_ports_tree="/usr/ports"
main_merge_from="ports github:smortex:bsd-sharp!"

p_mono_poudriere_tree="mono"
p_mono_merge_from="ports github:smortex:bsd-sharp!"
~~~
