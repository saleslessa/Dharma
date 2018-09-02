// ListItemsFromNameQuery.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Dharma.Core;
using Dharma.ItemsBlock.Models;

[assembly: InternalsVisibleTo("Dharma.ItemsBlock.Components.Tests")]
namespace Dharma.ItemsBlock.Components.Queries
{
	internal class ListItemsFromNameQuery : BaseQuery<ItemModel>
	{
		private readonly string _name;

		public ListItemsFromNameQuery(string name)
		{
			_name = name ?? name.ToLower().Trim();
		}

		protected override Expression<Func<ItemModel, bool>> _filter => (t => t.Active && t.Name.Trim().ToLower().Contains(_name));

		protected override string server => ItemsBlockQuery.Server;

		protected override int port => Convert.ToInt32(ItemsBlockQuery.Port);

		protected override string database => ItemsBlockQuery.Database;

		protected override string user => ItemsBlockQuery.User;

		protected override string pwd => ItemsBlockQuery.Pwd;
	}
}
