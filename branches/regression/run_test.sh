
_stdout=""
_stderr=""

_test_name=""

# _test_status determines if System() and Assert.*() are to be run or skipped
# and if the standard output and error have to be tracked.
#
#    Value | Meaning                   | Run | Log
#   -------+---------------------------+-----+-----
#        0 | Outside of any Test       | Yes | No
#        1 | In Test, status is OK     | Yes | Yes
#        2 | In Test, status is not OK | No  | n/a
_test_status=0

#----------#
# Counters #
#----------#

_total_test_count=0
_total_success_count=0
_total_failure_count=0

_test_test_count=0
_test_success_count=0
_test_failure_count=0

#-------------------#
# Special variables #
#-------------------#

# Return value of the last System() call.
_ret=0

# -------------------#
# Internal functions #
# -------------------#

# _clean_last_system_call()
#	Remove leftovers of the last System() call.
#	<no arguments>
_clean_last_system_call()
{
	if [ -f "${_stdout}" ]; then
		rm -f "${_stdout}"
	fi
	if [ -f "${_stderr}" ]; then
		rm -f "${_stderr}"
	fi
}

# _success()
#	Provide feedback for a successful assertion.
#	<no arguments>
_success()
{
	printf "."
	_test_success_count=$(($_test_success_count+1))
}

# _fail()
#	Provide feedback for a failed assertion.
#	$1 -- System error message
#	$2 -- User error message (optional)
_fail()
{
	printf "X\n   \033[31;1m* ${_test_name} failed.\033[0m\n$1"
	if [ -n "$2" ]; then
		printf "\n     Message:	$2"
	fi
	printf "\n   "
	_test_failure_count=$(($_test_failure_count+1))
	_test_status=2
}

#--------------------#
# Fixture Management #
#--------------------#

# Fixture.SetUp()
#	Setup the environment for running Tests. Display which Fixture is being
#	loaded.
#	<no arguments>
Fixture.SetUp()
{
	printf " \033[33;1m*\033[0;1m %s\033[0m\n   " "$0"
}

# Fixture.TearDown()
#	TearDown the environment after running Tests. Display statistics about
#	the regression tests and exit.
#	<no arguments>
Fixture.TearDown()
{
	printf "\n"
	printf " \033[33;1m*\033[0m \033[1mTests run: %d; success: %d; failures: %d.\033[0m\n\n" ${_total_test_count} ${_total_success_count} ${_total_failure_count}
	exit ${_total_failure_count}
}

#-----------------#
# Test management #
#-----------------#

# Test.SetUp()
#	Prepare for running tests.
#	$1 -- Regression Test name
Test.SetUp()
{
	_test_test_count=0
	_test_success_count=0
	_test_failure_count=0
	_test_name="$1"
	_test_status=1

	set -e
}

# Test.TearDown()
#	Collect statistics about the regression tests that habe just been run
#	and prepare for another Test.
#	<no arguments>
Test.TearDown()
{
	#printf "\n"
	#printf "   \033[33;1m*\033[0m \033[1mTests run: %d; success: %d; failures: %d.\033[0m\n\n" ${_test_test_count} ${_test_success_count} ${_test_failure_count}
	_total_success_count=$(($_total_success_count+$_test_success_count))
	_total_failure_count=$(($_total_failure_count+$_test_failure_count))
	_total_test_count=$(($_total_test_count+$_test_test_count))
	if [ ${_test_status} -lt 2 ]; then
		_clean_last_system_call
	fi
	_test_status=0
	set +e
}

#----------#
# Wrappers #
#----------#

# System()
#	Run a command which is allowed to fail and save it's exit code to
#	${_ret}.
#	$@ -- Command to run
System()
{
	if [ ${_test_status} -gt 1 ]; then
		return
	fi
	_clean_last_system_call
	_stdout="${_test_name}_$1.stdout"
	_stderr="${_test_name}_$1.stderr"
	if [ ${_test_status} -eq 1 ]; then
		set +e
		$@ > "${_stdout}" 2> "${_stderr}"
		_ret=$?
		set -e
	else
		$@ > /dev/null 2>&1
		_ret=$?
	fi
}


#----------------------#
# Unit test assertions #
#----------------------#

# Assert.AreEqual()
#	Assert two values are equal.
#	$1 -- Expected value
#	$2 -- Actual value
#	$3 -- User error message on failure (optional)
Assert.AreEqual()
{
	if [ ${_test_status} -ne 1 ]; then
		return
	fi
	_test_test_count=$(($_test_test_count+1))
	if [ "$1" = "$2" ]; then
		_success
	else
		_fail "     Expected:	$1\n     But was:	$2" "$3"
	fi
}

# Assert.AreNotEqual()
#	Assert two values are not equal.
#	$1 -- Unexpected value
#	$2 -- Actual value
#	$3 -- User error message on failure (optional)
Assert.AreNotEqual()
{
	if [ ${_test_status} -ne 1 ]; then
		return
	fi
	_test_test_count=$(($_test_test_count+1))
	if [ "$1" != "$2" ]; then
		_success
	else
		_fail  "     Expected:	not $1\n     But was:	$2" "$3"
	fi
}

