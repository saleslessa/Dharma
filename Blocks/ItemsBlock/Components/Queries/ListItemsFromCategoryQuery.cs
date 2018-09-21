// GetItemsFromCategoryQuery.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using System.Linq;
using System.Linq.Expressions;
using Dharma.ItemsBlock.Models;

namespace Dharma.ItemsBlock.Components.Queries
{
	internal class ListItemsFromCategoryQuery : ItemsBlockBaseQuery
	{
		private readonly string _category;

		public ListItemsFromCategoryQuery(string category)
		{
			_category = string.IsNullOrEmpty(category) ? string.Empty : category.Trim().ToLower();
		}

		protected override Expression<Func<ItemModel, bool>> _filter => (t => t.Active && t.Categories.Contains(_category));

	}
}
