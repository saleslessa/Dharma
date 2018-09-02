// ItemType.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System.ComponentModel;

namespace Dharma.ItemsBlock.Models
{
	internal enum ItemType
	{
		[Description("Quantity")]
		Amount,
		[Description("Hour")]
		Hour,
		[Description("Service")]
		Service
	}
}
