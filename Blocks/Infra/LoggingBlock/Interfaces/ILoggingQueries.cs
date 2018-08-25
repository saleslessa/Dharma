// LoggingQueries.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT

using System.Collections.Generic;
using Dharma.Core.Gateway;
using Dharma.LoggingBlock.Models;

namespace Dharma.LoggingBlock.Interfaces
{
	internal interface ILoggingQueries
	{
		LoggingBlockModel GetLoggingFromId(string id);

		IEnumerable<LoggingBlockModel> ListAllLoggingFromType(string blockName, LoggingBlockType type);

		IEnumerable<LoggingBlockModel> ListLoggingFromBlock(string blockName);

		IEnumerable<LoggingBlockModel> ListLoggingFromBlockNameAndType(string blockName, string type);

	}
}
