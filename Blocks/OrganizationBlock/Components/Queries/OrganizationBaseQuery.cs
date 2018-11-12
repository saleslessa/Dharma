using System;
using Dharma.Core;
using Dharma.OrganizationBlock.Components.Queries.Properties;
using Dharma.OrganizationBlock.Models;

namespace Dharma.OrganizationBlock.Components.Queries
{
    internal abstract class OrganizationBaseQuery : BaseQuery<OrganizationModel>
    {
		protected override string server => Resources.Server;

        protected override int port => Convert.ToInt32(Resources.Port);

        protected override string database => Resources.Database;

        protected override string user => Resources.User;

        protected override string pwd => Resources.Pwd;
    }
}