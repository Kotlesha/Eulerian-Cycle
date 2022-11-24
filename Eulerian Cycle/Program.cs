namespace Eulerian_Cycle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new(11, "graph.txt");
            Console.WriteLine(graph);
            Console.Write("Введите, пожалуйста, вершину: ");
            string vertex = Console.ReadLine();
            int number = int.Parse(vertex);
            Console.WriteLine($"Всевозможные эйлеровы цикл из вершины {number}:");
            graph.Run(number - 1);
        }
    }
}