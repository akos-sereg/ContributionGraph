using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContributionGraph.View
{
    public class DayPanel : Panel
    {
        public DateTime Date { get; set; }

        public DayPanel(int boxSize, int margin, Color color, DateTime date)
        {
            this.BackColor = color;
            this.Margin = new Padding(margin);
            this.Width = boxSize;
            this.Height = boxSize;
            this.AutoSize = false;

            this.Date = date;
        }
    }
}
