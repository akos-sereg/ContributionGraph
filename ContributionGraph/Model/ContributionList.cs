﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContributionGraph.Model
{
    public class ContributionList : List<ContributionItem>
    {
        public new void Add(ContributionItem newItem)
        {
            string date = newItem.Date.ToString("yyyy-MM-dd");
            ContributionItem existingItem = this.FirstOrDefault(x => x.Date.ToString("yyyy-MM-dd").Equals(date));
            if (existingItem != null)
            {
                existingItem.ContributionCount += newItem.ContributionCount;
                existingItem.Subject = string.Format("{0} contribution{1}", existingItem.ContributionCount, existingItem.ContributionCount > 1 ? "s" : "");
            }
            else
            {
                base.Add(newItem);
            }
        }

        public void Add(Commit commit)
        {
            string date = commit.Date.ToString("yyyy-MM-dd");
            ContributionItem existingItem = this.FirstOrDefault(x => x.Date.ToString("yyyy-MM-dd").Equals(date));
            if (existingItem != null)
            {
                existingItem.Commits.Add(commit);
                existingItem.Subject = string.Format("{0} contribution{1}", existingItem.ContributionCount, existingItem.ContributionCount > 1 ? "s" : "");
            }
            else
            {
                base.Add(new ContributionItem { Commits = new List<Commit> { commit }, Date = commit.Date, Subject = "1 contribution" });
            }
        }
    }
}
