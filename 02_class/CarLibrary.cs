using Engine;

namespace CarLibrary
{
    public class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Vehicle(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }
    }

    public class Car : Vehicle
    {
        public string Color { get; set; }

        public V8Engine Engine { get; set; }

        public Car(string make, string model, int year, string color)
            : base(make, model, year)
        {
            Color = color;
            Engine = new V8Engine();
        }

        public void PressEngineBtn()
        {
            Console.WriteLine("🔑 Engine button pressed");
            if (Engine.IsRunning)
            {
                Engine.stop();
            }
            else
            {
                Engine.start();
            }
        }

        public void Display()
        {
            Console.WriteLine("Car: " + Make + " " + Model + " " + Year + " " + Color);
            Engine.Status();
        }
    }
}
