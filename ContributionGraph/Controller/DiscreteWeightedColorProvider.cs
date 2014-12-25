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
            { 0, Color.FromArgb(204, 255, 152) },
            { 5, Color.FromArgb(0, 255, 51) },
            { 10, Color.FromArgb(0, 204, 51) },
            { 15, Color.FromArgb(0, 153, 51) },
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
