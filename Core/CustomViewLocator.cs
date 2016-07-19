using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Razor;

public class CustomViewLocator : IViewLocationExpander
{
    public void PopulateValues(ViewLocationExpanderContext context)
    { }

    public virtual IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    {
        //Replace folder view with CustomViews
        return viewLocations.Select(f => f.Replace("/Views/", "/CustomViews/"));
    }
}