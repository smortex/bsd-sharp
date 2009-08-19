#!/bin/sh

#
# Regression tests for mono
#
# Submitted by Romain Tartière <romain@blogreen.org>
#
# $Id$
#

#
# Ensure NUnit bundled with Mono can run regression tests
#

. $(dirname $0)/../run_test.sh

Fixture.SetUp

	Test.SetUp "PassingNUnitTest"
		System mcs -target:library -r:nunit.framework test_nunit_pass.cs
		Assert.AreEqual 0 ${_ret} "Error compiling test_nunit_pass.dll"
		System nunit-console test_nunit_pass.dll
		Assert.AreEqual 0 ${_ret} "Error running NUnit console on test_nunit_pass.dll"
	Test.TearDown
		System rm -f test_nunit_pass.dll TestResult.xml

	Test.SetUp "FailingNUnitTest"
		System mcs -target:library -r:nunit.framework test_nunit_fail.cs
		Assert.AreEqual 0 ${_ret} "Error compiling test_nunit_fail.dll"
		System nunit-console test_nunit_fail.dll
		Assert.AreEqual 1 ${_ret} "Error running NUnit console on test_nunit_fail.dll"
	Test.TearDown
		System rm -f test_nunit_fail.dll TestResult.xml

Fixture.TearDown
