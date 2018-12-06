using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grid.CellType;

namespace Grid
{
    class AStar
    {
        
        private Cell currentPosition = null;
        private List<Cell> openList = new List<Cell>();
        private List<Cell> closedList = new List<Cell>();
        private int g = 0;
        public GridManager gm2;
        static private Graphics dc;
        static private Rectangle displayRectangle;
        private GridManager map = new GridManager(dc, displayRectangle);

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
        public Cell CurrentPos
        {
            get { return currentPosition; }
            set { currentPosition = value; }
        }
        #endregion


        public void Search()
        {
            OpenList.Add(gm2.Start);

            while (OpenList.Count > 0)
            {
                int lowest = openList.Min(l=>l.F);
                currentPosition = openList.First(l => l.F == lowest);

                ClosedList.Add(currentPosition);
                OpenList.Remove(currentPosition);

                if (ClosedList.FirstOrDefault(l => l.X == gm2.Goal.X && l.Y == gm2.Goal.Y)!= null)
                    break;

                List<Cell> GetWalkableSquares = GetWalkableNodes(currentPosition.X, currentPosition.Y,map);
                g++;

                foreach (Cell GetWalkableSquare in GetWalkableSquares)
                {
                    if (closedList.FirstOrDefault(  l => l.X == GetWalkableSquare.X && l.Y == GetWalkableSquare.Y) != null)
                        continue;
                    if(openList.FirstOrDefault(l => l.X == GetWalkableSquare.X && l.Y == GetWalkableSquare.Y) != null)
                    {
                        GetWalkableSquare.G = g;
                        GetWalkableSquare.H = Cell.HScore(GetWalkableSquare.X, GetWalkableSquare.Y, gm2.Goal.X, gm2.Goal.Y);
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

        
        public List<Cell> GetWalkableNodes(int x, int y,GridManager map)
        {
            List<Cell> proposedLocations = new List<Cell>();
            {
                new Point { X = x, Y = y - 1 };
                new Point { X = x, Y = y + 1 };
                new Point { X = x - 1, Y = y };
                new Point { X = x + 1, Y = y };

            }

            return proposedLocations.Where(
        l => map.getCell(l.Y, l.X).MyType == CellType.EMPTY || map.getCell(l.Y, l.X).MyType == CellType.GOAL).ToList(); /*map[l.Y][l.X] == 'B').ToList()*//*;*/
        }

    }
}
