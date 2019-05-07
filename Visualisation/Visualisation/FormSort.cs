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

namespace Visualisation
{
    public partial class FormSort : Form
    {
        private int[] numbers;
        private const int MAX_WIDTH = 593;
        private int MAX_HEIGHT = 445;
        private Rectangle[] rectangles;
        Graphics graphics;

        public FormSort()
        {
            InitializeComponent();
        }

        // Пузырьковая сортировка
        private void buttonBubble_Click(object sender, EventArgs e)
        {

        }

        // Быстрая сортировка
        private void buttonQuick_Click(object sender, EventArgs e)
        {

        }

        // Сортировка выбором
        private void buttonSelection_Click(object sender, EventArgs e)
        {

        }

        // Пирамидальная сортировка
        private void buttonHeapsort_Click(object sender, EventArgs e)
        {

        }

        //Сортировка вставками
        private void buttonInsert_Click(object sender, EventArgs e)
        {

        }

        // Сортировка Шелла
        private void buttonShell_Click(object sender, EventArgs e)
        {

        }

        // TimSort
        private void buttonTimsort_Click(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            textBoxOutText.Text = "";
            numbers = GetNumbersFromTextBox();
            InitializeRectangles(numbers);
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

        private void InitializeRectangles(int[] array)
        {
            if (HasNegative(array))
                MAX_HEIGHT = MAX_HEIGHT / 2;

            int space = MAX_WIDTH / array.Length;
            int maxNumber = GetMax(array);
            int pixelsPerNumber = MAX_HEIGHT / maxNumber;

            panel1.Controls.Clear();
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
                string arr = "12";
                Font font1 = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);
                TextFormatFlags flags = TextFormatFlags.WordBreak;
                graphics = panel1.CreateGraphics();
                SolidBrush myBrush = new SolidBrush(Color.Red);
                Pen pen = new Pen(Color.Black);
                graphics.DrawRectangle(pen, left, top, width, height);
                graphics.DrawString(arr, font1, Brushes.Blue, rectangle);
                //graphics.FillRectangle(myBrush, left, top, width, height);
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
    }
}
