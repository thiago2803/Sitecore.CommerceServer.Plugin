using System.Threading.Tasks;

using Sitecore.Commerce.Core;
using Sitecore.Commerce.Core.Commands;

using Microsoft.AspNetCore.OData.Builder;

using Sitecore.Framework.Conditions;
using Sitecore.Framework.Pipelines;
using Sitecore.Commerce.Plugin.Carts;

namespace Sitecore.Foundation.Commerce.Engine.Plugin.EPF.Pipelines
{
    /// <summary>
    /// Defines a block which configures the OData model 
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         Sitecore.Framework.Pipelines.PipelineBlock{Microsoft.AspNetCore.OData.Builder.ODataConventionModelBuilder,
    ///         Microsoft.AspNetCore.OData.Builder.ODataConventionModelBuilder,
    ///         Sitecore.Commerce.Core.CommercePipelineExecutionContext}
    ///     </cref>
    /// </seealso>
    [PipelineDisplayName(CartsConstants.Pipelines.Blocks.ConfigureServiceApiBlock)]
    public class ConfigureServiceApiBlock : PipelineBlock<ODataConventionModelBuilder, ODataConventionModelBuilder, CommercePipelineExecutionContext>
    {
        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="modelBuilder">
        /// The argument.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="ODataConventionModelBuilder"/>.
        /// </returns>
        public override Task<ODataConventionModelBuilder> Run(ODataConventionModelBuilder modelBuilder, CommercePipelineExecutionContext context)
        {
            var CreateFileConfiguration = modelBuilder.Action("CreateFile");
            CreateFileConfiguration.Parameter<string>("cartId");
            CreateFileConfiguration.Parameter<string>("email");
            CreateFileConfiguration.ReturnsFromEntitySet<CommerceCommand>("Commands");

            var GetFileConfiguration = modelBuilder.Action("GetFile");
            GetFileConfiguration.ReturnsFromEntitySet<CommerceCommand>("Commands");

            return Task.FromResult(modelBuilder);
        }
    }
}
