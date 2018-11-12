using System;
using Dharma.Core;
using Dharma.OrganizationBlock.Components.Commands.Properties;
using Dharma.OrganizationBlock.Models;

namespace Dharma.OrganizationBlock.Components.Commands
{
    internal class OrganizationBlockBaseCommand: BaseCommand<OrganizationModel>
    {
        protected override string server => Resources.Server;

        protected override int port => Convert.ToInt32(Resources.Port);

        protected override string database => Resources.Database;

        protected override string user => Resources.User;

        protected override string pwd => Resources.Pwd;

        public OrganizationBlockBaseCommand(OrganizationModel model) : base(model)
        {
        }
    }
}