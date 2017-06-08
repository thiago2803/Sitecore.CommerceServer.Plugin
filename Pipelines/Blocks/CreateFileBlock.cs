using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Logging;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Core.Commands;
using Sitecore.Commerce.Plugin.Carts;
using Sitecore.Commerce.Plugin.ManagedLists;
using Sitecore.Commerce.Plugin.Orders;
using Sitecore.Commerce.Plugin.Pricing;
using Sitecore.Foundation.Commerce.Engine.Plugin.EPF.Pipelines.Arguments;
using Sitecore.Framework.Conditions;
using Sitecore.Framework.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sitecore.Foundation.Commerce.Engine.Plugin.EPF.Pipelines.Blocks
{
    [PipelineDisplayName("Minion.CreateFileBlock")]
    public class CreateFileBlock : PipelineBlock<FileArgument, Order, CommercePipelineExecutionContext>
    {
        private readonly IDeleteEntityPipeline _deletePipeline;
        private readonly TelemetryClient _telemetryClient;
        private readonly PerformanceCounterCommand _performanceCounterCommand;

        public CreateFileBlock(IDeleteEntityPipeline deleteEntityPipeline, TelemetryClient telemetryClient, PerformanceCounterCommand performanceCounterCommand)
          : base((string)null)
        {
            this._deletePipeline = deleteEntityPipeline;
            this._telemetryClient = telemetryClient;
            this._performanceCounterCommand = performanceCounterCommand;
        }

        public override async Task<Order> Run(FileArgument arg, CommercePipelineExecutionContext context)
        {
            return (Order)null;
        }
    }
}
