using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst1.ViewModels
{
    public class CommentViewModel
    {
        public List<commentModel> cm = new List<commentModel>();
    }
    public class commentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Time { get; set; }
        public string NameProducts { get; set; }
        public string Contains { get; set; }
        public double? Phone { get; set; }
    }

}