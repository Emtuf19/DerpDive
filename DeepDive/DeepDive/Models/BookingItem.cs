using DeepDive.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DeepDive.Models
{
    public class BookingItem
    {
        public int BookingItemId { get; set; }

        public int BookingId { get; set; }
        [JsonIgnore]
        public Booking Booking { get; set; }

        public EquipmentType EquipmentType { get; set; }
        public int EquipmentId { get; set; }

        public EquipmentSize? SelectedSize { get; set; }
        public EquipmentGender? SelectedGender { get; set; }

        public double Price { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
