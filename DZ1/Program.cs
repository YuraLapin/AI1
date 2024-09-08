namespace DZ1
{
    public static class Program
    {
        public const double INFINITY = 9999999;

        public static int Main()
        {
            //var startingState = new GameState(new List<int> { 2, 4, 3, 1, 8, 5, 7, 0, 6 });
            //var finalState = new GameState(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 0 });

            var startingState = new GameState(new List<int> { 2, 1, 6, 4, 0, 8, 7, 5, 3 });
            var finalState = new GameState(new List<int> { 1, 2, 3, 8, 0, 4, 7, 6, 5 });

            var coef = 1.0;

            var solver = new GameSolver(startingState, finalState, coef);

            solver.Solve();

            return 0;
        }
    }
}