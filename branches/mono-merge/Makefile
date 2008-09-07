PREFIX=/usr/local

install:
	install -o root -g wheel -m 555 mono-merge.sh ${PREFIX}/bin/mono-merge
	install -o root -g wheel -m 444 mono-merge.8 ${PREFIX}/man/man8
	install -o root -g wheel -m 444 mono-merge.cfg.sample ${PREFIX}/etc
	if [ ! -f ${PREFIX}/etc/mono-merge.cfg ] || cmp ${PREFIX}/etc/mono-merge.cfg.sample ${PREFIX}/etc/mono-merge.cfg; then install -o root -g wheel -m 644 mono-merge.cfg.sample ${PREFIX}/etc/mono-merge.cfg; fi

deinstall:
	if [ -f ${PREFIX}/bin/mono-merge ]; then rm ${PREFIX}/bin/mono-merge; fi
	if [ -f ${PREFIX}/man/man8 ]; then rm ${PREFIX}/man/man8/mono-merge.8; fi
	if [ -f ${PREFIX}/etc/mono-merge.cfg -a -f ${PREFIX}/etc/mono-merge.cfg.sample ] && cmp ${PREFIX}/etc/mono-merge.cfg.sample ${PREFIX}/etc/mono-merge.cfg; then rm ${PREFIX}/etc/mono-merge.cfg; fi
	if [ -f ${PREFIX}/etc/mono-merge.cfg.sample ]; then rm ${PREFIX}/etc/mono-merge.cfg.sample; fi

package:
	cd .. && tar zcvf mono-merge.tar.gz --exclude CVS mono-merge
