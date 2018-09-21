// ValidationResult.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dharma.Core
{
	/// <summary>
	/// Validation result.
	/// </summary>
  [Serializable]
	public sealed class ValidationResult
	{
    public Dictionary<Guid, string> Errors { get;  }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Dharma.AbstractBlock.ValidationResult"/> class.
		/// </summary>
		public ValidationResult()
		{
			Errors = new Dictionary<Guid, string>();
		}

		/// <summary>
		/// Add the specified message.
		/// </summary>
		/// <param name="message">Message.</param>
		public void Add(string message)
		{
			Errors.Add(Guid.NewGuid(), message);
		}

		/// <summary>
		/// Add a list of messages
		/// </summary>
		/// <param name="messages">List of messages</param>
		public void Add(Dictionary<Guid, string> messages)
		{
			foreach (var message in messages.Where(t => !string.IsNullOrEmpty(t.Value?.Trim())))
			{
				Errors.Add(message.Key, message.Value);
			}
		}

		/// <summary>
		/// Finds the by key.
		/// </summary>
		/// <returns>The by key.</returns>
		/// <param name="key">Key.</param>
		public KeyValuePair<Guid, string> FindByKey(Guid key)
		{
			return Errors.SingleOrDefault(t => t.Key == key);
		}

		/// <summary>
		/// Finds the by message.
		/// </summary>
		/// <returns>The by message.</returns>
		/// <param name="message">Message.</param>
		public IEnumerable<KeyValuePair<Guid, string>> FindByMessage(string message)
		{
			return Errors.Where(t => t.Value.Contains(message));
		}

		/// <summary>
		/// Lists all errors of parent model
		/// </summary>
		/// <returns>The all.</returns>
		public IEnumerable<string> ListAll()
		{
			return Errors.Select(t => t.Value).AsEnumerable();
		}

		/// <summary>
		/// Returns if some error exists in the parent model
		/// </summary>
		/// <returns><c>true</c>, if valid, <c>false</c> otherwise.</returns>
		internal bool IsValid()
		{
			return !Errors.Any();
		}

  }
}
