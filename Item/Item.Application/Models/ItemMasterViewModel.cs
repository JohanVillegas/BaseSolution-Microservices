using System;
using System.Collections.Generic;
using System.Text;

namespace Item.Application.Models
{
    public class ItemMasterViewModel
    {
        public ItemDTO Item { get; set; }

        public bool EditEnabled { get; set; }

        public bool DeleteEnabled { get; set; }
    }
}
