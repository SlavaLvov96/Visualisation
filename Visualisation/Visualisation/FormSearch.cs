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
            pb_animation.Invalidate(); // инициируем отрисовку на картинке
            rtb_result.AppendText("Дерево обновлено.\n");
        }


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

            RefreshTree();
            rtb_result.AppendText("Построено дерево из случайных вершин.\n");
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
            rtb_result.AppendText("Добавлена вершина " + tb_add.Text.ToString() + ".\n");
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (Tree.Remove(Convert.ToInt32(tb_delete.Text)) == false)
            {
                MessageBox.Show("Элемент " + tb_delete.ToString() + " отсутствует.");
                return;
            }

            RefreshTree();
            rtb_result.AppendText("Удалена вершина " + tb_delete.Text.ToString() + ".\n");
        }

       
        private void b_search_Click(object sender, EventArgs e)
        {
            var select = (Button)sender;
            switch (select.Name)
            {
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

                default:
                    rtb_result.AppendText("Поиск по умолчанию.\n");
                    binaryTreeSearch();
                    break;
            }
        }



        void binaryTreeSearch()
        {
            timer1.Enabled = true;

            if (Tree.binFind(Convert.ToInt32(tb_search_value.Text)) == false)
            {
                rtb_result.AppendText("Вершина " + tb_search_value.Text.ToString() + " отсутствует.\n");
                return;
            }

            RefreshTree();
            rtb_result.AppendText("Найдена вершина " + tb_search_value.Text.ToString() + ".\n");
        }

        void avlTreeSearch()
        {

        }

        void interpolationTreeSearch()
        {

        }

        void linearTreeSearch()
        {

        }

        void digitalTreeSearch()
        {

        }

        private void prev_click(object sender, EventArgs e)
        {

        }

        private void next_click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            // При достижении определенного значения
            // останавливаем таймер, и выполняем дальнейшие действия
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







       
        
     

 