using System;
using System.Collections.Generic;
using System.Text;

namespace App446MasterDetail.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Driver
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
