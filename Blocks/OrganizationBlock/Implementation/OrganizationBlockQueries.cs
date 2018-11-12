// OrganizationBlockQueries.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using System.Collections.Generic;
using Dharma.Core;
using Dharma.OrganizationBlock.Components.Queries;
using Dharma.OrganizationBlock.Interfaces;
using Dharma.OrganizationBlock.Models;

namespace Dharma.OrganizationBlock.Implementation
{
	internal class OrganizationBlockQueries : IOrganizationBlockQueries
	{
		public IEnumerable<OrganizationModel> Get(string Id)
		{
			try
			{
				return new GetOrganizationFromIdQuery(Id).Run();
			}
			catch (Exception ex)
			{
				var result = ErrorHandler.LogError<OrganizationModel>(ex);
				return new List<OrganizationModel>() { result };
			}
		}

		public IEnumerable<OrganizationModel> ListAll()
		{
			try
			{
				return new ListAllOrganizationsQuery().Run();
			}
			catch (Exception ex)
			{
				var result = ErrorHandler.LogError<OrganizationModel>(ex);
				return new List<OrganizationModel>() { result };
			}
		}

		public IEnumerable<OrganizationModel> ListAllFromArea(double latitude, double longitude, int radius)
		{
			try
			{
				return new ListAllOrganizationsFromAreaQuery(latitude, longitude, radius).Run();
			}
			catch (Exception ex)
			{
				var result = ErrorHandler.LogError<OrganizationModel>(ex);
				return new List<OrganizationModel>() { result };
			}
		}
	}
}
