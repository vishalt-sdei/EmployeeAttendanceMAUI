using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendanceMAUI.Models
{
    internal class Position : BaseModel
    {
        public string Label { get; set; }
        public string Description { get; set; }

        private Location location;
        public Location Location
        {
            get => location;
            set
            {
                location = value;
                OnPropertyChanged(nameof(Location));
            }
        }
    }
}
