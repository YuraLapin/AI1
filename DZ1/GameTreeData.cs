using System.Text;

namespace DZ1
{
    internal class GameTreeData
    {
        public GameState gameState;
        public int level;

        public GameTreeData(GameState gameState)
        {
            this.gameState = gameState;
            this.level = 0;
        }

        public GameTreeData(GameState gameState, int level)
        {
            this.gameState = gameState;
            this.level = level;
        }

        public double EvaluateState(GameState finalState, double coef)
        {
            return coef * gameState.EvaluateState(finalState) + level;
        }

        public bool CheckCompletion(GameState finalState)
        {
            return this.gameState.CheckCompletion(finalState);
        }

        public string ToString(GameState finalState, double coef)
        {
            var sb = new StringBuilder();
            sb = sb.Append('\n');

            for (int i = 0; i < this.gameState.size; ++i)
            {
                for (int j = 0; j < this.gameState.size; ++j)
                {
                    sb = sb.Append(this.gameState.gameField[i, j].ToString() + ' ');
                }
                sb = sb.Append('\n');
            }

            sb = sb.Append($"\nh = {this.level}\n");
            sb = sb.Append($"J = {this.EvaluateState(finalState, coef)}\n");

            return sb.ToString();
        }
    }
}
