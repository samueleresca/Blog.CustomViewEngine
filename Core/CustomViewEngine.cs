using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System;

namespace Core
{
    public class CustomViewEngine : RazorViewEngine
    {
        public CustomViewEngine(IRazorPageFactoryProvider pageFactory,
                IRazorPageActivator pageActivator,
                HtmlEncoder htmlEncoder,
                IOptions<RazorViewEngineOptions> optionsAccessor,
                ILoggerFactory loggerFactory)
            : base(pageFactory,
                  pageActivator,
                  htmlEncoder, optionsAccessor, loggerFactory
                  )
        { }

        public override IEnumerable<string> ViewLocationFormats
        {
            get
            {
                var origLocations = base.ViewLocationFormats;

                //MOCK: Replace with real-world condition
                var rand = new Random();
                var randomCondition = (rand.Next(0, 2) == 0);

                var varyExtension = randomCondition ? ".vary1" : ".vary2";

                /*
                * ViewLocationFormats contains the list of view location.
                * Replace the name of views with the vary extension
                */
                return base.ViewLocationFormats.Select(f => f.Replace(".cshtml", varyExtension + ".cshtml")).Concat(origLocations);
            }
        }

    }
}
