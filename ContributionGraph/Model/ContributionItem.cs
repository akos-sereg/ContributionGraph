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

        public List<Commit> Commits { get; set; }

        private long _contributionCount;

        /// <summary>
        /// Returns the number of commits, if Commits proeprty is not null; returns previously set value otherwise.
        /// </summary>
        public long ContributionCount
        {
            get
            {
                return this.Commits == null ? _contributionCount : this.Commits.Count;
            }
            set
            {
                if (this.Commits != null)
                {
                    throw new InvalidOperationException("Commits property is not empty, ContributionCount can not be set");
                }

                _contributionCount = value;
            }
        }

        public override string ToString()
        {
            return this.Subject;
        }
    }
}
