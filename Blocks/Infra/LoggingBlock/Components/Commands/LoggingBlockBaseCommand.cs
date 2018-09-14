// LoggingBlockBaseCommand.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using Dharma.Core;
using Dharma.LoggingBlock.Components.Commands.Properties;
using Dharma.LoggingBlock.Models;

namespace Dharma.LoggingBlock.Components.Commands
{
	internal abstract class LoggingBlockBaseCommand : BaseCommand<LoggingBlockModel>
	{
		public LoggingBlockBaseCommand(LoggingBlockModel model) : base(model)
		{
		}

		protected override string server => LoggingBlockCommandResources.Server;

		protected override int port => Convert.ToInt32(LoggingBlockCommandResources.Port);

		protected override string database => LoggingBlockCommandResources.Database;

		protected override string user => LoggingBlockCommandResources.User;

		protected override string pwd => LoggingBlockCommandResources.Pwd;
	}
}
