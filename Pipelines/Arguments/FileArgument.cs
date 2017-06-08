using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Carts;
using Sitecore.Framework.Conditions;

namespace Sitecore.Foundation.Commerce.Engine.Plugin.EPF.Pipelines.Arguments
{
    public class FileArgument : PipelineArgument
    {
        public Cart Cart { get; set; }

        public string Email { get; set; }

        public FileArgument(Cart cart, string email)
        {
            Condition.Requires<Cart>(cart).IsNotNull<Cart>("The cart can not be null");
            Condition.Requires<string>(email).IsNotNullOrEmpty("The customer email can not be null or empty");

            this.Cart = cart;
            this.Email = email;
        }
    }


    //public class CartArgument : PipelineArgument
    //{
    //    public Cart Cart { get; set; }

    //    public CartArgument(Cart cart)
    //    {
    //        Condition.Requires<Cart>(cart).IsNotNull<Cart>("The cart can not be null");
    //        this.Cart = cart;
    //    }
    //}
}
