namespace Finall_ASP.NET.DTOs
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Cuisine { get; set; } = string.Empty;
        public double Rating { get; set; }
    }
}