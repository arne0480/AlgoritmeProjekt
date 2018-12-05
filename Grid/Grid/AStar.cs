﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid
{
    class AStar
    {
        
        private Cell currentPosition = null;
        private Cell startPos;//Set to start pos
        private Cell endPos; //Set to end pos
        private List<Cell> openList = new List<Cell>();
        private List<Cell> closedList = new List<Cell>();
        private int g = 0;

        #region Properties
        public List<Cell> OpenList
        {
            get { return openList; }
            set { openList = value; }
        }
        public List<Cell> ClosedList
        {
            get { return closedList; }
            set { closedList = value; }
        }
        public Cell StartPos
        {
            get { return startPos; }
            set { startPos = value; }
        }
        public Cell EndPos
        {
            get { return endPos; }
            set { endPos = value; }
        }
        public Cell CurrentPos
        {
            get { return currentPosition; }
            set { currentPosition = value; }
        }
        #endregion

        public void Search()
        {
            OpenList.Add(startPos);

            while (OpenList.Count > 0)
            {
                int lowest = openList.Min(l=>l.F);
                currentPosition = openList.First(l => l.F == lowest);

                ClosedList.Add(currentPosition);
                OpenList.Remove(currentPosition);

                if (ClosedList.FirstOrDefault(l => l.X == EndPos.X && l.Y == EndPos.Y)!= null)
                    break;

                List<Cell> GetWalkableSquares = GetWalkableNodes(currentPosition.X, currentPosition.Y,Grid);

                foreach (Cell GetWalkableSquare in GetWalkableSquares)
                {
                    if (closedList.FirstOrDefault(l => l.X == GetWalkableSquare.X && l.Y == GetWalkableSquare.Y) != null)
                        continue;
                    if(openList.FirstOrDefault(l => l.X == GetWalkableSquare.X && l.Y == GetWalkableSquare.Y) != null)
                    {
                        GetWalkableSquare.G = g;
                        GetWalkableSquare.H = Cell.HScore(GetWalkableSquare.X, GetWalkableSquare.Y, EndPos.X, EndPos.Y);
                        GetWalkableSquare.F = GetWalkableSquare.G + GetWalkableSquare.H;
                        GetWalkableSquare.ParentNode = currentPosition;

                        openList.Insert(0, GetWalkableSquare);
                    }

                    else if(g + GetWalkableSquare.H < GetWalkableSquare.F)
                    {
                        GetWalkableSquare.G = g;
                        GetWalkableSquare.F = GetWalkableSquare.G + GetWalkableSquare.H;
                        GetWalkableSquare.ParentNode = currentPosition;

                    }
                }

            }
        }

        
        public List<Cell> GetWalkableNodes(int x, int y, List<Cell> map)
        {
            List<Cell> proposedLocations = new List<Cell>();
            {


            }
            

        }

    }
}
