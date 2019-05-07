using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Visualisation
    {
        public partial class FormGraph : Form
        {
            DrawGraph G;
            List<Vertex> V;
            List<Edge> E;
            int[,] AMatrix; //матрица смежности
            int[,] IMatrix; //матрица инцидентности

            int selected1; //выбранные вершины, для соединения линиями
            int selected2;

            public FormGraph()
            {
                InitializeComponent();
                V = new List<Vertex>();
                G = new DrawGraph(sheet.Width, sheet.Height);
                E = new List<Edge>();
                sheet.Image = G.GetBitmap();
            }

        class Vertex
        {
            public int x, y;

            public Vertex(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        class Edge
        {
            public int v1, v2;

            public Edge(int v1, int v2)
            {
                this.v1 = v1;
                this.v2 = v2;
            }
        }

        class DrawGraph
        {
            Bitmap bitmap;
            Pen blackPen;
            Pen redPen;
            Pen darkGoldPen;
            Graphics gr;
            Font fo;
            Brush br;
            PointF point;
            public int R = 20; //радиус окружности вершины

            public DrawGraph(int width, int height)
            {
                bitmap = new Bitmap(width, height);
                gr = Graphics.FromImage(bitmap);
                clearSheet();
                blackPen = new Pen(Color.Black);
                blackPen.Width = 2;
                redPen = new Pen(Color.Red);
                redPen.Width = 2;
                darkGoldPen = new Pen(Color.DarkGoldenrod);
                darkGoldPen.Width = 2;
                fo = new Font("Arial", 15);
                br = Brushes.Black;
            }

            public Bitmap GetBitmap()
            {
                return bitmap;
            }

            public void clearSheet()
            {
                gr.Clear(Color.White);
            }

            public void drawVertex(int x, int y, string number)
            {
                gr.FillEllipse(Brushes.White, (x - R), (y - R), 2 * R, 2 * R);
                gr.DrawEllipse(blackPen, (x - R), (y - R), 2 * R, 2 * R);
                point = new PointF(x - 9, y - 9);
                gr.DrawString(number, fo, br, point);
            }

            public void drawSelectedVertex(int x, int y)
            {
                gr.DrawEllipse(redPen, (x - R), (y - R), 2 * R, 2 * R);
            }

            public void drawEdge(Vertex V1, Vertex V2, Edge E, int numberE)
            {
                if (E.v1 == E.v2)
                {
                    gr.DrawArc(darkGoldPen, (V1.x - 2 * R), (V1.y - 2 * R), 2 * R, 2 * R, 90, 270);
                    point = new PointF(V1.x - (int)(2.75 * R), V1.y - (int)(2.75 * R));
                    gr.DrawString(((char)('a' + numberE)).ToString(), fo, br, point);
                    drawVertex(V1.x, V1.y, (E.v1 + 1).ToString());
                }
                else
                {
                    gr.DrawLine(darkGoldPen, V1.x, V1.y, V2.x, V2.y);
                    point = new PointF((V1.x + V2.x) / 2, (V1.y + V2.y) / 2);
                    gr.DrawString(((char)('a' + numberE)).ToString(), fo, br, point);
                    drawVertex(V1.x, V1.y, (E.v1 + 1).ToString());
                    drawVertex(V2.x, V2.y, (E.v2 + 1).ToString());
                }
            }

            public void drawALLGraph(List<Vertex> V, List<Edge> E)
            {
                //рисуем ребра
                for (int i = 0; i < E.Count; i++)
                {
                    if (E[i].v1 == E[i].v2)
                    {
                        gr.DrawArc(darkGoldPen, (V[E[i].v1].x - 2 * R), (V[E[i].v1].y - 2 * R), 2 * R, 2 * R, 90, 270);
                        point = new PointF(V[E[i].v1].x - (int)(2.75 * R), V[E[i].v1].y - (int)(2.75 * R));
                        gr.DrawString(((char)('a' + i)).ToString(), fo, br, point);
                    }
                    else
                    {
                        gr.DrawLine(darkGoldPen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x, V[E[i].v2].y);
                        point = new PointF((V[E[i].v1].x + V[E[i].v2].x) / 2, (V[E[i].v1].y + V[E[i].v2].y) / 2);
                        gr.DrawString(((char)('a' + i)).ToString(), fo, br, point);
                    }
                }
                //рисуем вершины
                for (int i = 0; i < V.Count; i++)
                {
                    drawVertex(V[i].x, V[i].y, (i + 1).ToString());
                }
            }

            //заполняет матрицу смежности
            public void fillAdjacencyMatrix(int numberV, List<Edge> E, int[,] matrix)
            {
                for (int i = 0; i < numberV; i++)
                    for (int j = 0; j < numberV; j++)
                        matrix[i, j] = 0;
                for (int i = 0; i < E.Count; i++)
                {
                    matrix[E[i].v1, E[i].v2] = 1;
                    matrix[E[i].v2, E[i].v1] = 1;
                }
            }

            //заполняет матрицу инцидентности
            public void fillIncidenceMatrix(int numberV, List<Edge> E, int[,] matrix)
            {
                for (int i = 0; i < numberV; i++)
                    for (int j = 0; j < E.Count; j++)
                        matrix[i, j] = 0;
                for (int i = 0; i < E.Count; i++)
                {
                    matrix[E[i].v1, i] = 1;
                    matrix[E[i].v2, i] = 1;
                }
            }


        }
    
        //кнопка - выбрать вершину
        private void selectButton_Click_1(object sender, EventArgs e)
        {
            selectButton.Enabled = false;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
            selected1 = -1;
        }

        //кнопка - рисовать вершину
        private void drawVertexButton_Click_1(object sender, EventArgs e)
        {
            drawVertexButton.Enabled = false;
            selectButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }

        //кнопка - рисовать ребро
        private void drawEdgeButton_Click_1(object sender, EventArgs e)
        {
            drawEdgeButton.Enabled = false;
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            deleteButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
            selected1 = -1;
            selected2 = -1;
        }

        //кнопка - удалить элемент
        private void deleteButton_Click_1(object sender, EventArgs e)
        {
            deleteButton.Enabled = false;
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }

        //кнопка - удалить граф
        private void deleteALLButton_Click_1(object sender, EventArgs e)
        {
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            const string message = "Вы действительно хотите полностью удалить граф?";
            const string caption = "Удаление";
            var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (MBSave == DialogResult.Yes)
            {
                V.Clear();
                E.Clear();
                G.clearSheet();
                sheet.Image = G.GetBitmap();
            }
        }

        //кнопка - матрица смежности
        private void buttonAdj_Click_1(object sender, EventArgs e)
        {
            createAdjAndOut();
        }

        //кнопка - матрица инцидентности 
        private void buttonInc_Click_1(object sender, EventArgs e)
        {
            createIncAndOut();
        }

        //поиск элементарных циклов
        private void cycleButton_Click_1(object sender, EventArgs e)
        {
            listBoxMatrix.Items.Clear();
            //1-white 2-black
            int[] color = new int[V.Count];
            for (int i = 0; i < V.Count; i++)
            {
                for (int k = 0; k < V.Count; k++)
                    color[k] = 1;
                List<int> cycle = new List<int>();
                cycle.Add(i + 1);
                DFScycle(i, i, E, color, -1, cycle);
            }
        }

        private void sheet_MouseClick(object sender, MouseEventArgs e)
            {
                //нажата кнопка "выбрать вершину", ищем степень вершины
                if (selectButton.Enabled == false)
                {
                    for (int i = 0; i < V.Count; i++)
                    {
                        if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                        {
                            if (selected1 != -1)
                            {
                                selected1 = -1;
                                G.clearSheet();
                                G.drawALLGraph(V, E);
                                sheet.Image = G.GetBitmap();
                            }
                            if (selected1 == -1)
                            {
                                G.drawSelectedVertex(V[i].x, V[i].y);
                                selected1 = i;
                                sheet.Image = G.GetBitmap();
                                createAdjAndOut();
                                listBoxMatrix.Items.Clear();
                                int degree = 0;
                                for (int j = 0; j < V.Count; j++)
                                    degree += AMatrix[selected1, j];
                                listBoxMatrix.Items.Add("Степень вершины №" + (selected1 + 1) + " равна " + degree);
                                break;
                            }
                        }
                    }
                }
                //нажата кнопка "рисовать вершину"
                if (drawVertexButton.Enabled == false)
                {
                    V.Add(new Vertex(e.X, e.Y));
                    G.drawVertex(e.X, e.Y, V.Count.ToString());
                    sheet.Image = G.GetBitmap();
                }
                //нажата кнопка "рисовать ребро"
                if (drawEdgeButton.Enabled == false)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        for (int i = 0; i < V.Count; i++)
                        {
                            if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                            {
                                if (selected1 == -1)
                                {
                                    G.drawSelectedVertex(V[i].x, V[i].y);
                                    selected1 = i;
                                    sheet.Image = G.GetBitmap();
                                    break;
                                }
                                if (selected2 == -1)
                                {
                                    G.drawSelectedVertex(V[i].x, V[i].y);
                                    selected2 = i;
                                    E.Add(new Edge(selected1, selected2));
                                    G.drawEdge(V[selected1], V[selected2], E[E.Count - 1], E.Count - 1);
                                    selected1 = -1;
                                    selected2 = -1;
                                    sheet.Image = G.GetBitmap();
                                    break;
                                }
                            }
                        }
                    }
                    if (e.Button == MouseButtons.Right)
                    {
                        if ((selected1 != -1) &&
                            (Math.Pow((V[selected1].x - e.X), 2) + Math.Pow((V[selected1].y - e.Y), 2) <= G.R * G.R))
                        {
                            G.drawVertex(V[selected1].x, V[selected1].y, (selected1 + 1).ToString());
                            selected1 = -1;
                            sheet.Image = G.GetBitmap();
                        }
                    }
                }
                //нажата кнопка "удалить элемент"
                if (deleteButton.Enabled == false)
                {
                    bool flag = false; //удалили ли что-нибудь по ЭТОМУ клику
                                       //ищем, возможно была нажата вершина
                    for (int i = 0; i < V.Count; i++)
                    {
                        if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                        {
                            for (int j = 0; j < E.Count; j++)
                            {
                                if ((E[j].v1 == i) || (E[j].v2 == i))
                                {
                                    E.RemoveAt(j);
                                    j--;
                                }
                                else
                                {
                                    if (E[j].v1 > i) E[j].v1--;
                                    if (E[j].v2 > i) E[j].v2--;
                                }
                            }
                            V.RemoveAt(i);
                            flag = true;
                            break;
                        }
                    }
                    //ищем, возможно было нажато ребро
                    if (!flag)
                    {
                        for (int i = 0; i < E.Count; i++)
                        {
                            if (E[i].v1 == E[i].v2) //если это петля
                            {
                                if ((Math.Pow((V[E[i].v1].x - G.R - e.X), 2) + Math.Pow((V[E[i].v1].y - G.R - e.Y), 2) <= ((G.R + 2) * (G.R + 2))) &&
                                    (Math.Pow((V[E[i].v1].x - G.R - e.X), 2) + Math.Pow((V[E[i].v1].y - G.R - e.Y), 2) >= ((G.R - 2) * (G.R - 2))))
                                {
                                    E.RemoveAt(i);
                                    flag = true;
                                    break;
                                }
                            }
                            else //не петля
                            {
                                if (((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) <= (e.Y + 4) &&
                                    ((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) >= (e.Y - 4))
                                {
                                    if ((V[E[i].v1].x <= V[E[i].v2].x && V[E[i].v1].x <= e.X && e.X <= V[E[i].v2].x) ||
                                        (V[E[i].v1].x >= V[E[i].v2].x && V[E[i].v1].x >= e.X && e.X >= V[E[i].v2].x))
                                    {
                                        E.RemoveAt(i);
                                        flag = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    //если что-то было удалено, то обновляем граф на экране
                    if (flag)
                    {
                        G.clearSheet();
                        G.drawALLGraph(V, E);
                        sheet.Image = G.GetBitmap();
                    }
                }
            }

            //создание матрицы смежности и вывод в листбокс
            private void createAdjAndOut()
            {
                AMatrix = new int[V.Count, V.Count];
                G.fillAdjacencyMatrix(V.Count, E, AMatrix);
                listBoxMatrix.Items.Clear();
                string sOut = "    ";
                for (int i = 0; i < V.Count; i++)
                    sOut += (i + 1) + " ";
                listBoxMatrix.Items.Add(sOut);
                for (int i = 0; i < V.Count; i++)
                {
                    sOut = (i + 1) + " | ";
                    for (int j = 0; j < V.Count; j++)
                        sOut += AMatrix[i, j] + " ";
                    listBoxMatrix.Items.Add(sOut);
                }
            }

            //создание матрицы инцидентности и вывод в листбокс
            private void createIncAndOut()
            {
                if (E.Count > 0)
                {
                    IMatrix = new int[V.Count, E.Count];
                    G.fillIncidenceMatrix(V.Count, E, IMatrix);
                    listBoxMatrix.Items.Clear();
                    string sOut = "    ";
                    for (int i = 0; i < E.Count; i++)
                        sOut += (char)('a' + i) + " ";
                    listBoxMatrix.Items.Add(sOut);
                    for (int i = 0; i < V.Count; i++)
                    {
                        sOut = (i + 1) + " | ";
                        for (int j = 0; j < E.Count; j++)
                            sOut += IMatrix[i, j] + " ";
                        listBoxMatrix.Items.Add(sOut);
                    }
                }
                else
                    listBoxMatrix.Items.Clear();
            }

            //поиск элементарных цепей
            private void chainButton_Click(object sender, EventArgs e)
            {
                listBoxMatrix.Items.Clear();
                //1-white 2-black
                int[] color = new int[V.Count];
                for (int i = 0; i < V.Count - 1; i++)
                    for (int j = i + 1; j < V.Count; j++)
                    {
                        for (int k = 0; k < V.Count; k++)
                            color[k] = 1;
                        DFSchain(i, j, E, color, (i + 1).ToString());
                    }
            }

            //обход в глубину. поиск элементарных цепей. (1-white 2-black)
            private void DFSchain(int u, int endV, List<Edge> E, int[] color, string s)
            {
                //вершину не следует перекрашивать, если u == endV (возможно в нее есть несколько путей)
                if (u != endV)
                    color[u] = 2;
                else
                {
                    listBoxMatrix.Items.Add(s);
                    return;
                }
                for (int w = 0; w < E.Count; w++)
                {
                    if (color[E[w].v2] == 1 && E[w].v1 == u)
                    {
                        DFSchain(E[w].v2, endV, E, color, s + "-" + (E[w].v2 + 1).ToString());
                        color[E[w].v2] = 1;
                    }
                    else if (color[E[w].v1] == 1 && E[w].v2 == u)
                    {
                        DFSchain(E[w].v1, endV, E, color, s + "-" + (E[w].v1 + 1).ToString());
                        color[E[w].v1] = 1;
                    }
                }
            }

            //поиск элементарных циклов


            //обход в глубину. поиск элементарных циклов. (1-white 2-black)
            //Вершину, для которой ищем цикл, перекрашивать в черный не будем. Поэтому, для избежания неправильной
            //работы программы, введем переменную unavailableEdge, в которой будет хранится номер ребра, исключаемый
            //из рассмотрения при обходе графа. В действительности это необходимо только на первом уровне рекурсии,
            //чтобы избежать вывода некорректных циклов вида: 1-2-1, при наличии, например, всего двух вершин.

            private void DFScycle(int u, int endV, List<Edge> E, int[] color, int unavailableEdge, List<int> cycle)
            {
                //если u == endV, то эту вершину перекрашивать не нужно, иначе мы в нее не вернемся, а вернуться необходимо
                if (u != endV)
                    color[u] = 2;
                else
                {
                    if (cycle.Count >= 2)
                    {
                        cycle.Reverse();
                        string s = cycle[0].ToString();
                        for (int i = 1; i < cycle.Count; i++)
                            s += "-" + cycle[i].ToString();
                        bool flag = false; //есть ли палиндром для этого цикла графа в листбоксе?
                        for (int i = 0; i < listBoxMatrix.Items.Count; i++)
                            if (listBoxMatrix.Items[i].ToString() == s)
                            {
                                flag = true;
                                break;
                            }
                        if (!flag)
                        {
                            cycle.Reverse();
                            s = cycle[0].ToString();
                            for (int i = 1; i < cycle.Count; i++)
                                s += "-" + cycle[i].ToString();
                            listBoxMatrix.Items.Add(s);
                        }
                        return;
                    }
                }
                for (int w = 0; w < E.Count; w++)
                {
                    if (w == unavailableEdge)
                        continue;
                    if (color[E[w].v2] == 1 && E[w].v1 == u)
                    {
                        List<int> cycleNEW = new List<int>(cycle);
                        cycleNEW.Add(E[w].v2 + 1);
                        DFScycle(E[w].v2, endV, E, color, w, cycleNEW);
                        color[E[w].v2] = 1;
                    }
                    else if (color[E[w].v1] == 1 && E[w].v2 == u)
                    {
                        List<int> cycleNEW = new List<int>(cycle);
                        cycleNEW.Add(E[w].v1 + 1);
                        DFScycle(E[w].v1, endV, E, color, w, cycleNEW);
                        color[E[w].v1] = 1;
                    }
                }
            }


    }
}
