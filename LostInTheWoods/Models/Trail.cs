using System.ComponentModel.DataAnnotations;
namespace LostInTheWoods.Models{
    public abstract class BaseEntity{}
    public class Trail : BaseEntity{
        [Key]
        public long Id{get;set;}
        [Required]
        public string trailName{get;set;}
        [MinLength(10)]
        public string Description{get;set;}
        [Range(0, double.MaxValue)]
        public double trailLength{get;set;}
        [Range(0, double.MaxValue)]
        public double elevationChange{get;set;}

        [Range(-180,180)]
        public double Longitude{get;set;}
        [Range(-90,90)]
        public double Latitude{get;set;}

        public Trail(string trailName, string Description, double trailLength, double elevationChange, double Longitude,double Latitude){
            this.trailName = trailName;
            this.Description = Description;
            this.trailLength = trailLength;
            this.elevationChange = elevationChange;
            this.Longitude = Longitude;
            this.Latitude = Latitude;
        }

    }
}