using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;

namespace FinalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebSearch : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public WebSearch()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}