using System;
using System.Collections.Generic;
using System.Text;

namespace Item.Application.Models
{
    public class ItemMasterListViewModel
    {
        public List<ItemDTO> Items { get; set; }

        public bool CreateEnabled { get; set; }
    }
}
