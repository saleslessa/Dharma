// LoggingImplementation.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT

using System;
using Dharma.Core;
using Dharma.LoggingBlock.Components.Commands;
using Dharma.LoggingBlock.Interfaces;
using Dharma.LoggingBlock.Models;


namespace Dharma.LoggingBlock.Implementation
{

	internal class LoggingCommandImplementation : ILoggingCommands
	{
		public LoggingBlockModel AddLog(LoggingBlockModel model)
		{
			try
			{
				if (!model.IsValid()) 
					return model;

				var command = new AddLoggingCommand(model);
				command.Run();
				return model;
			}
			catch (Exception e)
			{
				return ErrorHandler.LogError<LoggingBlockModel>(e);
			}
		}
	}
}
