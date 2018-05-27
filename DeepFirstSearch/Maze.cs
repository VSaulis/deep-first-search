﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DeepFirstSearch {
    public class Maze {
        private readonly List<List<int>> _maze;
        private int _rowsCount;
        private int _colsCount;

        public Maze(string filename) {
            _maze = new List<List<int>>();
            ReadMazeFromFile(filename);
        }

        public void PrintMaze() {
            Log.AddToLog("");
            foreach (var row in _maze) {
                string toLog = "";
                foreach (var col in row) {
                    toLog += " " + col;
                    Console.Write(" " + col);
                }
                Log.AddToLog(toLog);
                Console.WriteLine();
            }
            Log.AddToLog("");
        }

        public bool IsMazeEdge(int i, int j) {
            if (i == 0 || j == 0 || (_rowsCount - 1) == i || (_colsCount - 1) == j) {
                return true;
            }
            else {
                return false;
            }
        }

        public bool IsPositionValid(int i, int j) {
            if (i > 0 && j > 0 && _rowsCount > i && _colsCount > j) {
                return true;
            }
            else {
                return false;
            }
        }

        public bool IsPositionAvailable(int i, int j) {
            if (_maze[i][j] == 0) {
                return true;
            }
            else {
                return false;
            }
        }

        public void SetStatus(int status, int i, int j) {
            _maze[i][j] = status;
        }

        private void ReadMazeFromFile(string filename) {
            _rowsCount = 0;
            _colsCount = 0;
            List<string> lines = File.ReadAllLines(filename).ToList();
            foreach (var line in lines) {
                _rowsCount++;
                List<int> row = new List<int>();
                foreach (char symbol in line) {
                    if (Char.IsNumber(symbol)) {
                        _colsCount++;
                        row.Add((int)Char.GetNumericValue(symbol));
                    }
                }

                _maze.Add(row);

            }
            _colsCount = _colsCount / _rowsCount;
        }
    }
}