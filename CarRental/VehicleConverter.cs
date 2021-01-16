using Newtonsoft.Json.Converters;
using System;

namespace CarRental
{
    public class VehicleConverter : CustomCreationConverter<Vehicle>
    {
        public override Vehicle Create(Type objectType)
        {
            return new Transporter();
        }
    }
}