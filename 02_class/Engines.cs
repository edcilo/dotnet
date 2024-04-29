namespace Engine
{
    public class Engine
    {
        protected string name = "Base engine";
        public bool IsRunning { get; set; }
        protected int HorsePower { get; set; }

        public void start()
        {
            IsRunning = true;
        }

        public void stop()
        {
            IsRunning = false;
        }

        public void Status()
        {
            Console.WriteLine("Engine(" + HorsePower + "HP)  is " + (IsRunning ? "running" : "stopped"));
        }
    }

    public class V8Engine : Engine
    {
        public V8Engine()
        {
            name = "V8 engine";
            HorsePower = 400;
        }
    }

    public class V6Engine : Engine
    {
        public V6Engine()
        {
            name = "V6 engine";
            HorsePower = 300;
        }
    }
}