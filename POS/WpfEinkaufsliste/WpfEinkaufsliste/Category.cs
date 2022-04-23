using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEinkaufsliste
{
    public class Category
    {
        public Category(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
