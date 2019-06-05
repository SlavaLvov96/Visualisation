﻿using System;
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
        private const int SHELLSORT = 5;
        private const int TIMSORT = 6;

        private int sortType;

        private int[] numbers;
        private const int MAX_WIDTH = 593;
        private int MAX_HEIGHT = 491;
        private Rectangle[] rectangles;
        Graphics graphics;

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
            buttonShell.Enabled = true;
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
                    SetOrangeColor(i, j);
                    ChangeColorPredLine(1);
                    ChangeColorLine(2);
                    Thread.Sleep(300);
                    if (input[j] < input[i])
                    {
                        temp = input[j];
                        input[j] = input[i];
                        input[i] = temp;
                        ChangeColorPredLine(2);
                        ChangeColorLine(3);
                        Thread.Sleep(300);
                        SwapRectangles(i, j);
                        ChangeColorPredLine(3);
                    }
                    ChangeColorPredLine(2);
                    Thread.Sleep(300);
                   // SetRedColor(i, j);
                }
                ChangeColorPredLine(1);
                SetGrayColor(i);
            }
            ChangeColorPredLine(0);
            return input;
        }
        // Быстрая сортировка
        private void buttonQuick_Click(object sender, EventArgs e)
        {
            buttonBubble.Enabled = true;
            buttonQuick.Enabled = false;
            buttonSelection.Enabled = true;
            buttonHeapsort.Enabled = true;
            buttonInsert.Enabled = true;
            buttonShell.Enabled = true;
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
            buttonShell.Enabled = true;
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
            buttonShell.Enabled = true;
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
            buttonShell.Enabled = true;
            buttonTimsort.Enabled = true;
        }

        // Сортировка Шелла
        private void buttonShell_Click(object sender, EventArgs e)
        {
            buttonBubble.Enabled = true;
            buttonQuick.Enabled = true;
            buttonSelection.Enabled = true;
            buttonHeapsort.Enabled = true;
            buttonInsert.Enabled = true;
            buttonShell.Enabled = false;
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
            buttonShell.Enabled = true;
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
                //Random random = new Random();
                //int randomNumber = random.Next(0, 100);
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
                int width = 25;
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
                Rectangle rectangle = new Rectangle();                
    
                graphics = panelDraw.CreateGraphics();
                SolidBrush myBrush = new SolidBrush(Color.Red);
                Pen pen = new Pen(Color.Black);

                Rectangle[] rects = {
                    new Rectangle(left, top, width, height)
                };
                graphics.DrawRectangles(pen, rects);
                graphics.FillRectangles(myBrush, rects);

                string arr = numbers[i].ToString();
                
                Font drawFont = new Font("Consolas", 8);
                graphics.DrawString(arr, drawFont, Brushes.Black, left, top);

                rectangles[i] = rectangle;           
            }
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
                graphics.FillRectangle(Brushes.Orange, rectangles[index1]);
                graphics.FillRectangle(Brushes.Orange, rectangles[index2]);

                panelDraw.Update();
            });
        }

        private void SwapRectangles(int index1, int index2)
        {
            dispUI.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                int leftFirst = (int)rectangles[index1].Left;
                int leftSecond = (int)rectangles[index2].Left;
                int topFirst = (int)rectangles[index1].Top;
                int topSecond = (int)rectangles[index2].Top;
                //rectangles[index1] = new Thickness(leftSecond, topFirst, 0, 0);
                //rectangles[index2] = new Thickness(leftFirst, topSecond, 0, 0);
            });
            Rectangle temp = rectangles[index1];
            rectangles[index1] = rectangles[index2];
            rectangles[index2] = temp;
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
                    /*case INSERTION_SORT:
                        numbers = InsertionSort(numbers);
                        break;
                    case SHAKE_SORT:
                        numbers = ShakerSort(numbers);
                        break;*/
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

            if (buttonShell.Enabled == false)
                sortType = SHELLSORT;

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
            richTextBox.Invoke((MethodInvoker)delegate
            {
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
            richTextBox.Invoke((MethodInvoker)delegate
            {
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
