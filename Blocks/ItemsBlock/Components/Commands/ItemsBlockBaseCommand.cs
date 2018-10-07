// ItemsBlockBaseCommand.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using Dharma.Core;
using Dharma.ItemsBlock.Components.Commands.Properties;
using Dharma.ItemsBlock.Models;

namespace Dharma.ItemsBlock.Components.Commands
{
	internal class ItemsBlockBaseCommand : BaseCommand<ItemModel>
	{
		public ItemsBlockBaseCommand(ItemModel model) : base(model)
		{
		}

		protected override string server => ItemsBlockCommands.Server;

		protected override int port => Convert.ToInt32(ItemsBlockCommands.Port);

		protected override string database => ItemsBlockCommands.Database;

		protected override string user => ItemsBlockCommands.User;

		protected override string pwd => ItemsBlockCommands.Pwd;
	}
}
