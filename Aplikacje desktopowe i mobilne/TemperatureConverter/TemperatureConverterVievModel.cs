using System;
using System.Collections.ObjectModel;

namespace TemperatureConverter
{
    class TemperatureConverterViewModel : BindableObject
    {
        private string convertedTemperature;
        public string ConvertedTemperature
        {
            get { return convertedTemperature; }
            set { convertedTemperature = value; OnPropertyChanged(); }
        }

        public ObservableCollection<string> Units { get; set; }

        private string selectedUnit;
        public string SelectedUnit
        {
            get { return selectedUnit; }
            set
            {
                selectedUnit = value;
                OnPropertyChanged(nameof(SelectedUnit));
            }
        }

        private string temperatureEntry;
        public string TemperatureEntry
        {
            get { return temperatureEntry; }
            set { temperatureEntry = value; OnPropertyChanged(); }
        }

        private Command convertedTemperatureCommand;
        public Command ConvertedTemperatureCommand
        {
            get { return convertedTemperatureCommand; }
            set { convertedTemperatureCommand = value; }
        }

        public TemperatureConverterViewModel()
        {
            Units = new ObservableCollection<string>
            {
                "Celsjusz",
                "Farenheit"
            };

            ConvertedTemperatureCommand = new Command(Convert);
            SelectedUnit = "Celsjusz";
        }

        private double ToCelsius(double temperature)
        {
            return Math.Round((temperature - 32) * (5.0 / 9.0), 0);
        }

        private double ToFarenheit(double temperature)
        {
            return Math.Round(((temperature * 1.8) + 32), 0);
        }

        public void Convert()
        {
            int temperature = Int32.Parse(TemperatureEntry);
            if (SelectedUnit == "Farenheit")
                ConvertedTemperature = ToCelsius(temperature).ToString() + " C";
            else if (SelectedUnit == "Celsjusz")
                ConvertedTemperature = ToFarenheit(temperature).ToString() + " F";
        }
    }
}
