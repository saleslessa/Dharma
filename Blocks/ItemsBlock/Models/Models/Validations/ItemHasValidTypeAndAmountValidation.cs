// ItemHasValidTypeAndQuantity.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using Dharma.Core;

namespace Dharma.ItemsBlock.Models.Validations
{
	internal class ItemHasValidTypeAndAmountValidation : BaseValidation<ItemModel>
	{
		public override void Validate(ItemModel model)
		{
			if (model.Type == ItemType.Amount && model.Amount == null)
				model.ValidationResult.Add("Item Type requires quantity");
		}
	}
}
