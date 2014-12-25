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
using System.Globalization;

namespace ContributionGraph
{
    public partial class CalendarView : UserControl
    {
        public static readonly Color DEFAULT_COLOR = Color.FromArgb(240, 240, 240);
        private readonly int DISPLAYED_WEEKS = 53;
        private readonly int MARGIN = 1;
        private readonly int BOX_SIZE = 12;

        private readonly List<int> VisibleMonths = new List<int> { 0, 2, 5, 8, 11 };

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

        public DateTime EndDate { get; set; }
        
        public CalendarView()
        {
            InitializeComponent();
            SetDefaults();
            InitializeLayout();
        }

        private void CalendarView_Load(object sender, EventArgs e)
        {
            this.Resize();
        }

        protected void SetDefaults()
        {
            ColorProvider = new DiscreteWeightedColorProvider();
            EndDate = DateTime.Now;
        }

        protected void InitializeLayout()
        {
            DateTime startDate = EndDate.AddDays(-7 * DISPLAYED_WEEKS);
            DateTime originalStartDate = startDate;

            while (startDate.DayOfWeek != DayOfWeek.Monday)
            {
                startDate = startDate.AddDays(-1);
            }

            this.calendarTable.ColumnCount = DISPLAYED_WEEKS;
            this.calendarTable.ColumnStyles.Clear();
            for (int i = 0; i < DISPLAYED_WEEKS; i++)
            {
                this.calendarTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            }

            this.calendarTable.RowCount = 7;
            this.cellMessage.Text = string.Empty;
            this.BackColor = Color.White;

            // Fill Calendar Table with colored panels
            int startDay = 0;
            List<string> displayedMonths = new List<string>();
            for (int week = 0; week != DISPLAYED_WEEKS; week++)
            {
                DateTime dayPanelDate;
                DayPanel firstDayPanel = null;
                for (int dayOfWeek = 0; dayOfWeek != 7; dayOfWeek++)
                {
                    dayPanelDate = startDate.AddDays(startDay);
                    DayPanel dayPanel = new DayPanel(this.cellMessage, BOX_SIZE, MARGIN, DEFAULT_COLOR, dayPanelDate);

                    if (dayOfWeek == 0)
                    {
                        firstDayPanel = dayPanel;
                    }

                    if (originalStartDate > dayPanel.Date)
                    {
                        dayPanel.BackColor = Color.White;
                    }

                    this.calendarTable.Controls.Add(dayPanel, week, dayOfWeek);
                    startDay++;
                }

                // Put month label to the header
                DateTime firstDayOfWeek = startDate.AddDays(startDay - 7);
                int currentMonth = firstDayOfWeek.Month - 1;
                if (VisibleMonths.Contains(currentMonth) && !displayedMonths.Contains(firstDayOfWeek.ToString("yyyy-MM")))
                {
                    Label monthLabel = new Label();
                    monthLabel.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(currentMonth + 1);
                    monthLabel.Location = new System.Drawing.Point((week * BOX_SIZE) + (2 * MARGIN * week), 4);
                    monthLabel.ForeColor = Color.Gray;
                    this.Controls.Add(monthLabel);

                    displayedMonths.Add(firstDayOfWeek.ToString("yyyy-MM"));
                }

                this.calendarTable.ColumnStyles[week].SizeType = SizeType.AutoSize;
            }
        }

        protected new void Resize()
        {
            int headerMonthLabelHeight = 15;
            int padding = 5;

            this.Width = (DISPLAYED_WEEKS * BOX_SIZE) + (MARGIN * 2 * DISPLAYED_WEEKS) + padding;
            this.Height = (7 * BOX_SIZE) + (MARGIN * 2 * 7) + padding + this.cellMessage.Height + headerMonthLabelHeight;

            this.calendarTable.Width = (DISPLAYED_WEEKS * BOX_SIZE) + (MARGIN * 2 * DISPLAYED_WEEKS) + padding;
            this.calendarTable.Height = (7 * BOX_SIZE) + (MARGIN * 2 * 7) + padding;

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
