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
        // определяем дерево
        BinaryTree<int> Tree = new BinaryTree<int>();

        // для доступа к поверхности pictureBox
        Graphics pictGraphics; 

        // шрифт для показа содержимого вершин
        Font NodesFont = new Font(FontFamily.GenericSansSerif, (float)10.0, FontStyle.Regular);

        // цвет внутренних и внешних вершин
        Color NodesColor = Color.FromArgb(120, 219, 226); 
        Color LeavesColor = Color.FromArgb(100, 149, 237); 

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

        // обновляем изображение
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
            rtb_result.AppendText("Дерево удалено.\n");
        }

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
                MessageBox.Show("Вершина " + tb_delete.ToString() + " отсутствует.");
                return;
            }

            // иначе - обновляем изображение
            RefreshTree();
            rtb_result.AppendText("Удалена вершина " + tb_delete.Text.ToString() + ".\n");
        }
        
        // поиск вершины
        private void b_search_Click(object sender, EventArgs e)
        {
            var select = (Button)sender;
            switch (select.Name)
            {
                // поиск в авл-дереве
                case "avl_menu":
                    rtb_result.AppendText("Поиск в АВЛ дереве.\n");

                    rtb_pseudocode.Text = "Node search(x : Node, k : T):\n" +
                "   if x == null or k == x.key\n" +
                "      return x\n" +
                "   if k < x.key\n" +
                "      return search(x.left, k)\n" +
                "   else\n" +
                "                return search(x.right, k)";
                    avlTreeSearch();
                    break;

                // поиск в бинарном дереве
                case "binary_tree_menu":
                    rtb_result.AppendText("Поиск в бинарном дереве.\n");
                    rtb_pseudocode.Text = "Node search(x : Node, k : T):\n" +
                "   if x == null or k == x.key\n" +
                "      return x\n" +
                "   if k < x.key\n" +
                "      return search(x.left, k)\n" +
                "   else\n" +
                "                return search(x.right, k)";

                    binaryTreeSearch();
                    break;

                // интерполяционный поиск
                case "interpolation_menu":
                    rtb_result.AppendText("Интерполяционный поиск.\n");
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
                    interpolationTreeSearch();
                    break;

                //линейный поиск
                case "linear_menu":
                    rtb_result.AppendText("Линейный поиск.\n");
                    rtb_pseudocode.Text = "int LineSearch(int A[], int key)\n" +
                "{\n    " +
                "   for (i = 0; i < N; i++)\n       " +
                "   if (A[i] == key) return i;\n    " +
                "   return -1;\n" +
                "}";
                    linearTreeSearch();
                    break;

                // цифровой поиск
                case "digital_menu":
                    rtb_result.AppendText("Поиск в цифровом дереве.\n");
                    rtb_pseudocode.Text = "Item searchR(link h, Key v, int d)\n" +
                "      {\n" +
                "                if (h == 0) return nullItem;\n" +
                "                if (v == h->item.key()) return h->item;\n" +
                "                if (digit(v, d) == 0)\n" +
                "                    return searchR(h->l, v, d + 1);\n" +
                "                else\n" +
                "                    return searchR(h->r, v, d + 1);\n" +
                "            }";
                    digitalTreeSearch();
                    break;

                // поиск по умолчанию
                default:
                    rtb_result.AppendText("Поиск по умолчанию.\n");
                    binaryTreeSearch();
                    break;
            }
        }

        // поиск в бинарном дереве
        void binaryTreeSearch()
        {
            timer1.Enabled = true;

            // если вершина отсутствует
            if (Tree.binFind(Convert.ToInt32(tb_search_value.Text)) == false)
            {
                rtb_result.AppendText("Вершина " + tb_search_value.Text.ToString() + " отсутствует.\n");
                return;
            }

            // иначе - обновить изображение
            RefreshTree();
            rtb_result.AppendText("Найдена вершина " + tb_search_value.Text.ToString() + ".\n");
        }

        // поиск в авл-дереве
        void avlTreeSearch()
        {

        }

        // интерполяционный поиск
        void interpolationTreeSearch()
        {

        }

        // линейный поиск
        void linearTreeSearch()
        {

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

        // таймер
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Tree.binFind(Convert.ToInt32(tb_search_value.Text)) == true)
            {
                NodesColor = Color.Red; // цвет внутренных узлов
                LeavesColor = Color.Purple; // цвет листьев
                RefreshTree();

            }
            RefreshTree();
        }
    }
}







       
        
     

 