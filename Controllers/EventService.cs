using GymSystem.Data;

namespace GymSystem.Controllers
{
    public class EventService
    {
        public List<EventData> events = new List<EventData>();

        public async Task<List<EventData>> FetchEvents()
        {
            await Task.Delay(1000);

            return events;
        }

        public void NewEvent(EventData eventData)
        {
            events.Add(eventData);
        }

        public EventData? GetEventFromDate(DateTime date)
        {
            foreach (EventData eventData in events)
            {
                if (eventData.date == date) return eventData;
            }

            return null;
        }

        public void RemoveEvent(EventData eventData)
        {
            if (events.Contains(eventData))
            {
                events.Remove(eventData);
            }
        }
    }
}
