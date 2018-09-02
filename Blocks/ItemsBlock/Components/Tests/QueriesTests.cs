// QueriesTests.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using System.Collections.Generic;
using System.Linq;
using Dharma.ItemsBlock.Components.Queries;
using Dharma.ItemsBlock.Models;
using NUnit.Framework;


namespace Dharma.ItemsBlock.Components.Tests
{
	[TestFixture(Category = "Unit Test")]
	public class QueriesTests
	{
		[Test]
		public void ListAllItemsQuery_Should_ReturnAllItemsFromList()
		{
			// Arrange
			var mockDataSet = new List<ItemModel>()
			{
				new ItemModel("Item 1", ItemType.Amount, 0
											, new List<string>(){"Shirt", "For men", "Clothes"}, true),
				new ItemModel("Something", ItemType.Hour, 9
											, new List<string>(){"General Services", "Electrical"}, true),
				new ItemModel("Random item", ItemType.Service, 2
											, new List<string>(){"Elderly", "Children"}, true),
			};

			var query = new ListAllItemsQuery();

			// Act
			var result = query.Run();

			// Assert

			Assert.AreEqual(mockDataSet.Count(), result.Count());

			foreach (var item in mockDataSet)
			{
				Assert.True(result.SingleOrDefault(t => t == item) != null);
			}

		}
	}
}
