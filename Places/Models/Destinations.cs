using System.Collections.Generic;

namespace Places.Models
{
    public class Destination
    {
        public string CityName { get; set; }
        public string Description { get; set; }
        public int Id { get; }
        private static List<Destination> _instances = new List<Destination> { };

        public Destination(string cityName, string description)
        {
            CityName = cityName;
            Description = description;
            _instances.Add(this);
            Id = _instances.Count;
        }

        public static List<Destination> GetAll()
        {
            return _instances;
        }

        public static void ClearAll()
        {
            _instances.Clear();
        }

        public static Destination Find(int searchId)
        {
            return _instances[searchId - 1];
        }
    }
}
