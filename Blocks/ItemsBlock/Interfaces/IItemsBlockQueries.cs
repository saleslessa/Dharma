﻿// IItemsBlockQueries.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System.Collections.Generic;
using Dharma.ItemsBlock.Models;

namespace Dharma.ItemsBlock.Interfaces
{
	internal interface IItemsBlockQueries
	{
		IEnumerable<ItemModel> ListAllItems();

		IEnumerable<ItemModel> ListItemsFromCategory(IEnumerable<string> categories);

		IEnumerable<ItemModel> ListItemsFromName(string name);
	}
}
