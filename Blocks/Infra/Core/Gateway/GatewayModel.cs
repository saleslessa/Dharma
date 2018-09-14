// GatewayModel.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using System.ComponentModel.DataAnnotations;

namespace Dharma.Core.Gateway
{
  public class GatewayModel : BaseModel
  {
    public string Model { get; set; }

    [Required]
    public string Service { get; set; }

    [Required]
    public string Location { get; set; }

    public GatewayModel() {}

    protected override void Validate()
    {
      throw new NotImplementedException();
    }
  }
}
