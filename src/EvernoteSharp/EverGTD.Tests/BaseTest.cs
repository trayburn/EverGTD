using System;
using NUnit.Framework;

namespace EverGTD.Tests
{
	[TestFixture]
	public abstract class BaseTest
	{
		public virtual void BeforeEachTest() {}
		public virtual void AfterEachTest() {}
		public virtual void BeforeAllTests() {}
		public virtual void AfterAllTests() {}
		
		[SetUp]
		public void Setup()
		{
			BeforeEachTest();
		}
		
		[TearDown]
		public void Teardown()
		{
			AfterEachTest();
		}
		
		[TestFixtureSetUp]
		public void FixtureSetup()
		{
			BeforeAllTests();
		}
		
		[TestFixtureTearDown]
		public void FixtureTeardown()
		{
			AfterAllTests();
		}
	}
}

