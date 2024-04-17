using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendanceMAUI.ViewModel
{
    public class PunchPageViewModel : BaseViewModel
    {
        #region Constructor.
        // Initializes a PunchPageViewModel with navigation functionality.
        public PunchPageViewModel(INavigation navigation)
        {

            Navigation = navigation;
        }
        #endregion

        #region Punch Command.
        // Define a command property for executing the 'punch' action.
        private ICommand punchCommand;
        // Lazy initialization to ensure the command is created only when accessed.
        public ICommand PunchCommand
        {
            get => punchCommand ?? (punchCommand = new Command(async () => await ExecutePunchCommamd()));
        }
        // Method to execute punch command asynchronously.
        private async Task ExecutePunchCommamd()
        {
            await Task.CompletedTask;
        }
        #endregion

        #region Get Current Location Command.
        // Property for getting current location command,
        private ICommand getCurrentLocationCommand;
        // initializes command if not already set.
        public ICommand GetCurrentLocationCommand
        {
            get => getCurrentLocationCommand ?? (getCurrentLocationCommand = new Command(async () => await ExecuteGetCurrentLocationCommand()));
        }
        // Get the device's last known location asynchronously.
        private async Task ExecuteGetCurrentLocationCommand()
        {
            Location location = await Geolocation.Default.GetLastKnownLocationAsync();
            if (location != null)
            {
                CurrentLatitude = location.Latitude;
                CurrentLongitude = location.Longitude;
                // $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
                if (PositionPins == null)
                    PositionPins = new ObservableCollection<Models.Position>();
                PositionPins.Add(new Models.Position() { Location = location, Label = "Your current location", Description = "This is your current location" });
            }

        }
        #endregion

        #region Properties.
        // Retrieves the employee profile and provides access to it.
        public Models.EmployeeProfileResponse EmployeeProfile => Helper.Helper.EmployeeProfile;
        // Represents the current latitude.
        private double currentLatitude;
        // Gets or sets the current latitude, triggering property change notification.
        public double CurrentLatitude
        {
            get => currentLatitude;
            set
            {
                currentLatitude = value;
                OnPropertyChanged(nameof(CurrentLatitude));
            }
        }
        // Represents the current longitude coordinate, with property for accessing and updating it

        private double currentLongitude;
        public double CurrentLongitude
        {
            get => currentLongitude;
            set
            {
                currentLongitude = value;
                OnPropertyChanged(nameof(CurrentLongitude));
            }
        }
        // Represents a collection of position pins for tracking purposes.
        private ObservableCollection<Models.Position> positionPins;
        public ObservableCollection<Models.Position> PositionPins
        {
            get => positionPins;
            set
            {
                positionPins = value;
                OnPropertyChanged(nameof(PositionPins));
            }
        }


        #endregion

    }
}
