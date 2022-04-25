using ClassLibrary;

string sampleText = @"Aliquam sagittis massa non est euismod maximus. Mauris tincidunt egestas sem, et eleifend est facilisis ac. 
Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Pellentesque luctus 
feugiat nisl, eu dapibus orci gravida maximus. Vestibulum est arcu, gravida sed dolor sed, pharetra dapibus 
quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nam commodo 
aliquet leo. Maecenas at eros at magna imperdiet dictum. Suspendisse potenti. Maecenas quis fringilla neque.
Nam sit amet molestie nisi, porttitor venenatis lorem. Curabitur tempor mauris non sagittis consectetur. 
In eleifend a leo id venenatis. Etiamz nec efficitur sem, non commodo tellus.";

// a

var word = Text.GetWordEndsWith(sampleText, "z");

Console.WriteLine(word);

// b

int[] intArray = new[] { 5, 8, 0, -1, 6, 4, -1, -3 };
var positiveCount = Arithmetics.GetAllPositivesCount(intArray);
var averageValue = Arithmetics.GetAvaragePositive(intArray);
Console.WriteLine("Array has {0} positive values.", positiveCount);
Console.WriteLine("Average positive value in array is {0}.", averageValue);
// c

string text = "Женя скоро будет свободен, а у вас все только начинается";

var removalResult = Text.RemoveChar(text, "о");
Console.WriteLine(removalResult);

// d 

List <Car> carsList = new()
{
    new Car(1, 1998, 1, "Honda", "Red", "Civic"),
    new Car(2, 2002, 2, "Honda", "Black", "Civic"),
    new Car(3, 2000, 1, "Toyota", "Blue", "Corola"),
    new Car(4, 2005, 2, "Toyota", "White", "Toundra"),
    new Car(5, 2007, 1, "Dodge", "Red", "Viper"),
    new Car(6, 1999, 3, "Subaru", "Green", "Forester"),
};

List<CarOwner> ownersList = new()
{
    new CarOwner(1, "First Owner", new[]{ 1, 3, 5 }),
    new CarOwner(2, "Second Owner",new[] { 2, 4 }),
    new CarOwner(3, "Third Owner", new[] { 1, 6 }),
    new CarOwner(4, "Fourth Owner", null),
    new CarOwner(5, "Fifth Owner", new[] { 5 }),
};

var carsByOwners = from owner in ownersList // join
                   join car in carsList on owner.Id equals car.OwnerId
                   select new CarSelection(owner.Name, car.GetInfo());

foreach (var item in carsByOwners)
{
    Console.WriteLine("Owner: {0}, Info: {1}", item.OwnerName, item.CarInfo);
}

var carsByColor = from car in carsList  // where
                  where car.Colour == "Red"
                  select car;

foreach (var item in carsByColor)
{
    Console.WriteLine(item.GetInfo());
}

Console.WriteLine("*** page 1 ***");
CarSelectionPaging<CarSelection>(carsByOwners, 2, 0);
Console.WriteLine("*** page 2 ***");
CarSelectionPaging<CarSelection>(carsByOwners, 4, 2);
Console.WriteLine("*** page 3 ***");
CarSelectionPaging<CarSelection>(carsByOwners, 6, 4);

void CarSelectionPaging<CarSelection>(IEnumerable<CarSelection> collection,int takeRange, int skipRange)
{   // take & skip
    var items = collection.Take(takeRange).Skip(skipRange);
    foreach (var item in items)
    {
        Console.WriteLine(item);
    };
}

class CarSelection
{
    public readonly string OwnerName, CarInfo;

    public CarSelection(string ownerName, string carInfo)
    {
        OwnerName = ownerName;
        CarInfo = carInfo;
    }

    public override string ToString()
    {
        return $"Property of {OwnerName}. {CarInfo}";
    }
}