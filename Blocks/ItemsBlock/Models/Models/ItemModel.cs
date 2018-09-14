// ItemsBlock.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dharma.Core;
using Dharma.ItemsBlock.Models.Validations;

namespace Dharma.ItemsBlock.Models
{
	internal class ItemModel : BaseModel
	{

		[Required]
		public string Name { get; set; }

		public ItemType Type { get; set; }

		public uint? Amount { get; set; }

		public IEnumerable<string> Categories { get; set; }

		public bool Active { get; set; }

		public ItemModel()
		{
			Active = true;
			Categories = new List<string>();
		}

		public ItemModel(string name, ItemType type, uint? amount
		                 , IEnumerable<string> categories, bool active)
		{
			Name = name;
			Type = type;
			Amount = amount;
			Categories = categories ?? new List<string>();
			Active = active;
		}

		protected override void Validate()
		{
			new ItemHasValidNameValidation().Validate(this);
			new ItemHasValidTypeAndAmountValidation().Validate(this);
			new ItemHasNoDuplicateCategoriesValidation().Validate(this);
		}
	}
}
