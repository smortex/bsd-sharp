PREFIX=/usr/local

install:
	install -o root -g wheel -m 555 mono-merge.sh ${PREFIX}/bin/mono-merge
	install -o root -g wheel -m 444 mono-merge.8 ${PREFIX}/man/man8
	install -o root -g wheel -m 444 mono-merge.cfg ${PREFIX}/etc

package:
	cd .. && tar zcvf mono-merge.tar.gz --exclude CVS mono-merge
