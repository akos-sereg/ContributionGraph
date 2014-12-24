using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContributionGraph.Model
{
    public class ContributionItem
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public long ContributionCount { get; set; }
    }
}
