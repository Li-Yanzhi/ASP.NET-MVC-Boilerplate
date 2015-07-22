﻿namespace MvcBoilerplate
{
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Diagnostics;
    using Microsoft.AspNet.Hosting;
    using Boilerplate.Web.Mvc;

    public partial class Startup
    {
        /// <summary>
        /// Configures the error pages for the application.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <param name="environment">The environment the application is running under. This can be Development, 
        /// Staging or Production by default.</param>
        private static void ConfigureErrorPages(
            IApplicationBuilder application,
            IHostingEnvironment environment)
        {
            // Add the following to the request pipeline only in the development environment.
            if (environment.IsDevelopment())
            {
                // When an error occurs, displays a detailed error page with full diagnostic information. It is unsafe
                // to use this in production. See http://docs.asp.net/en/latest/fundamentals/diagnostics.html
                application.UseErrorPage(ErrorPageOptions.ShowAll);

                // When a database error occurs, displays a detailed error page with full diagnostic information. It is 
                // unsafe to use this in production. Uncomment this if using a database.
                // application.UseDatabaseErrorPage(DatabaseErrorPageOptions.ShowAll);
            }
            else // Add the following to the request pipeline only in the staging or production environments.
            {
                // Add the following to the request pipeline only in the staging environment.
                if (!environment.IsProduction())
                {
                    application.UseErrorPageTests("/debug/{0}/");
                }

                // Add Error handling middle-ware which catches all application specific errors and send the request to 
                // the following path or controller action.
                // application.UseErrorHandler("/error/internalservererror/");

                // Add error handling middle-ware which handles all HTTP status codes from 400 to 599 by re-executing
                // the request pipeline for the following URL. '{0}' is the name of the HTTP status code e.g. notfound.
                application.UseStatusNamePagesWithReExecute("/error/{0}/");
            }
        }
    }
}