// ILoggingImplementation.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
using Dharma.LoggingBlock.Models;

namespace Dharma.LoggingBlock.Interfaces
{
	internal interface ILoggingCommands
	{
		LoggingBlockModel AddLog(string origin, string message, LoggingBlockType type  = LoggingBlockType.Warning);
	}
}
