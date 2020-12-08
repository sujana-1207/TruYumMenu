using MenuItemsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuItemsService.Repositories
{
    public interface IMenu
    {
        public List<MenuItem> GetMenuItems();
        public MenuItem UpdateMenuItem(MenuItem m);
        public int AddMenuItem(MenuItem m);
    }
}
