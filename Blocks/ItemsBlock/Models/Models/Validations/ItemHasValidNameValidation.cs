// ItemHasValidNameValidation.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using Dharma.Core;

namespace Dharma.ItemsBlock.Models.Validations
{
	internal class ItemHasValidNameValidation : BaseValidation<ItemModel>
	{
		public override void Validate(ItemModel model)
		{
			if (model.Name == null || string.IsNullOrEmpty(model.Name.Trim()))
				model.ValidationResult.Add("Invalid Name");
		}
	}
}
