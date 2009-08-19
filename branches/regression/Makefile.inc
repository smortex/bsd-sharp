
test:
	@for _test in test_*.sh; do sh "$${_test}" || exit 1; done
