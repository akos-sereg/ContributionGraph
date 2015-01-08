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
        public delegate void ContributionSelectedEventHandler(ContributionItem contribution);
        public event ContributionSelectedEventHandler OnContributionSelected;

        #region Constants

        private readonly int MARGIN = 1;

        private readonly List<int> VisibleMonths = new List<int> { 0, 2, 5, 8, 11 };

        #endregion

        #region Properties

        public IColorProvider ColorProvider { get; set; }

        private Color _defaultColorHover;
        public Color DefaultColorHover
        {
            get
            {
                return _defaultColorHover;
            }
            set
            {
                _defaultColorHover = value;
                this.InitializeLayout();
                this.Resize();
            }
        }

        private Color _defaultColor;
        public Color DefaultColor 
        {
            get 
            {
                return _defaultColor;
            }
            set
            {
                _defaultColor = value;
                this.InitializeLayout();
                this.Resize();
            }
        }

        private int _cellSize;
        public int CellSize
        {
            get
            {
                return _cellSize;
            }
            set
            {
                _cellSize = value;
                this.InitializeLayout();
                this.Resize();
            }
        }

        private ContributionList _dataSource;
        public ContributionList DataSource {
            get
            {
                return _dataSource;
            }
            set
            {
                _dataSource = value;
                this.Reset();
                this.Draw();
            }
        }

        private int _displayedWeeks;
        public int DisplayedWeeks
        {
            get
            {
                return _displayedWeeks;
            }
            set
            {
                this._displayedWeeks = value;
                this.InitializeLayout();
                this.Resize();
            }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                this._endDate = value;
                this.InitializeLayout();
                this.Resize();
            }
        }

        #endregion

        #region Constructors

        public CalendarView()
        {
            SetDefaults();

            InitializeLayout();
        }

        #endregion

        #region Initialize

        private void CalendarView_Load(object sender, EventArgs e)
        {
        }

        protected void SetDefaults()
        {
            this.DefaultColor = Color.FromArgb(238, 238, 238);
            this.DefaultColorHover = Color.FromArgb(220, 220, 220);
            this.ColorProvider = new DiscreteWeightedColorProvider();
            this.EndDate = DateTime.Now;
            this.DisplayedWeeks = 53;
            this.CellSize = 12;
        }

        protected void InitializeLayout()
        {
            this.Controls.Clear();
            this.InitializeComponent();

            this.Cursor = Cursors.Hand;

            DateTime startDate = EndDate.AddDays(-7 * this.DisplayedWeeks);
            DateTime originalStartDate = startDate;

            while (startDate.DayOfWeek != DayOfWeek.Monday)
            {
                startDate = startDate.AddDays(-1);
            }

            this.calendarTable.ColumnCount = this.DisplayedWeeks + 1;
            this.calendarTable.ColumnStyles.Clear();
            for (int i = 0; i < this.DisplayedWeeks + 1; i++)
            {
                this.calendarTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            }

            this.calendarTable.RowCount = 7;
            this.cellMessage.Text = string.Empty;
            this.BackColor = Color.White;

            // Fill Calendar Table with colored panels
            int startDay = 0;
            List<string> displayedMonths = new List<string>();
            for (int week = 0; week != this.DisplayedWeeks + 1; week++)
            {
                DateTime dayPanelDate;
                DayPanel firstDayPanel = null;
                for (int dayOfWeek = 0; dayOfWeek != 7; dayOfWeek++)
                {
                    dayPanelDate = startDate.AddDays(startDay);
                    DayPanel dayPanel = new DayPanel(this.cellMessage, this.CellSize, MARGIN, this.DefaultColor, this.DefaultColor, this.DefaultColorHover, dayPanelDate);
                    dayPanel.Click += (x, y) => {
                        ContributionSelectedEventHandler eventHandler = this.OnContributionSelected;
                        if (eventHandler != null)
                        {
                            eventHandler(dayPanel.Contribution);
                        }
                    };

                    if (dayOfWeek == 0)
                    {
                        firstDayPanel = dayPanel;
                    }

                    if (originalStartDate > dayPanel.Date)
                    {
                        dayPanel.Color = Color.White;
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
                    monthLabel.Location = new System.Drawing.Point((week * this.CellSize) + (2 * MARGIN * week), 4);
                    monthLabel.ForeColor = Color.Gray;
                    this.Controls.Add(monthLabel);

                    displayedMonths.Add(firstDayOfWeek.ToString("yyyy-MM"));
                }

                this.calendarTable.ColumnStyles[week].SizeType = SizeType.AutoSize;
            }
        }

        #endregion

        #region Layout functions

        protected new void Resize()
        {
            int headerMonthLabelHeight = 15;
            int padding = 5;

            int width = ((this.DisplayedWeeks + 1) * this.CellSize) + (MARGIN * 2 * (this.DisplayedWeeks + 1)) + padding;
            int height = (7 * this.CellSize) + (MARGIN * 2 * 7) + padding + this.cellMessage.Height + headerMonthLabelHeight;

            this.MinimumSize = new Size(width, height);
            this.MaximumSize = new Size(width, height);

            this.Width = width;
            this.Height = height;

            this.calendarTable.Width = ((this.DisplayedWeeks + 1) * this.CellSize) + (MARGIN * 2 * (this.DisplayedWeeks + 1)) + padding;
            this.calendarTable.Height = (7 * this.CellSize) + (MARGIN * 2 * 7) + padding;

            for (int i = 0; i != 7; i++)
            {
                this.calendarTable.RowStyles[i].SizeType = SizeType.AutoSize;
            }

            // Cell Message positioning
            this.cellMessage.Location = new Point(5, (7 * this.CellSize) + (MARGIN * 2 * 7) + padding + headerMonthLabelHeight);
        }

        public void Reset()
        {
            for (int week = 0; week != this.DisplayedWeeks + 1; week++)
            {
                for (int dayOfWeek = 0; dayOfWeek != 7; dayOfWeek++)
                {
                    DayPanel dayPanel = (DayPanel)this.calendarTable.GetControlFromPosition(week, dayOfWeek);
                    dayPanel.Reset();
                }
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
                    dayPanel.Color = ColorProvider.GetColor(this.DefaultColor, item, this.DataSource);
                }
            }
        }

        #endregion

        #region Helpers

        private DayPanel DayPanelFor(DateTime dateTime)
        {
            DayPanel dayPanel = null;
            for (int week = 0; week != this.DisplayedWeeks + 1; week++)
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

        #endregion
    }
}
