// AddLoggingCommand.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
using System;
using Dharma.Core;
using Dharma.LoggingBlock.Components.Commands;
using Dharma.LoggingBlock.Models;

namespace Dharma.LoggingBlock.Components.Command.Commands
{
	internal class AddLoggingCommand : BaseCommand<LoggingBlockModel>
	{
		public AddLoggingCommand(LoggingBlockModel model) : base(model)
		{
		}

		protected override string server => LoggingBlockCommand.Server;

		protected override int port => Convert.ToInt32(LoggingBlockCommand.Port);

		protected override string database => LoggingBlockCommand.Database;

		protected override string user => LoggingBlockCommand.User;

		protected override string pwd => LoggingBlockCommand.Pwd;


		public override void Run()
		{
			try
			{
				GetConnection().InsertOne(_model);
			}
			catch (Exception ex)
			{
				_model.ValidationResult.Add(ex.Message);
			}
		}
	}
}
