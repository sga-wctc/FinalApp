using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogEntryListPage : ContentPage
    {
        public LogEntryListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            TriplogDatabase database = await TriplogDatabase.Instance;
            listView.ItemsSource = await database.GetLogEntryListAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogEntryPage
            {
                BindingContext = new Triplog()
            });
        }
        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new LogEntryPage
                {
                    BindingContext = e.SelectedItem as Triplog
                });
            }
        }
    }
}