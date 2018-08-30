// Validation.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
namespace Dharma.Core
{
  public abstract class BaseValidation<T> where T : BaseModel
  {
    public abstract void Validate(T model);
  }
}
