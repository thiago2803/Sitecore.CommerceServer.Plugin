using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Orders;
using Sitecore.Foundation.Commerce.Engine.Plugin.EPF.Pipelines.Arguments;
using Sitecore.Framework.Pipelines;

namespace Sitecore.Foundation.Commerce.Engine.Plugin.EPF.Pipelines
{
    [PipelineDisplayName("Minion.pipeline.createfile")]
    public interface ICreateFilePipeline : IPipeline<FileArgument, Order, CommercePipelineExecutionContext>, IPipelineBlock<FileArgument, Order, CommercePipelineExecutionContext>, IPipelineBlock, IPipeline
    {
    }
}
