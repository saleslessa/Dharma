using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using Dharma.OrganizationBlock.Interfaces;
using Dharma.OrganizationBlock.Models;
using NUnit.Framework;

namespace Dharma.OrganizationBlock.Components.Tests
{
    [TestFixture]
    public class OrganizationBlockQueriesTest
    {
        private ILifetimeScope _lifetimeScope;
        private IOrganizationBlockQueries _queries;

        public OrganizationBlockQueriesTest()
        {
            var container = new ContainerBuilder();
        }

        
        
        [Test]
        public void ListAllOrganizations_Should_ReturnAllActiveOrganizations()
        {
            // Arrange
            
            var model = OrganizationFactory.GetListOfValidOrganizations(5);
            

            // Act
            

            // Asset
        }
    }
}