// ItemHasNoDuplicateCategoriesValidation.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System.Linq;
using Dharma.Core;

namespace Dharma.ItemsBlock.Models.Validations
{
	internal class ItemHasNoDuplicateCategoriesValidation : BaseValidation<ItemModel>
	{
		public override void Validate(ItemModel model)
		{
			if (model.Categories.Any())
			{
				model.Categories = model.Categories.Distinct();
			}
			else 
			{
				model.ValidationResult.Add("Category missing");
			}
		}
	}
}
