# $Id$

STATUS_REPORT=	status-report.xml

SEND_TO=	monthly@FreeBSD.org
SEND_CC=	mono@FreeBSD.org
SEND_SUBJECT=	[status-report] BSD\# Project

lint:
	@xmllint --noout ${STATUS_REPORT} && echo "${STATUS_REPORT} looks fine..."

send: lint
	@printf "Please find attached the BSD# status-report.\n\nWith kind regards\nThe BSD# Team" | mutt -c "${SEND_CC}" -s "${SEND_SUBJECT}" -a "${STATUS_REPORT}" -- ${SEND_TO}
	@echo "Mail sent."
