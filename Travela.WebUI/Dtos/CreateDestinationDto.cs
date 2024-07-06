namespace Travela.WebUI.Dtos
{
    public class CreateDestinationDto
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string ImageUrl { get; set; }
        public int CountDay { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        IFormFile Image { get; set; }
    }
}
