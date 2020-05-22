using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeRepository
{
    public class MenuListRepository
    {
        private List<MenuList> _menuLists = new List<MenuList>();


        //read
        public List<MenuList> GetMenuList()
        {
            return _menuLists;
        }
        //create
        public void AddMenuItem(MenuList content)
        {
            _menuLists.Add(content);
        }

        //delete
        public bool RemoveMenuItem(string name)
        {
            MenuList content = GetMenuNames(name);
            
            if (content == null)
            {
                return false;
            }
            int initialCount = _menuLists.Count;
            _menuLists.Remove(content);

            if (initialCount > _menuLists.Count)
            {
                return true;
            }
            else
            {
                return false;
            }


        }



        //helper grabs menulist and places it into content
        public MenuList GetMenuNames(string title)
        {
            foreach (MenuList content in _menuLists)
            {
                if (content.Name.ToLower() == title.ToLower())
                {
                    return content;
                }
                
            }
            return null;
        }






    }
}
