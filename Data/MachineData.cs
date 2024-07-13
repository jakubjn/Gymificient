namespace GymSystem.Data
{
    [Serializable]
    public class MachineData
    {
        public string? machineName {get; set;}
        public string? displayImageURL {get; set;}
        public float utilization {get; set;}
    }
}
