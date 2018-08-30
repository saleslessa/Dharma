// LoggingModel.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Dharma.Core;

[assembly: InternalsVisibleTo("LoggingBlock.Components.Commands")]
[assembly: InternalsVisibleTo("LoggingBlock.Components.Queries")]
[assembly: InternalsVisibleTo("LoggingBlock.Interfaces")]
[assembly: InternalsVisibleTo("LoggingBlock.Implementation")]
[assembly: InternalsVisibleTo("LoggingBlock")]
[assembly: InternalsVisibleTo("LoggingBlock.Component.Tests")]
namespace Dharma.LoggingBlock.Models
{
	
	/// <summary>
	/// Model class to be used by client blocks to log some message
	/// </summary>
	internal class LoggingBlockModel : BaseModel
	{

		/// <summary>
		/// Message
		/// </summary>
		/// <value>The message.</value>
		[Required]
		public string Message { get; set; }

		/// <summary>
		/// Timestamp of requested logging message
		/// </summary>
		/// <value>The time stamp.</value>
		public DateTime TimeStamp { get; set; }

		/// <summary>
		/// Message type
		/// </summary>
		/// <value>The type.</value>
		public LoggingBlockType Type { get; set; }

		/// <summary>
		/// Client block name
		/// </summary>
		/// <value>The origin.</value>
		[Required]
		public string BlockOrigin { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Logging.Models.LoggingModel"/> class.
		/// </summary>
		/// <param name="origin">Origin.</param>
		/// <param name="message">Message.</param>
		/// <param name="type">Type.</param>
		public LoggingBlockModel(string origin, string message, LoggingBlockType type = LoggingBlockType.Warning)
		{
			Id = Guid.NewGuid().ToString();
			TimeStamp = DateTime.Now;
			BlockOrigin = origin;
			Message = message;
			Type = type;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Logging.Models.LoggingModel"/> class.
		/// </summary>
		public LoggingBlockModel() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Logging.Models.LoggingModel"/> class.
		/// </summary>
		/// <param name="validations">Validations.</param>
		public LoggingBlockModel(List<string> validations)
		{
			validations.ForEach(ValidationResult.Add);
		}

		/// <summary>
		/// Validate this instance.
		/// </summary>
		protected override void Validate()
		{
			// TODO: Put magic strings into resources file
			if (string.IsNullOrEmpty(Message) || Message.Trim().Length == 0)
				ValidationResult.Add($"Invalid Logging Message");
		}

	}
}
