using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContributionGraph.Model
{
    public class Commit
    {
        public DateTime Date { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string AvatarUrl { get; set; }

        public string Sha { get; set; }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
