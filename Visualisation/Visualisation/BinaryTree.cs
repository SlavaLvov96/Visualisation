using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Visualisation
{
    class BinaryTreeNode<Data>// шаблон класса УЗЕЛ ДЕРЕВА
    {
        public Data data; // полезные данные
        public BinaryTreeNode<Data> left, right; // ссылки на дочерние узлы
        public BinaryTreeNode(Data data) // конструктор
        {
            this.data = data;
            this.left = null;
            this.right = null;
        }

        // является ли узел листовым?
        public bool IsLeaf()
        {
            return (left == null && right == null) ? true : false;
        }
    }

    // класс БИНАРНОЕ ДЕРЕВО ПОИСКА
    class BinaryTree<Data> where Data : IComparable<Data> 
    {
        private BinaryTreeNode<Data> root; // ссылка на корень
        public BinaryTree() // конструктор пустого дерева
        {
            this.root = null;
        }

        private void QuickSort(Data[] A, int low, int high) // "быстрая сортировка"
        {
            int i = low, j = high;
            Data x = A[(low + high) / 2];
            do
            {
                while (A[i].CompareTo(x) < 0) i++;
                while (A[j].CompareTo(x) > 0) j--;
                if (i <= j)
                {
                    Data temp = A[i];
                    A[i] = A[j];
                    A[j] = temp;
                    i++;
                    j--;
                }
            }
            while (i < j);

            if (low < j) QuickSort(A, low, j);
            if (i < high) QuickSort(A, i, high);
        }

        // следующая функция вставки формирует идеально сбалансированное дерево
        void IBTInsert(Data[] A, int low, int high)
        {
            if (low > high) return; // граничное условие - для пустого подмассива
            int middle = (low + high) / 2; // середина подмассива
            this.Insert(A[middle]); // вставляем элемент из середины подмассива
            IBTInsert(A, low, middle - 1); // рекурсия для левой половины
            IBTInsert(A, middle + 1, high); // рекурсия для правой половины
        }

        // конструктор на основе массива
        public BinaryTree(Data[] recordsArray, int newRecords)
        {
            if (newRecords == 0) // если массив пустой
            {
                this.root = null;
                return;
            }

            // если более одной записи - требуется сортировка
            if (newRecords > 1) QuickSort(recordsArray, 0, newRecords - 1);

            // строим по отсортированному массиву сбалансированное дерево
            IBTInsert(recordsArray, 0, newRecords - 1);
        }

        // вставка
        public bool Insert(Data NewItem) 
        {
            if (root == null) // если дерево пустое
            {
                root = new BinaryTreeNode<Data>(NewItem);
                return true;
            }

            // для непустого дерева

            BinaryTreeNode<Data> current = root;
            while (true)
            {
                // если такой элемент уже есть в дереве, вставка неуспешна
                if (current.data.CompareTo(NewItem) == 0) return false;

                // если элемент в узле cur больше элемента NewItem
                if (current.data.CompareTo(NewItem) > 0)
                {
                    if (current.left == null) // если у cur нет левого потомка
                    {
                        // вставляем влево и завершаем вставку
                        current.left = new BinaryTreeNode<Data>(NewItem);
                        break;
                    }

                    current = current.left; // если у cur есть левый потомок, идём к нему
                }

                else // если элемент в узле cur меньше элемента NewItem
                {
                    // действуем аналогично предыдущей ситуации, но в правом поддереве
                    if (current.right == null)
                    {
                        current.right = new BinaryTreeNode<Data>(NewItem);
                        break;
                    }

                    current = current.right;
                }
            }
            
            return true;
        }
 
        // визуализация поддерева с корнем root
        private void DrawTree(Graphics graphics, BinaryTreeNode<Data> root,
        int LevelH, int radius, int left, int right, int top, Color NodesColor,
        Color LeavesColor, Font NodesLabel)
        {
            // levelH - высота области под один уровень, radius - радиус круга, который показывает узел,
            // NodesColor - цвет внутренныз узлов, LeavesColor - цвет листьев,
            // NodesLabel - шрифт для показа элементов, G - объект, куда выводим

            
            // координаты центра круга, обозначающего узел дерева
            int x_center = (left + right) / 2, y_center = top + LevelH / 2;

            // кисть для закраски круга, цвет зависит от того, root - лист или нет
            Brush ForEllipse = new SolidBrush((root.IsLeaf() == true) ? LeavesColor : NodesColor);

            // рисуем узел-кружок
            graphics.FillEllipse(ForEllipse,
            new Rectangle(x_center - radius, y_center - radius, 3 * radius, 3 * radius));

            // показываем элемент узла
            graphics.DrawString(root.data.ToString(), NodesLabel, Brushes.Black,
            new Rectangle(x_center , y_center - radius /2, 2 * radius, 2*radius));

            int d = (int)(Math.Sqrt(1) * ((double)radius));
            int rchild_left, rchild_top = top + LevelH, rchild_right;
            int x_center_child, y_center_child = rchild_top + LevelH / 2;

            if (root.left != null) // если есть левое поддерево
            {
                // координаты области построения
                rchild_left = left;
                rchild_right = (left + right) / 2;
                x_center_child = (rchild_left + rchild_right) / 2;

                // рисуем соединительную линию между узлом и левым сыном
                graphics.DrawLine(new Pen(Color.Black), x_center_child, y_center_child - d, x_center - d, y_center + d);

                // рекурсивный вызов для левого сына
                DrawTree(graphics, root.left, LevelH, radius, rchild_left, rchild_right,
                rchild_top, NodesColor, LeavesColor, NodesLabel);
            }

            if (root.right != null) // если есть правое поддерево (аналогично левому)
            {
                rchild_left = (left + right) / 2;
                rchild_right = right;
                x_center_child = (rchild_left + rchild_right) / 2;
                graphics.DrawLine(new Pen(Color.Black), x_center + d, y_center + d, x_center_child, y_center_child - d);
                DrawTree(graphics, root.right, LevelH, radius, rchild_left, rchild_right,
                rchild_top, NodesColor, LeavesColor, NodesLabel);
            }
        }
  
        // количество уровней в поддереве с корнем root
        private int LevelsCount(BinaryTreeNode<Data> root)
        {
            int level_left_sub = 0, level_right_sub = 0;

            // если левое поддерево непустое, считаем его число уровней
            if (root.left != null) level_left_sub = LevelsCount(root.left);

            // если правое поддерево непустое, считаем его число уровней
            if (root.right != null) level_right_sub = LevelsCount(root.right);

            // число уровней дерева = 1 + число уровней самого высокого поддерева

            // если левое поддерево выше правого
            if (level_left_sub >= level_right_sub)
                return level_left_sub + 1;
            return level_right_sub + 1; // если правое поддерево выше левого
        }

        // визуализация дерева - главная функция
        public void DrawTree(Graphics graphics, int radius, int width, int height,
        Color NodesColor, Color LeavesColor, Font NodesLabel)
        {
            if (this.root == null) // для пустого дерева
            {
                graphics.DrawString("Дерево пустое ", NodesLabel, Brushes.Black,
                (float)0.0, (float)0.0);
                return;
            }

            // для непустого дерева

            int countLevels = LevelsCount(this.root); // вычисляем количество уровней
            DrawTree(graphics, this.root, height / countLevels, radius, 0, width, 0,
            NodesColor, LeavesColor, NodesLabel); // визуализируем дерево
        }

        // поиск родителя для узла Item
        private BinaryTreeNode<Data> FindParent(Data item)
        {
            if (this.root.data.CompareTo(item) == 0) return null;
            BinaryTreeNode<Data> current = root;
            while (true)
            {
                if (current.data.CompareTo(item) > 0)
                {
                    if (current.left == null) break;
                    if (current.left.data.CompareTo(item) == 0) break;
                    current = current.left;
                }

                else
                {
                    if (current.right == null) break;
                    if (current.right.data.CompareTo(item) == 0) break;
                    current = current.right;
                }
            }

            return current;
        }

        // удаление элемента ToRemove
        public bool Remove(Data ToRemove) 
        {
            BinaryTreeNode<Data> nodeToRemove = root;
            BinaryTreeNode<Data> parent = null;

            // спуск с поиском удаляемого узла
            while ((nodeToRemove != null) && (ToRemove.CompareTo(nodeToRemove.data) != 0))
            {
                parent = nodeToRemove;
                if (ToRemove.CompareTo(nodeToRemove.data) < 0)
                    nodeToRemove = nodeToRemove.left;
                else nodeToRemove = nodeToRemove.right;
            }

            // если запрашиваемый элемент отсутствует
            if (nodeToRemove == null) return false;

            // если удаляемый узел - корень, и он единственный
            if (nodeToRemove == root && root.IsLeaf() == true)
            {
                root = null;
                return true;
            }

            // если удаляемый узел является листовым
            if (nodeToRemove.left == null && nodeToRemove.right == null)
            {
                // если он - левый ребёнок своего родителя
                if (nodeToRemove.data.CompareTo(parent.data) < 0)
                    parent.left = null;

                else parent.right = null; // если он - правый ребёнок своего родителя
                return true;
            }

            // если у удаляемого узла есть только правое поддерево
            if (nodeToRemove.left == null && nodeToRemove.right != null)
            {
                // если удаляемый узел - корень
                if (nodeToRemove == root) root = root.right;
                else // если удаляемый узел - не корень
                {

                    // если удаляемый узел - левый ребёнок своего родителя
                    if (nodeToRemove.data.CompareTo(parent.data) < 0)
                        parent.left = nodeToRemove.right;

                    // если он правый ребёнок своего родителя
                    else parent.right = nodeToRemove.right;
                }
                return true;
            }

            // если у удаляемого узла есть только левое поддерево
            if (nodeToRemove.left != null && nodeToRemove.right == null)
            {
                // если удаляемый узел - корень
                if (nodeToRemove == root) root = root.left;
                else // если удаляемый узел - не корень
                {
                    // если удаляемый узел - левый ребёнок своего родителя
                    if (nodeToRemove.data.CompareTo(parent.data) < 0)
                        parent.left = nodeToRemove.left;

                    // если удаляемый узел - правый ребёнок своего родителя
                    else parent.right = nodeToRemove.left;
                }
                return true;
            }

            // если у удаляемого узла есть оба поддерева
            // ищем наибольший элемент в левом поддереве удаляемого узла
            BinaryTreeNode<Data> biggestItem = nodeToRemove.left;
            while (biggestItem.right != null)
                biggestItem = biggestItem.right;
            // ищем родителя наибольшего элемента в левом поддереве
            BinaryTreeNode<Data> biggestItem_parent = FindParent(biggestItem.data);
            if (nodeToRemove.left != biggestItem) // если этот родитель - не сам удаляемый узел
            {
                // если у наибольшего элемента есть левое поддерево
                if (biggestItem.left != null) biggestItem_parent.right = biggestItem.left;
                else biggestItem_parent.right = null; // если у него нет левого поддерева
            }

            // если этот родитель - сам удаляемый узел
            else nodeToRemove.left = biggestItem.left;

            // заменяем элемент удаляемого узла на наибольший элемент в левом поддереве
            nodeToRemove.data = biggestItem.data;
            return true;
        }
    }
}
