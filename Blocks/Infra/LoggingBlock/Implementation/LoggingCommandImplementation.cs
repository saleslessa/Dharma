// LoggingImplementation.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
using Dharma.LoggingBlock.Components.Commands;
using Dharma.LoggingBlock.Interfaces;
using Dharma.LoggingBlock.Models;


namespace Dharma.LoggingBlock.Implementation
{

	internal class LoggingCommandImplementation : ILoggingCommands
	{
		public LoggingBlockModel AddLog(string origin, string message, LoggingBlockType type)
		{
			var model = new LoggingBlockModel(origin, message, type);
			if (!model.IsValid()) return model;

			var command = new AddLoggingCommand(model);
			command.Run();
			return model;
		}
	}
}
