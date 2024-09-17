using Microsoft.AspNetCore.Mvc;
using Unit_Converter.Models;

namespace Unit_Converter.Controllers
{
    public class ConverterController : Controller
    {
        // GET: Index
        public IActionResult Index()
        {
            var model = new ConverterModel();
            return View(model);
        }

        // POST: Convert
        [HttpPost]
        public IActionResult Convert(ConverterModel model)
        {
            // Handle Length Conversion
            if (model.ConversionType == "Length")
            {
                model.output_val = ConvertLength(model.input_val, model.input_unit, model.output_unit);
            }

            // Handle Temperature Conversion
            else if (model.ConversionType == "Temperature")
            {
                model.temp_output_val = ConvertTemperature(model.temp_input_val, model.temp_input_unit, model.temp_output_unit);
            }

            // Handle Number Base Conversion
            else if (model.ConversionType == "NumberBase")
            {
                model.number_output_val = ConvertNumberBase(model.number_input_val, model.number_input_base, model.number_output_base);
            }

            // Handle Degrees to Radians Conversion
            else if (model.ConversionType == "DegreesToRadians")
            {
                model.angle_output_val = DegreesToRadians(model.degrees_input_val);
            }

            // Handle Radians to Degrees Conversion
            else if (model.ConversionType == "RadiansToDegrees")
            {
                model.angle_output_val = RadiansToDegrees(model.radians_input_val);
            }

            return View("Index", model);
        }

        // Conversion Methods
        private double ConvertLength(double value, string fromUnit, string toUnit)
        {
            // Conversion logic for length units
            double meters = value;
            switch (fromUnit)
            {
                case "kilometer":
                    meters = value * 1000;
                    break;
                case "centimeter":
                    meters = value / 100;
                    break;
                case "millimeter":
                    meters = value / 1000;
                    break;
                case "inch":
                    meters = value * 0.0254;
                    break;
                case "foot":
                    meters = value * 0.3048;
                    break;
                case "mile":
                    meters = value * 1609.344;
                    break;
            }
            switch (toUnit)
            {
                case "kilometer":
                    return meters / 1000;
                case "centimeter":
                    return meters * 100;
                case "millimeter":
                    return meters * 1000;
                case "inch":
                    return meters / 0.0254;
                case "foot":
                    return meters / 0.3048;
                case "mile":
                    return meters / 1609.344;
                default:
                    return meters;
            }
        }

        private double ConvertTemperature(double value, string fromUnit, string toUnit)
        {
            // Conversion logic for temperature units
            double celsius = value;
            switch (fromUnit)
            {
                case "K":
                    celsius = value - 273.15;
                    break;
                case "F":
                    celsius = (value - 32) * 5 / 9;
                    break;
            }
            switch (toUnit)
            {
                case "K":
                    return celsius + 273.15;
                case "F":
                    return celsius * 9 / 5 + 32;
                default:
                    return celsius;
            }
        }

        private string ConvertNumberBase(string value, string fromBase, string toBase)
        {
            // Convert value from the given base to decimal
            int decimalValue = System.Convert.ToInt32(value, fromBase switch
            {
                "binary" => 2,
                "octal" => 8,
                "decimal" => 10,
                "hexadecimal" => 16,
                _ => 10
            });

            // Convert decimal value to the target base
            return toBase switch
            {
                "binary" => System.Convert.ToString(decimalValue, 2),
                "octal" => System.Convert.ToString(decimalValue, 8),
                "decimal" => decimalValue.ToString(),
                "hexadecimal" => System.Convert.ToString(decimalValue, 16),
                _ => decimalValue.ToString()
            };
        }

        private double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

        private double RadiansToDegrees(double radians)
        {
            return radians * 180 / Math.PI;
        }
    }
}
