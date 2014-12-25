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
            { 0, Color.FromArgb(226, 255, 195) },
            { 5, Color.FromArgb(195, 255, 131) },
            { 10, Color.FromArgb(156, 255, 52) },
            { 15, Color.FromArgb(126, 236, 0) },
        };

        public Color GetColor(Model.ContributionItem contributionItem, Model.ContributionList contributionList)
        {
            var color = CalendarView.DEFAULT_COLOR;

            Thresholds.OrderByDescending(x => x.Key).ToList().ForEach(x => 
                {
                    if (x.Key > contributionItem.ContributionCount)
                    {
                        color = x.Value;
                    }
                });

            return color;
        }
    }
}
