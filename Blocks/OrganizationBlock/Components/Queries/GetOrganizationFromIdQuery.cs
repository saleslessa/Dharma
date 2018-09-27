using System;
using System.Linq.Expressions;
using Dharma.OrganizationBlock.Models;

namespace Dharma.OrganizationBlock.Components.Queries
{
    internal class GetOrganizationFromIdQuery : OrganizationBaseQuery
    {
        private readonly string _id;

        public GetOrganizationFromIdQuery(string id)
        {
            _id = id;
        }

        protected override Expression<Func<OrganizationModel, bool>> _filter => (t => t.Id == _id);
    }
}