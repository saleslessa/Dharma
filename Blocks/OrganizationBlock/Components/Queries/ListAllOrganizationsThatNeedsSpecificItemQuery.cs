using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dharma.OrganizationBlock.Models;

namespace Dharma.OrganizationBlock.Components.Queries
{
    internal class ListAllOrganizationsThatNeedsSpecificItemQuery : OrganizationBaseQuery
    {
        private readonly IEnumerable<string> _itemName;

        public ListAllOrganizationsThatNeedsSpecificItemQuery(IEnumerable<string> items)
        {
            _itemName = items.Select(t => t.ToLower().Trim());
        }

        protected override Expression<Func<OrganizationModel, bool>> _filter =>
            t => t.Active && t.ItemsNeeded.Where(i => i.Amount > 0)
                     .Select(i => i.Name.ToLower().Trim())
                     .Any(c => _itemName.Contains(c));
    }
}