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
        private static readonly Dictionary<long, Color> Thresholds = new Dictionary<long, Color>
        {
            { 0, Color.FromArgb(214, 230, 133) },
            { 5, Color.FromArgb(140, 198, 101) },
            { 10, Color.FromArgb(68, 163, 64) },
            { 15, Color.FromArgb(30, 104, 35) },
        };

        public Color GetColor(Model.ContributionItem contributionItem, Model.ContributionList contributionList)
        {
            var color = CalendarView.DEFAULT_COLOR;

            Thresholds.OrderBy(x => x.Key).ToList().ForEach(x => 
                {
                    if (contributionItem.ContributionCount > x.Key)
                    {
                        color = x.Value;
                    }
                });

            return color;
        }
    }
}
