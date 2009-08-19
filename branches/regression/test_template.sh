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

. $(dirname $0)/../run_test.sh

Fixture.SetUp

	Test.SetUp "TestName"
		System true
		Assert.AreEqual 0 ${_ret} "true does not return a correct value"
		System false
		Assert.AreEqual 1 ${_ret} "false does not return a correct value"
	Test.TearDown
		System echo "Cleanup"

Fixture.TearDown
