// GetLoggingFromIdQuery.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
using System;
using System.Linq.Expressions;
using Dharma.Core;
using Dharma.LoggingBlock.Models;

namespace Dharma.LoggingBlock.Components.Queries
{

	internal class GetLoggingFromIdQuery : LoggingBlockBaseQuery
	{

		private readonly string Id;

		public GetLoggingFromIdQuery(string id)
		{
			Id = id;
		}

		protected override Expression<Func<LoggingBlockModel, bool>> _filter => (t => t.Id == this.Id);

	}
}
