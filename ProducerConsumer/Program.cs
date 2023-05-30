namespace ProducerConsumer;

internal class Program
{
    private static void ProduceFunc()
    {
        int item = new Random().Next(100);
        Console.WriteLine($"Produced {item} on {Thread.CurrentThread.ManagedThreadId}");
        // work emulation
        Thread.Sleep(100);
    }

    private static void ConsumeAction(int item)
    {
        Console.WriteLine($"Consumed {item} on {Thread.CurrentThread.ManagedThreadId}");
        // work emulation
        Thread.Sleep(500);
    }

    private const int ProducersCount = 4;
    private const int ConsumersCount = 4;

    public static void Main(string[] args)
    {
        Console.WriteLine("Manager started");
        var manager = new Manager<int>(ProducersCount, ConsumersCount, ProduceFunc, ConsumeAction);

        manager.Start();

        Console.ReadKey(true);

        manager.Dispose();
        Console.WriteLine("Manager stopped");
    }
}
