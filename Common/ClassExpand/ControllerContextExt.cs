using System.Web.Http.Controllers;
using System.Web.Mvc;
namespace Common.ClassExpand
{
    public static class ControllerContextExt
    {
        /// <summary>
        /// 存储Session
        /// </summary>
        /// <param name="context"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetSession(this ControllerContext context, string key, object value)
        {
            context.HttpContext.Session[key] = value;
        }

        /// <summary>
        /// 清除Session
        /// </summary>
        /// <param name="context"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void ClearSession(this ControllerContext context)
        {
            context.HttpContext.Session.Clear();
        }


        /// <summary>
        /// 获取Session
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetSession<T>(this ControllerContext context, string key)
        {
            try
            {
                return (T)context.HttpContext.Session[key];
            }
            catch
            {
                return default(T);
            }
        }
    }
}