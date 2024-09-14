namespace DZ1
{
    internal class GameSolver
    {
        public GameState rootState;
        public GameState finalState;

        public FifteenLogger logger;

        public double coef;
        public int tryLimit;

        public GameSolver()
        {
            this.tryLimit = 1000000;
            this.finalState = new GameState(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 0}) ;
            this.coef = 1;
            this.logger = new FifteenLogger();
        }

        public GameSolver(GameState startingState, GameState finalState, double coef) : this()
        {
            this.rootState = startingState;
            this.finalState = finalState;
            this.coef = coef;
            this.logger = new FifteenLogger();
        }

        public GameSolver(GameState startingState, GameState finalState, double coef, FifteenLogger logger) : this(startingState, finalState, coef)
        {
            this.logger = logger;
        }

        public void Solve()
        {
            var rootNode = new GameTreeNode(rootState);
            var curChild = rootNode;
            var tries = 1;
            logger.Log(curChild.data, tries, finalState, coef);


            var allChildren = new List<GameState>() { rootState };
            var choiceHistory = new List<GameState>() { };

            while (!curChild.CheckCompletion(finalState) && tries <= tryLimit)
            {
                curChild.SpawnChildren(allChildren);
                curChild = rootNode.FindBestChild(choiceHistory, finalState, coef);
                logger.Log(curChild.data, tries, finalState, coef);
                ++tries;
            }

            var path = new List<GameTreeData>();

            while (curChild.parent != null)
            {
                path.Add(curChild.data);
                curChild = curChild.parent;
            }

            path.Reverse();

            logger.Log(path, finalState, coef);
        }

        public int SolveSilently()
        {
            var rootNode = new GameTreeNode(rootState);
            var curChild = rootNode;
            var tries = 1;


            var allChildren = new List<GameState>() { rootState };
            var choiceHistory = new List<GameState>() { };

            while (!curChild.CheckCompletion(finalState) && tries <= tryLimit)
            {
                curChild.SpawnChildren(allChildren);
                curChild = rootNode.FindBestChild(choiceHistory, finalState, coef);
                ++tries;
            }

            return tries;
        }
    }
}
