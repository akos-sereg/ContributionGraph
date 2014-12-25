namespace ContributionGraph
{
    partial class DemoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ContributionGraph.Controller.DiscreteWeightedColorProvider discreteWeightedColorProvider1 = new ContributionGraph.Controller.DiscreteWeightedColorProvider();
            this.calendarView1 = new ContributionGraph.CalendarView();
            this.SuspendLayout();
            // 
            // calendarView1
            // 
            this.calendarView1.BackColor = System.Drawing.Color.White;
            this.calendarView1.ColorProvider = discreteWeightedColorProvider1;
            this.calendarView1.DataSource = null;
            this.calendarView1.DisplayedWeeks = 53;
            this.calendarView1.EndDate = new System.DateTime(2014, 12, 25, 13, 35, 0, 589);
            this.calendarView1.Location = new System.Drawing.Point(12, 12);
            this.calendarView1.MaximumSize = new System.Drawing.Size(761, 131);
            this.calendarView1.MinimumSize = new System.Drawing.Size(761, 131);
            this.calendarView1.Name = "calendarView1";
            this.calendarView1.Size = new System.Drawing.Size(761, 131);
            this.calendarView1.TabIndex = 0;
            // 
            // DemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 175);
            this.Controls.Add(this.calendarView1);
            this.Name = "DemoForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private CalendarView calendarView1;
    }
}

