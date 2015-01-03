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
        private Color _color;

        private Label _cellMessage;

        #region Properties

        public ContributionItem Contribution { get; set; }

        public DateTime Date { get; set; }

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                this.BackColor = _color;
            }
        }

        private Color _defaultColor;

        private Color _defaultColorHover;

        #endregion

        public DayPanel(Label cellMessage, int boxSize, int margin, Color color, Color defaultColor, Color defaultColorHover, DateTime date)
        {
            this._cellMessage = cellMessage;
            this._color = color;
            this._defaultColor = defaultColor;
            this._defaultColorHover = defaultColorHover;

            this.BackColor = color;
            this.Margin = new Padding(margin);
            this.Width = boxSize;
            this.Height = boxSize;
            this.AutoSize = false;
            this.Cursor = Cursors.Hand;

            this.Date = date;

            this.MouseEnter += DayPanel_MouseEnter;
            this.MouseLeave += DayPanel_MouseLeave;

            if (this.Date.ToString("yyyy-MM-dd").Equals(DateTime.Now.ToString("yyyy-MM-dd")))
            {
                this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            }
        }

        public void Reset()
        {
            this.Color = _defaultColor;
            this.Contribution = null;

            if (this.Date.ToString("yyyy-MM-dd").Equals(DateTime.Now.ToString("yyyy-MM-dd")))
            {
                this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            }
            else
            {
                this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            }
        }

        void DayPanel_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = _color;
            this._cellMessage.Text = string.Empty;
        }

        void DayPanel_MouseEnter(object sender, EventArgs e)
        {
            if (_color == _defaultColor)
            {
                this.BackColor = this._defaultColorHover;
            }

            this._cellMessage.Text = string.Format("{0}: {1}", 
                this.Date.ToString("yyyy MMM d"), 
                (this.Contribution == null ? "no contribution" : this.Contribution.ToString()));
        }
    }
}
