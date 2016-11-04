namespace Dnn.Modules.Pipeline.Controllers
{
    using System;
    using System.Web.Mvc;

    using DotNetNuke.Collections;
    using DotNetNuke.Security;
    using DotNetNuke.Web.Mvc.Framework.ActionFilters;
    using DotNetNuke.Web.Mvc.Framework.Controllers;
    using ValidateAntiForgeryToken = DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryTokenAttribute;

    [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.Edit)]
    [DnnHandleError]
    public class SettingsController : DnnController
    {
        [HttpGet]
        public ActionResult Settings()
        {
            var settings = new Models.Settings
                           {
                               Setting1 = this.ModuleContext.Configuration.ModuleSettings.GetValueOrDefault("Pipeline_Setting1", false),
                               Setting2 = this.ModuleContext.Configuration.ModuleSettings.GetValueOrDefault("Pipeline_Setting2", DateTime.Now),
                           };

            return this.View(settings);
        }

#pragma warning disable SEC0019 // Missing AntiForgeryToken Attribute
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Settings(Models.Settings settings)
#pragma warning restore SEC0019 // Missing AntiForgeryToken Attribute
        {
            this.ModuleContext.Configuration.ModuleSettings["Pipeline_Setting1"] = settings.Setting1.ToString();
            this.ModuleContext.Configuration.ModuleSettings["Pipeline_Setting2"] = settings.Setting2.ToUniversalTime().ToString("u");

            return this.RedirectToDefaultRoute();
        }
    }
}