using Sitecore.Commerce.Core;

namespace Sitecore.Foundation.Commerce.Engine.Plugin.EPF.Models
{
    public class CreateFile : Model
    {
        public string OrderId { get; set; }

        public CreateFile()
        {
            this.OrderId = string.Empty;
        }
    }
}
