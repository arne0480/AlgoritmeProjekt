using System;
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

                if (ClosedList.FirstOrDefault(l => l.X == EndPos.X && l.Y == EndPos.Y)! = null)
                    break;

            }
        }
        public List<Cell> GetWalkableNodes(int x, int y, GridManager map)
        {

        }

    }
}
