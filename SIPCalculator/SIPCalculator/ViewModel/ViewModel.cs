using System.ComponentModel;

namespace SIPCalculator.ViewModel
{
    /// <summary>
    /// View Model class for SIP calculator
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private double monthlyInvestment;
        private double timePeriod;
        private double expectedReturnRate;
        public double investedAmount;
        public double totalInvetment;
        public double result;
        double monthlyReturns;

        /// <summary>
        /// Gets or sets a value for monthly investment.
        /// </summary>
        public double MonthlyInvestment
        {
            get { return monthlyInvestment; }
            set
            {
                if (monthlyInvestment != value)
                {
                    monthlyInvestment = value;
                    MonthlyInvestmentSlider_ValueChanged(value);
                    OnPropertyChanged(nameof(MonthlyInvestment));
                }

            }
        }

        /// <summary>
        /// Gets or sets a value for SIP time period.
        /// </summary>
        public double TimePeriod
        {
            get { return timePeriod; }
            set
            {
                if (timePeriod != value)
                {
                    timePeriod = value;
                    TimePeroidSlider_ValueChanged(value);
                    OnPropertyChanged(nameof(TimePeriod));
                }

            }
        }
        
        /// <summary>
        /// Gets or sets a value for expected return rate.
        /// </summary>
        public double ExpectedReturnRate
        {
            get { return expectedReturnRate; }
            set
            {
                if (expectedReturnRate != value)
                {
                    expectedReturnRate = value;
                    ExpectedReturnSlider_ValueChanged(value);
                    OnPropertyChanged(nameof(ExpectedReturnRate));
                }

            }
        }

        /// <summary>
        /// Gets or sets a value for invested amount.
        /// </summary>
        public double InvestedAmount
        {
            get { return investedAmount; }
            set
            {
                if (investedAmount != value)
                {
                    investedAmount = value;
                    OnPropertyChanged(nameof(InvestedAmount));
                }

            }
        }

        /// <summary>
        /// Gets or sets a value total investment.
        /// </summary>
        public double TotalInvetment
        {
            get { return totalInvetment; }
            set
            {
                if (totalInvetment != value)
                {
                    totalInvetment = value;
                    OnPropertyChanged(nameof(TotalInvetment));
                }

            }
        }

        /// <summary>
        /// Gets or sets a value for the final result.
        /// </summary>
        public double EstimatedReturns
        {
            get { return result; }
            set
            {
                if (result != value)
                {
                    result = value;
                    OnPropertyChanged(nameof(EstimatedReturns));
                }

            }
        }

        /// <summary>
        /// Updates the values when the time period was changed.
        /// </summary>
        private void MonthlyInvestmentSlider_ValueChanged(double value)
        {
            MonthlyInvestment = value;
            InvestedAmount = MonthlyInvestment * 12 * TimePeriod;
            monthlyReturns = ExpectedReturnRate / (12 * 100);
            EstimatedReturns = MonthlyInvestment * ((Math.Pow(1 + monthlyReturns, TimePeriod * 12) - 1) / monthlyReturns) * (1 + monthlyReturns) - InvestedAmount;
            TotalInvetment = InvestedAmount + EstimatedReturns;
        }

        /// <summary>
        /// Updates the values when the expected return rate was changed.
        /// </summary>
        private void ExpectedReturnSlider_ValueChanged(double value)
        {
            ExpectedReturnRate = value;
            monthlyReturns = ExpectedReturnRate / (12 * 100);
            EstimatedReturns = MonthlyInvestment * ((Math.Pow(1 + monthlyReturns, TimePeriod * 12) - 1) / monthlyReturns) * (1 + monthlyReturns) - InvestedAmount;
            TotalInvetment = InvestedAmount + EstimatedReturns;
        }

        /// <summary>
        /// Updates the values when the time-period was changed.
        /// </summary>
        private void TimePeroidSlider_ValueChanged(double value)
        {
            TimePeriod = value;
            InvestedAmount = MonthlyInvestment * 12 * TimePeriod;
            monthlyReturns = expectedReturnRate / (12 * 100);
            EstimatedReturns = MonthlyInvestment * ((Math.Pow(1 + monthlyReturns, TimePeriod * 12) - 1) / monthlyReturns) * (1 + monthlyReturns) - InvestedAmount;
            TotalInvetment = InvestedAmount + EstimatedReturns;
        }

        /// <summary>
        /// Invokes the OnPropertyChanged method.
        /// </summary>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ViewModel()
        {
            monthlyInvestment = 25000;
            timePeriod = 10;
            expectedReturnRate = 12;
            InvestedAmount = MonthlyInvestment * 12 * TimePeriod;
            monthlyReturns = ExpectedReturnRate / (12 * 100);
            EstimatedReturns = MonthlyInvestment * ((Math.Pow(1 + monthlyReturns, TimePeriod * 12) - 1) / monthlyReturns) * (1 + monthlyReturns) - InvestedAmount;
            TotalInvetment = InvestedAmount + EstimatedReturns;
        }
    }
}
