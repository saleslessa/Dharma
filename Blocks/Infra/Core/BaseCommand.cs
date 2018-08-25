// Command.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
using System;
namespace Dharma.Core
{
	/// <summary>
	/// Base class for all commands used in the project. It will contain all common behavior and 
	/// information, such as the timestamp of requested command to be executed
	/// </summary>
  public abstract class BaseCommand<T> : BaseConnection<T> where T : BaseModel, new()
	{
		/// <summary>
		/// Exact time of when the command was requested
		/// </summary>
		/// <value>The timestamp.</value>
		public DateTime Timestamp { get; }

    /// <summary>
    /// The model.
    /// </summary>
		public readonly T _model;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Dharma.AbstractBlock.BaseCommand"/> class.
		/// </summary>
		public BaseCommand(T model)
		{
			Timestamp = DateTime.Now;
			_model = model;
		}

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:Dharma.Core.BaseCommand`1"/> successful operation.
    /// </summary>
    /// <value><c>true</c> if successful operation; otherwise, <c>false</c>.</value>
		public bool SuccessfulOperation => _model.IsValid();

    /// <summary>
    /// Run this instance.
    /// </summary>
		public abstract void Run();

	}
}
