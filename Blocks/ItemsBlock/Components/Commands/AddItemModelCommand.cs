// AddItemCommand.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using Dharma.ItemsBlock.Models;

namespace Dharma.ItemsBlock.Components.Commands
{
	internal class AddItemModelCommand : ItemsBlockBaseCommand
	{
		public AddItemModelCommand(ItemModel model) : base(model)
		{
		}

		public override void Run()
		{
			try
			{
				GetConnection().InsertOne(_model);
			}
			catch (Exception ex)
			{
				_model.ValidationResult.Add(ex.Message);
			}
		}
	}
}
