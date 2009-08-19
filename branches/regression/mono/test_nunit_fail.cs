using System;
using NUnit.Framework;

[TestFixture]
public class NunitTestClass
{
	[Test]
	public void nunit_test()
	{
		Assert.AreNotEqual(1, 1);
	}
}
