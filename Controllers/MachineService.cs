using GymSystem.Data;

namespace GymSystem.Controllers
{
    public class MachineService
    {
        public List<Machine> machinesInSystem = new List<Machine>()
        {
            new Machine()
            {
                machineName = "Bench Press",
                displayImageURL = "",
                utilization = new double[] {10, 40, 35, 65, 80, 50, 30, 3}
            },

            new Machine()
            {
                machineName = "Hamstring Curler",
                displayImageURL = "",
                utilization = new double[] {3, 10, 25, 50, 37, 48, 15, 3}
            },

            new Machine()
            {
                machineName = "Leg Press",
                displayImageURL = "",
                utilization = new double[] {7, 15, 33, 67, 48, 34, 17, 0}
            },

            new Machine()
            {
                machineName = "Lateral Pulldowns",
                displayImageURL = "",
                utilization = new double[] {35, 64, 100, 100, 93, 64, 47, 22}
            }
        };

        public async Task<List<Machine>> GetMachinesAsync()
        {
            await Task.Delay(1000);

            return machinesInSystem;
        }

        public void UpdateMachine(Machine machine)
        {

        }

        public Machine? GetMachineFromName(string name)
        {
            foreach(Machine machine in machinesInSystem)
            {
                if(machine.machineName == name)
                {
                    return machine;
                }
            }

            return null;
        }
     }
}
