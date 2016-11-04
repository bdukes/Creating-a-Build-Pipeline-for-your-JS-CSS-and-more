namespace Dnn.Modules.Pipeline.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Dnn.Modules.Pipeline.Components;
    using Dnn.Modules.Pipeline.Models;

    using DotNetNuke.Entities.Users;
    using DotNetNuke.Framework.JavaScriptLibraries;
    using DotNetNuke.Web.Mvc.Framework.ActionFilters;
    using DotNetNuke.Web.Mvc.Framework.Controllers;
    using ValidateAntiForgeryToken = DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryTokenAttribute;

    [DnnHandleError]
    public class ItemController : DnnController
    {
        public ActionResult Delete(int itemId)
        {
            ItemManager.Instance.DeleteItem(itemId, this.ModuleContext.ModuleId);
            return this.RedirectToDefaultRoute();
        }

        public ActionResult Edit(int itemId = -1)
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);

            var userlist = UserController.GetUsers(this.PortalSettings.PortalId);
            var users = from user in userlist.Cast<UserInfo>().ToList()
                        select new SelectListItem { Text = user.DisplayName, Value = user.UserID.ToString() };

            this.ViewBag.Users = users;

            var item = (itemId == -1)
                 ? new Item { ModuleId = this.ModuleContext.ModuleId }
                 : ItemManager.Instance.GetItem(itemId, this.ModuleContext.ModuleId);

            return this.View(item);
        }

#pragma warning disable SEC0019 // Missing AntiForgeryToken Attribute
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item item)
#pragma warning restore SEC0019 // Missing AntiForgeryToken Attribute
        {
            if (item.ItemId == -1)
            {
                item.CreatedByUserId = this.User.UserID;
                item.CreatedOnDate = DateTime.UtcNow;
                item.LastModifiedByUserId = this.User.UserID;
                item.LastModifiedOnDate = DateTime.UtcNow;

                ItemManager.Instance.CreateItem(item);
            }
            else
            {
                var existingItem = ItemManager.Instance.GetItem(item.ItemId, item.ModuleId);
                existingItem.LastModifiedByUserId = this.User.UserID;
                existingItem.LastModifiedOnDate = DateTime.UtcNow;
                existingItem.ItemName = item.ItemName;
                existingItem.ItemDescription = item.ItemDescription;
                existingItem.AssignedUserId = item.AssignedUserId;

                ItemManager.Instance.UpdateItem(existingItem);
            }

            return this.RedirectToDefaultRoute();
        }

        [ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
        public ActionResult Index()
        {
            var items = ItemManager.Instance.GetItems(this.ModuleContext.ModuleId);
            return this.View(items);
        }
    }
}
