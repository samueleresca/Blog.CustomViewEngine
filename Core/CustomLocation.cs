using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Core
{
    public class CustomViewEngine : RazorViewEngine
{
    public CustomViewEngine( IRazorPageFactoryProvider pageFactory,
            IRazorPageActivator pageActivator,
            System.Text.Encodings.Web.HtmlEncoder htmlEncoder,
            Microsoft.Extensions.Options.IOptions<RazorViewEngineOptions> optionsAccessor,
            Microsoft.Extensions.Logging.ILoggerFactory loggerFactory) 
        : base(pageFactory, 
              pageActivator, 
              htmlEncoder, optionsAccessor, loggerFactory
              )
    {
    }

    public override IEnumerable<string> ViewLocationFormats
    {
        get
        {
            var origLocations= base.ViewLocationFormats;
            return  base.ViewLocationFormats.Select(f => f.Replace(".cshtml", ".theme.cshtml")).Concat(origLocations);
        }
    }

}
}