// OrganizationModel.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using System.ComponentModel.DataAnnotations;
using Dharma.Core;

namespace OrganizationBlock.Models
{
	internal class OrganizationModel : BaseModel
	{

		[Required]
		public string Name { get; set; }


		public OrganizationModel()
		{
		}

		protected override void Validate()
		{
			throw new NotImplementedException();
		}
	}
}
