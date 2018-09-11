// UpdateItemModelCommand.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using Dharma.ItemsBlock.Models;
using MongoDB.Driver;

namespace Dharma.ItemsBlock.Components.Commands
{
	internal class UpdateItemModelCommand : ItemsBlockBaseCommand
	{
		public UpdateItemModelCommand(ItemModel model) : base(model)
		{
		}

		public override void Run()
		{
			try
			{
				var filter = Builders<ItemModel>.Filter.Eq("Id", _model.Id);

				GetConnection().ReplaceOne(filter, _model);
			}
			catch (Exception ex)
			{
				_model.ValidationResult.Add(ex.Message);
			}
		}
	}
}
