using ER_Library;
using ER_Library.Helpers;
using ER_Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ER_UI
{
    public partial class ER_MainScreen : Form
    {

        //TODO - safecheck: empty lists, server connection, bnr connection
        List<CurrencyModel> currencyModels = new List<CurrencyModel>();
        CurrencyModel currentCurrency = new CurrencyModel();
        List<KeyValuePair<DateTime, decimal>> rates = new List<KeyValuePair<DateTime, decimal>>();

        enum PeriodSpan { Days, DoubleDays, Weeks, Months, Years}
        PeriodSpan selectedPeriod = PeriodSpan.Days;

        int skipValue = 1;

        public ER_MainScreen()
        {
            InitializeComponent();   
        }
        private void ER_MainScreen_Load(object sender, EventArgs e)
        {      
            syncToolTip.SetToolTip(syncCurrenciesButton, GlobalConfig.GetAppConfig("SyncToolTip"));
            InitializeCalendar();

            PopulateCurrencies();
            RefreshExchangeRates();
        }

        private void CurrencyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrencyComboBox.SelectedItem != null)
            {
                currentCurrency = CurrencyComboBox.SelectedItem as CurrencyModel;
                ratesChart.Series[0].Name = currentCurrency.currency_name;

                FlagPictureBox.Image = currentCurrency.Flag();                
            }            

            FlagPictureBox.Focus();
        }

        private void PopulateRatesGrid()
        {           
            ratesDataGridView.AutoGenerateColumns = false;
            ratesDataGridView.DataSource = rates;
        }

        private void PopulateRatesChart()
        {   
            ratesChart.Series[0].YValueMembers = "Value";
            ratesChart.Series[0].XValueMember = "Key";

            if (rates.Count() == 1)
            {
                rates.Add(new KeyValuePair<DateTime, decimal>(rates[0].Key.AddDays(-skipValue), rates[0].Value));               

                ratesChart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
                ratesChart.ChartAreas[0].AxisX.Title = rates[0].Key.ToLongDateString();
            }
            else
            {
                ratesChart.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
                ratesChart.ChartAreas[0].AxisX.Title = "";
            }

            ratesChart.DataSource = rates;           
            RatesChartRefreshPoints();            
        }

        private void RatesChartRefreshPoints()
        {
            ratesChart.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            ratesChart.ChartAreas[0].AxisY2.LabelStyle.Enabled = false;
      
            ratesChart.ChartAreas[0].AxisX.IntervalOffset = 0;

            decimal minRate;
            decimal maxRate;

            rates.Select(x => x.Value).ToList().GetMinMax(out minRate, out maxRate);

            ratesChart.ChartAreas[0].AxisY.Minimum = (double)minRate;
            ratesChart.ChartAreas[0].AxisY.Maximum = (double)maxRate;

            ratesChart.ChartAreas[0].AxisX.Minimum = rates[rates.Count() - 1].Key.ToOADate();
            ratesChart.ChartAreas[0].AxisX.Maximum = rates[0].Key.ToOADate();
            
            switch (selectedPeriod)
            {
                case PeriodSpan.Days:
                    ratesChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
                    ratesChart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;

                    if (endDateTimePicker.Value.Day % 2 == 1)
                    {
                        ratesChart.ChartAreas[0].AxisX.IntervalOffset = 1;
                    }
                    break;

                case PeriodSpan.DoubleDays:
                    ratesChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
                    ratesChart.ChartAreas[0].AxisX.LabelStyle.Interval = 2;

                    if (endDateTimePicker.Value.Day % 2 == 1)
                    {
                        ratesChart.ChartAreas[0].AxisX.IntervalOffset = 1;
                    }
                    break;

                case PeriodSpan.Weeks:
                    ratesChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Weeks;
                    ratesChart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;

                    if ((int)endDateTimePicker.Value.DayOfWeek != 7)
                    {
                        ratesChart.ChartAreas[0].AxisX.IntervalOffset = (int)endDateTimePicker.Value.DayOfWeek;
                    }
                    break;

                case PeriodSpan.Months:
                    ratesChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
                    ratesChart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;

                    if (endDateTimePicker.Value.Day != 1)
                    {
                        ratesChart.ChartAreas[0].AxisX.IntervalOffset = endDateTimePicker.Value.Day - 1;
                    }
                    break;

                case PeriodSpan.Years:
                    ratesChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Years;
                    ratesChart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;

                    if (endDateTimePicker.Value.DayOfYear != 1)
                    {
                        ratesChart.ChartAreas[0].AxisX.IntervalOffset = endDateTimePicker.Value.DayOfYear - 1;
                    }
                    break;
                default:
                    break;
            }

            //ratesChart.ChartAreas[0].AxisX.Interval = (ratesChart.ChartAreas[0].AxisX.Maximum - ratesChart.ChartAreas[0].AxisX.Minimum) / rates.Count();
            //ratesChart.ChartAreas[0].AxisX.IntervalOffset = 0;  


            List<DateTime> customLabels = rates.Select(x => x.Key).ToList();

            foreach (DateTime date in customLabels)
            {
                CustomLabel customLabel = new CustomLabel(date.ToOADate() - 2, date.ToOADate() + 2, "test", 0, LabelMarkStyle.None);
                ratesChart.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);
            }
        }

        private void SwitchPeriodSpan()
        {
            TimeSpan period = endDateTimePicker.Value - startDateTimePicker.Value;

            if (period.TotalDays <= 15)
            {
                selectedPeriod = PeriodSpan.Days;
                skipValue = 1;
            }
            else if (period.TotalDays <= 31)
            {
                selectedPeriod = PeriodSpan.DoubleDays;
                skipValue = 2;
            }
            else if (period.TotalDays <= 93)
            {
                selectedPeriod = PeriodSpan.Weeks;
                skipValue = 5;
            }
            else if (period.TotalDays <= 365)
            {
                selectedPeriod = PeriodSpan.Months;
                skipValue = 23;
            }
            else
            {
                selectedPeriod = PeriodSpan.Years;
                skipValue = 262;
            }
        }

        private void GetRates()
        {
            rates = ApiHelper.GetRates(
                startDateTimePicker.Value,
                endDateTimePicker.Value,
                currentCurrency.currency_id,
                skipValue);
        }

        private void PopulateCurrencies()
        {
            currencyModels = ApiHelper.GetCurrency();
            CurrencyComboBox.DisplayMember = "Info";
            CurrencyComboBox.ValueMember = "currency_id";
            CurrencyComboBox.DataSource = currencyModels;

            currentCurrency = currencyModels[0];
        }

        private void RefreshExchangeRates()
        {
            if (IsValidData())
            {
                SwitchPeriodSpan();
                GetRates();

                if (rates.Count() == 0)
                {
                    MessageBox.Show("No exchange rates available in the selected period");
                    return;
                }

                PopulateRatesGrid();
                PopulateRatesChart();
            }            
        }

        private void RefreshRatesButton_Click(object sender, EventArgs e)
        {
            RefreshExchangeRates();
        }

        private bool IsValidData()
        {
            if (startDateTimePicker.Value > endDateTimePicker.Value)
            {
                MessageBox.Show("Start date can't be higher than End date");
                return false;
            }
            return true;
        }

        private void InitializeCalendar()
        {
            // TODO - better with holiday list
            DateTime today = DateTime.Today;
            endDateTimePicker.MaxDate = today;
            startDateTimePicker.MaxDate = today;

            if (today.DayOfWeek >= DayOfWeek.Monday && today.DayOfWeek <= DayOfWeek.Friday)
            {
                endDateTimePicker.Value = today;
            }
            else
            {
                endDateTimePicker.Value = today.AddDays(5 - (int)today.DayOfWeek);                
            }
            startDateTimePicker.Value = endDateTimePicker.Value.AddDays(-7);            
        }
    }
}
