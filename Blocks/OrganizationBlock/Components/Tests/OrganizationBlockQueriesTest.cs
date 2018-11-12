using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dharma.OrganizationBlock.Components.Queries;
using Dharma.OrganizationBlock.Models;
using NUnit.Framework;

namespace Dharma.OrganizationBlock.Components.Tests
{
	[TestFixture]
	public class OrganizationBlockQueriesTest
	{
		[Test]
		public void ListAllOrganizations_Should_ReturnAllActiveOrganizations()
		{
			// Arrange
			var mockQuery = new ListAllOrganizationsTest();
			var model = OrganizationFactory.GetListOfValidOrganizations(5).ToList();
			model.First().Active = false;

			// Act
			var result = model.Where(mockQuery.Filter.Compile());

			// Asset
			Assert.AreEqual(4, result.Count());
			Assert.False(result.Any(t => t.Active == false));
		}

		[Test]
		public void ListAllOrganizationThatNeedsSpecificItem_Should_ReturnOnlyOrganizationsThatNeedsThatItem()
		{
			// Arrange
			var model = OrganizationFactory.GetListOfValidOrganizations(10).ToList();
			model.Single(t => t.Name == "Something 0").ItemsNeeded.Add(new ItemModel()
			{
				Name = "Food",
				Amount = 2
			});
			model.Single(t => t.Name == "Something 1").ItemsNeeded.Add(new ItemModel()
			{
				Name = "food ",
				Amount = 1
			});
			model.Single(t => t.Name == "Something 2").ItemsNeeded.Add(new ItemModel()
			{
				Name = "Food",
				Amount = 0
			});
			model.Single(t => t.Name == "Something 3").ItemsNeeded.Add(new ItemModel()
			{
				Name = " test new demand",
				Amount = 99
			});

			var mockCriteria = new[] { "food", "test new demand" };
			var mockQuery = new ListAllOrganizationsThatNeedsSpecificItemTest(mockCriteria);

			// Act
			var result = model.Where(mockQuery.Filter.Compile()).ToList();

			// Assert
			Assert.AreEqual(3, result.Count());
			Assert.False(result.Any(t => t.Name.Contains("4")));

			foreach (var item in result.Select(t => t.ItemsNeeded.Select(i => i.Name.Trim().ToLower())))
			{
				Assert.True(item.Any(t => mockCriteria.Select(c => c.ToLower().Trim()).Contains(t)));
			}
		}

		[Test]
		public void ListAllOrganizationsFromCategory_Should_ReturnOnlyOrganizationWithTheseCategories()
		{
			// Arrange
			var model = OrganizationFactory.GetListOfValidOrganizations(10);
			model.Single(t => t.Name == "Something 0").Categories.Add("To be find");
			model.Single(t => t.Name == "Something 1").Categories.Add("To not be found");
			model.Single(t => t.Name == "Something 2").Categories.Add("To be find ");
			model.Single(t => t.Name == "Something 3").Categories.Add("never find me ");
			model.Single(t => t.Name == "Something 4").Categories.Add(" To be find ");
			model.Single(t => t.Name == "Something 5").Categories.Add("any text find middle");

			const string mockCriteria = "TO BE FIND";
			var mockQuery = new ListAllOrganizationsFromCategoryTest(mockCriteria);

			// Act
			var result = model.Where(mockQuery.Filter.Compile()).ToList();

			// Assert
			Assert.AreEqual(3, result.Count());
			Assert.False(result.Any(t => t.Name == "Something 3"));
			Assert.False(result.Any(t => t.Name == "Something 5"));
			Assert.True(result.Any(t => t.Name == "Something 4"));
			Assert.True(result.SingleOrDefault(t => t.Name == "Something 0") != null);
		}

		[Test]
		public void GetOrganizationFromId_Should_RetrieveOnlySpecificId()
		{
			// Arrange
			var model = OrganizationFactory.GetListOfValidOrganizations(10);
			model.Last().Id = "Specific";
			model.Last().Name = "This one";

			var mockQuery = new GetOrganizationFromIdTest("Specific");

			// Act
			var result = model.Where(mockQuery.Filter.Compile()).ToList();

			// Assert
			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("Specific", result.Single().Id);
			Assert.AreEqual("This one", result.Single().Name);
		}

		[TestCase(1)]
		[TestCase(5)]
		[TestCase(90)]
		[TestCase(400)]
		public void SearchAllOrganizationsFromArea_Should_RetrieveOnlyWithinArea(int radius)
		{
			// Arrange
			var model = OrganizationFactory.GetListOfValidOrganizations(5);
			model.First().Address.Latitude = -8.05428;
			model.First().Address.Longitude = -34.8813;
			model.First().Address.Street = "Recife";

			model.Last().Address.Latitude = 48.864716;
			model.Last().Address.Longitude = 2.349014;
			model.Last().Address.Street = "Paris";

			model.First(t => t.Name == "Something 1").Address.Latitude = 51.426591;
			model.First(t => t.Name == "Something 1").Address.Longitude = 5.471808;
			model.First(t => t.Name == "Something 1").Address.Street = "Somewhere in Eindhoven 1";

			model.First(t => t.Name == "Something 2").Address.Latitude = 51.423053;
			model.First(t => t.Name == "Something 2").Address.Longitude = 5.469985;
			model.First(t => t.Name == "Something 2").Address.Street = "Somewhere in Eindhoven 2";

			model.First(t => t.Name == "Something 3").Address.Latitude = 51.424060;
			model.First(t => t.Name == "Something 3").Address.Longitude = 5.479824;
			model.First(t => t.Name == "Something 3").Address.Street = "Somewhere in Eindhoven 3";

			// Act
			var mockQuery = new ListAllOrganizationsFromAreaTest(51.426760, 5.478174, radius);
			var result = model.Where(mockQuery.Filter.Compile()).ToList();

			// Assert
			if (radius > 350)
			{
				Assert.True(result.Any(t => t.Address.Street == "Paris"));
			}
			else {
				Assert.False(result.Any(t => t.Address.Street == "Paris"));
			}
			Assert.False(result.Any(t => t.Address.Street == "Recife"));
			Assert.True(result.Count(t => t.Address.Street.Contains("Somewhere in Eindhoven")) == 3);
		}

		[TestCase(51.438668668523, 5.4347664491414065, 2)]
		public void LookCloseToAreaButOutsideRadius_Should_NotRetrieveItems(double lat, double lng, int radius)
		{
			// Arrange
			var model = OrganizationFactory.GetListOfValidOrganizations(5);
			model.First().Address.Latitude = -8.05428;
			model.First().Address.Longitude = -34.8813;
			model.First().Address.Street = "Recife";

			model.Last().Address.Latitude = 48.864716;
			model.Last().Address.Longitude = 2.349014;
			model.Last().Address.Street = "Paris";

			model.First(t => t.Name == "Something 1").Address.Latitude = 51.426591;
			model.First(t => t.Name == "Something 1").Address.Longitude = 5.471808;
			model.First(t => t.Name == "Something 1").Address.Street = "Somewhere in Eindhoven 1";

			model.First(t => t.Name == "Something 2").Address.Latitude = 51.423053;
			model.First(t => t.Name == "Something 2").Address.Longitude = 5.469985;
			model.First(t => t.Name == "Something 2").Address.Street = "Somewhere in Eindhoven 2";

			model.First(t => t.Name == "Something 3").Address.Latitude = 51.424060;
			model.First(t => t.Name == "Something 3").Address.Longitude = 5.479824;
			model.First(t => t.Name == "Something 3").Address.Street = "Somewhere in Eindhoven 3";

			// Act
			var mockQuery = new ListAllOrganizationsFromAreaTest(lat, lng, radius);
			var result = model.Where(mockQuery.Filter.Compile()).ToList();

			// Assert
			Assert.False(result.Any());
		}
	}

	#region Test classes

	internal class ListAllOrganizationsFromAreaTest : ListAllOrganizationsFromAreaQuery
	{
		public Expression<Func<OrganizationModel, bool>> Filter => _filter;

		public ListAllOrganizationsFromAreaTest(double lat, double lon, int radius) 
			: base(lat, lon, radius)
		{
		}
	}

	internal class GetOrganizationFromIdTest : GetOrganizationFromIdQuery
	{
		public Expression<Func<OrganizationModel, bool>> Filter => _filter;

		public GetOrganizationFromIdTest(string id) : base(id)
		{
		}
	}

	internal class ListAllOrganizationsTest : ListAllOrganizationsQuery
	{
		public Expression<Func<OrganizationModel, bool>> Filter => _filter;
	}

	internal class ListAllOrganizationsThatNeedsSpecificItemTest : ListAllOrganizationsThatNeedsSpecificItemQuery
	{
		public Expression<Func<OrganizationModel, bool>> Filter => _filter;

		public ListAllOrganizationsThatNeedsSpecificItemTest(IEnumerable<string> items) : base(items)
		{
		}
	}

	internal class ListAllOrganizationsFromCategoryTest : ListAllOrganizationFromCategoryQuery
	{
		public Expression<Func<OrganizationModel, bool>> Filter => _filter;

		public ListAllOrganizationsFromCategoryTest(string category) : base(category)
		{
		}
	}

	#endregion
}