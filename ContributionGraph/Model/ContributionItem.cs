using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContributionGraph.Model
{
    public class ContributionItem
    {
        public string Subject { get; set; }

        public DateTime Date { get; set; }

        public long ContributionCount { get; set; }

        public override string ToString()
        {
            return string.Format("{0} contribution{1} for {2}", 
                this.ContributionCount, 
                this.ContributionCount > 1 ? "s" : string.Empty, 
                this.Subject);
        }
    }
}
