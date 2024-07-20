namespace GymSystem.Data
{
    [Serializable]
    public class Machine
    {
        public string? machineName {get; set;}
        public string? displayImageURL {get; set;}
        public double[]? utilization {get; set;}
        public DateTime? lastService { get; set; }
        public DateTime? warranty { get; set; }
        public List<MachineProblem>? problems { get; set; }
    }
}
