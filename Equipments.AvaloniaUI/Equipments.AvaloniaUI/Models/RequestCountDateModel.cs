namespace Equipments.AvaloniaUI.Models
{
    public class RequestCountDateModel
    {
        public RequestCountDateModel(string date, int count)
        {
            Date = date;
            Count = count;
        }

        public string Date { get; set; }
        public int Count { get; set; }

    }
}
