using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clarksons.Till.Core.Models;

namespace Clarksons.Till.Data
{
    public class MenuItemRepository :IMenuItemRepository
    {
        public MenuItemRepository()
        {
            MenuItems = new List<MenuItem>
            {
                new MenuItem { Id=1, Name = "Starter1", Description = "Starter1 Description", MenuItemType = MenuItemType.Starter, Price = 4.40m},
                new MenuItem { Id=2, Name = "Starter2", Description = "Starter2 Description", MenuItemType = MenuItemType.Starter, Price = 4.40m},
                new MenuItem { Id=3, Name = "Starter3", Description = "Starter3 Description", MenuItemType = MenuItemType.Starter, Price = 4.40m},
                new MenuItem { Id=4, Name = "Starter4", Description = "Starter4 Description", MenuItemType = MenuItemType.Starter, Price = 4.40m},
                new MenuItem { Id=5, Name = "Starter5", Description = "Starter5 Description", MenuItemType = MenuItemType.Starter, Price = 4.40m},

                new MenuItem { Id=6, Name = "Main1", Description = "Main1 Description", MenuItemType = MenuItemType.Main, Price = 7.00m},
                new MenuItem { Id=7, Name = "Main2", Description = "Main2 Description", MenuItemType = MenuItemType.Main, Price = 7.00m},
                new MenuItem { Id=8, Name = "Main3", Description = "Main3 Description", MenuItemType = MenuItemType.Main, Price = 7.00m},
                new MenuItem { Id=9, Name = "Main4", Description = "Main4 Description", MenuItemType = MenuItemType.Main, Price = 7.00m},
                new MenuItem { Id=10, Name = "Main5", Description = "Main5 Description", MenuItemType = MenuItemType.Main, Price = 7.00m},
            };
        }

        private IList<MenuItem> MenuItems { get; set; }
        public MenuItem Get(int id) 
        {
            return MenuItems.FirstOrDefault(x => x.Id == id);
        }
    }
}
