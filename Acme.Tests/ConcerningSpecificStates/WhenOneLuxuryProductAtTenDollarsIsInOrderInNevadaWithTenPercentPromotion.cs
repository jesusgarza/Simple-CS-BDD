﻿using NUnit.Framework;

namespace Acme.Tests.ConcerningSpecificStates
{
	[TestFixture]
    public class When_one_luxury_product_at_ten_dollars_is_in_order_in_Nevada_with_ten_percent_promotion
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			_order = CreateOrder.Of(new Product(10) { IsLuxuryItem = true }).Apply(CreatePromotion.WithDiscountOf(.1m)).In(StateOf.NV);
		}

		[Test] public void Should_total_to_nine_seventy()
		{
			_order.Total.ShouldEqual(9.7m);
		}

		[Test] public void Should_pretax_total_to_nine_dollars()
		{
			_order.PreTaxTotal.ShouldEqual(9m);
		}

		[Test] public void Should_have_taxes_of_seventy_cents()
		{
			_order.Tax.ShouldEqual(.7m);
		}
	}
}