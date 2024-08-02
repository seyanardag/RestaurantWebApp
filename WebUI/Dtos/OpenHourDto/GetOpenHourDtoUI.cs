namespace WebUI.Dtos.OpenHourDto
{
    public class GetOpenHourDtoUI
    {
        public int Id { get; set; }
        public string OpenDays { get; set; }
        public string OpeningHour { get; set; }
        public string ClosingHour { get; set; }
        public bool IsActive { get; set; }
    }
}
