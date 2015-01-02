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
                existingItem.ContributionCount++;
                existingItem.Subject = "Multiple contributions";
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
                existingItem.Subject = "Multiple contributions";
            }
            else
            {
                base.Add(new ContributionItem { Commits = new List<Commit> { commit }, Date = commit.Date, Subject = "Commit" });
            }
        }

        //public ContributionList Aggregated
        //{
        //    get
        //    {
        //        ContributionList aggregatedList = new ContributionList();
        //        foreach (ContributionItem item in this)
        //        {
        //            string date = item.Date.ToString("yyyy-MM-dd");
        //            ContributionItem existingItem = aggregatedList.FirstOrDefault(x => x.Date.ToString("yyyy-MM-dd").Equals(date));
        //            if (existingItem != null) 
        //            {
        //                existingItem.ContributionCount++;
        //                existingItem.Subject += "," + item.Subject;
        //            }
        //            else 
        //            {
        //                aggregatedList.Add(item);
        //            }
        //        }

        //        return aggregatedList;
        //    }
        //    private set { }
        //}
    }
}
