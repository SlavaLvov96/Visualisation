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
using System.Threading;
using System.Windows.Threading;

namespace Visualisation
    {
        public partial class FormGraph : Form
        {
            DrawGraph G;    // инициализация Графа
            List<Vertex> V; // множество Вершин
            List<Edge> E;   // множество Ребер

            int[,] AMatrix; // матрица смежности
            int[,] IMatrix; // матрица инцидентности

            int selected1;  //выбранные вершины, для соединения линиями
            int selected2;
            
            // инициализация Графа
            public FormGraph()
            {
                InitializeComponent();
                V = new List<Vertex>();
                G = new DrawGraph(sheet.Width, sheet.Height);
                E = new List<Edge>();
                sheet.Image = G.GetBitmap();
            }
        // класс отрисовки графа в PictureBox
        class DrawGraph
        {
            Bitmap bitmap;
            Pen blackPen;
            Pen redPen;
            Pen greenPen;
            Graphics gr;
            Font fo;
            Brush br;
            PointF point;
            public int R = 20; //радиус окружности вершины

            public Pen GetRedPen()
            {
                redPen = new Pen(Color.Red);
                redPen.Width = 2;
                return redPen;
            }

            public Pen GetGreenPen()
            {
                greenPen = new Pen(Color.Green);
                greenPen.Width = 2;
                return greenPen;
            }

            // инициализация объектов рисования
            public DrawGraph(int width, int height)
            {
                bitmap = new Bitmap(width, height);
                gr = Graphics.FromImage(bitmap);
                clearSheet();
                blackPen = new Pen(Color.Black);
                blackPen.Width = 2;
                redPen = new Pen(Color.Red);
                redPen.Width = 2;
                greenPen = new Pen(Color.Green);
                greenPen.Width = 2;
                fo = new Font("Arial", 15);
                br = Brushes.Black;
            }

            public Bitmap GetBitmap()
            {
                return bitmap;
            }

            //отчистка области рисования
            public void clearSheet()
            {
                gr.Clear(Color.White);
            }

            //функция отрисовки Вершин
            public void drawVertex(int x, int y, string number)
            {
                gr.FillEllipse(Brushes.White, (x - R), (y - R), 2 * R, 2 * R);
                gr.DrawEllipse(blackPen, (x - R), (y - R), 2 * R, 2 * R);
                point = new PointF(x - 9, y - 9);
                gr.DrawString(number, fo, br, point);
            }

            //функция отрисовки окружности 
            public void drawSelectedVertex(Vertex vertex, Pen pen)
            {
                gr.DrawEllipse(pen, (vertex.X - R), (vertex.Y - R), 2 * R, 2 * R);
            }

            //функция отрисовки Ребер
            public void drawEdge(Vertex V1, Vertex V2, Edge E, int numberE)
            {
                //отрисовка Ребра около одной Вершины
                if (E.From == E.To)
                {
                    gr.DrawArc(blackPen, (V1.X - 2 * R), (V1.Y - 2 * R), 2 * R, 2 * R, 90, 270);
                    point = new PointF(V1.X - (int)(2.75 * R), V1.Y - (int)(2.75 * R));
                    gr.DrawString(((char)('a' + numberE) + " (" + E.Weight + ")").ToString(), fo, br, point);
                    drawVertex(V1.X, V1.Y, (E.From + 1).ToString());
                }
                //отрисовка Ребра между двумя Вершинами
                else
                {
                    gr.DrawLine(blackPen, V1.X, V1.Y, V2.X, V2.Y);
                    point = new PointF((V1.X + V2.X) / 2, (V1.Y + V2.Y) / 2);
                    gr.DrawString(((char)('a' + numberE) + " (" + E.Weight + ")").ToString(), fo, br, point);
                    drawVertex(V1.X, V1.Y, (E.From + 1).ToString());
                    drawVertex(V2.X, V2.Y, (E.To + 1).ToString());
                }
            }

            //перерисовка всего Графа
            public void drawALLGraph(List<Vertex> V, List<Edge> E)
            {
                //рисуем ребра
                for (int i = 0; i < E.Count; i++)
                {
                    if (E[i].From == E[i].To)
                    {
                        gr.DrawArc(blackPen, (V[E[i].From].X - 2 * R), (V[E[i].From].Y - 2 * R), 2 * R, 2 * R, 90, 270);
                        point = new PointF(V[E[i].From].X - (int)(2.75 * R), V[E[i].From].Y - (int)(2.75 * R));
                        gr.DrawString(((char)('a' + i) + " (" + E[i].Weight + ")").ToString(), fo, br, point);
                    }
                    else
                    {
                        gr.DrawLine(blackPen, V[E[i].From].X, V[E[i].From].Y, V[E[i].To].X, V[E[i].To].Y);
                        point = new PointF((V[E[i].From].X + V[E[i].To].X) / 2, (V[E[i].From].Y + V[E[i].To].Y) / 2);
                        gr.DrawString(((char)('a' + i) + " (" + E[i].Weight + ")").ToString(), fo, br, point);
                    }
                }
                //рисуем вершины
                for (int i = 0; i < V.Count; i++)
                {
                    drawVertex(V[i].X, V[i].Y, (i + 1).ToString());
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
                    matrix[E[i].From, E[i].To] = E[i].Weight;
                    matrix[E[i].To, E[i].From] = E[i].Weight;
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
                    matrix[E[i].From, i] = E[i].Weight;
                    matrix[E[i].To, i] = E[i].Weight;
                }
            }
        }
    /*
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

        }
        */
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

        private void sheet_MouseClick(object sender, MouseEventArgs e)
            {
            /*
                //нажата кнопка "выбрать вершину", ищем степень вершины
                if (selectButton.Enabled == false)
                {*/
                    for (int i = 0; i < V.Count; i++)
                    {
                        if (Math.Pow((V[i].X - e.X), 2) + Math.Pow((V[i].Y - e.Y), 2) <= G.R * G.R)
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
                                G.drawSelectedVertex(V[i], G.GetRedPen());
                                selected1 = i;
                                sheet.Image = G.GetBitmap();
                                createAdjAndOut();
                                listBox2.Items.Clear();
                                int degree = 0;
                                for (int j = 0; j < V.Count; j++)
                                    degree += AMatrix[selected1, j];
                                listBox2.Items.Add("Степень вершины №" + (selected1 + 1) + " равна " + degree);
                                break;
                            }
                        }
                    }/*
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
                            if (Math.Pow((V[i].X - e.X), 2) + Math.Pow((V[i].Y - e.Y), 2) <= G.R * G.R)
                            {
                                if (selected1 == -1)
                                {
                                    G.drawSelectedVertex(V[i], G.GetRedPen());
                                    selected1 = i;
                                    sheet.Image = G.GetBitmap();
                                    break;
                                }
                                if (selected2 == -1)
                                {
                                    G.drawSelectedVertex(V[i], G.GetRedPen());
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
                            (Math.Pow((V[selected1].X - e.X), 2) + Math.Pow((V[selected1].Y - e.Y), 2) <= G.R * G.R))
                        {
                            G.drawVertex(V[selected1].X, V[selected1].Y, (selected1 + 1).ToString());
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
                        if (Math.Pow((V[i].X - e.X), 2) + Math.Pow((V[i].Y - e.Y), 2) <= G.R * G.R)
                        {
                            for (int j = 0; j < E.Count; j++)
                            {
                                if ((E[j].From == i) || (E[j].To == i))
                                {
                                    E.RemoveAt(j);
                                    j--;
                                }
                                else
                                {
                                    if (E[j].From > i) E[j].From--;
                                    if (E[j].To > i) E[j].To--;
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
                            if (E[i].From == E[i].To) //если это петля
                            {
                                if ((Math.Pow((V[E[i].From].X - G.R - e.X), 2) + Math.Pow((V[E[i].From].Y - G.R - e.Y), 2) <= ((G.R + 2) * (G.R + 2))) &&
                                    (Math.Pow((V[E[i].From].X - G.R - e.X), 2) + Math.Pow((V[E[i].From].Y - G.R - e.Y), 2) >= ((G.R - 2) * (G.R - 2))))
                                {
                                    E.RemoveAt(i);
                                    flag = true;
                                    break;
                                }
                            }
                            else //не петля
                            {
                                if (((e.X - V[E[i].From].X) * (V[E[i].To].Y - V[E[i].From].Y) / (V[E[i].To].X - V[E[i].From].X) + V[E[i].From].Y) <= (e.Y + 4) &&
                                    ((e.X - V[E[i].From].X) * (V[E[i].To].Y - V[E[i].From].Y) / (V[E[i].To].X - V[E[i].From].X) + V[E[i].From].Y) >= (e.Y - 4))
                                {
                                    if ((V[E[i].From].X <= V[E[i].To].X && V[E[i].From].X <= e.X && e.X <= V[E[i].To].X) ||
                                        (V[E[i].From].X >= V[E[i].To].X && V[E[i].From].X >= e.X && e.X >= V[E[i].To].X))
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
                }*/
            }

            //создание матрицы смежности и вывод в листбокс
            private void createAdjAndOut()
            {
                AMatrix = new int[V.Count, V.Count];
                G.fillAdjacencyMatrix(V.Count, E, AMatrix);
                listBox2.Items.Clear();
                string sOut = "    ";
                for (int i = 0; i < V.Count; i++)
                    sOut += (i + 1) + " ";
                listBox2.Items.Add(sOut);
                for (int i = 0; i < V.Count; i++)
                {
                    sOut = (i + 1) + " | ";
                    for (int j = 0; j < V.Count; j++)
                        sOut += AMatrix[i, j] + " ";
                    listBox2.Items.Add(sOut);
                }
            }

            //создание матрицы инцидентности и вывод в листбокс
            private void createIncAndOut()
            {
                if (E.Count > 0)
                {
                    IMatrix = new int[V.Count, E.Count];
                    G.fillIncidenceMatrix(V.Count, E, IMatrix);
                    listBox2.Items.Clear();
                    string sOut = "    ";
                    for (int i = 0; i < E.Count; i++)
                        sOut += (char)('a' + i) + " ";
                    listBox2.Items.Add(sOut);
                    for (int i = 0; i < V.Count; i++)
                    {
                        sOut = (i + 1) + " | ";
                        for (int j = 0; j < E.Count; j++)
                            sOut += IMatrix[i, j] + " ";
                        listBox2.Items.Add(sOut);
                    }
                }
                else
                    listBox2.Items.Clear();
            }

            //поиск элементарных циклов
            private void cycleButton_Click_1(object sender, EventArgs e)
            {
                listBox2.Items.Clear();
            
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
                
                /*
                for (int i = 0; i < V.Count; i++)
                {
                    
                }*/
            }

            //поиск элементарных цепей
            private void chainButton_Click(object sender, EventArgs e)
            {
                listBox2.Items.Clear();
                //1-white 2-black
                int[] color = new int[V.Count];
            //for (int i = 0; i < V.Count - 1; i++)
            //    for (int j = i + 1; j < V.Count; j++)
            //    {
            //        for (int k = 0; k < V.Count; k++)
            //            color[k] = 1;
            //        DFSchain(i, j, E, color, (i + 1).ToString());
            //    }
            //DFSchain(0, 4, E, color, (1).ToString());
            for (int i = 0; i < 1; i++)
                for (int j = V.Count-1; j < V.Count; j++)
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
            {
                color[u] = 2;
            }
            else
            {
                listBox2.Items.Add(s);
                return;
            }
                for (int w = 0; w < E.Count; w++)
                {
                Thread.Sleep(10);
                if (color[E[w].To] == 1 && E[w].From == u)
                    {
                        DFSchain(E[w].To, endV, E, color, s + "-" + (E[w].To + 1).ToString());
                        color[E[w].To] = 1;
                    G.drawALLGraph(V, E);
                    G.drawSelectedVertex(V[(E[w].To)], G.GetGreenPen());
                    sheet.Image = G.GetBitmap();
                    Thread.Sleep(10);
                }
                    else if (color[E[w].From] == 1 && E[w].To == u)
                    {
                        DFSchain(E[w].From, endV, E, color, s + "-" + (E[w].From + 1).ToString());
                        color[E[w].From] = 1;
                    G.drawALLGraph(V, E);
                    G.drawSelectedVertex(V[(E[w].From)], G.GetGreenPen());
                    sheet.Image = G.GetBitmap();
                    Thread.Sleep(10);
                }

                
                //listBox2.Items.Add(s);
                //return;
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
                        for (int i = 0; i < listBox2.Items.Count; i++)
                            if (listBox2.Items[i].ToString() == s)
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
                            listBox2.Items.Add(s);
                        }
                        return;
                    }
                }
                for (int w = 0; w < E.Count; w++)
                {
                    if (w == unavailableEdge)
                        continue;
                    if (color[E[w].To] == 1 && E[w].From == u)
                    {
                        List<int> cycleNEW = new List<int>(cycle);
                        cycleNEW.Add(E[w].To + 1);
                        DFScycle(E[w].To, endV, E, color, w, cycleNEW);
                        color[E[w].To] = 1;
                    }
                    else if (color[E[w].From] == 1 && E[w].To == u)
                    {
                        List<int> cycleNEW = new List<int>(cycle);
                        cycleNEW.Add(E[w].From + 1);
                        DFScycle(E[w].From, endV, E, color, w, cycleNEW);
                        color[E[w].From] = 1;
                    }
                }
            }

        public void Wave(int start, int finish)
        {           

        }

        public void DFSsearch(int start, int finish)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            string str = "";
            for (int i = 0; i < V.Count; i++)
            {
                str += i + "-ая вершина: " + V[i].x.ToString() + " " + V[i].y.ToString() + Environment.NewLine;
            }
            for (int i = 0; i < E.Count; i++)
            {
                str += (i+1) + "-ое ребро: " + (E[i].v1 + 1).ToString() + " " + (E[i].v2 + 1).ToString() + Environment.NewLine;
            }

                tb_result.Text = str;*/

            if (comboBoxNum.SelectedItem != null)
            {
                V.Clear();
                E.Clear();
                G.clearSheet();

                switch (comboBoxNum.SelectedItem.ToString())
                {
                    case "5":
                        {
                            V.Add(new Vertex(70, 50));//0
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(70, 270));//1
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(500, 50));//2
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(500, 270));//3
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(285, 160));//4
                            sheet.Image = G.GetBitmap();

                            E.Add(new Edge(0, 1, 5));
                            E.Add(new Edge(0, 2, 7));
                            E.Add(new Edge(2, 3, 4));
                            E.Add(new Edge(1, 3, 3));
                            E.Add(new Edge(0, 4, 6));
                            E.Add(new Edge(2, 4, 5));
                            E.Add(new Edge(1, 4, 8));
                            E.Add(new Edge(3, 4, 2));
                        };
                        break;
                    case "6":
                        {
                            V.Add(new Vertex(50, 160));//0
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(200, 50));//1
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(200, 270));//2
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(370, 50));//3
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(370, 270));//4
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(520, 160));//5
                            sheet.Image = G.GetBitmap();

                            E.Add(new Edge(0, 1));
                            E.Add(new Edge(0, 2));
                            E.Add(new Edge(2, 3));
                            E.Add(new Edge(1, 3));
                            E.Add(new Edge(0, 4));
                            E.Add(new Edge(2, 4));
                            E.Add(new Edge(1, 5));
                            E.Add(new Edge(3, 5));
                            E.Add(new Edge(4, 5));
                        };
                        break;
                    case "7":
                        {
                            V.Add(new Vertex(50, 160));//0
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(200, 50));//1
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(200, 270));//2
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(285, 160));//3
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(370, 50));//4
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(370, 270));//5
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(520, 160));//6
                            sheet.Image = G.GetBitmap();

                            E.Add(new Edge(0, 1));
                            E.Add(new Edge(0, 2));
                            E.Add(new Edge(2, 3));
                            E.Add(new Edge(1, 3));
                            E.Add(new Edge(0, 3));
                            E.Add(new Edge(1, 4));
                            E.Add(new Edge(2, 5));
                            E.Add(new Edge(3, 4));
                            E.Add(new Edge(3, 5));
                            E.Add(new Edge(3, 6));
                            E.Add(new Edge(4, 6));
                            E.Add(new Edge(5, 6));
                        };
                        break;
                    case "8":
                        {
                            V.Add(new Vertex(50, 110));//0
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(50, 210));//1
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(200, 50));//2
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(200, 270));//3
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(370, 50));//4
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(370, 270));//5
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(520, 110));//6
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(520, 210));//7
                            sheet.Image = G.GetBitmap();

                            E.Add(new Edge(0, 1));
                            E.Add(new Edge(0, 2));
                            E.Add(new Edge(2, 3));
                            E.Add(new Edge(1, 3));
                            E.Add(new Edge(2, 4));
                            E.Add(new Edge(3, 5));
                            E.Add(new Edge(4, 5));
                            E.Add(new Edge(0, 6));
                            E.Add(new Edge(4, 6));
                            E.Add(new Edge(6, 7));
                            E.Add(new Edge(1, 7));
                            E.Add(new Edge(5, 7));
                        };
                        break;
                    case "9":
                        {
                            V.Add(new Vertex(50, 110));//0
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(50, 210));//1
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(200, 50));//2
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(200, 270));//3
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(285, 160));//4
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(370, 50));//5
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(370, 270));//6
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(520, 110));//7
                            sheet.Image = G.GetBitmap();
                            V.Add(new Vertex(520, 210));//8
                            sheet.Image = G.GetBitmap();

                            E.Add(new Edge(0, 1));
                            E.Add(new Edge(0, 2));
                            E.Add(new Edge(2, 4));
                            E.Add(new Edge(1, 3));
                            E.Add(new Edge(1, 4));
                            E.Add(new Edge(0, 4));
                            E.Add(new Edge(2, 5));
                            E.Add(new Edge(5, 4));
                            E.Add(new Edge(4, 3));
                            E.Add(new Edge(3, 6));
                            E.Add(new Edge(4, 6));
                            E.Add(new Edge(5, 7));
                            E.Add(new Edge(4, 7));
                            E.Add(new Edge(7, 8));
                            E.Add(new Edge(4, 8));
                            E.Add(new Edge(6, 8));
                        };
                        break;
                }
                G.drawALLGraph(V, E);
            }
            
        }

        private void comboBoxGraph_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             *  Крускала
                Дейкстры-Примы
                Поиск в глубину
                Поиск в ширину
                Минимальное остомное дерево
                Фундаментальные остовы циклов
                Кратчайшие пути
                Эйлеров цикл
             */
            switch (comboBoxGraph.Text)
            {
                case "Крускала":
                    {
                        richTextBox.Text = "for i=0 to N-1 step 1\n" +
                 "      for j=i+1 to N-1 step 1\n" +
                 "      if A[j]<A[i] then\n" +
                 "          swap A[i],A[j]\n";
                    };
                    break;
                case "Дейкстры-Примы":
                    {

                    };
                    break;
                case "Поиск в глубину":
                    {

                    };
                    break;
                case "Поиск в ширину":
                    {
                        richTextBox.Text = "for i=0 to N-1 step 1\n" +
                "      for j=i+1 to N-1 step 1\n" +
                "      if A[j]<A[i] then\n" +
                "          swap A[i],A[j]\n";
                    };
                    break;
                case "Минимальное остомное дерево":
                    {

                    };
                    break;
                case "Фундаментальные остовы циклов":
                    {

                    };
                    break;
                case "Кратчайшие пути":
                    {

                    };
                    break;
                case "Эйлеров цикл":
                    {

                    };
                    break;
            }
        }

        /*
        private void graph_from_file(int vertexCount)
        {
            StreamReader objReader = new StreamReader("graph.txt");
            string sLine = "";

            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    if (sLine == vertexCount)
            }
            objReader.Close();
        }*/

        // Изменение цвета текста одной строки псевдокода
        void ChangeColorLine(int line)
        {
            //dispUI.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            //{
            //    richTextBox.Invoke((MethodInvoker)delegate
            //{
                int start = richTextBox.GetFirstCharIndexFromLine(line);
                int length;

                if (line + 1 >= richTextBox.Lines.Length)
                    length = richTextBox.TextLength - start;
                else
                    length = richTextBox.GetFirstCharIndexFromLine(line + 1) - start;

                richTextBox.Select(start, length);
                richTextBox.SelectionColor = Color.Red;
            //});
        }

        // Изменение цвета текста предыдущей строки псевдокода
        void ChangeColorPredLine(int line)
        {
            //dispUI.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            //{
                //richTextBox.Invoke((MethodInvoker)delegate
            //{
                int start = richTextBox.GetFirstCharIndexFromLine(line);
                int length;

                if (line + 1 >= richTextBox.Lines.Length)
                    length = richTextBox.TextLength - start;
                else
                    length = richTextBox.GetFirstCharIndexFromLine(line + 1) - start;

                richTextBox.Select(start, length);
                richTextBox.SelectionColor = Color.Black;
            //});
        }
        public int schetchik = 1;
        private void buttonNext_Click(object sender, EventArgs e)
        {
            ChangeColorPredLine(schetchik-1);
            ChangeColorLine(schetchik++);
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            ChangeColorPredLine(schetchik--);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
