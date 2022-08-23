using Client.Models.Abstract;


namespace Client.Models
{
    public class FacultyModel: IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Altitude { get; set; }
        public string Address { get; set; }
        public int UniversityId { get; set; }
    }
}