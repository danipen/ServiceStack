﻿using System;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using ServiceStack.Redis.Generic;

namespace ServiceStack.Redis.Tests.Generic
{
	[TestFixture]
	public class RedisClientTests
	{
		[Test]
		public void Can_Set_and_Get_string()
		{
			const string value = "value";
			using (var redis = new RedisGenericClient<string>())
			{
				redis.Set("key", value);
				var valueString = redis.Get("key");

				Assert.That(valueString, Is.EqualTo(value));
			}
		}
	}
}