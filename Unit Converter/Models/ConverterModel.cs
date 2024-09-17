using System.ComponentModel.DataAnnotations;

namespace Unit_Converter.Models
{
    public class ConverterModel
    {
        public string ConversionType { get; set; } // New property to determine which conversion type is selected

        // Length Conversion
        public double input_val { get; set; }
        public string input_unit { get; set; }
        public string output_unit { get; set; }
        public double output_val { get; set; }

        // Temperature Conversion
        public double temp_input_val { get; set; }
        public string temp_input_unit { get; set; }
        public string temp_output_unit { get; set; }
        public double temp_output_val { get; set; }

        // Number Base Conversion
        public string number_input_val { get; set; }
        public string number_input_base { get; set; }
        public string number_output_base { get; set; }
        public string number_output_val { get; set; }

        // Degrees to Radians Conversion
        public double degrees_input_val { get; set; }
        public double angle_output_val { get; set; }

        // Radians to Degrees Conversion
        public double radians_input_val { get; set; }
    }
}
