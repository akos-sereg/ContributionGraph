using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContributionGraph.Controller
{
    public class DiscreteWeightedColorProvider : IColorProvider
    {
        public Color GetColor(Model.ContributionItem contributionItem, Model.ContributionList contributionList)
        {
            if (contributionItem.ContributionCount > 15)
            {
                return Color.FromArgb(126, 236, 0);
            }
            else if (contributionItem.ContributionCount > 10)
            {
                return Color.FromArgb(156, 255, 52);
            }
            else if (contributionItem.ContributionCount > 5)
            {
                return Color.FromArgb(195, 255, 131);
            }
            else if (contributionItem.ContributionCount > 0)
            {
                return Color.FromArgb(226, 255, 195);
            }
            else
            {
                return CalendarView.DEFAULT_COLOR;
            }
        }
    }
}
