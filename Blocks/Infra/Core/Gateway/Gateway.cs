// Gateway.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dharma.Core.Gateway
{
  public static class Gateway
  {
    public static GatewayModel GetGateway(string service)
    {
      return new GatewayQuery<GatewayModel>(new GatewayModel() { Service = service }).Run().FirstOrDefault();
    }
  }
}
