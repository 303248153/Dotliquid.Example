using DotLiquid.FileSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotLiquid;
using System.IO;

namespace Dotliquid.Example.Dotliquid
{
    public class DotliquidTemplateFileSystem : IFileSystem
    {
        public string ReadTemplateFile(Context context, string templateName)
        {
            var path = context[templateName] as string;
            if (string.IsNullOrEmpty(path))
                return path;
            var fullPath = HttpContext.Current.Server.MapPath(path);
            return File.ReadAllText(fullPath);
        }
    }
}