using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Package_Manager
{
    /// <summary>
    /// Provides static methods for validating data.
    /// </summary>
    public static class Validator
    {
        private static string title = "Entry Error";

        /// <summary>
        /// The title that will appear in dialog boxes.
        /// </summary>
        public static string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        /// <summary>
        /// Checks whether the user entered a string length within a specified range int into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <param name="min">The minimum value for the range int.</param>
        /// <param name="max">The maximum value for the range int.</param>
        /// <returns>True if the user has entered a string length within the specified range.</returns>
        public static bool StringIsWithinRange(TextBox textBox, int min, int max)
        {
            int number = textBox.Text.Length;
            if (number < min || number > max)
            {
                MessageBox.Show(textBox.Tag + " must be between " + min
                    + " and " + max + " characters.", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }

        public static bool IsNonNegativeDecimal(TextBox tb)
        {
            bool isValid = true;
            decimal result; // for TryParse
            if (!Decimal.TryParse(tb.Text, out result)) // TryParse returned false
            {
                isValid = false;
                MessageBox.Show(tb.Tag + " must be a number");
                tb.SelectAll(); // select all content for replacement
                tb.Focus();
            }
            else // it's decimal value, but could be negative
            {
                if (result < 0)
                {
                    isValid = false;
                    MessageBox.Show(tb.Tag + " must be positive or zero");
                    tb.SelectAll(); // select all content for replacement
                    tb.Focus();
                }
            }
            return isValid;
        }

        /// <summary>
        /// Checks whether the user entered data into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <returns>True if the user has entered data.</returns>
        public static bool IsPresent(Control control)
        {
            if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox textBox = (TextBox)control;
                if (textBox.Text == "")
                {
                    MessageBox.Show(textBox.Tag + " is a required field.", Title);
                    textBox.Focus();
                    return false;
                }
            }
            else if (control.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                ComboBox comboBox = (ComboBox)control;
                if (comboBox.SelectedIndex == -1)
                {
                    MessageBox.Show(comboBox.Tag + " is a required field.", "Entry Error");
                    comboBox.Focus();
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks whether the user entered a decimal value into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <returns>True if the user has entered a decimal value.</returns>
        public static bool IsDecimal(TextBox textBox)
        {
            try
            {
                Convert.ToDecimal(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be a decimal number.", Title);
                textBox.Focus();
                return false;
            }
        }

        /// <summary>
        /// Checks whether the user entered an int value into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <returns>True if the user has entered an int value.</returns>
        public static bool IsInt32(TextBox textBox)
        {
            try
            {
                Convert.ToInt32(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be an integer.", Title);
                textBox.Focus();
                return false;
            }
        }

        /// <summary>
        /// Checks whether the user entered a value within a specified range into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <param name="min">The minimum value for the range.</param>
        /// <param name="max">The maximum value for the range.</param>
        /// <returns>True if the user has entered a value within the specified range.</returns>
        public static bool DecimalIsWithinRange(TextBox textBox, decimal min, decimal max)
        {
            string strippedBase = Regex.Replace(textBox.Text.ToString(), @"[^0-9.]+", "");
            decimal number = Convert.ToDecimal(strippedBase);
            if (number < min || number > max)
            {
                MessageBox.Show(textBox.Tag + " must be between " + min
                    + " and " + max + ".", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks whether the user entered a value within a specified range into a date time picker.
        /// </summary>
        /// <param name="dateTimePicker">The date time picker control to be validated.</param>
        /// <param name="min">The minimum value for the range.</param>
        /// <param name="max">The maximum value for the range.</param>
        /// <returns>True if the user has entered a value within the specified range.</returns>
        public static bool DateTimeIsWithinRange(DateTimePicker dateTimePicker, DateTime min, DateTime max)
        {
           DateTime date = Convert.ToDateTime(dateTimePicker.Value);
            if (date < min || date > max)
            {
                MessageBox.Show(dateTimePicker.Tag + " must be between " + min
                    + " and " + max + ".", Title);
                dateTimePicker.Focus();
                return false;
            }
            return true;
        }
    }
}