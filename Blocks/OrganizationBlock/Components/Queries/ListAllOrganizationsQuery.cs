using System;
using System.Linq.Expressions;
using Dharma.OrganizationBlock.Models;

namespace Dharma.OrganizationBlock.Components.Queries
{
    internal class ListAllOrganizationsQuery : OrganizationBaseQuery
    {
        protected override Expression<Func<OrganizationModel, bool>> _filter => (t => t.Active);
    }
}