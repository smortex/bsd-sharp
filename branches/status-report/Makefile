# $Id$

STATUS_REPORT=	status-report.xml

SEND_TO=	monthly@FreeBSD.org
SEND_CC=	bsd-sharp@googlegroups.com
SEND_SUBJECT=	[status-report] BSD\#

lint:
	@xmllint --noout ${STATUS_REPORT} && echo "${STATUS_REPORT} looks fine..."

send: lint
	@printf "Please find attached the BSD# status-report.\n\nWith kind regards\nThe BSD# Team" | mutt -a "${STATUS_REPORT}" -c "${SEND_CC}" -s "${SEND_SUBJECT}" ${SEND_TO}
	@echo "Mail sent."
