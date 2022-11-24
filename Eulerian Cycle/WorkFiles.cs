namespace Eulerian_Cycle
{
    internal static class WorkFiles
    {
        public static List<string> ReadInfromation(string path)
        {
            StreamReader reader = new(path);
            List<string> result = new();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();    

                if (!string.IsNullOrEmpty(line))
                {
                    result.Add(line);
                }
            }

            reader.Close();
            return result;
        }
    }
}
