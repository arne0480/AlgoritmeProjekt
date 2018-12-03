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

        public bool search (Cell currentNode)
        {
            List<Cell> surroundingNodes = GetAdjacentWalkableNodes(currentNode);
            surroundingNodes.Sort((cell1, cell2) => cell1.F.CompareTo(cell2.F));
            foreach (Cell cell in surroundingNodes)
            {

            }
            return;
        }
        public List<Cell> GetAdjacentWalkableNodes(Cell fromNode)
        {
            List<Cell> walkableNodes = new List<Cell>();
            IEnumerable<Point> nextLocation = GetAdjacentWalkableNodes(fromNode.Position);

            foreach  (Point location in nextLocation)
            {
                int x = location.X;
                int y = location.Y;

                if (x < 0 || x >= this.width || y < 0 || y >= this.height)
                    continue;
                Cell cell = this.nodes[x, y];
                if (!fromNode.WalkAble)
                    continue;
                if (cell.NodeState == NodeState.CLOSED)
                    continue;
                if(cell.NodeState == NodeState.EMPTY)
                {

                }
            }
        }
    }
}
