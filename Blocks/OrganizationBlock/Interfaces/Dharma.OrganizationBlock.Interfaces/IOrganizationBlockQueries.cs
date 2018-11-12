using System.Collections.Generic;
using Dharma.OrganizationBlock.Models;

namespace Dharma.OrganizationBlock.Interfaces
{
	internal interface IOrganizationBlockQueries
    {
		IEnumerable<OrganizationModel> ListAll();

		IEnumerable<OrganizationModel> ListAllFromArea(double latitude, double longitude, int radius);

		IEnumerable<OrganizationModel> Get(string Id);
    }
}