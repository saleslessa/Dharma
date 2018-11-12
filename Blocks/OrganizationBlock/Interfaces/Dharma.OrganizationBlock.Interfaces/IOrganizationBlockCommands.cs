using Dharma.Core;
using Dharma.OrganizationBlock.Models;

namespace Dharma.OrganizationBlock.Interfaces
{
	internal interface IOrganizationBlockCommands
    {
		OrganizationModel Add(OrganizationModel model);

		OrganizationModel Update(OrganizationModel model);

		ValidationResult Remove(string Id);
    }
}