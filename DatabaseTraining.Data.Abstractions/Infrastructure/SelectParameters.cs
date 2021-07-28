namespace DatabaseTraining.Data.Abstractions.Infrastructure
{
    public class SelectParameters
    {
        public int? Skip { get; set; }

        public int? Take { get; set; }

        public OrderBy OrderBy { get; set; }
    }
}