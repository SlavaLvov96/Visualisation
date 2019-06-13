using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Media;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Documents;

namespace Visualisation
{
    public partial class FormSort : Form
    {
        private const int BUBBLESORT = 0;
        private const int QUICKSORT = 1;
        private const int SELECTIONSORT = 2;
        private const int HEAPSORT = 3;
        private const int INSERTSORT = 4;
        private const int SHAKERSORT = 5;
        private const int TIMSORT = 6;

        private int sortType;

        private int[] numbers;
        private const int MAX_WIDTH = 593;
        private int MAX_HEIGHT = 491;
        private Rectangle[] rectangles;
        Graphics graphics;
        private Color[] colors;
       

        Dispatcher dispUI = Dispatcher.CurrentDispatcher;

        public FormSort()
        {
            InitializeComponent();
        }

        // Пузырьковая сортировка
        private void buttonBubble_Click(object sender, EventArgs e)
        {
            buttonBubble.Enabled = false;
            buttonQuick.Enabled = true;
            buttonSelection.Enabled = true;
            buttonHeapsort.Enabled = true;
            buttonInsert.Enabled = true;
            buttonShaker.Enabled = true;
            buttonTimsort.Enabled = true;

            richTextBox.Text = "for i=0 to N-1 step 1\n" +
                "      for j=i+1 to N-1 step 1\n" +
                "      if A[j]<A[i] then\n" +
                "          swap A[i],A[j]\n";

            
            // BubbleSort(numbers);
        }

        private int[] BubbleSort(int[] input)
        {
            int temp;
            
            ChangeColorLine(0);
            Thread.Sleep(300);
            for (int i = 0; i < input.Length; i++)
            {
                ChangeColorPredLine(0);
                ChangeColorLine(1);
                Thread.Sleep(300);
                for (int j = i + 1; j < input.Length; j++)
                {
                    //SetOrangeColor(i, j);
                    for (int index = 0; index < colors.Length; index++)
                    {
                        if (colors[index] == Color.Orange)
                        {
                            colors[index] = Color.Red;
                        }
                    }

                    ChangeColorPredLine(1);
                    ChangeColorLine(2);
                    Thread.Sleep(30);
                    if (input[j] < input[i])
                    {
                        temp = input[j];
                        input[j] = input[i];
                        input[i] = temp;
                        ChangeColorPredLine(2);
                        ChangeColorLine(3);
                        Thread.Sleep(30);
                        SwapRectangles(i, j);
                        colors[i] = Color.Orange;
                        colors[j] = Color.Orange;
                        DrawAllRectangles(numbers, rectangles, colors);
                        ChangeColorPredLine(3);
                    }
                    ChangeColorPredLine(2);
                    Thread.Sleep(300);
                    //SetRedColor(i, j);
                }
                ChangeColorPredLine(1);
                //SetGrayColor(i);
                colors[i] = Color.Gray;
            }
            ChangeColorPredLine(0);
            return input;
        }

        public int[] InsertionSort(int[] array)
        {
            int[] result = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int j = i;
                
                while (j > 0 && result[j - 1] > array[i])
                {
                    for (int index = 0; index < colors.Length; index++)
                    {
                        if (colors[index] == Color.Orange)
                        {
                            colors[index] = Color.Red;
                        }
                    }
                    //SetOrangeColor(i, j - 1);
                    result[j] = result[j - 1];
                    SwapRectangles(j, j - 1);
                    colors[i] = Color.Orange;
                    colors[j - 1] = Color.Orange;
                    Thread.Sleep(300);
                    //SetRedColor(i, j - 1);
                    DrawAllRectangles(numbers, rectangles, colors);
                    colors[i] = Color.Red;
                    colors[j - 1] = Color.Red;
                    j--;
                }
                result[j] = array[i];
            }
            return result;
        }

        private int[] ShakerSort(int[] myint)
        {
            int beg, end;
            int count = 0;
            for (int i = 0; i < myint.Length / 2; i++)
            {
                beg = 0;
                end = myint.Length - 1;
                do
                {
                    //SetOrangeColor(beg, beg + 1);
                    count += 2;
                    if (myint[beg] > myint[beg + 1])
                    {
                        Swap(myint, beg, beg + 1);
                        SwapRectangles(beg, beg + 1);
                    }
                    colors[beg] = Color.Orange;
                    colors[beg + 1] = Color.Orange;
                    Thread.Sleep(400);
                    SetRedColor(beg, beg + 1);
                    colors[beg] = Color.Red;
                    colors[beg + 1] = Color.Red;
                    beg++;
                    //SetOrangeColor(end, end - 1);
                    if (myint[end - 1] > myint[end])
                    {
                        Swap(myint, end - 1, end);
                        SwapRectangles(end - 1, end);
                    }
                    colors[end] = Color.Orange;
                    colors[end - 1] = Color.Orange;
                    Thread.Sleep(400);
                    //SetRedColor(end, end - 1);
                    colors[end] = Color.Red;
                    colors[end - 1] = Color.Red;
                    end--;
                }
                while (beg <= end);
            }
            return myint;
        }
        private void Swap(int[] myint, int i, int j)
        {
            int glass;
            //Rectangle glass = new Rectangle();
            glass = myint[i];
            myint[i] = myint[j];
            myint[j] = glass;
            Thread.Sleep(300);
            SwapRectangles(i, j);
        }
        // Быстрая сортировка
        private void buttonQuick_Click(object sender, EventArgs e)
        {
            buttonBubble.Enabled = true;
            buttonQuick.Enabled = false;
            buttonSelection.Enabled = true;
            buttonHeapsort.Enabled = true;
            buttonInsert.Enabled = true;
            buttonShaker.Enabled = true;
            buttonTimsort.Enabled = true;
        }

        // Сортировка выбором
        private void buttonSelection_Click(object sender, EventArgs e)
        {
            buttonBubble.Enabled = true;
            buttonQuick.Enabled = true;
            buttonSelection.Enabled = false;
            buttonHeapsort.Enabled = true;
            buttonInsert.Enabled = true;
            buttonShaker.Enabled = true;
            buttonTimsort.Enabled = true;
        }

        // Пирамидальная сортировка
        private void buttonHeapsort_Click(object sender, EventArgs e)
        {
            buttonBubble.Enabled = true;
            buttonQuick.Enabled = true;
            buttonSelection.Enabled = true;
            buttonHeapsort.Enabled = false;
            buttonInsert.Enabled = true;
            buttonShaker.Enabled = true;
            buttonTimsort.Enabled = true;
        }

        //Сортировка вставками
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            buttonBubble.Enabled = true;
            buttonQuick.Enabled = true;
            buttonSelection.Enabled = true;
            buttonHeapsort.Enabled = true;
            buttonInsert.Enabled = false;
            buttonShaker.Enabled = true;
            buttonTimsort.Enabled = true;
        }

        // Сортировка Шелла
        private void buttonShaker_Click(object sender, EventArgs e)
        {
            buttonBubble.Enabled = true;
            buttonQuick.Enabled = true;
            buttonSelection.Enabled = true;
            buttonHeapsort.Enabled = true;
            buttonInsert.Enabled = true;
            buttonShaker.Enabled = false;
            buttonTimsort.Enabled = true;
        }

        // TimSort
        private void buttonTimsort_Click(object sender, EventArgs e)
        {
            buttonBubble.Enabled = true;
            buttonQuick.Enabled = true;
            buttonSelection.Enabled = true;
            buttonHeapsort.Enabled = true;
            buttonInsert.Enabled = true;
            buttonShaker.Enabled = true;
            buttonTimsort.Enabled = false;
        }

        private void buttonInit_Click(object sender, EventArgs e)
        {
            MAX_HEIGHT = 491;
            textBoxOutText.Text = "";
            numbers = GetNumbersFromTextBox();
            RectanglesInit(numbers);
            buttonStartPause.Enabled = true;
        }

        private int[] GetNumbersFromTextBox()
        {
            string inputNum = textBoxInText.Text;
            
            if (inputNum.Equals(""))
            {              
                inputNum = "6 4 7 2 8 7 9 5 6 8 1";
                textBoxInText.Text = inputNum;
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

        private void RectanglesInit(int[] array)
        {
            colors = new Color[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                colors[i] = Color.Red;
            }
            if (HasNegative(array))
                MAX_HEIGHT = MAX_HEIGHT / 2;

            int space = MAX_WIDTH / array.Length;
            int maxNumber = GetMax(array);
            int pixelsPerNumber = MAX_HEIGHT / maxNumber;

            panelDraw.Controls.Clear();
            panelDraw.Refresh();
            panelDraw.Update();
            rectangles = new Rectangle[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                int width = 50;
                int height = 0;
                int top = 0;
                if (array[i] < 0)
                {
                    height = (-1) * array[i] * pixelsPerNumber;
                    top = MAX_HEIGHT;
                }
                else
                {
                    height = array[i] * pixelsPerNumber;
                    top = MAX_HEIGHT - height;
                }
                int left = space * i;
               // Rectangle rectangle = new Rectangle();                
    
               /* graphics = panelDraw.CreateGraphics();
                SolidBrush myBrush = new SolidBrush(Color.Red);
                Pen pen = new Pen(Color.Black);*/

                Rectangle rectBas = new Rectangle(left, top, width, height);
                /*graphics.DrawRectangle(pen, rectBas);
                graphics.FillRectangle(myBrush, rectBas);

                string arr = numbers[i].ToString();
                Font drawFont = new Font("Consolas", width/3);
                graphics.DrawString(arr, drawFont, Brushes.Black, left, top);*/

                rectangles[i] = rectBas;
                DrawRectangle(rectangles[i], colors[i], numbers[i].ToString());
            }
        }

        private void DrawRectangle(Rectangle rectangle, Color color, string str)
        {
            graphics = panelDraw.CreateGraphics();
            SolidBrush myBrush = new SolidBrush(color);
            Pen pen = new Pen(Color.Black);

            //Rectangle rectBas = new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height);
            graphics.DrawRectangle(pen, rectangle);
            graphics.FillRectangle(myBrush, rectangle);

            //string arr = numbers[index].ToString();
            Font drawFont = new Font("Consolas", rectangle.Width / 3);
            graphics.DrawString(str, drawFont, Brushes.Black, rectangle.Left, rectangle.Top);
        }

        private void DrawAllRectangles(int[] numbers, Rectangle[] rectangles,  Color[] colors)
        {
            richTextBox.Invoke((MethodInvoker)delegate
            {
                panelDraw.Controls.Clear();
                panelDraw.Refresh();
                panelDraw.Update();

                for (int i = 0; i < numbers.Length; i++)
                {
                    DrawRectangle(rectangles[i], colors[i], numbers[i].ToString());
                }
                
            });
        }

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

        private bool HasNegative(int[] array)
        {
            foreach (int n in array)
            {
                if (n < 0) return true;
            }
            return false;
        }

        private void SetOrangeColor(int index1, int index2)
        {

            dispUI.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
           //richTextBox.Invoke((MethodInvoker)delegate
            //{
                //graphics.FillRectangle(Brushes.Aqua, 100, 150, 10, 10);
                graphics.FillRectangle(Brushes.Orange, rectangles[index1]);
                graphics.FillRectangle(Brushes.Orange, rectangles[index2]);
            });
            //});
        }

        private void SwapRectangles(int index1, int index2)
        {
            /*Rectangle temp = new Rectangle();
            temp.X = rectangles[index1].X;
            temp.Y = rectangles[index1].Y;
            rectangles[index2].X = temp.X;       
            rectangles[index2].Y = temp.Y;*/
            /*graphics.DrawRectangle(new Pen(Color.White), rectangles[index1]);
            graphics.DrawRectangle(new Pen(Color.White), rectangles[index2]);
            graphics.FillRectangle(Brushes.White, rectangles[index1]);
            graphics.FillRectangle(Brushes.White, rectangles[index2]);*/

            var temp = rectangles[index1];
            rectangles[index1] = rectangles[index2];
            rectangles[index2] = temp;

            Rectangle temp1 = new Rectangle();
            temp1.X = rectangles[index1].X;
            //temp1.Y = rectangles[index1].Y;
            rectangles[index1].X = rectangles[index2].X;
            //rectangles[index1].Y = rectangles[index2].Y;
            rectangles[index2].X = temp1.X;
            //rectangles[index2].Y = temp1.Y;
            /*

            Thread.Sleep(1000);
            graphics.DrawRectangle(new Pen(Color.Black), rectangles[index1]);
            graphics.DrawRectangle(new Pen(Color.Black), rectangles[index2]);
            graphics.FillRectangle(Brushes.Red, rectangles[index1]);
            graphics.FillRectangle(Brushes.Red, rectangles[index2]);*/

        }

        private void SetGrayColor(int index1)
        {
            dispUI.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                graphics = panelDraw.CreateGraphics();
                SolidBrush myBrush = new SolidBrush(Color.Gray);
                graphics.FillRectangle(myBrush, rectangles[index1]);
            });
        }

        private void SetRedColor(int index1, int index2)
        {
            dispUI.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                graphics = panelDraw.CreateGraphics();
                SolidBrush myBrush = new SolidBrush(Color.Red);
                graphics.FillRectangle(myBrush, rectangles[index1]);
                graphics.FillRectangle(myBrush, rectangles[index2]);
            });
        }

        private void buttonStartPause_Click(object sender, EventArgs e)
        {
            buttonStartPause.Enabled = false;
            GetSortType();
            Thread sortingThread = new Thread(delegate ()
            {
                switch (sortType)
                {
                    case BUBBLESORT:
                        numbers = BubbleSort(numbers);
                        break;
                    case INSERTSORT:
                        numbers = InsertionSort(numbers);
                        break;
                    case SHAKERSORT:
                        numbers = ShakerSort(numbers);
                        break;
                }

                dispUI.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
                {
                    buttonStartPause.Enabled = true;
                });

                PrintArrayToTextField(numbers);
            });
            sortingThread.IsBackground = true;
            sortingThread.Start();
        }

        private void GetSortType()
        {
            buttonInit.Enabled = false;

            if (buttonBubble.Enabled == false)
                sortType = BUBBLESORT;

            if (buttonQuick.Enabled == false)
                sortType = QUICKSORT;

            if (buttonSelection.Enabled == false)
                sortType = SELECTIONSORT;

            if (buttonHeapsort.Enabled == false)
                sortType = HEAPSORT;

            if (buttonInsert.Enabled == false)
                sortType = INSERTSORT;

            if (buttonShaker.Enabled == false)
                sortType = SHAKERSORT;

            if (buttonTimsort.Enabled == false)
                sortType = TIMSORT;
        }

        private void PrintArrayToTextField(int[] array)
        {
            dispUI.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                textBoxOutText.Text = "";
                foreach (int n in array)
                {
                    textBoxOutText.Text += n + " ";
                }
                buttonInit.Enabled = true;
            });
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxInText.Clear();
            panelDraw.Controls.Clear();
            panelDraw.Invalidate();
        }

        // Изменение цвета текста одной строки псевдокода
        void ChangeColorLine(int line)
        {
            dispUI.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {/*
                richTextBox.Invoke((MethodInvoker)delegate
            {*/
               int start = richTextBox.GetFirstCharIndexFromLine(line);
               int length;

               if (line + 1 >= richTextBox.Lines.Length)
                   length = richTextBox.TextLength - start;
               else
                   length = richTextBox.GetFirstCharIndexFromLine(line + 1) - start;

               richTextBox.Select(start, length);
               richTextBox.SelectionColor = Color.Red;
           });
        }

        // Изменение цвета текста предыдущей строки псевдокода
        void ChangeColorPredLine(int line)
        {
            dispUI.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {/*
                richTextBox.Invoke((MethodInvoker)delegate
            {*/
                int start = richTextBox.GetFirstCharIndexFromLine(line);
                int length;

                if (line + 1 >= richTextBox.Lines.Length)
                    length = richTextBox.TextLength - start;
                else
                    length = richTextBox.GetFirstCharIndexFromLine(line + 1) - start;

                richTextBox.Select(start, length);
                richTextBox.SelectionColor = Color.Black;
            });
        }
    }
}
            