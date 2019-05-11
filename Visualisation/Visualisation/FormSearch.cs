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
    public partial class FormSearch : Form
    {

        BinaryTree<int> Tree = new BinaryTree<int>();

        Graphics pictGraphics; // для доступа к поверхности pictureBox

        // шрифт для показа содержимого узлов
        Font NodesFont = new Font(FontFamily.GenericSansSerif, (float)10.0, FontStyle.Regular);

        Color NodesColor = Color.FromArgb(120, 219, 226); // цвет внутренных узлов
        Color LeavesColor = Color.FromArgb(100, 149, 237); // цвет листьев

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

            int pb_width = pb_animation.Width, pb_height = pb_animation.Height; // размеры pictureBox

            // следующий код даёт доступ к рисованию на картинке
            pb_animation.Image = (Image)new Bitmap(pb_width, pb_height);
            pictGraphics = Graphics.FromImage(pb_animation.Image);

            RefreshTree(); // обновляем картинку
            
        }

        // содержится ли элемент item среди первых n элементов массива ?
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
            // DateTime.Now.Millisecond - для инициализации случайного датчика
            Random random = new Random(DateTime.Now.Millisecond);

            int n = random.Next(nmin, nmax + 1); // получаем случайный размер
            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                int newDigit = random.Next(xmin, xmax + 1); // генерируем новое случайное число

                // если оно уже есть среди ранее сгенерированных случайных чисел
                if (ContainsInArray(array, i, newDigit) == true) i--;
                else array[i] = newDigit; // если оно НОВОЕ
            }

            return array;
        }

        // обновление картинки
        void RefreshTree() 
        {
            pictGraphics.Clear(pb_animation.BackColor); // очищаем картинку
            Tree.DrawTree(pictGraphics, 14, pb_animation.Width, pb_animation.Height,
            NodesColor, LeavesColor, NodesFont); // показываем дерево
            //CopyRight(); // рисуем копирайт
            pb_animation.Invalidate(); // инициируем отрисовку на картинке
        }

        void ClearTree()
        {
            pictGraphics.Clear(pb_animation.BackColor); // очищаем картинку
            pb_animation.Invalidate(); // инициируем отрисовку на картинке
            rtb_result.AppendText("Дерево удалено\n");
        }

        private void b_random_click(object sender, EventArgs e)
        {
            // получаем случайные числа (в данном случае от 1 до 99)
            int[] A = GetRandItems(3, 15, 1, 99);
            Tree = new BinaryTree<int>(A, A.Length); // строим дерево

            RefreshTree();
            rtb_result.AppendText("Построено дерево из случайных вершин\n");
        }

        private void b_add_Click(object sender, EventArgs e)
        {
            //tb_add.Text

            // Insert возвращает false, если была попытка вставки существующего элемента
            if (Tree.Insert(Convert.ToInt32(tb_add.Text)) == false)
            {
                MessageBox.Show("Элемент " + tb_add.Text.ToString() + " уже имеется");
                return;
            }

            RefreshTree();
            rtb_result.AppendText(  "Добавлена вершина " + tb_add.Text.ToString()+"\n");
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (Tree.Remove(Convert.ToInt32(tb_delete.Text)) == false)
            {
                MessageBox.Show("Элемент " + tb_delete.ToString() + " отсутствует");
                return;
            }

            RefreshTree();
            rtb_result.AppendText("Удалена вершина" + tb_delete.Text.ToString()+"\n");
        }

        // выбор файла с помощью стандартного диалога
        string GetFName()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Special Tree Files (*.derevo)|*.derevo";
            dlg.Multiselect = false;
            dlg.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            if (dlg.ShowDialog() == DialogResult.OK)
                return dlg.FileName;
            return null;
        }

        /*private void загрузитьКоллекциюИзФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string FileName = GetFName(); // пользователь выбирает файл в стандартном диалоге
            if (FileName == null) return; // если пользователь ничего не выбрал

            // грузим элементы из файла в список (не в массив, т.к. число элементов
            // неясно до полного просмотра файла)
            List<int> Items = new List<int>();
            StreamReader sr = new StreamReader(FileName, Encoding.GetEncoding(1251));
            string buffer;
            while ((buffer = sr.ReadLine()) != null)
            {
                Items.Add(Convert.ToInt32(buffer));
            }
            sr.Close();

            int[] A = Items.ToArray(); // получаем массив по списку элементов

            Derevo = new BinaryTree<int>(A, A.Length); // строим дерево

            RefreshTree();
        }*/

        private void avl_click(object sender, EventArgs e)
        {
           //ClearTree();
           rtb_pseudocode.Text = "Node search(x : Node, k : T):\n" +
                "   if x == null or k == x.key\n" +
                "      return x\n" +
                "   if k < x.key\n" +
                "      return search(x.left, k)\n" +
                "   else\n" +
                "                return search(x.right, k)";
                }

        private void binary_click(object sender, EventArgs e)
        {
            //ClearTree();
            rtb_pseudocode.Text = "Node search(x : Node, k : T):\n" +
                "   if x == null or k == x.key\n" +
                "      return x\n" +
                "   if k < x.key\n" +
                "      return search(x.left, k)\n" +
                "   else\n" +
                "                return search(x.right, k)";
    }

        private void interpolation_click(object sender, EventArgs e)
        {
            //ClearTree();
            rtb_pseudocode.Text = "int InterpolSearch(int A[], int key)\n " +
                "{\n    " +
                "   int mid, left = 0, right = N - 1;\n     " +
                "   while (A[left] <= key && A[right] >= key)\n" +
                "   {\n  " +
                "       mid = left + ((key - A[left]) * (right - left)) / (A[right] - A[left]);\n" +
                "       if (A[mid] < key) left = mid + 1;\n" +
                "       else if (A[mid] > key) right = mid - 1;\n" +
                "       else return mid;\n" +
                "   }\n" +
                "   if (A[left] == key) return left;\n" +
                "   else return -1;\n}";
        }

        private void linear_click(object sender, EventArgs e)
        {
            //ClearTree();
            rtb_pseudocode.Text="int LineSearch(int A[], int key)\n" +
                "{\n    " +
                "   for (i = 0; i < N; i++)\n       " +
                "   if (A[i] == key) return i;\n    " +
                "   return -1;\n" +
                "}";
        }

        private void numeral_click(object sender, EventArgs e)
        {
            //ClearTree();
            rtb_pseudocode.Text= "Item searchR(link h, Key v, int d)\n" +
                "      {\n" +
                "                if (h == 0) return nullItem;\n" +
                "                if (v == h->item.key()) return h->item;\n" +
                "                if (digit(v, d) == 0)\n" +
                "                    return searchR(h->l, v, d + 1);\n" +
                "                else\n" +
                "                    return searchR(h->r, v, d + 1);\n" +
                "            }";
        }

        private void prev_click(object sender, EventArgs e)
        {

        }

        private void next_click(object sender, EventArgs e)
        {

        }


    }
}




       
        
     

       /* void CopyRight() // рисование копирайта
        {
            string s = "Автор Бартенева Н.И.";
            Brush B = new SolidBrush(Color.Red); // цвет надписи копирайта

            // центр круга, по которому выведем буквы
            double xc = pictDerevo.Width - 80;
            double yc = 80;
            // h_fi - шаг угла, cur_fi - текущий угол
            double h_fi = 2.0 * Math.PI / s.Length, cur_fi = Math.PI / 2.0;

            for (int i = 0; i < s.Length; i++, cur_fi += h_fi)
            {
                // позиция для вывода i-ой буквы
                double x = xc - 60 * Math.Cos(cur_fi);
                double y = yc - 60 * Math.Sin(cur_fi);

                // вывод i-ой буквы
                pictGraphics.DrawString(s.Substring(i, 1), NodesFont, B, (float)x, (float)y);
            }
        }*/




//класс вершин
/*   class Vertices
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
*/
