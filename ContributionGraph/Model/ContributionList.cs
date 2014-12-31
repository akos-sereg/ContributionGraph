using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContributionGraph.Model
{
    public class ContributionList : List<ContributionItem>
    {
        public ContributionList Aggregated
        {
            get
            {
                ContributionList aggregatedList = new ContributionList();
                foreach (ContributionItem item in this)
                {
                    string date = item.Date.ToString("yyyy-MM-dd");
                    ContributionItem existingItem = aggregatedList.FirstOrDefault(x => x.Date.ToString("yyyy-MM-dd").Equals(date));
                    if (existingItem != null) 
                    {
                        existingItem.ContributionCount++;
                        existingItem.Subject += "," + item.Subject;
                    }
                    else 
                    {
                        aggregatedList.Add(item);
                    }
                }

                return aggregatedList;
            }
            private set { }
        }
    }
}
