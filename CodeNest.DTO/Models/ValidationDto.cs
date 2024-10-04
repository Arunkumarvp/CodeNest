namespace CodeNest.DTO.Models
{
    public class ValidationDto
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public JsonDto? JsonDto { get; set; } 
    }
}
