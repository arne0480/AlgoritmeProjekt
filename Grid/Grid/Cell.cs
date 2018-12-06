using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grid.CellType;

namespace Grid
{
    enum CellType { START, GOAL, WALL, EMPTY, CLOSED };

    class Cell
    {
        /// <summary>
        /// The grid position of the cell
        /// </summary>

        private Point position;
        private int x;
        private int y;
        private int g;
        private int h;
        private int f;
        private Cell parentNode;
        private CellType nodeState;
        
        /// <summary>
        /// The size of the cell
        /// </summary>
        private int cellSize;

        /// <summary>
        /// The cell's sprite
        /// </summary>
        private Image sprite;

        #region Properties
        public CellType NodeState
        {
            get { return nodeState; }
            set { nodeState = value; }
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }
        public int G
        {
            get { return g; }
            set { g = value; }
        }
        public int H
        {
            get { return h; }
            set { h = value; }
        }
        public int F
        {
            get { return f; }
            set { f = value; }
        }

        public Cell ParentNode
        {
            get { return parentNode; }
            set { parentNode = value; }
        }


        #endregion



        /// <summary>
        /// Sets the celltype to empty as default
        /// </summary>
        CellType myType = EMPTY;

        /// <summary>
        /// The bounding rectangle of the cell
        /// </summary>
        public Rectangle BoundingRectangle
        {
            get
            {
                return new Rectangle(position.X * cellSize, position.Y * cellSize, cellSize, cellSize);
            }
        }



        /// <summary>
        /// The cell's constructor
        /// </summary>
        /// <param name="position">The cell's grid position</param>
        /// <param name="size">The cell's size</param>
        public Cell(Point position, int size)
        {
            //Sets the position
            this.position = position;

            //Sets the cell size
            this.cellSize = size;

        }

        public static int HScore(int x, int y, int targetX, int targetY)
        {
            return Math.Abs(targetX - x) + Math.Abs(targetY - y);
        }
        /// <summary>
        /// Renders the cell
        /// </summary>
        /// <param name="dc">The graphic context</param>
        public void Render(Graphics dc)
        {
            //Draws the rectangles color
            dc.FillRectangle(new SolidBrush(Color.White), BoundingRectangle);

            //Draws the rectangles border
            dc.DrawRectangle(new Pen(Color.Black), BoundingRectangle);

            //If the cell has a sprite, then we need to draw it
            if (sprite != null)
            {
                dc.DrawImage(sprite, BoundingRectangle);
            }


            //Write's the cells grid position
            dc.DrawString(string.Format("{0}", position), new Font("Arial", 7, FontStyle.Regular), new SolidBrush(Color.Black), position.X * cellSize, (position.Y * cellSize) + 10);
        }

        /// <summary>
        /// Clicks the cell
        /// </summary>
        /// <param name="clickType">The click type</param>
        public void Click(ref CellType clickType)
        {
            if (clickType == START) //If the click type is START
            {
                sprite = Image.FromFile(@"Images\Start.png");
                myType = clickType;
                clickType = GOAL;
                
            }
            else if (clickType == GOAL && myType != START) //If the click type is GOAL
            {
                sprite = Image.FromFile(@"Images\Goal.png");
                clickType = WALL;
                myType = GOAL;
                
            }
            else if (clickType == WALL && myType != START && myType != GOAL && myType != WALL) //If the click type is WALL
            {
                sprite = Image.FromFile(@"Images\Wall.png");
                myType = WALL;
            }
            else if (clickType == WALL && myType == WALL) //If the click type is WALL
            {
                sprite = null;
                myType = EMPTY;
            }
        }
    }
}
