using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmergentSoftware.Models
{
    public class SoftwareList
    {
        public IEnumerable<Software> softwares { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
    }
}
