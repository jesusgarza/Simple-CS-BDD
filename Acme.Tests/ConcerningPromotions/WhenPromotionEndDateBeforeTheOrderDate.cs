﻿using System;
using Acme.Discounts;
using NUnit.Framework;

namespace Acme.Tests.ConcerningPromotions
{
	[TestFixture]
	public class When_promotion_end_date_before_the_order_date
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			Product product = new Product(10);
			Promotion promotion = CreatePromotion.WithDiscountOf(.1m).Starting(DateTime.Now.AddDays(-4)).Ending(DateTime.Now.AddDays(-1));
			_order = CreateOrder.Of(product).On(DateTime.Now).Apply(promotion).In(StateOf.UT);
		}

		[Test] public void Should_not_apply_discount()
		{
			_order.Total.ShouldEqual(10m);
		}
	}
}