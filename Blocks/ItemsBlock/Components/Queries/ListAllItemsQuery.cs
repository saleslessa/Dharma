// ListAllItemsQuery.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Dharma.ItemsBlock.Models;

namespace Dharma.ItemsBlock.Components.Queries
{
	internal class ListAllItemsQuery : ItemsBlockBaseQuery
	{
		protected override Expression<Func<ItemModel, bool>> _filter => (t => t.Active);
	}
}
