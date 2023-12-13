// using System.Text.Json;
// using FluentValidation;
// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Diagnostics;
// using Microsoft.AspNetCore.Http;
// using Portfolio.Shared.Kernel.Domain.Constants;
//
// namespace Portfolio.Shared.Kernel.Presentation.Extensions;
//
// public static class AppValidationExceptionHandling
// {
//     public static void UseFluentValidationExceptionHandler(this IApplicationBuilder app)
//     {
//         app.UseExceptionHandler(x =>
//         {
//             x.Run(async context =>
//             {
//                 var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
//                 var exception = errorFeature.Error;
//
//                 if (!(exception is ValidationException validationException))
//                 {
//                     throw exception;
//                 }
//
//                 var errors =
//                     validationException.Errors.Select(error =>
//                         new
//                         {
//                             error.PropertyName,
//                             error.ErrorMessage
//                         });
//
//                 var errorText = JsonSerializer.Serialize(errors);
//                 context.Response.StatusCode = StatusCodes.Status400BadRequest;
//                 context.Response.ContentType = ContentType.ApplicationJson;
//                 await context.Response.WriteAsync(errorText);
//             });
//         });
//     }
// }