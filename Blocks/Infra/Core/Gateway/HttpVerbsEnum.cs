// HttpVerbsEnum.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using System.ComponentModel;

namespace Dharma.Core.Gateway
{
  /// <summary>
  /// Http verbs enum.
  /// </summary>
  public enum HttpVerbsEnum
  {
    /// <summary>
    /// The get.
    /// </summary>
    [DisplayName("GET")]
    GET,
    /// <summary>
    /// The post.
    /// </summary>
    [DisplayName("POST")]
    POST,
    /// <summary>
    /// The put.
    /// </summary>
    [DisplayName("PUT")]
    PUT,
    /// <summary>
    /// The delete.
    /// </summary>
    [DisplayName("DELETE")]
    DELETE
  }
}
