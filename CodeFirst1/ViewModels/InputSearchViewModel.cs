using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst1.ViewModels
{
    public class InputSearchViewModel
    {
           public List<string> Manufacture { get; set; }
           public decimal giaMin { get; set; }
           public decimal giaMax { get; set; }
           public string a { get; set; }
    }
}