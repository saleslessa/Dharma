// OrganizationViewModelExtensions.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using Dharma.OrganizationBlock.Models;

namespace Dharma.OrganizationBlock.ViewModels
{
	internal static class OrganizationViewModelExtensions
	{
		public static BasicOrganizationViewModel ToBasic(this OrganizationModel model)
		{
			return new BasicOrganizationViewModel()
			{
				id = model.Id,
				lat = model.Address.Latitude,
				lng = model.Address.Longitude,
				label = model.Name,
				Categories = model.Categories,
				PhoneNumber = model.PhoneNumber
			};
		}

		public static OrganizationModel ToModel(this AddOrganizationViewModel viewModel)
		{
			return new OrganizationModel()
			{ 
				Name = viewModel.Name,
				Categories = viewModel.Categories,
				PhoneNumber = viewModel.PhoneNumber,
				Address = new AddressModel()
				{
					Latitude = viewModel.Latitude,
					Longitude = viewModel.Longitude,
					Street = viewModel.StreetName,
					StreetNumber = viewModel.StreetNumber
				},
				Active = true
			};
		}

		public static AddOrganizationViewModel Map(this OrganizationModel model)
		{
			var result = new AddOrganizationViewModel()
			{
				Name = model.Name,
				Categories = model.Categories,
				PhoneNumber = model.PhoneNumber,
				Latitude = model.Address.Latitude,
				Longitude = model.Address.Longitude,
				StreetName = model.Address.Street,
				StreetNumber = model.Address.StreetNumber,
				Id = model.Id
			};

			result.SetValidationResult(model.ValidationResult);

			return result;
		}
	}
}
