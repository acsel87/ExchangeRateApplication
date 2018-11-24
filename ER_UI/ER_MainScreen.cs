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
            decimal minRate;
            decimal maxRate;

            rates.Select(x => x.Value).ToList().GetMinMax(out minRate, out maxRate);

            ratesChart.ChartAreas[0].AxisY.Minimum = (double)minRate;
            ratesChart.ChartAreas[0].AxisY.Maximum = (double)maxRate;

            ratesChart.ChartAreas[0].AxisX.Minimum = rates[rates.Count() - 1].Key.ToOADate();
            ratesChart.ChartAreas[0].AxisX.Maximum = rates[0].Key.ToOADate();

            ratesChart.ChartAreas[0].AxisX.Interval = (ratesChart.ChartAreas[0].AxisX.Maximum - ratesChart.ChartAreas[0].AxisX.Minimum) / rates.Count();
           
            List<DateTime> customLabels = rates.Select(x => x.Key).ToList();
            ratesChart.ChartAreas[0].AxisX.CustomLabels.Clear();

            foreach (DateTime date in customLabels)
            {
                CustomLabel customLabel = new CustomLabel(date.ToOADate() - skipValue, date.ToOADate() + skipValue, date.ToString("d\nMMM\nyy"), 0, LabelMarkStyle.None);
                ratesChart.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);
            }
        }

        private void SwitchPeriodSpan()
        {
            TimeSpan period = endDateTimePicker.Value - startDateTimePicker.Value;

            if (period.TotalDays <= 15)
            {
                skipValue = 1;
            }
            else if (period.TotalDays <= 31)
            {
                skipValue = 2;
            }
            else if (period.TotalDays <= 93)
            {
                skipValue = 5;
            }
            else if (period.TotalDays <= 365)
            {
                skipValue = 23;
            }
            else
            {
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
                endDateTimePicker.Value = today.AddDays(((int)today.DayOfWeek + 6) % 5 - 3);                
            }
            startDateTimePicker.Value = endDateTimePicker.Value.AddDays(-7);            
        }
    }
}
