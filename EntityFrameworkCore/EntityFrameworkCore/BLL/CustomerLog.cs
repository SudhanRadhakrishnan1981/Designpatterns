namespace EntityFrameworkCore.BLL
{
    public class CustomerLog
    {

        public CustomerLog() {

            DisplayMeasurement(-4);  // Output: Measured value is -4; too low.
            DisplayMeasurement(5);  // Output: Measured value is 5.
            DisplayMeasurement(30);  // Output: Measured value is 30; too high.
            DisplayMeasurement(double.NaN);  // Output: Failed measurement.
        }

        private string DisplayMeasurement(double measurement)
        {
            string returnvalue = string.Empty;
            switch (measurement)
            {
                case < 0.0:
                    returnvalue = $"Measured value is {measurement}; too low." ;
                    break;

                case > 15.0:
                    returnvalue= $"Measured value is {measurement}; too high.";
                    break;

                case double.NaN:
                    returnvalue = "Failed measurement.";
                    break;

                default:
                    returnvalue = $"Measured value is {measurement}.";
                    break;
            }

            string result = measurement switch
            {
                < 0.0 => $"Measured value is {measurement}; too low.",
                > 15.0 => $"Measured value is {measurement}; too high.",
                double.NaN => "Failed measurement.",
                _ => $"Measured value is {measurement}."
            };

            return returnvalue;
        }
    }
}
