using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ComputeBodyMassIndexApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KilogramAndMeter : Page
    {
        public KilogramAndMeter()
        {
            this.InitializeComponent();
        }

        // CONSTANTS.
        double KILOGRAMS_PER_POUND = 0.45359237;
        double METERS_PER_INCH = 0.0254;

        double weight = 0;
        double height = 0;

        private void weight_SelectionChanged(object sender, RoutedEventArgs e)
        {
            weight = double.Parse(weightTextbox.Text);
        }

        private void heightTextbox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            height = double.Parse(heightTextbox.Text);
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            checkBMI();
        }

        // A function to calculate BMI
        public void checkBMI()
        {
            convertWeightAndHeight(weight, height);
            double bmi = weight / Math.Pow(height, 2);
            if (bmi < 18.5)
                result.Text = "BMI is " + bmi + "\nUnderweight";
            else if (bmi < 25)
                result.Text = "BMI is " + bmi + "\nNormal";
            else if (bmi < 30)
                result.Text = "BMI is " + bmi + "\nOverweight";
            else
                result.Text = "BMI is " + bmi + "\nObese";
        }


        // A method to convert Weight to Kilograms and Height to meters.
        public void convertWeightAndHeight(double w, double h)
        {
            if (weightUnits.SelectedIndex == 1)
                weight *= KILOGRAMS_PER_POUND;

            if (heightUnits.SelectedIndex == 1)
                height /= 100;
            else if (heightUnits.SelectedIndex == 2)
                height *= METERS_PER_INCH;
        }
    }
}
