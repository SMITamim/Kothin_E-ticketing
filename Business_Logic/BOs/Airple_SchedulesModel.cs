namespace BusinessLogic.BOs
{
    public class Airple_SchedulesModel
    {
        public int Id { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }

        public int AirplaneId { get; set; }
    }
}

