﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Threading;
using System.Threading;

namespace Visualisation
{
    public partial class FormSearch : Form
    {
        //инициализация кнопок для меню
        private const int AVL = 0;
        private const int BINTREE = 1;
        private const int INTERPOLATION = 2;
        private const int LINEAR = 3;
        private const int DIGIT = 4;

        //значения для линейного поиска
        private int[] numbers;
        private Rectangle[] rectangles;
        private const int MAX_WIDTH = 593;
        private int MAX_HEIGHT = 491;

        //вид алгоритма поиска
        private int searchType;

        // определяем дерево
        BinaryTree<int> Tree = new BinaryTree<int>();

        // для доступа к поверхности pictureBox
        Graphics pictGraphics; 

        // шрифт для показа содержимого вершин
        Font NodesFont = new Font(FontFamily.GenericSansSerif, (float)10.0, FontStyle.Regular);

        // цвет внутренних и внешних вершин
        Color NodesColor = Color.FromArgb(120, 219, 226); 
        Color LeavesColor = Color.FromArgb(100, 149, 237);

        //диспетчер
        Dispatcher dispID = Dispatcher.CurrentDispatcher;

        // инициализируем форму
        public FormSearch()
        {
            InitializeComponent();
        }

        // при загрузке формы
        private void FormSearch_Load(object sender, EventArgs e)
        {
            // кнопки "развернуть" и "свернуть" будут недоступны
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            // размеры pictureBox
            int pb_width = pb_animation.Width, pb_height = pb_animation.Height; 

            // доступ к рисованию на картинке
            pb_animation.Image = (Image)new Bitmap(pb_width, pb_height);
            pictGraphics = Graphics.FromImage(pb_animation.Image);

            // обновляем картинку
            RefreshTree(); 
        }

        // содержится ли вершина среди первых n элементов массива ?
        bool ContainsInArray(int[] array, int n, int item)
        {
            for (int i = 0; i < n; i++)
                if (array[i] == item) return true;
            return false;
        }

        // получение случайных чисел в диапазоне [xmin; xmax]
        // размер массива случайный от nmin до nmax
        int[] GetRandItems(int nmin, int nmax, int xmin, int xmax)
        {
            Random random = new Random(DateTime.Now.Millisecond);

            // получаем случайный размер
            int n = random.Next(nmin, nmax + 1); 
            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                // генерируем новое случайное число
                int newDigit = random.Next(xmin, xmax + 1); 

                // если оно уже есть среди ранее сгенерированных случайных чисел
                if (ContainsInArray(array, i, newDigit) == true) i--;

                // если оно НОВОЕ
                else array[i] = newDigit; 
            }
            return array;
        }

        // обновляем изображение дерева
        void RefreshTree()
        {
            pictGraphics.Clear(pb_animation.BackColor); // очищаем картинку
            Tree.DrawTree(pictGraphics, 14, pb_animation.Width, pb_animation.Height,
            NodesColor, LeavesColor, NodesFont); // показываем дерево
            pb_animation.Invalidate(); // инициируем отрисовку на картинке
        }

        // очищаем изображение
        void ClearTree()
        {
            pictGraphics.Clear(pb_animation.BackColor); // очищаем картинку
            pb_animation.Invalidate(); // инициируем отрисовку на картинке
            rtb_result.AppendText("Изображение удалено.\n");
        }

        // рисуем случайное дерево
        private void b_random_click(object sender, EventArgs e)
        {
            // получаем случайные числа (в данном случае от 1 до 99)
            int[] A = GetRandItems(3, 15, 1, 99);
            Tree = new BinaryTree<int>(A, A.Length); // строим дерево

            // обновляем изображение
            RefreshTree();
            rtb_result.AppendText("Построено дерево из случайных вершин.\n");
        }

        // добавление вершины
        private void b_add_Click(object sender, EventArgs e)
        {
            // Insert возвращает false, если была попытка вставки существующей вершины
            if (Tree.Insert(Convert.ToInt32(tb_add.Text)) == false)
            {
                MessageBox.Show("Вершина " + tb_add.Text.ToString() + " уже есть.");
                return;
            }

            // иначе - обновляем изображение
            RefreshTree();
            rtb_result.AppendText("Добавлена вершина " + tb_add.Text.ToString() + ".\n");
        }

        // удаление вершины
        private void b_delete_Click(object sender, EventArgs e)
        {
            // Remove возвращает false, если была попытка удаления несуществующей вершины
            if (Tree.Remove(Convert.ToInt32(tb_delete.Text)) == false)
            {
                MessageBox.Show("Вершина " + tb_delete.Text.ToString() + " отсутствует.");
                return;
            }

            // иначе - обновляем изображение
            RefreshTree();
            rtb_result.AppendText("Удалена вершина " + tb_delete.Text.ToString() + ".\n");
        }
   
        // поиск в бинарном дереве
        void binaryTreeSearch()
        {
            if ((tb_search_value.Text==null)||(Tree.binFind(Convert.ToInt32(tb_search_value.Text)) == false))
            {
                MessageBox.Show("Вершина " + tb_search_value.Text.ToString() + " отсутствует.\n");
                return;
            }

            // анимация псевдокода
            ChangeColorLine(0);
            Thread.Sleep(300);
            if ((tb_search_value.Text == null)||(Tree.binFind(Convert.ToInt32(tb_search_value.Text))==false))
            {
                ChangeColorPrevLine(0);
                ChangeColorLine(1);
                Thread.Sleep(300);
            }
            ChangeColorPrevLine(1);
            ChangeColorLine(2);
            Thread.Sleep(300);
            if (Tree.binFind(Convert.ToInt32(tb_search_value.Text)) == true)
            {
                ChangeColorPrevLine(2);
                ChangeColorLine(3);
                Thread.Sleep(300);
            }
            ChangeColorPrevLine(3);
            ChangeColorLine(4);
            Thread.Sleep(300);
            if (Tree.binFind(Convert.ToInt32(tb_search_value.Text)) == true)
            {
                ChangeColorPrevLine(5);
                ChangeColorLine(6);
                Thread.Sleep(300);
            }
            ChangeColorPrevLine(0);
            MessageBox.Show("Найдена вершина " + tb_search_value.Text.ToString() + ".");
        }

        // поиск в авл-дереве такой же как и в бинарном дереве
        void avlTreeSearch()
        {
            if ((tb_search_value.Text == null) || (Tree.binFind(Convert.ToInt32(tb_search_value.Text)) == false))
            {
                MessageBox.Show("Вершина " + tb_search_value.Text.ToString() + " отсутствует.\n");
                return;
            }

            // анимация псевдокода
            ChangeColorLine(0);
            Thread.Sleep(300);
            if ((tb_search_value.Text == null) || (Tree.binFind(Convert.ToInt32(tb_search_value.Text)) == false))
            {
                ChangeColorPrevLine(0);
                ChangeColorLine(1);
                Thread.Sleep(300);
            }
            ChangeColorPrevLine(1);
            ChangeColorLine(2);
            Thread.Sleep(300);
            if (Tree.binFind(Convert.ToInt32(tb_search_value.Text)) == true)
            {
                ChangeColorPrevLine(2);
                ChangeColorLine(3);
                Thread.Sleep(300);
            }
            ChangeColorPrevLine(3);
            ChangeColorLine(4);
            Thread.Sleep(300);
            if (Tree.binFind(Convert.ToInt32(tb_search_value.Text)) == true)
            {
                ChangeColorPrevLine(5);
                ChangeColorLine(6);
                Thread.Sleep(300);
            }
            ChangeColorPrevLine(0);
            MessageBox.Show("Найдена вершина " + tb_search_value.Text.ToString() + ".");
        }

        // линейный поиск
        private int[] linearTreeSearch(int[] input)
        {
            ChangeColorLine(0);
            Thread.Sleep(300);
            ChangeColorPrevLine(0);
            ChangeColorLine(1);
            Thread.Sleep(300);
            for (int i = 0; i < input.Length; i++)
            {
                ChangeColorPrevLine(1);
                ChangeColorLine(2);
                Thread.Sleep(300);
                if (input[i] == Convert.ToInt32(tb_search_value.Text))
                {
                    ChangeColorPrevLine(2);
                    ChangeColorLine(3);
                    Thread.Sleep(300);
                    FindBorder(i);
                    ChangeColorPrevLine(3);
                }
                else
                {
                    NotEqual(i);
                }
                             
            }
            ChangeColorPrevLine(0);
            return input;
        }

        // интерполяционный поиск
        private int InterpolationTreeSearch(int[] input)
        {
            int left = 0;  // левая граница поиска (будем считать, что элементы массива нумеруются с нуля) 
            int right = input.Length - 1; // правая граница поиска 
            int mid;

            ChangeColorLine(0);
            Thread.Sleep(300);
            ChangeColorPrevLine(0);
            ChangeColorLine(1);
            Thread.Sleep(300);
            ChangeColorPrevLine(1);
            ChangeColorLine(2);
            Thread.Sleep(300);
            ChangeColorPrevLine(2);
            ChangeColorLine(3);
            Thread.Sleep(300);

            while ((input[left] < Convert.ToInt32(tb_search_value.Text)) && (Convert.ToInt32(tb_search_value.Text) < input[right]))
            {
                ChangeColorPrevLine(3);
                ChangeColorLine(4);
                Thread.Sleep(300);
                ChangeColorPrevLine(4);
                ChangeColorLine(5);
                Thread.Sleep(300);
                mid = left + (Convert.ToInt32(tb_search_value.Text) - input[left]) * (right - left) / (input[right] - input[left]);
                ChangeColorPrevLine(5);
                ChangeColorLine(6);
                Thread.Sleep(300);
                if (input[mid] < Convert.ToInt32(tb_search_value.Text))
                {
                    left = mid + 1;
                    ChangeColorPrevLine(6);
                    ChangeColorLine(7);
                    Thread.Sleep(300);
                    NotFind(left);
                }
                else if (input[mid] > Convert.ToInt32(tb_search_value.Text))
                {
                    right = mid - 1;
                    ChangeColorPrevLine(7);
                    ChangeColorLine(8);
                    Thread.Sleep(300);
                    NotFind(right);
                }
                else
                {
                    ChangeColorPrevLine(8);
                    ChangeColorLine(9);
                    Thread.Sleep(300);
                    FindBorder(mid);
                    MessageBox.Show("Значение " + tb_search_value.Text.ToString() + " найдено.");
                    return mid;

                }
                ChangeColorPrevLine(9);
                ChangeColorLine(10);
                Thread.Sleep(300);
            }
            if (input[left] == Convert.ToInt32(tb_search_value.Text))
            {
                ChangeColorPrevLine(10);
                ChangeColorLine(11);
                Thread.Sleep(300);
                FindBorder(left);
                MessageBox.Show("Значение " + tb_search_value.Text.ToString() + " найдено.");
                return left;
            }
            else if (input[right] == Convert.ToInt32(tb_search_value.Text))
            {
                ChangeColorPrevLine(11);
                ChangeColorLine(12);
                Thread.Sleep(300);
                FindBorder(right);
                MessageBox.Show("Значение " + tb_search_value.Text.ToString() + " найдено.");
                return right;
            }
            else
            {
                ChangeColorPrevLine(12);
                ChangeColorLine(13);
                Thread.Sleep(300);
                MessageBox.Show("Данного значения нет в массиве.");
                return -1;
            }
        }        
        
        // цифровой поиск
        void digitalTreeSearch()
        {

        }

        // предыдущий шаг
        private void prev_click(object sender, EventArgs e)
        {

        }

        //следующий шаг
        private void next_click(object sender, EventArgs e)
        {

        }

        // нажатие кнопки АВЛ-дерево
        private void avl_menu_Click(object sender, EventArgs e)
        {
            avl_menu.Enabled = false;
            binary_tree_menu.Enabled = true;
            interpolation_menu.Enabled = true;
            linear_menu.Enabled = true;
            digital_menu.Enabled = true;

            rtb_result.AppendText("Поиск в АВЛ дереве.\n");

            rtb_pseudocode.Text = "Поиск в АВЛ-дереве(x : Node, k : T):\n" +
            "   если x == null или k == x.key\n" +
            "      вернуть x\n" +
            "   если k < x.key\n" +
            "      вернуть Поиск в АВЛ-дереве(x.left, k)\n" +
            "   иначе\n" +
            "                return Поиск в АВЛ-дереве(x.right, k)";
            ClearTree();
            //avlTreeSearch();
        }

        // нажатие кнопки Бинарное дерево поиска
        private void binary_tree_menu_Click(object sender, EventArgs e)
        {
            avl_menu.Enabled = true;
            binary_tree_menu.Enabled = false;
            interpolation_menu.Enabled = true;
            linear_menu.Enabled = true;
            digital_menu.Enabled = true;

            rtb_result.AppendText("Поиск в бинарном дереве.\n");
            rtb_pseudocode.Text = "Поиск в бинарном дереве(x : Node, k : T):\n" +
            "   если x == null или k == x.key\n" +
            "      вернуть x\n" +
            "   если k < x.key\n" +
            "      вернуть Поиск в бинарном дереве(x.left, k)\n" +
            "   иначе\n" +
            "                вернуть Поиск в бинарном дереве(x.right, k)";
            ClearTree();
            //binaryTreeSearch();
        }

        // нажатие кнопки интерполяционный поиск
        private void interpolation_menu_Click(object sender, EventArgs e)
        {
            avl_menu.Enabled = true;
            binary_tree_menu.Enabled = true;
            interpolation_menu.Enabled = false;
            linear_menu.Enabled = true;
            digital_menu.Enabled = true;

            rtb_result.AppendText("Интерполяционный поиск.\n");
            rtb_pseudocode.Text = "int Интерполяционный поиск(int A[], int key)\n " +
            "{\n    " +
            "   int mid, left = 0, right = N - 1\n     " +
            "   пока (A[left] <= key && A[right] >= key)\n" +
            "   {\n  " +
            "       mid = left + ((key - A[left]) * (right - left)) / (A[right] - A[left])\n" +
            "       если (A[mid] < key) увеличить левый ключ\n" +
            "       иначе если (A[mid] > key) уменьшить правый ключ\n" +
            "       иначе вернуть середину\n" +
            "   }\n" +
            "   если (A[left] == key) вернуть левый ключ\n" +
            "   иначе если A[right] == key вернуть правый ключ\n"+
            "   иначе вернуть -1;\n}";
            ClearTree();
            numbers = GetNumbersI();
            RectanglesInit(numbers);
        }

        // нажатие кнопки Линейный поиск
        private void linear_menu_Click(object sender, EventArgs e)
        {
            avl_menu.Enabled = true;
            binary_tree_menu.Enabled = true;
            interpolation_menu.Enabled = true;
            linear_menu.Enabled = false;
            digital_menu.Enabled = true;

            rtb_result.AppendText("Линейный поиск.\n");
            rtb_pseudocode.Text = "int Линейный поиск(int A[], int key)\n" +
            "{\n    " +
            "   для (i = 0; i < N; i++)\n       " +
            "   если (A[i] == key) вернуть i;\n    " +
            "   вернуть -1;\n" +
            "}";
            ClearTree();
            numbers = GetNumbers();
            RectanglesInit(numbers);
        }

        // нажатие кнопки Цифровой поиск
        private void digital_menu_Click(object sender, EventArgs e)
        {
            avl_menu.Enabled = true;
            binary_tree_menu.Enabled = true;
            interpolation_menu.Enabled = true;
            linear_menu.Enabled = true;
            digital_menu.Enabled = false;

            rtb_result.AppendText("Поиск в цифровом дереве.\n");
            rtb_pseudocode.Text = "Цифровой_поиск(link h, Key v, int d)\n" +
            "      {\n" +
            "                если (h == 0) вернуть nullItem;\n" +
            "                если (v == h->item.key()) вернуть h->item;\n" +
            "                если (digit(v, d) == 0)\n" +
            "                    вернуть Цифровой_поиск(h->l, v, d + 1);\n" +
            "                иначе\n" +
            "                    вернуть Цифровой_поиск(h->r, v, d + 1);\n" +
            "            }";
            ClearTree();
        }

        // нажатие кнопки Старт/Пауза 
        private void b_start_pause_Click(object sender, EventArgs e)
        {
            b_start_pause.Enabled = false;
            SearchType();
            Thread searchingThread = new Thread(delegate ()
            {
                switch (searchType)
                {
                    case AVL:
                        avlTreeSearch();
                        break;
                    case BINTREE:
                        binaryTreeSearch();
                        break;
                    case INTERPOLATION:
                        InterpolationTreeSearch(numbers);
                        break;
                    case LINEAR:
                        numbers = linearTreeSearch(numbers);
                        break;
                    case DIGIT:
                        digitalTreeSearch();
                        break;
                }

                dispID.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
                {
                    b_start_pause.Enabled = true;
                });

            });
            searchingThread.IsBackground = true;
            searchingThread.Start();
        }

        // выбор вида поиска
        private void SearchType()
        {
            if (avl_menu.Enabled == false)
                searchType = AVL;

            if (binary_tree_menu.Enabled == false)
                searchType = BINTREE;

            if (interpolation_menu.Enabled == false)
                searchType = INTERPOLATION;

            if (linear_menu.Enabled == false)
                searchType = LINEAR;

            if (digital_menu.Enabled == false)
                searchType = DIGIT;
        }

        // Найденный элемент имеет зеленую рамку
        private void FindBorder(int index1)
        {
            dispID.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                pictGraphics = pb_animation.CreateGraphics();
                Pen myPen = new Pen(Color.Green, 6);
                pictGraphics.DrawRectangle(myPen, rectangles[index1]);
            });
        }

        // Элемент не равный заданному значению имеет пурпурную рамку
        private void NotEqual(int index1)
        {
            dispID.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                pictGraphics = pb_animation.CreateGraphics();
                Pen myPen = new Pen(Color.MediumPurple, 4);
                pictGraphics.DrawRectangle(myPen, rectangles[index1]);
            });
        }

        private void NotFind(int index1)
        {
            dispID.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                pictGraphics = pb_animation.CreateGraphics();
                pictGraphics.FillRectangle(Brushes.Azure, rectangles[index1]);
            });
        }

        // значения для линейного поиска
        private int[] GetNumbers()
        {
            string inputNum = "";
            if (inputNum.Equals(""))
            {
                inputNum = "1 3 5 2 7 4 6 10 8 9 11";
            }
            string[] arrayNum = inputNum.Split(' ');
            int[] numbersLength = new int[arrayNum.Length];
            for (int i = 0; i < arrayNum.Length; i++)
            {
                if (!arrayNum[i].Equals(""))
                {
                    numbersLength[i] = Int32.Parse(arrayNum[i]);
                }
            }
            return numbersLength;
        }

        // значения для линейного поиска
        private int[] GetNumbersI()
        {
            string inputNum = "";
            if (inputNum.Equals(""))
            {
                inputNum = "1 2 3 4 5 5 6 7 7 8 9 10 11";
            }
            string[] arrayNum = inputNum.Split(' ');
            int[] numbersLength = new int[arrayNum.Length];
            for (int i = 0; i < arrayNum.Length; i++)
            {
                if (!arrayNum[i].Equals(""))
                {
                    numbersLength[i] = Int32.Parse(arrayNum[i]);
                }
            }
            return numbersLength;
        }

        // инициализация формы для линейного поиска
        private void RectanglesInit(int[] array)
        {
            int space = MAX_WIDTH / array.Length;
            int maxNumber = GetMax(array);
            int pixelsPerNumber = MAX_HEIGHT / maxNumber;

            pb_animation.Controls.Clear();
            pb_animation.Refresh();
            pb_animation.Update();
            rectangles = new Rectangle[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                int width = 50;
                int height = 50;
                int top = 180;

                int left = space * i + 50;
                pictGraphics = pb_animation.CreateGraphics();
                SolidBrush myBrush = new SolidBrush(Color.Azure);
                Pen pen = new Pen(Color.LightSkyBlue, 4);

                Rectangle rectBas = new Rectangle(left, top, width, height);
                pictGraphics.DrawRectangle(pen, rectBas);
                pictGraphics.FillRectangle(myBrush, rectBas);

                string arr = numbers[i].ToString();
                Font drawFont = new Font("Ink Free", width / 3);
                pictGraphics.DrawString(arr, drawFont, Brushes.Black, left + 10, top + 10);

                rectangles[i] = rectBas;
            }
        }

        // получить максимальное значение
        private int GetMax(int[] array)
        {
            int temp = array[0];
            foreach (int n in array)
            {
                if (n < 0)
                {
                    if (-1 * n > temp) temp = -1 * n;
                }
                if (n > temp) temp = n;
            }
            return temp;
        }

        // Изменение цвета одной строки псевдокода
        void ChangeColorLine(int line)
        {
            dispID.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                int start = rtb_pseudocode.GetFirstCharIndexFromLine(line);
                int length;

                if (line + 1 >= rtb_pseudocode.Lines.Length)
                    length = rtb_pseudocode.TextLength - start;
                else
                    length = rtb_pseudocode.GetFirstCharIndexFromLine(line + 1) - start;

                rtb_pseudocode.Select(start, length);
                rtb_pseudocode.SelectionBackColor = Color.SkyBlue;
                rtb_pseudocode.SelectionColor = Color.White;
            });
        }

        // Изменение цвета предыдущей строки псевдокода
        void ChangeColorPrevLine(int line)
        {
            dispID.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                int start = rtb_pseudocode.GetFirstCharIndexFromLine(line);
                int length;

                if (line + 1 >= rtb_pseudocode.Lines.Length)
                    length = rtb_pseudocode.TextLength - start;
                else
                    length = rtb_pseudocode.GetFirstCharIndexFromLine(line + 1) - start;

                rtb_pseudocode.Select(start, length);
                rtb_pseudocode.SelectionBackColor = Color.SeaShell;
                rtb_pseudocode.SelectionColor = Color.Black;
            });
        }
    }
}
