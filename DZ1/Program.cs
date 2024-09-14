using System.Runtime.CompilerServices;

namespace DZ1
{
    public static class Program
    {
        public const double INFINITY = 9999999;

        public static int Main()
        {
            //var startingState = new GameState(new List<int> { 2, 4, 3, 1, 8, 5, 7, 0, 6 });
            //var finalState = new GameState(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 0 });

            //var startingState = new GameState(new List<int> { 2, 1, 6, 4, 0, 8, 7, 5, 3 });
            //var finalState = new GameState(new List<int> { 1, 2, 3, 8, 0, 4, 7, 6, 5 });

            var startingState = new GameState(new List<int> { 0, 8, 7, 6, 5, 4, 3, 2, 1 });
            var finalState = new GameState(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 0 });

            var coef = 1;

            var bestRes = INFINITY;
            double bestCoef = 1;

            //for (double i = 1; i <= 5; i += 0.1)
            //{
            //    var solver = new GameSolver(startingState, finalState, i);
            //    var curRes = solver.SolveSilently();

            //    Console.WriteLine($"{i}: {curRes}");

            //    if (curRes <= bestRes)
            //    {
            //        bestRes = curRes;
            //        bestCoef = i;
            //    }
            //}

            //Console.WriteLine($"\nЛучший коэффициент: {bestCoef}");

            var solver = new GameSolver(startingState, finalState, coef);
            solver.Solve();

            return 0;
        }
    }
}