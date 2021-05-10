using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogEntryPage : ContentPage
    {
        string PhotoPath = null;
        public LogEntryPage()
        {
            InitializeComponent();
        }

        async void OnClick_TakePicture(object sender, EventArgs e)
        {
            var result = await MediaPicker.CapturePhotoAsync();
            if (result != null)
            {
                await LoadPhotoAsync(result);  //

                var stream = await result.OpenReadAsync();
                pictureImage.Source = ImageSource.FromStream(() => stream);
                //await DisplayAlert("Alert", PhotoPath, "OK");
            }
        }
        async Task LoadPhotoAsync(FileResult photo)
        {  // https://docs.microsoft.com/en-us/xamarin/essentials/media-picker?tabs=android
            // save Picture taken...
                // canceled
                if (photo == null)
            {
                PhotoPath = null;
                return;
            }
            // save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);

            PhotoPath = newFile;
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var logEntry = (Triplog)BindingContext;
            if (PhotoPath != null)
            {
                logEntry.ImageFile  = PhotoPath;
                PhotoPath = null;
            }
            TriplogDatabase database = await TriplogDatabase.Instance;
            await database.SaveLogEntryAsync(logEntry);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var logEntry = (Triplog)BindingContext;
            TriplogDatabase database = await TriplogDatabase.Instance;
            await database.DeleteLogEntryAsync(logEntry);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}