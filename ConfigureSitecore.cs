// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureSitecore.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// <summary>
//   The SamplePlugin startup class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Foundation.Commerce.Engine.Plugin.EPF
{
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;
    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Configuration;
    using Sitecore.Framework.Pipelines.Definitions.Extensions;
    using Pipelines;
    using Pipelines.Blocks;
    using Commands;

    /// <summary>
    /// The carts configure sitecore class.
    /// </summary>
    public class ConfigureSitecore : IConfigureSitecore
    {
        /// <summary>
        /// The configure services.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.RegisterAllPipelineBlocks(assembly);

            services.Sitecore().Pipelines(config => config
             .AddPipeline<SamplePipeline, SamplePipeline>(
                    configure =>
                    {
                        configure.Add<SampleBlock>();
                    })
            .AddPipeline<ICreateFilePipeline, CreateFilePipeline>(builder => builder
                .Add<CreateFileBlock>())
            .ConfigurePipeline<IConfigureServiceApiPipeline>(configure => configure.Add<Sitecore.Foundation.Commerce.Engine.Plugin.EPF.Pipelines.ConfigureServiceApiBlock>())
            );


            services
                .AddScoped<SampleCommand, SampleCommand>().AddScoped<CreateFileCommand, CreateFileCommand>();
        }
    }
}