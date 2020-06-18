using System;
using System.Collections.Generic;
using System.Text;

namespace PG.Models
{
    public class Photo : BaseModel
    {
        public Guid Id { get; set; }
        public Guid ClipId { get; set; }
        public virtual Clip Clip { get; set; }
        public String Title { get; set; }
        public String Subject { get; set; }
        public Int16 Sort { get; set; }
        public Int16 Rating { get; set; }
        public String Tags { get; set; }
        public String Comments { get; set; }
        public DateTime DateTaken { get; set; }
        public String Dimensions { get; set; }
        public String Width { get; set; }
        public String Height { get; set; }
        public String CameraMaker { get; set; }
        public String CameraModel { get; set; }
        public Decimal Latitude { get; set; }
        public Decimal Longitude { get; set; }
        public Decimal Altitude { get; set; }
        public Decimal Size { get; set; }
    }
}
