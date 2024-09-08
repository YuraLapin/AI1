using System.Collections;

namespace DZ1
{
    internal class GameTreeNode: IEnumerable<GameTreeNode>
    {
        public GameTreeData data;
        public GameTreeNode? parent;
        public List<GameTreeNode> children;

        public GameTreeNode(GameState gameState)
        {
            this.data = new GameTreeData(gameState);
            this.parent = null;
            this.children = new List<GameTreeNode>();
        }

        public GameTreeNode(GameState gameState, GameTreeNode parent)
        {
            this.data = new GameTreeData(gameState, parent.data.level + 1);
            this.parent = parent;
            this.children = new List<GameTreeNode>();
        }

        public GameTreeNode FindBestChild(List<GameState> choiceHistory, GameState finalState, double coef)
        {
            var curBestValue = Program.INFINITY;
            GameTreeNode? curBest = null;

            foreach (GameTreeNode node in this)
            {
                var curValue = node.data.EvaluateState(finalState, coef);

                if (curValue < curBestValue && node.children.Count == 0)
                {
                    if (!node.data.gameState.IsIn(choiceHistory))
                    {
                        curBest = node;
                        curBestValue = curValue;
                    }
                }
            }

            if (curBest == null)
            {
                throw new Exception("Game is unsolvable");
            }

            choiceHistory.Add(curBest.data.gameState);

            return curBest;
        }

        public IEnumerator<GameTreeNode> GetEnumerator()
        {
            yield return this;

            foreach (var child in children)
            {
                foreach (GameTreeNode data in child)
                {
                    yield return data;
                }
            }
        }

        public bool CheckCompletion(GameState finalState)
        {
            return this.data.CheckCompletion(finalState);
        }

        public void SpawnChildren(List<GameState> history)
        {
            var possibleMoves = this.data.gameState.GetNextMoves();

            foreach (var move in possibleMoves)
            {
                if (!move.IsIn(history))
                {
                    if (this.parent == null || !move.CheckCompletion(this.parent.data.gameState))
                    {
                        this.children.Add(new GameTreeNode(move, this));
                        history.Add(move);
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
