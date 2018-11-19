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

            ratesChart.DataSource = rates;

            RatesChartRefreshGrid();
        }

        private void RatesChartRefreshGrid()
        {
            ratesChart.Series[0].IsValueShownAsLabel = true;
            ratesChart.ChartAreas[0].AxisX.IntervalOffset = 0;

            double minRate;
            double maxRate;

            rates.Select(x => x.Value).ToList().GetMinMax(out minRate, out maxRate);

            ratesChart.ChartAreas[0].AxisY.Minimum = minRate;
            ratesChart.ChartAreas[0].AxisY.Maximum = maxRate;

            ratesChart.ChartAreas[0].AxisX.Minimum = rates[rates.Count() - 1].Key.ToOADate();
            ratesChart.ChartAreas[0].AxisX.Maximum = rates[0].Key.ToOADate();

            //TODO - Fix intervals to depend on EndDate (also when only 1 day/year is selected)
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

            //ratesChart.ChartAreas[0].AxisX.IntervalOffset = 0;            
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
                skipValue = 7;
            }
            else if (period.TotalDays <= 365)
            {
                selectedPeriod = PeriodSpan.Months;
                skipValue = 31;
            }
            else
            {
                selectedPeriod = PeriodSpan.Years;
                skipValue = 365;
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
