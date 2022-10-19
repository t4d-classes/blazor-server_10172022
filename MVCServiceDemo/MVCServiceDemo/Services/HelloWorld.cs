using MVCServiceDemo.Services.Interfaces;

namespace MVCServiceDemo.Services
{
  public class HelloWorldConsole: IHelloWorld
  {
    private static int _instanceCount = 0;

    public HelloWorldConsole()
    {
      _instanceCount++;

      Console.WriteLine("Hello World Instance Count: " + _instanceCount.ToString());
    }

    public void SayHello()
    {
      Console.WriteLine("Hello!");
    }
  }

  public class BonjourLeMondeConsole : IHelloWorld
  {

    public void SayHello()
    {
      Console.WriteLine("Bonjour, le monde!");
    }
  }
}
