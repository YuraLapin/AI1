namespace DZ1
{
    internal class FifteenLogger
    {
        public string divider = "------------------------------------------------------";

        public void Log(GameTreeData gameState, GameState finalState, double coef)
        {
            Console.WriteLine(gameState.ToString(finalState, coef));
            Console.WriteLine(divider);
        }
    }
}
