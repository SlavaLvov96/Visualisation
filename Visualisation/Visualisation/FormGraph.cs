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
        public Graphics graphics;
        List<Vertex> V; // множество Вершин
        List<Edge> E;   // множество Ребер

        int[,] AMatrix; // матрица смежности

        int selected1;  //выбранные вершины, для соединения линиями

        private Pen[] colorsVertex; // массив цветов для всех Вершин
        private Pen[] colorsEdge;   // массив цветов для всех Ребер

        int speed = 300;
        int iter = 0;

        public void updateSheet()
        {
            sheet.Update();
        }

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

            public Pen GetBlackPen()
            {
                blackPen = new Pen(Color.Black);
                blackPen.Width = 2;
                return blackPen;
            }

            public Pen GetRedPen()
            {
                redPen = new Pen(Color.Red);
                redPen.Width = 5;
                return redPen;
            }

            public Pen GetGreenPen()
            {
                greenPen = new Pen(Color.Green);
                greenPen.Width = 4;
                return greenPen;
            }

            // инициализация объектов рисования
            public DrawGraph(int width, int height)
            {
                bitmap = new Bitmap(width, height);
                gr = Graphics.FromImage(bitmap);
                clearSheet();
                fo = new Font("Arial", 15);
                br = Brushes.Black;
            }

            // карта на которой обозначаются объекты
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
            public void drawVertex(int x, int y, string number, Pen penColor)
            {
                gr.FillEllipse(Brushes.White, (x - R), (y - R), 2 * R, 2 * R);
                gr.DrawEllipse(penColor, (x - R), (y - R), 2 * R, 2 * R);
                point = new PointF(x - 9, y - 9);
                gr.DrawString(number, fo, br, point);
            }

            //функция отрисовки окружности 
            public void drawSelectedVertex(Vertex vertex, Pen pen)
            {
                gr.DrawEllipse(pen, (vertex.X - R), (vertex.Y - R), 2 * R, 2 * R);
            }

            //функция отрисовки Ребер
            public void drawEdge(int ver1, int ver2, int edge, Vertex[] V, Edge[] E, int numberE, Pen[] colorsVertex, Pen[] colorsEdge)
            {
                //отрисовка Ребра около одной Вершины
                if (E[edge].From == E[edge].To)
                {
                    gr.DrawArc(colorsEdge[edge], (V[ver1].X - 2 * R), (V[ver1].Y - 2 * R), 2 * R, 2 * R, 90, 270);
                    point = new PointF(V[ver1].X - (int)(2.75 * R), V[ver1].Y - (int)(2.75 * R));
                    gr.DrawString(((char)('a' + numberE) + " (" + E[edge].Weight + ")").ToString(), fo, br, point);
                    drawVertex(V[ver1].X, V[ver1].Y, (E[edge].From + 1).ToString(), colorsVertex[ver1]);
                }
                //отрисовка Ребра между двумя Вершинами
                else
                {
                    gr.DrawLine(colorsEdge[edge], V[ver1].X, V[ver1].Y, V[ver2].X, V[ver2].Y);
                    point = new PointF((V[ver1].X + V[ver2].X) / 2, (V[ver1].Y + V[ver2].Y) / 2);
                    gr.DrawString(((char)('a' + numberE) + " (" + E[edge].Weight + ")").ToString(), fo, br, point);
                    drawVertex(V[ver1].X, V[ver1].Y, (E[edge].From + 1).ToString(), colorsVertex[ver1]);
                    drawVertex(V[ver2].X, V[ver2].Y, (E[edge].To + 1).ToString(), colorsVertex[ver2]);
                }
            }

            //перерисовка всего Графа
            public void drawALLGraph(List<Vertex> V, List<Edge> E, Pen[] colorsVertex, Pen[] colorsEdge)
            {
                clearSheet();

                //рисуем ребра
                for (int i = 0; i < E.Count; i++)
                {
                    if (E[i].From == E[i].To)
                    {
                        gr.DrawArc(colorsEdge[i], (V[E[i].From].X - 2 * R), (V[E[i].From].Y - 2 * R), 2 * R, 2 * R, 90, 270);
                        point = new PointF(V[E[i].From].X - (int)(2.75 * R), V[E[i].From].Y - (int)(2.75 * R));
                        gr.DrawString(((char)('a' + i) + " (" + E[i].Weight + ")").ToString(), fo, br, point);
                    }
                    else
                    {
                        gr.DrawLine(colorsEdge[i], V[E[i].From].X, V[E[i].From].Y, V[E[i].To].X, V[E[i].To].Y);
                        point = new PointF((V[E[i].From].X + V[E[i].To].X) / 2, (V[E[i].From].Y + V[E[i].To].Y) / 2);
                        gr.DrawString(((char)('a' + i) + " (" + E[i].Weight + ")").ToString(), fo, br, point);
                    }
                }
                //рисуем вершины
                for (int i = 0; i < V.Count; i++)
                {
                    drawVertex(V[i].X, V[i].Y, (i + 1).ToString(), colorsVertex[i]);
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
        }


        // Функции


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

        //обход в глубину. поиск элементарных цепей. (1-white 2-black)
        private void DFSchain(int u, int endV, List<Edge> E, int[] color, string s, Pen[] colorsVertex, Pen[] colorsEdge)
        {

            ChangeColorLine(4);
            ChangeColorPredLine(4);
            //вершину не следует перекрашивать, если u == endV (возможно в нее есть несколько путей)
            if (u != endV) //если текущая вершина - u не последняя
            {
                colorsVertex[u] = G.GetRedPen(); // перекрашивание первой вершины
                color[u] = 2;   // помечаем как пройденную вершину
                ChangeColorLine(5);
                ChangeColorPredLine(5);
                ChangeColorLine(6);
                ChangeColorPredLine(6);
            }
            else
            {
                listBox2.Items.Add(s); //вывод списка вариантов прохода в область результата
                G.clearSheet();
                colorsVertex[u] = G.GetBlackPen();
                G.drawALLGraph(V, E, colorsVertex, colorsEdge);
                ChangeColorLine(9);
                ChangeColorPredLine(9);
                sheet.Image = G.GetBitmap();
                sheet.Update();
                return;
            }
            for (int w = 0; w < E.Count; w++) // просматриваем все ребра
            {
                if (color[E[w].To] == 1 && E[w].From == u) // если имеется не посещенная вершина связанная с текущей ребром E[w]
                {
                    G.clearSheet(); // отчистка области рисования
                    colorsVertex[E[w].To] = G.GetRedPen(); // закрашивание в красный вершину, в которую идем
                    colorsEdge[w] = G.GetRedPen();  // закрашивание в красный  текущего рассматриваемого ребра
                    iter++;
                    G.drawALLGraph(V, E, colorsVertex, colorsEdge);
                    sheet.Image = G.GetBitmap();
                    sheet.Update();
                    ChangeColorLine(7);
                    ChangeColorPredLine(7);
                    ChangeColorLine(8);
                    ChangeColorPredLine(8);
                    DFSchain(E[w].To, endV, E, color, s + "-" + (E[w].To + 1).ToString(), colorsVertex, colorsEdge); // рекурсивно заходим в функцию, отномительно вершины смежной с текущей по ребру E[w]
                    color[E[w].To] = 1;
                    colorsVertex[E[w].To] = G.GetBlackPen();
                    colorsEdge[w] = G.GetBlackPen();
                    iter++;
                    G.drawALLGraph(V, E, colorsVertex, colorsEdge);
                    sheet.Image = G.GetBitmap();
                    sheet.Update();
                    Thread.Sleep(500);
                }
                else if (color[E[w].From] == 1 && E[w].To == u) //если у текущей вершины E[w].To имеются связанные не посещенные вершины E[w].From, поднимаемся на уровень выше
                {
                    G.clearSheet();
                    colorsVertex[E[w].From] = G.GetRedPen();
                    colorsEdge[w] = G.GetRedPen();
                    iter++;
                    G.drawALLGraph(V, E, colorsVertex, colorsEdge);
                    sheet.Image = G.GetBitmap();
                    sheet.Update();
                    ChangeColorLine(7);
                    ChangeColorPredLine(7);
                    ChangeColorLine(8);
                    ChangeColorPredLine(8);
                    Thread.Sleep(500);
                    DFSchain(E[w].From, endV, E, color, s + "-" + (E[w].From + 1).ToString(), colorsVertex, colorsEdge);
                    color[E[w].From] = 1;
                    G.clearSheet();
                    colorsVertex[E[w].From] = G.GetBlackPen();
                    colorsEdge[w] = G.GetBlackPen();
                    iter++;
                    G.drawALLGraph(V, E, colorsVertex, colorsEdge);
                    sheet.Image = G.GetBitmap();
                    sheet.Update();
                    Thread.Sleep(500);
                }
            }
            return;
        }

        // обход в ширину
        private int BFSwave(int u, List<Edge> E, int[] queue, int count, int[] colorWave, string s, Pen[] colorsVertex, Pen[] colorsEdge)
        {
            colorsVertex[u] = G.GetGreenPen();
            colorWave[u] = 2;

            ChangeColorLine(7);
            ChangeColorPredLine(7);
            ChangeColorLine(8);
            ChangeColorPredLine(8);
            ChangeColorLine(9);
            ChangeColorPredLine(9);

            for (int w = 0; w < E.Count; w++) // просматриваем все ребра
            {
                ChangeColorLine(10);
                ChangeColorPredLine(10);
                ChangeColorLine(11);
                ChangeColorPredLine(11);
                if (E[w].From == u && colorWave[E[w].To] == 1) // если имеется не посещенная вершина связанная с текущей ребром E[w]
                {
                    ChangeColorLine(12);
                    ChangeColorPredLine(12);
                    ChangeColorLine(13);
                    ChangeColorPredLine(13);
                    ChangeColorLine(14);
                    ChangeColorPredLine(14);
                    colorWave[E[w].To] = 2;
                    count = count + 1;
                    queue[count] = E[w].To;
                    G.clearSheet(); // отчистка области рисования
                    colorsVertex[E[w].To] = G.GetRedPen(); // закрашивание в красный вершину, в которую идем
                    colorsEdge[w] = G.GetRedPen();  // закрашивание в красный  текущего рассматриваемого ребра
                    iter++;
                    G.drawALLGraph(V, E, colorsVertex, colorsEdge);
                    sheet.Image = G.GetBitmap();
                    sheet.Update();
                    Thread.Sleep(1000);
                }
            }
            for (int i = 0; i < E.Count; i++) // перекрашиваем все пройденные ребра в зеленый
            {
                if (colorsEdge[i].Color == Color.Red)
                    colorsEdge[i] = G.GetGreenPen();
            }
            
            G.drawALLGraph(V, E, colorsVertex, colorsEdge);
            sheet.Image = G.GetBitmap();
            sheet.Update();
            ChangeColorLine(15);
            ChangeColorPredLine(15);
            Thread.Sleep(1000);
            return count;
        }

        // Алгоритм Дейкстры - Прима
        private void DPminTree(int u, List<Edge> E, int[] color, string s, Pen[] colorsVertex, Pen[] colorsEdge)
        {
            color[u] = 2; // знак, что текущая вершина была посещена

            for (int w = 0; w < E.Count; w++) // просматриваем все ребра
            {
                if (color[E[w].To] == 1 && E[w].From == u) // если имеется не посещенная вершина связанная с текущей ребром E[w]
                {
                    color[E[w].To] = 2;
                    G.clearSheet(); // отчистка области рисования
                    colorsVertex[E[w].To] = G.GetRedPen(); // закрашивание в красный вершину, в которую идем
                    colorsEdge[w] = G.GetRedPen();  // закрашивание в красный  текущего рассматриваемого ребра
                    G.drawALLGraph(V, E, colorsVertex, colorsEdge);
                    sheet.Image = G.GetBitmap();
                    sheet.Update();
                    Thread.Sleep(500);
                }
            }
            for (int i = 0; i < E.Count; i++) // просматриваем все ребра
            {
                if (colorsEdge[i] == G.GetRedPen())
                    colorsEdge[i] = G.GetGreenPen();
            }
            colorsVertex[u] = G.GetGreenPen();
            G.drawALLGraph(V, E, colorsVertex, colorsEdge);
            sheet.Image = G.GetBitmap();
            sheet.Update();
            Thread.Sleep(500);
        }


        // Кнопки 


        // кнопка запуска работы алгоритмов
        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            /*if (stop == true)
            {
                stop = false;
                Thread.ResetAbort();
            } 
            else
            {*/
            switch (comboBoxGraph.Text)
            {
                case "Дейкстры-Примы":
                    {
                        int[] color = new int[V.Count];
                        for (int i = 0; i < V.Count; i++)
                        {
                            color[i] = 1;
                        }
                        for (int i = 0; i < V.Count; i++)
                            DPminTree(i, E, color, (i + 1).ToString(), colorsVertex, colorsEdge);
                    };
                    break;
                case "Поиск в глубину":
                    {

                        //массив, отвечающий за то были ли вхождения в вершину
                        int[] color = new int[V.Count];
                        for (int i = Convert.ToInt32(comboBoxStart.Text.ToString()) - 1; i < Convert.ToInt32(comboBoxStart.Text.ToString()); i++)
                            for (int j = Convert.ToInt32(comboBoxFinish.Text.ToString()) - 1; j < Convert.ToInt32(comboBoxFinish.Text.ToString()); j++)
                            {
                                for (int k = 0; k < V.Count; k++)
                                {
                                    ChangeColorLine(0);
                                    ChangeColorPredLine(0);
                                    ChangeColorLine(1);
                                    ChangeColorPredLine(1);
                                    color[k] = 1;
                                }
                                ChangeColorLine(2);
                                ChangeColorPredLine(2);
                                iter = 0;
                                DFSchain(i, j, E, color, (i + 1).ToString(), colorsVertex, colorsEdge);
                            }
                    }
                    break;
                case "Поиск в ширину":
                    {
                        iter = 0;
                        int[] queue = new int[V.Count];
                        queue[0] = Convert.ToInt32(comboBoxStart.Text.ToString()) - 1;
                        int count = 0;
                        int[] colorWave = new int[V.Count];
                        for (int i = 0; i < V.Count; i++)
                        {
                            ChangeColorLine(0);
                            ChangeColorPredLine(0);
                            ChangeColorLine(1);
                            ChangeColorPredLine(1);
                            colorWave[i] = 1;
                        }
                        for (int i = 0; i < V.Count; i++)
                        {
                            ChangeColorLine(2);
                            ChangeColorPredLine(2);
                            ChangeColorLine(3);
                            ChangeColorPredLine(3);
                            ChangeColorLine(4);
                            ChangeColorPredLine(4);
                            ChangeColorLine(6);
                            ChangeColorPredLine(6);
                            count = BFSwave(queue[i], E, queue, count, colorWave, (i + 1).ToString(), colorsVertex, colorsEdge);
                        }
                        for (int i = 0; i < V.Count; i++)
                            colorsVertex[i] = G.GetBlackPen();
                        for (int i = 0; i < E.Count; i++)
                            colorsEdge[i] = G.GetBlackPen();
                        G.drawALLGraph(V, E, colorsVertex, colorsEdge);
                    };
                    break;
            }
            //textBoxIter.Text = iter.ToString();
            /*stop = true;
            }*/
        }

        //кнопка - матрица смежности
        private void buttonAdj_Click_1(object sender, EventArgs e)
        {
            createAdjAndOut();
        }

        // действия при нажатии мышкой в области рисования
        private void sheet_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < V.Count; i++)
            {
                if (Math.Pow((V[i].X - e.X), 2) + Math.Pow((V[i].Y - e.Y), 2) <= G.R * G.R)
                {
                    if (selected1 != -1)
                    {
                        selected1 = -1;
                        G.clearSheet();
                        G.drawALLGraph(V, E, colorsVertex, colorsEdge);
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
            }
        }

        // кнопка создания шаблонных графов
        private void button1_Click(object sender, EventArgs e)
        {
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
                // заполнение комбобокса начальной вершины для алгоритмов 
                for (int i = 0; i < V.Count - 1; i++)
                {
                    comboBoxStart.Items.Add(i + 1);
                }

                // заполнение массивов цветов для вершин и ребер базовым - черным цветом
                colorsVertex = new Pen[V.Count];
                for (int i = 0; i < V.Count; i++)
                {
                    colorsVertex[i] = G.GetBlackPen();
                }
                colorsEdge = new Pen[E.Count];
                for (int i = 0; i < E.Count; i++)
                {
                    colorsEdge[i] = G.GetBlackPen();
                }

                // вывод графов на экран
                G.drawALLGraph(V, E, colorsVertex, colorsEdge);
            }
        }

        // кнопка отвечающая за отчистку (области псевдокода, рисования и результата)
        private void buttonClear_Click(object sender, EventArgs e)
        {
            V.Clear();
            E.Clear();
            G.clearSheet();
            G.drawALLGraph(V, E, colorsVertex, colorsEdge);
            sheet.Image = G.GetBitmap();
            richTextBox.Clear();
            listBox2.Items.Clear();
        }

        // кнопка вперед
        private void buttonNext_Click(object sender, EventArgs e)
        {

        }

        // кнопка назад
        private void buttonPrev_Click(object sender, EventArgs e)
        {

        }

        // кнопка создания вершин
        private void buttonAddVertex_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                E.Clear();
                V.Clear();
                G.clearSheet();

                switch (comboBox1.SelectedItem.ToString())
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
                        };
                        break;
                }
                for (int i = 0; i < V.Count - 1; i++)
                {
                    comboBoxStart.Items.Add(i + 1);
                }

                colorsVertex = new Pen[V.Count];
                for (int i = 0; i < V.Count; i++)
                {
                    colorsVertex[i] = G.GetBlackPen();
                }
                G.drawALLGraph(V, E, colorsVertex, colorsEdge);
            }
        }

        // кнопка добавления нового ребра
        private void buttonAddEdge_Click(object sender, EventArgs e)
        {
            G.clearSheet();
            int weight;
            if (textBoxWeight.Text.ToString() == "")
            {
                weight = 1;
                E.Add(new Edge(Convert.ToInt32(textBoxFrom.Text.ToString()) - 1, Convert.ToInt32(textBoxTo.Text.ToString()) - 1, weight));
            }
            else
                E.Add(new Edge(Convert.ToInt32(textBoxFrom.Text.ToString()) - 1, Convert.ToInt32(textBoxTo.Text.ToString()) - 1, Convert.ToInt32(textBoxWeight.Text.ToString())));
            colorsEdge = new Pen[E.Count];
            for (int i = 0; i < E.Count; i++)
            {
                colorsEdge[i] = G.GetBlackPen();
            }

            sheet.Image = G.GetBitmap();
            G.drawALLGraph(V, E, colorsVertex, colorsEdge);
        }


        // Псевдокод


        // занесение псевдокода в область псевдокода
        private void comboBoxGraph_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxGraph.Text)
            {
                case "Дейкстры-Примы":
                    {
                        richTextBox.Text =
                          "for (v in V):\n" +
                          "  new(v) = NOT_VISITED\n" +
                          "for (v in V):\n" +
                          "  if new(v) = NOT_VISITED\n" +
                          "    BFS(v)\n" +
                          "\n" +
                          "procedure DP(v in V):\n" +
                          "  Queue Q = 0 \n" +
                          "  Q <= v\n" +
                          "  new(v) = VISITED\n" +
                          "  while Q != 0\n" +
                          "    for (w in Adj(v)):\n" +
                          "      if new(w) = NOT_VISITED\n" +
                          "        Q <= w\n" +
                          "        new(w) = VISITED\n" +
                          "return\n";
                    };
                    break;
                case "Поиск в глубину":
                    {
                        richTextBox.Text =
                          "for (v in V):\n" +
                          "  new(v) = NOT_VISITED\n" +
                          "DFS(v)\n" +
                          "\n" +
                          "procedure DFS(v in V):\n" +
                          "  new(v) = VISITED\n" +
                          "  for (w in Adj(v)):\n" +
                          "    if new(w) = NOT_VISITED\n" +
                          "    then DFS(w)\n" +
                          "return\n";
                    };
                    break;
                case "Поиск в ширину":
                    {
                        richTextBox.Text =
                          "for (v in V):\n" +
                          "  new(v) = NOT_VISITED\n" +
                          "for (v in V):\n" +
                          "  if new(v) = NOT_VISITED\n" +
                          "    BFS(v)\n" +
                          "\n" +
                          "procedure BFS(v in V):\n" +
                          "  Queue Q = 0 \n" +
                          "  Q <= v\n" +
                          "  new(v) = VISITED\n" +
                          "  while Q != 0\n" +
                          "    for (w in Adj(v)):\n" +
                          "      if new(w) = NOT_VISITED\n" +
                          "        Q <= w\n" +
                          "        new(w) = VISITED\n" +
                          "return\n";
                    };
                    break;
            }
        }

        // Изменение цвета текста одной строки псевдокода
        void ChangeColorLine(int line)
        {
            /* dispId.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
             {*/
            int start = richTextBox.GetFirstCharIndexFromLine(line);
            int length;

            if (line + 1 >= richTextBox.Lines.Length)
                length = richTextBox.TextLength - start;
            else
                length = richTextBox.GetFirstCharIndexFromLine(line + 1) - start;

            richTextBox.Select(start, length);
            richTextBox.SelectionBackColor = Color.SkyBlue;
            richTextBox.SelectionColor = Color.White;
            richTextBox.Invalidate();
            richTextBox.Update();
            Thread.Sleep(speed);
            //});
        }

        // Изменение цвета текста предыдущей строки псевдокода
        void ChangeColorPredLine(int line)
        {
            /*dispId.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {*/
            int start = richTextBox.GetFirstCharIndexFromLine(line);
            int length;

            if (line + 1 >= richTextBox.Lines.Length)
                length = richTextBox.TextLength - start;
            else
                length = richTextBox.GetFirstCharIndexFromLine(line + 1) - start;

            richTextBox.Select(start, length);
            richTextBox.SelectionBackColor = Color.White;
            richTextBox.SelectionColor = Color.Black;
            richTextBox.Invalidate();
            richTextBox.Update();
            //});
        }


        // Комбобокс


        // ограничение для "задание вершин для алгоритма"
        // чтобы конечная вершина не была меньше стартовой
        private void comboBoxStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxFinish.Text = "";
            comboBoxFinish.Items.Clear();
            for (int i = Convert.ToInt32(comboBoxStart.SelectedItem.ToString()); i < V.Count; i++)
            {
                comboBoxFinish.Items.Add(i + 1);
            }
        }

        // комбобокс изменения скорости
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedItem.ToString())
            {
                case "1":
                    {
                        speed = 50;
                    };
                    break;
                case "2":
                    {
                        speed = 100;
                    };
                    break;
                case "3":
                    {
                        speed = 300;
                    };
                    break;
            }
        }
    }
}
