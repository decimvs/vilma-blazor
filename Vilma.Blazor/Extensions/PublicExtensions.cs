﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilma.Blazor
{
    public static class PublicExtensions
    {
        /// <summary>
        /// Adds the services needed for Vilma to work.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddVilmaBlazorServices(this IServiceCollection services)
        {
            services.AddSingleton<VilmaToastService>();

            return services;
        }
    }
}