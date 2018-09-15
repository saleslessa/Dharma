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
		protected override string server => Resources.Server;

		protected override int port => Convert.ToInt32(Resources.Port);

		protected override string database => Resources.Database;

		protected override string user => Resources.User;

		protected override string pwd => Resources.Pwd;
	}
}
