using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContributionGraph.Model;

namespace ContributionGraph.Controller
{
    public interface IColorProvider
    {
        Color GetColor(Color defaultColor, ContributionItem contributionItem, ContributionList contributionList);
    }
}
