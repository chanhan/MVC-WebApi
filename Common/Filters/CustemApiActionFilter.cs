using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Net.Http;
using Newtonsoft.Json;
namespace Common.Filters
{
   public class CustemApiActionFilter : ActionFilterAttribute
    {
       public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
       {
           base.OnActionExecuting(actionContext);
           //获取请求消息提数据
           //Stream stream = actionContext.Request.Content.ReadAsStreamAsync().Result;
           //Encoding encoding = Encoding.UTF8;
           //stream.Position = 0;
           //string responseData = "";
           //using (StreamReader reader = new StreamReader(stream, encoding))
           //{
           //    responseData = reader.ReadToEnd().ToString();
           //}
           ////反序列化进行处理
           //var serialize = new JavaScriptSerializer();
           //JsonConvert.DeserializeObject<>
           //var obj = serialize.Deserialize<RequestDTO>(responseData);
           ////在action执行前终止请求时，应该使用填充方法Response，将不返回action方法体。
           //if (obj == null)
           //    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, obj);

           //if (string.IsNullOrEmpty(obj.PhoneType) || string.IsNullOrEmpty(obj.PhoneVersion)
           //  || string.IsNullOrEmpty(obj.PhoneID) || obj.StartCity < 1)
           //{
           //    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, obj);
           //}
       }
    }
}
