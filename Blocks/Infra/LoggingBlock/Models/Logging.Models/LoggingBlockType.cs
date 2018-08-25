// LoggingType.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LoggingBlock.Components.Commands")]
[assembly: InternalsVisibleTo("LoggingBlock.Components.Queries")]
[assembly: InternalsVisibleTo("LoggingBlock.Interfaces")]
[assembly: InternalsVisibleTo("LoggingBlock.Implementation")]
[assembly: InternalsVisibleTo("LoggingBlock")]
[assembly: InternalsVisibleTo("LoggingBlock.Component.Tests")]
namespace Dharma.LoggingBlock.Models
{
	/// <summary>
	/// Possible types of logging of a client block
	/// </summary>
	internal enum LoggingBlockType
	{
		Info,
		Warning,
		Error,
		Fatal
	}
}
