namespace ER_UI
{
    partial class ER_MainScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ER_MainScreen));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.CurrencyComboBox = new System.Windows.Forms.ComboBox();
            this.FlagPictureBox = new System.Windows.Forms.PictureBox();
            this.ratesDataGridView = new System.Windows.Forms.DataGridView();
            this.rate_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.syncCurrenciesButton = new System.Windows.Forms.Button();
            this.refreshRatesButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.syncToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.FlagPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratesChart)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CurrencyComboBox
            // 
            this.CurrencyComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CurrencyComboBox.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrencyComboBox.FormattingEnabled = true;
            this.CurrencyComboBox.ItemHeight = 17;
            this.CurrencyComboBox.Location = new System.Drawing.Point(714, 48);
            this.CurrencyComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.CurrencyComboBox.Name = "CurrencyComboBox";
            this.CurrencyComboBox.Size = new System.Drawing.Size(278, 25);
            this.CurrencyComboBox.TabIndex = 0;
            this.CurrencyComboBox.SelectedIndexChanged += new System.EventHandler(this.CurrencyComboBox_SelectedIndexChanged);
            // 
            // FlagPictureBox
            // 
            this.FlagPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FlagPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("FlagPictureBox.InitialImage")));
            this.FlagPictureBox.Location = new System.Drawing.Point(676, 50);
            this.FlagPictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FlagPictureBox.Name = "FlagPictureBox";
            this.FlagPictureBox.Size = new System.Drawing.Size(35, 26);
            this.FlagPictureBox.TabIndex = 1;
            this.FlagPictureBox.TabStop = false;
            // 
            // ratesDataGridView
            // 
            this.ratesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ratesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ratesDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ratesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ratesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rate_date,
            this.rate});
            this.ratesDataGridView.Location = new System.Drawing.Point(3, 3);
            this.ratesDataGridView.Name = "ratesDataGridView";
            this.ratesDataGridView.Size = new System.Drawing.Size(330, 525);
            this.ratesDataGridView.TabIndex = 3;
            // 
            // rate_date
            // 
            this.rate_date.DataPropertyName = "Key";
            this.rate_date.HeaderText = "Date";
            this.rate_date.Name = "rate_date";
            this.rate_date.ReadOnly = true;
            // 
            // rate
            // 
            this.rate.DataPropertyName = "Value";
            this.rate.HeaderText = "Rate";
            this.rate.Name = "rate";
            this.rate.ReadOnly = true;
            // 
            // ratesChart
            // 
            this.ratesChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.InterlacedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            chartArea1.AxisX.IsInterlaced = true;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.LabelStyle.Format = "d \\\\n MMM \\\\n yy";
            chartArea1.CursorY.Interval = 0.2D;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.LineWidth = 2;
            chartArea1.Name = "ChartArea1";
            this.ratesChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ratesChart.Legends.Add(legend1);
            this.ratesChart.Location = new System.Drawing.Point(365, 3);
            this.ratesChart.Margin = new System.Windows.Forms.Padding(0);
            this.ratesChart.Name = "ratesChart";
            this.ratesChart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.CustomProperties = "IsXAxisQuantitative=False";
            series1.EmptyPointStyle.IsValueShownAsLabel = true;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            series1.IsValueShownAsLabel = true;
            series1.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            series1.LabelToolTip = "#VALX";
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = System.Drawing.Color.Transparent;
            series1.Name = "Euro";
            series1.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.No;
            series1.SmartLabelStyle.CalloutStyle = System.Windows.Forms.DataVisualization.Charting.LabelCalloutStyle.Box;
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.ratesChart.Series.Add(series1);
            this.ratesChart.Size = new System.Drawing.Size(640, 525);
            this.ratesChart.TabIndex = 4;
            this.ratesChart.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.ratesDataGridView);
            this.panel1.Controls.Add(this.ratesChart);
            this.panel1.Location = new System.Drawing.Point(0, 149);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 540);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.syncCurrenciesButton);
            this.panel2.Controls.Add(this.refreshRatesButton);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.endDateTimePicker);
            this.panel2.Controls.Add(this.startDateTimePicker);
            this.panel2.Controls.Add(this.CurrencyComboBox);
            this.panel2.Controls.Add(this.FlagPictureBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 143);
            this.panel2.TabIndex = 6;
            // 
            // syncCurrenciesButton
            // 
            this.syncCurrenciesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.syncCurrenciesButton.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.syncCurrenciesButton.Location = new System.Drawing.Point(942, 12);
            this.syncCurrenciesButton.Name = "syncCurrenciesButton";
            this.syncCurrenciesButton.Size = new System.Drawing.Size(50, 30);
            this.syncCurrenciesButton.TabIndex = 7;
            this.syncCurrenciesButton.Text = "Sync";
            this.syncCurrenciesButton.UseVisualStyleBackColor = true;
            // 
            // refreshRatesButton
            // 
            this.refreshRatesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshRatesButton.FlatAppearance.BorderSize = 0;
            this.refreshRatesButton.Location = new System.Drawing.Point(898, 102);
            this.refreshRatesButton.Name = "refreshRatesButton";
            this.refreshRatesButton.Size = new System.Drawing.Size(94, 23);
            this.refreshRatesButton.TabIndex = 6;
            this.refreshRatesButton.Text = "Refresh rates";
            this.refreshRatesButton.UseVisualStyleBackColor = true;
            this.refreshRatesButton.Click += new System.EventHandler(this.RefreshRatesButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "End Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Start Date";
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(276, 50);
            this.endDateTimePicker.MaxDate = new System.DateTime(2018, 11, 21, 0, 0, 0, 0);
            this.endDateTimePicker.MinDate = new System.DateTime(2005, 7, 5, 0, 0, 0, 0);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(224, 25);
            this.endDateTimePicker.TabIndex = 3;
            this.endDateTimePicker.Value = new System.DateTime(2018, 11, 5, 0, 0, 0, 0);
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(15, 50);
            this.startDateTimePicker.MaxDate = new System.DateTime(2018, 11, 20, 0, 0, 0, 0);
            this.startDateTimePicker.MinDate = new System.DateTime(2005, 7, 4, 0, 0, 0, 0);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(228, 25);
            this.startDateTimePicker.TabIndex = 2;
            this.startDateTimePicker.Value = new System.DateTime(2018, 10, 23, 0, 0, 0, 0);
            // 
            // syncToolTip
            // 
            this.syncToolTip.AutomaticDelay = 200;
            this.syncToolTip.ToolTipTitle = "Sync Currencies";
            // 
            // ER_MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 689);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1024, 728);
            this.Name = "ER_MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exchange rate";
            this.Load += new System.EventHandler(this.ER_MainScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FlagPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratesChart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CurrencyComboBox;
        private System.Windows.Forms.PictureBox FlagPictureBox;
        private System.Windows.Forms.DataGridView ratesDataGridView;
        private System.Windows.Forms.DataVisualization.Charting.Chart ratesChart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button refreshRatesButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn rate_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn rate;
        private System.Windows.Forms.Button syncCurrenciesButton;
        private System.Windows.Forms.ToolTip syncToolTip;
    }
}

