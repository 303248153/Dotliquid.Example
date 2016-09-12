using DotLiquid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dotliquid.Example.Dotliquid
{
    public abstract class DotliquidController : Controller
    {
        public ContentResult DotliquidView(string path = null, object parameters = null)
        {
            // 路径为空时根据当前的Action决定
            if (string.IsNullOrEmpty(path))
            {
                var controller = RouteData.Values["controller"];
                var action = RouteData.Values["action"];
                path = $"~/DotliquidViews/{controller}/{action}.html";
            }
            // 根据路径读取模板内容
            var templateStr = Template.FileSystem.ReadTemplateFile(new Context(), "'" + path + "'");
            // 解析模板，这里可以缓存Parse出来的对象，但是为了简单这里就略去了
            var template = Template.Parse(templateStr);
            // 描画模板
            Hash templateParameters;
            if (parameters is IDictionary<string, object>)
                templateParameters = Hash.FromDictionary((IDictionary<string, object>)parameters);
            else
                templateParameters = Hash.FromAnonymousObject(parameters ?? new { });
            var result = template.Render(templateParameters);
            // 返回描画出来的内容
            return Content(result, "text/html");
        }
    }
}