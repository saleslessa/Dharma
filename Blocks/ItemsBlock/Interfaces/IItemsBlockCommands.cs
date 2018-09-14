// IItemsBlockCommands.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using Dharma.ItemsBlock.Models;

namespace Dharma.ItemsBlock.Interfaces
{
	internal interface IItemsBlockCommands
	{
		ItemModel Add(ItemModel model);

		ItemModel Update(ItemModel model);
	}
}
