using System;

namespace Item.Application.Models
{
    public class ItemDTO
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Decription { get; set; }
        public DateTime DateTime { get; set; }
        public bool Active { get; set; }
    }
}