using Microsoft.AspNetCore.Mvc;
using Sitecore.Commerce.Core;
using Sitecore.Foundation.Commerce.Engine.Plugin.EPF.Commands;
using System;
using System.Web.Http.OData;

namespace Sitecore.Foundation.Commerce.Engine.Plugin.EPF.Controllers
{
    public class CommandsController : CommerceController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandsController"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="globalEnvironment">The global environment.</param>
        public CommandsController(IServiceProvider serviceProvider, CommerceEnvironment globalEnvironment) : base(serviceProvider, globalEnvironment)
        { }

        /// <summary>
        /// Samples the command.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("CreateFileCommand()")]
        public IActionResult SampleCommand([FromBody] ODataActionParameters value)
        {
            var id = value["Id"].ToString();
            var command = Command<CreateFileCommand>();
            var result = command.Process(CurrentContext, id, string.Empty).Result;

            return new ObjectResult(command);
        }
    }
}
