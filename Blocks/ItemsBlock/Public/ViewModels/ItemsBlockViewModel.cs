// ItemsBlockViewModel.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System.Collections.Generic;
using Dharma.Core;

namespace Dharma.ItemsBlock.ViewModels
{
	public class ItemsBlockViewModel : BaseViewModel
	{
		public string Name { get; set; }

		public string Type { get; set; }

		public uint? Amount { get; set; }

		public IEnumerable<string> Categories { get; set; }

		public bool Active { get; set; }
		
		protected override ValidationResult ValidationResult { get; set; }
	}
}
