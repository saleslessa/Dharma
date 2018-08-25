// ILoggingImplementation.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
using System.Runtime.CompilerServices;
using Dharma.LoggingBlock.Models;

[assembly: InternalsVisibleTo("LoggingBlock.Implementation")]
[assembly: InternalsVisibleTo("LoggingBlock")]
namespace Dharma.LoggingBlock.Interfaces
{
	internal interface ILoggingCommands
	{
		LoggingBlockModel AddLog(string origin, string message, LoggingBlockType type  = LoggingBlockType.Warning);
	}
}
