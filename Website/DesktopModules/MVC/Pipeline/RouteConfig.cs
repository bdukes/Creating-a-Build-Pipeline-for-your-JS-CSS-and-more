namespace Dnn.Modules.Pipeline
{
    using DotNetNuke.Web.Mvc.Routing;

    using JetBrains.Annotations;

    [UsedImplicitly]
    public class RouteConfig : IMvcRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapRoute(
                routeName: "Dnn.Modules.Pipeline",
                moduleFolderName: "Dnn.Modules.Pipeline",
                url: "{controller}/{action}",
                namespaces: new[] { "Dnn.Modules.Pipeline.Controllers", });
        }
    }
}
