namespace Eulerian_Cycle
{
    internal class Graph
    {
        private int edges;
        private List<List<int>> vertices = new();

        public Graph(int count, string path)
        {
            for (int i = 0; i < count; i++)
            {
                vertices.Add(new List<int>());
            }

            List<string> information = WorkFiles.ReadInfromation(path);

            foreach (string line in information)
            {
                string[] numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int vertex_1 = int.Parse(numbers[0]) - 1, vertex_2 = int.Parse(numbers[1]) - 1;
                AddEdge(vertex_1, vertex_2);
            }

            edges = information.Count;
            information.Clear();
            information = null;
        }

        private void AddEdge(int vertex_1, int vertex_2)
        {
            vertices[vertex_1].Add(vertex_2);
            vertices[vertex_2].Add(vertex_1);
        }

        private void DeleteEdge(int vertex_1, int vertex_2)
        {
            vertices[vertex_1].Remove(vertex_2);
            vertices[vertex_2].Remove(vertex_1);
        }

        private bool CheckEdge(int vertex_1, int vertex_2)
        {
            if (vertices[vertex_1].Count == 1)
            {
                return true;
            }

            bool[] isVisited = new bool[vertices.Count];
            int count1 = dfsCount(vertex_1, isVisited);
            DeleteEdge(vertex_1, vertex_2);
            isVisited = new bool[vertices.Count];
            int count2 = dfsCount(vertex_1, isVisited);
            AddEdge(vertex_1, vertex_2);

            return count1 <= count2;
        }

        private int dfsCount(int vertex, bool[] isVisited)
        {
            int count = 1;
            isVisited[vertex] = true;

            foreach (int i in vertices[vertex])
            {
                if (!isVisited[i])
                {
                    count += dfsCount(i, isVisited);
                }
            }

            return count;
        }

        private int GetVertex(int vertex)
        {
            for (int i = 0; i < vertices[vertex].Count; i++)
            {
                int vertex_1 = vertices[vertex][i];
                if (CheckEdge(vertex, vertex_1))
                {
                    DeleteEdge(vertex, vertex_1);
                    return vertex_1;
                }
            }

            return -1;
        }

        public void Run(int vertex)
        {
            List<int> cycle = new();
            int count = 0;

            while (true)
            {
                int s = vertex + 1;
                cycle.Add(s);
                Console.Write($"{s} ");
                vertex = GetVertex(vertex);
                count++;

                if (count > edges)
                {
                    break;
                }
            }

            Console.WriteLine();
        }

        public override string ToString()
        {
            string result = string.Empty;
            result = string.Concat(result, "Список рёбер: \n");

            for (int i = 0; i < vertices.Count; i++)
            {
                string temp = string.Empty;

                for (int j = 0; j < vertices[i].Count; j++)
                {
                    temp = string.Concat(temp, i + 1, " -> ", vertices[i][j] + 1, "\n");
                }

                result = string.Concat(result, temp);
            }

            return result;
        }
    }
}
