// AddLoggingCommand.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
using System;
using Dharma.LoggingBlock.Models;

namespace Dharma.LoggingBlock.Components.Commands
{
	internal class AddLoggingCommand : LoggingBlockBaseCommand
	{
		public AddLoggingCommand(LoggingBlockModel model) : base(model)
		{
		}

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
