using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillieSandoval_2_28_2021.Models;

namespace WillieSandoval_2_28_2021.ViewModels
{
    public class EmployersViewModel
    {
        public Company Company { get; set; }

        public IEnumerable<Company> Companies { get; set; }
    }
}
