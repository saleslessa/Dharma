// ItemsBlockBaseQuery.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using Dharma.Core;
using Dharma.ItemsBlock.Components.Queries.Properties;
using Dharma.ItemsBlock.Models;

namespace Dharma.ItemsBlock.Components.Queries
{
	internal abstract class ItemsBlockBaseQuery : BaseQuery<ItemModel>
	{
		protected override string server => ItemsBlockQuery.Server;

		protected override int port => Convert.ToInt32(ItemsBlockQuery.Port);

		protected override string database => ItemsBlockQuery.Database;

		protected override string user => ItemsBlockQuery.User;

		protected override string pwd => ItemsBlockQuery.Pwd;

	}
}
