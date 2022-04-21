using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lithium_Balance.Views;
using Lithium_Balance.Models;
using WPFMainWindow.Models;

namespace Lithium_Balance.Models
{
    public class Customer : IPersistable
    {
        public string Email { get; set; }
        public string Name { get; set; }

        public void Parse(string line)
        {
            string[] data = line.Split(';');
            Email = data[0];
            Name = data[1];
        }

        public string Format()
        {
            return $"{Email};{Name}";
        }
        
    }
}
