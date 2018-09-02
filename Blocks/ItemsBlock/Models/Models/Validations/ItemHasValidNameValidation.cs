﻿// ItemHasValidNameValidation.cs
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
			if (string.IsNullOrEmpty(model.Name))
				model.ValidationResult.Add("Invalid Name");
		}
	}
}