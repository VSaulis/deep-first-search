using System;

namespace DeepFirstSearch
{
    public class DeepFirstSearch {
        private readonly Maze _maze;
        private int _stepsCount = 0;

        public DeepFirstSearch(string filename) 
        {
            _maze = new Maze(filename);
        }

        public bool Start(int i, int j) {
            if (_maze.IsPositionValid(i, j)) {
                _maze.SetStatus(2, i, j);
            }
            bool status = Iterate(1, 2, i, j);
            _maze.PrintMaze();
            return status;
        }

        private bool Iterate(int depth, int step, int i, int j) {

            if (_maze.IsMazeEdge(i, j)) {
                _stepsCount++;
                Log.AddToLog(_stepsCount + ". " + new String('.', depth) + "Step : "+ step +". Maze edge reached.");
                return true;
            }

            foreach (Directions direction in Enum.GetValues(typeof(Directions))) {
                Tuple<int, int> newPosition = Move(direction, i, j);
                if (_maze.IsPositionValid(newPosition.Item1, newPosition.Item2)) {
                    if (_maze.IsPositionAvailable(newPosition.Item1, newPosition.Item2)) {
                        step++;
                        depth++;
                        _stepsCount++;
                        Log.AddToLog(_stepsCount + ". " + new String('.', depth) + "Step : " + step + ". Move to i : " + newPosition.Item1 + " j : " + newPosition.Item2);
                        _maze.SetStatus(step, newPosition.Item1, newPosition.Item2);
                        if (!Iterate(depth, step, newPosition.Item1, newPosition.Item2)) {
                            _stepsCount++;
                            Log.AddToLog(_stepsCount + ". " + new String('.', depth) + "Step : " + step + ". Unsuccessfull path. Backtracking.");
                            step--;
                            _maze.SetStatus(0, newPosition.Item1, newPosition.Item2);
                        }
                        else {
                            return true;
                        }
                    }
                    else {
                        _stepsCount++;
                        Log.AddToLog(_stepsCount + ". " + new String('.', depth) + "Step : " + step + ". Try to move to visited position.");
                    }
                }
                else {
                    _stepsCount++;
                    Log.AddToLog(_stepsCount + ". " + new String('.', depth) + "Step : " + step + ". Try to move out of maze.");
                }

            }

            return false;
        }

        private Tuple<int, int> Move(Directions direction, int i, int j) {
            switch (direction) {
                case Directions.Up:
                    i += 1;
                    break;
                case Directions.Right:
                    j += 1;
                    break;
                case Directions.Bottom:
                    i -= 1;
                    break;
                case Directions.Left:
                    j -= 1;
                    break;

            }
            return new Tuple<int, int>(i, j);
        }

        
    }
}
