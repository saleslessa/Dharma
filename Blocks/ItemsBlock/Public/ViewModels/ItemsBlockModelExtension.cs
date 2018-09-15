// ItemsBlockModelExtension.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using Dharma.ItemsBlock.Models;

namespace Dharma.ItemsBlock.ViewModels
{
	internal static class ItemsBlockModelExtension
	{
		public static ItemModel Map(this ItemsBlockViewModel model)
		{
			return new ItemModel(model.Name, model.Type != null
					? (ItemType) Enum.Parse(typeof(ItemType), model.Type)
					: ItemType.Amount, 
				model.Amount, model.Categories, model.Active);
		}

		public static ItemsBlockViewModel Map(this ItemModel model)
		{
			var result = new ItemsBlockViewModel()
			{
				Name = model.Name,
				Amount = model.Amount,
				Active = model.Active,
				Categories = model.Categories,
				Type = Enum.GetName(typeof(ItemType), model.Type)
			};

			result.SetValidationResult(model.ValidationResult);

			return result;
		}
	}
}
