using Microsoft.Extensions.Logging;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Orders;
using Sitecore.Foundation.Commerce.Engine.Plugin.EPF.Pipelines.Arguments;
using Sitecore.Framework.Pipelines;

namespace Sitecore.Foundation.Commerce.Engine.Plugin.EPF.Pipelines
{
    public class CreateFilePipeline : CommercePipeline<FileArgument, Order>, ICreateFilePipeline, IPipeline<FileArgument, Order, CommercePipelineExecutionContext>, IPipelineBlock<FileArgument, Order, CommercePipelineExecutionContext>, IPipelineBlock, IPipeline
    {
        public CreateFilePipeline(IPipelineConfiguration<ICreateFilePipeline> configuration, ILoggerFactory loggerFactory)
          : base((IPipelineConfiguration) configuration, loggerFactory)
        {
        }
    }
}