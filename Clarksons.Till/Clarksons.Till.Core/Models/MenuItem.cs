using System;
using System.Collections.Generic;
using System.Text;

namespace Clarksons.Till.Core.Models
{
    public class MenuItem : IEquatable<MenuItem>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MenuItemType MenuItemType { get; set; }
        public decimal Price { get; set; }
        public bool Equals(MenuItem other)
        {
            if (other == null)
            {
                return false;
            }

            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is MenuItem menuItemObj))
            {
                return false;
            }

            return Equals(menuItemObj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(MenuItem menuItem1, MenuItem menuItem2)
        {
            if ((object)menuItem1 == null || (menuItem2 as object) == null)
            {
                return Equals(menuItem1, menuItem2);
            }

            return menuItem1.Equals(menuItem2);
        }

        public static bool operator !=(MenuItem menuItem1, MenuItem menuItem2)
        {
            return !(menuItem1 == menuItem2);
        }
    }
}
