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
using System.Runtime.CompilerServices;
using Dharma.Core;
using Dharma.ItemsBlock.Models;

[assembly: InternalsVisibleTo("Dharma.ItemsBlock.Components.Tests")]
namespace Dharma.ItemsBlock.Components.Queries
{
	internal class ListItemsFromCategoryQuery : BaseQuery<ItemModel>
	{
		private readonly string _category;

		public ListItemsFromCategoryQuery(string category)
		{
			_category = category ?? category.Trim().ToLower();
		}

		protected override Expression<Func<ItemModel, bool>> _filter => (t => t.Active && t.Categories.Any(c => c.Trim().ToLower().Contains(_category)));

		protected override string server => ItemsBlockQuery.Server;

		protected override int port => Convert.ToInt32(ItemsBlockQuery.Port);

		protected override string database => ItemsBlockQuery.Database;

		protected override string user => ItemsBlockQuery.User;

		protected override string pwd => ItemsBlockQuery.Pwd;
	}
}
