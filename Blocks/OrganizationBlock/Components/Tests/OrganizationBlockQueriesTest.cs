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

            var mockCriteria = new[] {"food", "test new demand"};
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
}