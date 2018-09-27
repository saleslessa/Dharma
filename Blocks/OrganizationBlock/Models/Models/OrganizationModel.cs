// OrganizationModel.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Dharma.Core;
using Dharma.OrganizationBlock.Models.Validations.Organization;

namespace Dharma.OrganizationBlock.Models
{
	internal class OrganizationModel : BaseModel
	{
		[Required]
		public string Name { get; set; }
		
		public string PhoneNumber { get; set; }
	
		[Required]
		public AddressModel Address { get; set; }
		
		public List<string> Categories { get; set; }
		
		public List<ItemModel> ItemsNeeded { get; set; }
		
		public List<OwnerModel> Owners { get; set; }

		public bool Active { get; set; }

		public OrganizationModel()
		{
			ItemsNeeded = new List<ItemModel>();
			Owners = new List<OwnerModel>();
			Categories = new List<string>();
		}

		protected override void Validate()
		{
			ItemsNeeded?.ForEach(t => t.IsValid());
			ItemsNeeded?.ForEach(t => ValidationResult.Add(t.ValidationResult.Errors));
			
			Owners?.ForEach(t => t.IsValid());
			Owners?.ForEach(t => ValidationResult.Add(t.ValidationResult.Errors));
			
			new OrganizationHasValidAddressValidation().Validate(this);
			new OrganizationHasValidNameValidation().Validate(this);
		}
	}
}
