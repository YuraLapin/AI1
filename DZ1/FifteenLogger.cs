namespace DZ1
{
    internal class FifteenLogger
    {
        public string divider = "------------------------------------------------------";

        public void Log(GameTreeData gameState, int tries, GameState finalState, double coef)
        {
            Console.WriteLine($"{tries}\n");
            Console.WriteLine(gameState.ToString(finalState, coef));
            Console.WriteLine(divider);
        }

        public void Log(GameTreeData gameState, GameState finalState, double coef)
        {
            Console.WriteLine(gameState.ToString(finalState, coef));
            Console.WriteLine(divider);
        }

        public void Log(GameTreeData gameState)
        {
            Console.WriteLine(gameState.ToString());
            Console.WriteLine(divider);
        }

        public void Log(List<GameTreeData> path, GameState finalState, double coef)
        {
            Console.WriteLine("\n\n\n" + divider);
            Console.WriteLine(divider);
            Console.WriteLine("Путь:");

            foreach (var node in path)
            {
                this.Log(node, finalState, coef);
            }

            Console.WriteLine($"Длина пути: {path.Count}");
        }
    }
}
