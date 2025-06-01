using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYDWP.Models
{
    public class SubCardModel
    {
        public bool IsMainView { get; set; } = false;
        public string Title { get; set; }
        public string PendingText { get; set; }
        public int AppliedCount { get; set; }
    }
}
