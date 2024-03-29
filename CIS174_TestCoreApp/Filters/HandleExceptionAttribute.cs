﻿using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Filters
{
    public class HandleExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Log.Error("Error occurred!");
            var error = new
            {
                Success = false,
                Errors = new[]
            {
                context.Exception.Message

            }
            };
            Guid guid = Guid.NewGuid();
            context.Result = new ObjectResult(error)
            {
                StatusCode = 500
               
            };
            context.ExceptionHandled = true;
        }
    }
}
