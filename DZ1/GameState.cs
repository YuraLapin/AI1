namespace DZ1
{
    internal class GameState
    {
        public int[,] gameField;
        public readonly int size = 3;

        private int emptyX = 0;
        private int emptyY = 0;

        public GameState()
        {
            this.gameField = new int[this.size, this.size];
        }

        public GameState(List<int> values)
        {
            if (values.Count != this.size * this.size)
            {
                throw new ArgumentException($"Array size must  be {size * size}");
            }

            this.gameField = new int[this.size, this.size];

            int k = 0;

            for (int i = 0; i < this.size; ++i)
            {
                for (int j = 0; j < this.size; ++j)
                {
                    this.gameField[i, j] = values[k];
                    ++k;
                }
            }
        }


        public int EvaluateState(GameState finalState)
        {
            int value = 0;

            for (int i = 0; i < this.size; ++i)
            {
                for (int j = 0; j < this.size; ++j)
                {
                    if (this.gameField[i, j] != finalState.gameField[i, j])
                    {
                        ++value;
                    }
                }
            }

            return value;
        }

        public bool CheckCompletion(GameState finalState)
        {
            for (int i = 0; i < this.size; ++i)
            {
                for (int j = 0; j < this.size; ++j)
                {
                    if (this.gameField[i, j] != finalState.gameField[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void findEmpty()
        {
            for (int i = 0; i < this.size; ++i)
            {
                for (int j = 0; j < this.size; ++j)
                {
                    if (this.gameField[i, j] == 0)
                    {
                        this.emptyX = i;
                        this.emptyY = j;
                    }
                }
            }
        }

        private GameState GetDeepCopy()
        {
            var copy = new GameState();

            for (int i = 0; i < this.size; ++i)
            {
                for (int j = 0; j < this.size; ++j)
                {
                    copy.gameField[i, j] = this.gameField[i, j];
                }
            }

            return copy;
        }

        private GameState moveUp()
        {
            var copy = this.GetDeepCopy();
            copy.findEmpty();

            var t = copy.gameField[copy.emptyX - 1, copy.emptyY];
            copy.gameField[copy.emptyX - 1, copy.emptyY] = 0;
            copy.gameField[copy.emptyX, copy.emptyY] = t;

            return copy;
        }

        private GameState moveRight()
        {
            var copy = this.GetDeepCopy();
            copy.findEmpty();

            var t = copy.gameField[copy.emptyX, copy.emptyY + 1];
            copy.gameField[copy.emptyX, copy.emptyY + 1] = 0;
            copy.gameField[copy.emptyX, copy.emptyY] = t;

            return copy;
        }

        private GameState moveDown()
        {
            var copy = this.GetDeepCopy();
            copy.findEmpty();

            var t = copy.gameField[copy.emptyX + 1, copy.emptyY];
            copy.gameField[copy.emptyX + 1, copy.emptyY] = 0;
            copy.gameField[copy.emptyX, copy.emptyY] = t;

            return copy;
        }

        private GameState moveLeft()
        {
            var copy = this.GetDeepCopy();
            copy.findEmpty();

            var t = copy.gameField[copy.emptyX, copy.emptyY - 1];
            copy.gameField[copy.emptyX, copy.emptyY - 1] = 0;
            copy.gameField[copy.emptyX, copy.emptyY] = t;

            return copy;
        }

        public List<GameState> GetNextMoves()
        {
            var nextMoves = new List<GameState>();

            try
            {
                nextMoves.Add(this.moveUp());
            }
            catch(IndexOutOfRangeException)
            {

            }

            try
            {
                nextMoves.Add(this.moveRight());
            }
            catch (IndexOutOfRangeException)
            {

            }

            try
            {
                nextMoves.Add(this.moveDown());
            }
            catch (IndexOutOfRangeException)
            {

            }

            try
            {
                nextMoves.Add(this.moveLeft());
            }
            catch (IndexOutOfRangeException)
            {

            }

            return nextMoves;
        }

        public bool IsIn(List<GameState> list)
        {
            foreach (var state in list)
            {
                if (this.CheckCompletion(state))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
