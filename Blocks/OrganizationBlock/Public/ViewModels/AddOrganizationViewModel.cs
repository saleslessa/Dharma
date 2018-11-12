// CompleteOrganizationViewModel.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dharma.Core;

namespace Dharma.OrganizationBlock.ViewModels
{
	public class AddOrganizationViewModel : BaseViewModel
	{

		public string Id { get; set; }

		[Required]
		public string Name { get; set; }

		public string PhoneNumber { get; set; }

		[Required]
		public double Latitude { get; set; }

		[Required]
		public double Longitude { get; set; }

		public string StreetName { get; set; }

		public uint StreetNumber { get; set; }

		public List<string> Categories { get; set; }

		protected override Core.ValidationResult ValidationResult { get; set; }
	}
}
