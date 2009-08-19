#!/bin/sh

#
# Regression tests for ${module}
#
# Submitted by ${name} <${email}>
#
# $Id$
#

#
# ${description}
#

address="127.0.0.1"
port="4242"

. $(dirname $0)/../run_test.sh

Fixture.SetUp

	Test.SetUp "TestName"

		downloaded=`mktemp -t fetch`

		(
			cd test_bin_directory/Bin && gmcs -target:library library.cs
		)

		cd test_bin_directory
		xsp --address "${address}" --port "${port}" --nonstop > /dev/null 2>&1 &
		cd ..
		xsp_pid=$!

		Assert.AreNotEqual 0 ${xsp_pid} "Can't get xsp PID."

		sleep 3

		System ps ${xsp_pid}
		Assert.AreEqual 0 ${_ret} "xsp (${xsp_pid}) is not running"

		System fetch -o${downloaded} "http://${address}:${port}"
		Assert.AreEqual 0 ${_ret} "Fetch failed"

		System cmp -s "${downloaded}" test_bin_directory/default.aspx
		Assert.AreEqual 0 ${_ret} "Downloaded file different"


	Test.TearDown
	System rm -f test_bin_directory/Bin/library.dll ${downloaded}
		kill ${xsp_pid} > /dev/null 2>&1
		wait > /dev/null 2>&1

Fixture.TearDown
