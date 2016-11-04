namespace Dnn.Modules.Pipeline.Components
{
    using System;
    using System.Collections.Generic;

    using Dnn.Modules.Pipeline.Models;

    using DotNetNuke.Data;
    using DotNetNuke.Framework;

    internal class ItemManager : ServiceLocator<IItemManager, ItemManager>, IItemManager
    {
        public void CreateItem(Item t)
        {
            using (var context = DataContext.Instance())
            {
                context.GetRepository<Item>().Insert(t);
            }
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            var item = this.GetItem(itemId, moduleId);
            this.DeleteItem(item);
        }

        public void DeleteItem(Item t)
        {
            using (var context = DataContext.Instance())
            {
                context.GetRepository<Item>().Delete(t);
            }
        }

        public IEnumerable<Item> GetItems(int moduleId)
        {
            using (var context = DataContext.Instance())
            {
                return context.GetRepository<Item>().Get(moduleId);
            }
        }

        public Item GetItem(int itemId, int moduleId)
        {
            using (var context = DataContext.Instance())
            {
                return context.GetRepository<Item>().GetById(itemId, moduleId);
            }
        }

        public void UpdateItem(Item t)
        {
            using (var context = DataContext.Instance())
            {
                context.GetRepository<Item>().Update(t);
            }
        }

        protected override Func<IItemManager> GetFactory()
        {
            return () => new ItemManager();
        }
    }
}
