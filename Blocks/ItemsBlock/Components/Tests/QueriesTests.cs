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
using System.Linq.Expressions;
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

			var query = new TestListAllItemsQuery();

			// Act
			var result = mockDataSet.Where(query.filter.Compile()).ToList();

			// Assert

			Assert.AreEqual(mockDataSet.Count(), result.Count());

			foreach (var item in mockDataSet)
			{
				Assert.True(result.SingleOrDefault(t => t == item) != null);
			}

		}

		[Test]
		public void ListItemsFromCategoryQuery_Should_RetrieveOnlyCategorySearched()
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

			var query = new TestListItemsFromCategoryQuery("Clothes");

			// Act
			var result = mockDataSet.Where(query.filter.Compile()).ToList();

			// Assert
			Assert.AreEqual(1, result.Count());
			Assert.AreEqual(result.Single(), mockDataSet.First());
		}
	}

	internal class TestListItemsFromCategoryQuery : ListItemsFromCategoryQuery
	{
		public Expression<Func<ItemModel, bool>> filter { get; }
		
		public TestListItemsFromCategoryQuery(string category) : base(category)
		{
			filter = _filter;
		}
	}

	internal class TestListAllItemsQuery : ListAllItemsQuery
	{
		public Expression<Func<ItemModel, bool>> filter { get; }

		public TestListAllItemsQuery()
		{
			filter = _filter;
		}
	}
}
