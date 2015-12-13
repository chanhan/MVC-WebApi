using Models.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Common.ModelBinder
{
    public class UserBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            User user = new User();
            Type type = typeof(User);
            foreach (var item in type.GetProperties())
            {
                ValueProviderResult result = controllerContext.Controller.ValueProvider.GetValue(item.Name);
                if (result != null)
                {
                    if (item.PropertyType.Name == "Int32")
                    {
                        item.SetValue(user, Convert.ToInt32(result.AttemptedValue));
                    }
                    else
                    {
                        item.SetValue(user, result.AttemptedValue);
                    }
                }
            }
            user.UserName = user.UserName.ToUpper();
            return user;
        }
    }
}
