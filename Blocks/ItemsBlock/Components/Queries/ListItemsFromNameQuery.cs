// ListItemsFromNameQuery.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using System.Linq.Expressions;
using Dharma.ItemsBlock.Models;

namespace Dharma.ItemsBlock.Components.Queries
{
	internal class ListItemsFromNameQuery : ItemsBlockBaseQuery
	{
		private readonly string _name;

		public ListItemsFromNameQuery(string name)
		{
			_name = name == null ? string.Empty : name.ToLower().Trim();
		}

		protected override Expression<Func<ItemModel, bool>> _filter => (t => t.Active && t.Name.Trim().ToLower().Contains(_name));

	}
}
