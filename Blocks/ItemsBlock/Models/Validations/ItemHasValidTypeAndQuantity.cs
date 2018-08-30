// ItemHasValidTypeAndQuantity.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using Dharma.Core;

namespace ItemsBlock.Models.Validations
{
	internal class ItemHasValidTypeAndQuantity : BaseValidation<ItemModel>
	{
		public override void Validate(ItemModel model)
		{
			if (model.Type == ItemType.Quantity && model.Quantity == null)
				model.ValidationResult.Add($"Item Type requires quantity");
		}
	}
}
