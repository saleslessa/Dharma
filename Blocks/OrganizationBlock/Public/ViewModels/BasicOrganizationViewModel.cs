// EmptyClass.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using System.Collections.Generic;
using Dharma.Core;

namespace Dharma.OrganizationBlock.ViewModels
{
	public class BasicOrganizationViewModel : BaseViewModel
	{
		public string id { get; set; }

		public string label { get; set; }

		public double lat { get; set; }

		public double lng { get; set; }

		public string PhoneNumber { get; set; }

		public List<string> Categories { get; set; }

		protected override ValidationResult ValidationResult { get; set; }
	}
}
