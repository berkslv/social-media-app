using Client.Models.Abstract;


namespace Client.Models
{
    public class UniversityModel: IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int FoundationYear { get; set; }
    }
}