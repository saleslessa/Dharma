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
using ItemsBlock.Models.Validations;

namespace ItemsBlock.Models
{
	internal class ItemModel : BaseModel
	{

		[Required]
		public string Name { get; set; }

		public ItemType Type { get; set; }

		public uint? Quantity { get; set; }

		public IEnumerable<string> Categories { get; set; }

		public ItemModel()
		{
			Categories = new List<string>();
		}

		protected override void Validate()
		{
			new ItemHasValidNameValidation().Validate(this);
			new ItemHasValidTypeAndQuantity().Validate(this);
		}
	}
}
