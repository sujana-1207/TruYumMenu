using MenuItemsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuItemsService.Repositories
{
    public class MenuRepository:IMenu
    {
        private static List<MenuItem> _menuItems = new List<MenuItem>()
        {
            new MenuItem{Id=1,Name="Pizza",Price=200,DateOflaunch=DateTime.Parse("10-10-2019"),Category="Main Course",FreeDelivery=true},
             new MenuItem{Id=2,Name="Paneer Tikka",Price=100,DateOflaunch=DateTime.Parse("10-10-2019"),Category="Starter",FreeDelivery=true},
              new MenuItem{Id=3,Name="Choco Lava Cake",Price=150,DateOflaunch=DateTime.Parse("10-12-2019"),Category="Dessert",FreeDelivery=false}
        };

        public int AddMenuItem(MenuItem m)
        {
            try
            {
                _menuItems.Add(m);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public List<MenuItem> GetMenuItems()
        {
            return _menuItems;
        }

        public MenuItem UpdateMenuItem(MenuItem m)
        {
                var updatemenuitem = _menuItems.FirstOrDefault(c => c.Id == m.Id);

                updatemenuitem.Name = m.Name;
                updatemenuitem.DateOflaunch = m.DateOflaunch;
                updatemenuitem.Price = m.Price;
                updatemenuitem.Category = m.Category;
                updatemenuitem.FreeDelivery = m.FreeDelivery;
                updatemenuitem.Active = m.Active;
                return updatemenuitem;
                        
        }
    }
}
