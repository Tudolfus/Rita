﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Mapping
{
    public static class MappingExtension
    {
        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
