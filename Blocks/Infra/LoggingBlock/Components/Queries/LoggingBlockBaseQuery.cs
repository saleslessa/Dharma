// LoggingBlockBaseQuery.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using Dharma.Core;
using Dharma.LoggingBlock.Components.Queries.Properties;
using Dharma.LoggingBlock.Models;

namespace Dharma.LoggingBlock.Components.Queries
{
	internal abstract class LoggingBlockBaseQuery : BaseQuery<LoggingBlockModel>
	{
		protected override string server => LoggingBlockQuery.Server;

		protected override int port => Convert.ToInt32(LoggingBlockQuery.Port);

		protected override string database => LoggingBlockQuery.Database;

		protected override string user => LoggingBlockQuery.User;

		protected override string pwd => LoggingBlockQuery.Pwd;
	}
}
