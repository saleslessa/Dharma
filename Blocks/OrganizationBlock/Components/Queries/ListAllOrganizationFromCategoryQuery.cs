using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Dharma.OrganizationBlock.Models;

namespace Dharma.OrganizationBlock.Components.Queries
{
    internal class ListAllOrganizationFromCategoryQuery : OrganizationBaseQuery
    {
        private readonly string _category;

        public ListAllOrganizationFromCategoryQuery(string category)
        {
            _category = category?.ToLower().Trim();
        }

        protected override Expression<Func<OrganizationModel, bool>> _filter =>
            t => t.Active && t.Categories.Select(c => c.ToLower().Trim()).Contains(_category);

    }
}