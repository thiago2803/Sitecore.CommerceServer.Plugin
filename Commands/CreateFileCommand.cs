using Sitecore.Commerce.Core;
using Sitecore.Commerce.Core.Commands;
using Sitecore.Commerce.Plugin.Carts;
using Sitecore.Commerce.Plugin.Orders;
using Sitecore.Foundation.Commerce.Engine.Plugin.EPF.Pipelines;
using Sitecore.Foundation.Commerce.Engine.Plugin.EPF.Pipelines.Arguments;
using Sitecore.Framework.Pipelines;
using System;
using System.Threading.Tasks;

namespace Sitecore.Foundation.Commerce.Engine.Plugin.EPF.Commands
{
    public class CreateFileCommand : CommerceCommand
    {
        private readonly ICreateFilePipeline _pipeline;
        private readonly IGetCartPipeline _getCartPipeline;

        public CreateFileCommand(IGetCartPipeline getCartPipeline, ICreateFilePipeline createFilePipeline, IServiceProvider serviceProvider)
          : base(serviceProvider)
        {
            this._getCartPipeline = getCartPipeline;
            this._pipeline = createFilePipeline;
        }

        public async Task<Order> Process(CommerceContext commerceContext, string cartId, string email)
        {
            Activity activity = TransactionalCommandActivity.Start(commerceContext, (CommerceCommand)this);
            Order order;
            try
            {
                order = await this._pipeline.Run(new FileArgument(await this._getCartPipeline.Run(new ResolveCartArgument(commerceContext.CurrentShopName(), cartId, commerceContext.CurrentShopperId()), (IPipelineExecutionContextOptions)commerceContext.GetPipelineContextOptions()), email), (IPipelineExecutionContextOptions)commerceContext.GetPipelineContextOptions());
            }
            finally
            {
                if (activity != null)
                    activity.Dispose();
            }
            activity = (Activity)null;
            return order;
        }
    }
}
