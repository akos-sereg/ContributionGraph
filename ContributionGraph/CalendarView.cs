using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContributionGraph.View;
using ContributionGraph.Model;
using ContributionGraph.Controller;

namespace ContributionGraph
{
    /// <summary>
    /// TODO: 
    /// - First Day of Week property
    /// </summary>
    public partial class CalendarView : UserControl
    {
        public static readonly Color DEFAULT_COLOR = Color.FromArgb(240, 240, 240);
        private readonly int DISPLAYED_WEEKS = 52;
        private readonly int MARGIN = 1;
        private readonly int BOX_SIZE = 12;

        public IColorProvider ColorProvider { get; set; }

        private ContributionList _dataSource;
        public ContributionList DataSource {
            get
            {
                return _dataSource;
            }
            set
            {
                _dataSource = value;
                Draw();
            }
        }

        public DateTime StartDate { get; set; }

        public CalendarView()
        {
            InitializeComponent();

            ColorProvider = new DiscreteWeightedColorProvider();
            StartDate = DateTime.Now.AddDays(-365);
            DateTime originalStartDate = StartDate;

            // Adjust StartDate to the last Monday
            while (StartDate.DayOfWeek != DayOfWeek.Monday)
            {
                StartDate = StartDate.AddDays(-1);
            }

            // Initialize Calendar Component
            // -----------------------------------------------------------------
            this.cellMessage.Text = string.Empty;

            this.BackColor = Color.White;
            
            // Fill Calendar Table with colored panels
            int startDay = 0;
            for (int week = 0; week != DISPLAYED_WEEKS; week++)
            {
                for (int dayOfWeek = 0; dayOfWeek != 7; dayOfWeek++)
                {
                    DateTime dayPanelDate = this.StartDate.AddDays(startDay);
                    DayPanel dayPanel = new DayPanel(this.cellMessage, BOX_SIZE, MARGIN, DEFAULT_COLOR, dayPanelDate);

                    if (originalStartDate > dayPanel.Date)
                    {
                        dayPanel.BackColor = Color.White;
                    }

                    this.calendarTable.Controls.Add(dayPanel, week, dayOfWeek);
                    startDay++;
                }

                this.calendarTable.ColumnStyles[week].SizeType = SizeType.AutoSize;
            }
        }

        private void CalendarView_Load(object sender, EventArgs e)
        {
            this.Resize();
        }

        private new void Resize()
        {
            this.Width = (52 * BOX_SIZE) + (MARGIN * 2 * 52) + 5;
            this.Height = (7 * BOX_SIZE) + (MARGIN * 2 * 7) + 5 + this.cellMessage.Height;

            this.calendarTable.Width = (52 * BOX_SIZE) + (MARGIN * 2 * 52) + 5;
            this.calendarTable.Height = (7 * BOX_SIZE) + (MARGIN * 2 * 7) + 5;

            for (int i = 0; i != 7; i++)
            {
                this.calendarTable.RowStyles[i].SizeType = SizeType.AutoSize;
            }
        }

        private void Draw()
        {
            if (this.DataSource == null)
            {
                return;
            }

            foreach (ContributionItem item in this.DataSource)
            {
                DayPanel dayPanel = DayPanelFor(item.Date);
                if (dayPanel != null)
                {
                    dayPanel.Contribution = item;
                    dayPanel.BackColor = ColorProvider.GetColor(item, this.DataSource);
                }
            }
        }

        private DayPanel DayPanelFor(DateTime dateTime)
        {
            DayPanel dayPanel = null;
            for (int week = 0; week != DISPLAYED_WEEKS; week++)
            {
                for (int dayOfWeek = 0; dayOfWeek != 7; dayOfWeek++)
                {
                    dayPanel = (DayPanel)this.calendarTable.GetControlFromPosition(week, dayOfWeek);
                    
                    if (dayPanel != null && dayPanel.Date.ToString("yyyy-MM-dd").Equals(dateTime.ToString("yyyy-MM-dd")))
                    {
                        return dayPanel;
                    }
                }
            }

            return null;
        }
    }
}
