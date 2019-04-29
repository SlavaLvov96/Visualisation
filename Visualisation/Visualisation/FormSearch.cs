using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visualisation
{
    public partial class FormSearch : Form
    {
        public FormSearch()
        {
            InitializeComponent();
        }

        private void avl_click(object sender, EventArgs e)
        {

        }

        private void binary_click(object sender, EventArgs e)
        {

        }

        private void interpolation_click(object sender, EventArgs e)
        {

        }

        private void linear_click(object sender, EventArgs e)
        {

        }

        private void numeral_click(object sender, EventArgs e)
        {

        }

        private void prev_click(object sender, EventArgs e)
        {

        }

        private void next_click(object sender, EventArgs e)
        {

        }
    }

    //класс вершин
    class Vertices
    {
        public int x, y;

        public Vertices(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    //класс дуг
    class Arcs
    {
        public int vertex1, vertex2;

        public Arcs(int vertex1, int vertex2)
        {
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
        }
    }

    //класс рисования
    class drawTree
    {
        Bitmap treeBitmap;
        Pen blackPen;
        Pen redPen;
        Pen greenPen;
        Graphics graphics;
        PointF pointf;
        Font font;
        Brush brush;
        public int radius = 20; //радиус окружности

        public drawTree(int width, int height)
        {
            treeBitmap = new Bitmap(width, height);
            graphics = Graphics.FromImage(treeBitmap);
            clearBitmap();
            blackPen = new Pen(Color.Black);
            blackPen.Width = 2;
            redPen = new Pen(Color.Red);
            redPen.Width = 2;
            greenPen = new Pen(Color.Green);
            greenPen.Width = 2;
            font = new Font("", 12);
            brush = Brushes.Black;
        }
        
        //получаем битмап
        public Bitmap GetBitmap()
        {
            return treeBitmap;
        }

        //очищаем битмап
        public void clearBitmap()
        {
            graphics.Clear(Color.White);
        }

        //рисуем вершины
        public void drawVertices(int x, int y, string number)
        {
            graphics.FillEllipse(Brushes.White, (x - radius), (y - radius), 2 * radius, 2 * radius);
            graphics.DrawEllipse(blackPen, (x - radius), (y - radius), 2 * radius, 2 * radius);
            pointf = new PointF(x - 9, y - 9);
            graphics.DrawString(number, font, brush, pointf);
        }

        //рисуем ребра
        public void drawArcs(Vertices vertices1,Vertices vertices2, Arcs arc,int numberArc)
        {
            if(arc.vertex1 == arc.vertex2)
            {
                graphics.DrawArc(greenPen, (vertices1.x - 2 * radius), (vertices1.y - 2 * radius), 2 * radius, 2 * radius, 90, 270);
                pointf = new PointF(vertices1.x - (int)(2.75 * radius), vertices1.y - (int)(2.75 * radius));
                graphics.DrawString(((char)('a' + numberArc)).ToString(), font, brush, pointf);
                drawVertices(vertices1.x, vertices1.y, (arc.vertex1 + 1).ToString());
            }
            else
            {
                graphics.DrawLine(greenPen, vertices1.x, vertices1.y, vertices2.x, vertices2.y);
                pointf = new PointF((vertices1.x + vertices2.x) / 2, (vertices1.y + vertices2.y) / 2);
                graphics.DrawString(((char)('a' + numberArc)).ToString(), font, brush, pointf);
                drawVertices(vertices1.x, vertices1.y, (arc.vertex1 + 1).ToString());
                drawVertices(vertices2.x, vertices2.y, (arc.vertex2 + 1).ToString());
            }
        }

        //нарисовать дерево поиска
        public void drawSearchTree(List<Vertices> V,List<Arcs> A)
        {
            //arcs
            for(int i=0;i<A.Count;i++)
            {
                if (A[i].vertex1 == A[i].vertex2)
                {
                    graphics.DrawArc(greenPen, (V[A[i].vertex1].x - 2 * radius), (V[A[i].vertex1].y - 2 * radius), 2 * radius, 2 * radius, 90, 270);
                    pointf = new PointF(V[A[i].vertex1].x - (int)(2.75 * radius), V[A[i].vertex1].y - (int)(2.75 * radius));
                    graphics.DrawString(((char)('a' + i)).ToString(), font, brush, pointf);
                }
                else
                {
                    graphics.DrawLine(greenPen, V[A[i].vertex1].x, V[A[i].vertex1].y, V[A[i].vertex2].x, V[A[i].vertex2].y);
                    pointf = new PointF((V[A[i].vertex1].x + V[A[i].vertex2].x)/ 2, (V[A[i].vertex1].y + V[A[i].vertex2].y) / 2);
                    graphics.DrawString(((char)('a' + i)).ToString(), font, brush, pointf);
                }
            }
            //vertices
            for(int i=0;i<V.Count;i++)
            {
                drawVertices(V[i].x, V[i].y, (i + 1).ToString());
            }
        }
    }
}
