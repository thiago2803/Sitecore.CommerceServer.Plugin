using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.Logging;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Core.Commands;
using Sitecore.Commerce.Plugin.Orders;
using Sitecore.Foundation.Commerce.Engine.Plugin.EPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.OData;

namespace Sitecore.Foundation.Commerce.Engine.Plugin.EPF.Controllers
{
    [Microsoft.AspNetCore.OData.EnableQuery]
    [Route("api/Epf")]
    public class FileController : CommerceController
    {
        public FileController(IServiceProvider serviceProvider, CommerceEnvironment globalEnvironment)
          : base(serviceProvider, globalEnvironment)
        {
        }

        [HttpGet]
        [Route("(Id={id})")]
        [Microsoft.AspNetCore.OData.EnableQuery]
        public async Task<IActionResult> Get(string id)
        {
            if (!this.ModelState.IsValid)
                return (IActionResult)new BadRequestObjectResult(this.ModelState);
            if (string.IsNullOrEmpty(id))
                return (IActionResult)new BadRequestObjectResult((object)id);

            Order cart = await this.Command<CreateFileCommand>().Process(this.CurrentContext, id, string.Empty).ConfigureAwait(false);

            return cart != null ? (IActionResult)new ObjectResult((object)cart) : (IActionResult)this.NotFound();
        }
    }
}
