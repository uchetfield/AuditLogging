﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Skoruba.AuditLogging.Configuration;
using Skoruba.AuditLogging.Helpers.HttpContextHelpers;

namespace Skoruba.AuditLogging.Events
{
    public class AuditHttpAction : IAuditAction
    {
        public AuditHttpAction(IHttpContextAccessor accessor, AuditHttpActionOptions options)
        {
            Action = new
            {
                TraceIdentifier = accessor.HttpContext.TraceIdentifier,
                RequestUrl = accessor.HttpContext.Request.GetDisplayUrl(),
                HttpMethod = accessor.HttpContext.Request.Method,
                FormVariables = options.IncludeFormVariables ? HttpContextHelpers.GetFormVariables(accessor.HttpContext) : null
            };
        }

        public object Action { get; set; }
    }
}