using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContributionGraph.Model;

namespace ContributionGraph.View
{
    public class DayPanel : Panel
    {
        private Label _cellMessage;

        public ContributionItem Contribution { get; set; }

        public DateTime Date { get; set; }

        public DayPanel(Label cellMessage, int boxSize, int margin, Color color, DateTime date)
        {
            this._cellMessage = cellMessage;

            this.BackColor = color;
            this.Margin = new Padding(margin);
            this.Width = boxSize;
            this.Height = boxSize;
            this.AutoSize = false;

            this.Date = date;

            this.MouseEnter += DayPanel_MouseEnter;
            this.MouseLeave += DayPanel_MouseLeave;
        }

        void DayPanel_MouseLeave(object sender, EventArgs e)
        {
            this._cellMessage.Text = string.Empty;
        }

        void DayPanel_MouseEnter(object sender, EventArgs e)
        {
            this._cellMessage.Text = string.Format("{0}: {1}", 
                this.Date.ToString("yyyy MMM d"), 
                (this.Contribution == null ? "no contribution" : this.Contribution.ToString()));
        }
    }
}
