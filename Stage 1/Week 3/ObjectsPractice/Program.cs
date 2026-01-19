class Restaurant
    {
    private string name;
    public string Name
    {
    get { return name; }
    set { name = value; }
    }

    OR shorthand version

    public string Name
    {get; set;}


    public string cuisine;
    public int starRating;

    public Restaurant(string restaurantName)
    {
    name = restaurantName;
    }

    }


class Program
  {
    static voic Main(string[] args)
    {
     Restaurant Quiznos = new Restaurant("Quiznos");
     Console.WriteLine(Restaurant.Name);  //outputs "Quiznos"
     quiznos.cuisine = "Sandwiches";
     quiznos.starRating = 4;

     Restaurant Subway = new Restaurant();
     subway.Name = "Subway";
     subway.cuisine = "Sandwiches";
     subway.starRating = 4;
    }
    }
  }


class Restaurant
    {
    public string name;
    public string cuisine;
    public int starRating;

    public Restaurant(string restaurantName, string restaurantCuisine, int starRating)
    {
    name = restaurantName;
    cuisine = restaurantCuisine;
    starRating = restaurantStarRating;
    }

    }

class Program
  {
    static voic Main(string[] args)
    {
     Restaurant Quiznos = new Restaurant("Quiznos", "Sandwiches", 4);
     Console.WriteLine(Quiznos.name + " " + Quiznos.cuisine + " " + Quiznos.starRating);  //outputs "Quiznos Sandwhiches 4"

     Restaurant Subway = new Restaurant();
     subway.name = "Subway";
     subway.cuisine = "Sandwiches";
     subway.starRating = 4;
    }
    }