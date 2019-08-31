using OnnxOnXamarin.DependencyServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnnxOnXamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public int VisibilityInput { get; private set; }
        public int MagnitudeInput { get; private set; }
        public int WindInput { get; private set; }
        public int SignInput { get; private set; }
        public int ErrorInput { get; private set; }
        public int StabilityInput { get; private set; }

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var autoLandingDecider = DependencyService.Get<IShuttleAutoLand>();

            var mlResult = await autoLandingDecider.CanUseAutoLanding(VisibilityInput, ErrorInput, SignInput, WindInput, MagnitudeInput, VisibilityInput);

            if(mlResult)
            {
                label_Result.Text = "Auto-Landing";
            }
            else
            {
                label_Result.Text = "Manual Landing";
            }
        }

        private void Picker_VISIBILITY_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sender is Picker picker)) { return; }

            var selectIndex = picker.SelectedIndex;

            if(selectIndex != -1)
            {
                this.VisibilityInput = picker.SelectedIndex + 1;
            }
        }

        private void Picker_MAGNITUDE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sender is Picker picker)) { return; }

            var selectIndex = picker.SelectedIndex;

            if (selectIndex != -1)
            {
                this.MagnitudeInput = picker.SelectedIndex + 1;
            }
        }

        private void Picker_WIND_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sender is Picker picker)) { return; }

            var selectIndex = picker.SelectedIndex;

            if (selectIndex != -1)
            {
                this.WindInput = picker.SelectedIndex + 1;
            }
        }

        private void Picker_SIGN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sender is Picker picker)) { return; }

            var selectIndex = picker.SelectedIndex;

            if (selectIndex != -1)
            {
                this.SignInput = picker.SelectedIndex + 1;
            }
        }

        private void Picker_ERROR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sender is Picker picker)) { return; }

            var selectIndex = picker.SelectedIndex;

            if (selectIndex != -1)
            {
                this.ErrorInput = picker.SelectedIndex + 1;
            }
        }

        private void Picker_STABILITY_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sender is Picker picker)) { return; }

            var selectIndex = picker.SelectedIndex;

            if (selectIndex != -1)
            {
                this.StabilityInput = picker.SelectedIndex + 1;
            }
        }
    }
}
