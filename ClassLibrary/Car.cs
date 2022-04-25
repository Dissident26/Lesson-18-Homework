namespace ClassLibrary
{
    public class Car
    {
        public int Id { get; }
        public int OwnerId { get; set; }
        private int YearOfProduction { get; }
        private string Manufacturer { get; } = string.Empty;
        public string Colour { get; set; } = string.Empty;
        private string ModelName { get; } = string.Empty;

        public string GetInfo()
        {
            return $"This car is {Colour} {Manufacturer} {ModelName}, made in {YearOfProduction}.";
        }

        public Car(int id, int yearOfProduction, int ownerId, string manufacturer, string colour, string modelName)
        {
            Id = id;
            YearOfProduction = yearOfProduction;
            OwnerId = ownerId;
            Manufacturer = manufacturer;
            Colour = colour;
            ModelName = modelName;
        }
    }

    public class CarOwner {
        public int Id { get; }
        public string Name { get; }

        private List<int> OwnedCarsIds = new ();

        public void AddCar(int carId)
        {
            OwnedCarsIds.Add(carId);
        }

        public void RemoveCar(int carId)
        {
            OwnedCarsIds.Remove(carId);
        }

        public List<int> GetOwnedCrasIds()
        {
            return OwnedCarsIds;
        }

        public CarOwner(int id, string name, int[]? ownedCarIds)
        {
            Id = id;
            Name = name;

            if (ownedCarIds != null)
            {
                foreach (var carId in ownedCarIds)
                {
                    AddCar(carId);
                }
            }
        }
    }


}
