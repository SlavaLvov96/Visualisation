using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Visualisation
{
    // класс УЗЕЛ ДЕРЕВА
    class BinaryTreeNode<Data>
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

        // быстрая сортировка
        private void QuickSort(Data[] A, int low, int high) 
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

            // сортировка в зависимости больше значение или меньше
            if (low < j) QuickSort(A, low, j);
            if (i < high) QuickSort(A, i, high);
        }

        // Формирование идеально сбалансированного дерева
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
            // если массив пустой
            if (newRecords == 0) 
            {
                this.root = null;
                return;
            }

            // если более одной записи, выполняется сортировка
            if (newRecords > 1) QuickSort(recordsArray, 0, newRecords - 1);

            // формируем сбалансированное дерево
            IBTInsert(recordsArray, 0, newRecords - 1);
        }

        // добавление вершины дерева
        public bool Insert(Data NewItem) 
        {
            // если дерево пустое
            if (root == null) 
            {
                root = new BinaryTreeNode<Data>(NewItem);
                return true;
            }

            // если дерево не пустое
            BinaryTreeNode<Data> current = root;
            while (true)
            {
                // если такая вершина уже есть в дереве, добавление неуспешно
                if (current.data.CompareTo(NewItem) == 0) return false;

                // если вершина больше новой 
                if (current.data.CompareTo(NewItem) > 0)
                {
                    // если у вершины нет левого потомка
                    if (current.left == null) 
                    {
                        // добавляем вершину влево и завершаем добавление
                        current.left = new BinaryTreeNode<Data>(NewItem);
                        break;
                    }

                    // если у вершины есть левый потомок, идём к нему
                    current = current.left; 
                }

                // если вершина меньше новой
                else 
                {
                    // действуем аналогично предыдущей ситуации, но в правом поддереве
                    if (current.right == null)
                    {
                        current.right = new BinaryTreeNode<Data>(NewItem);
                        break;
                    }

                    // если у вершины есть правый потомок, идём к нему
                    current = current.right;
                }
            }
            
            // добавление произошло
            return true;
        }
 
        // рисование поддерева с корнем root
        private void DrawTree(Graphics graphics, BinaryTreeNode<Data> root,
        int Level, int radius, int left, int right, int top, Color NodesColor,
        Color LeavesColor, Font NodesLabel)
        {
            // level - высота области под один уровень, radius - радиус круга, который показывает узел,
            // NodesColor - цвет внутренних узлов, LeavesColor - цвет листьев,
            // NodesLabel - шрифт для показа элементов, graphics - объект, куда выводим

            // координаты центра круга, обозначающего узел дерева
            int x_center = (left + right) / 2, y_center = top + Level / 2;

            // кисть для закраски круга, цвет зависит от того, root - лист или нет
            Brush ForEllipse = new SolidBrush((root.IsLeaf() == true) ? LeavesColor : NodesColor);

            // кисть для рамки круга
            Pen ForEllipseFind = new Pen(Color.Black, 4);
            
            // рисуем рамку вершины
            graphics.DrawEllipse(ForEllipseFind,
           new Rectangle(x_center - radius, y_center - radius, 3 * radius, 3 * radius));

            // заполняем вершину
            graphics.FillEllipse(ForEllipse,
            new Rectangle(x_center - radius, y_center - radius, 3 * radius, 3 * radius));
                        
            // заполняем значение вершины
            graphics.DrawString(root.data.ToString(), NodesLabel, Brushes.Black,
            new Rectangle(x_center , y_center - radius /2, 2 * radius, 2*radius));

            // определяем координаты вершин
            int d = (int)(Math.Sqrt(1) * ((double)radius));
            int rchild_left, rchild_top = top + Level, rchild_right;
            int x_center_child, y_center_child = rchild_top + Level / 2;

            // если есть левое поддерево
            if (root.left != null) 
            {
                // координаты области построения
                rchild_left = left;
                rchild_right = (left + right) / 2;
                x_center_child = (rchild_left + rchild_right) / 2;

                // рисуем соединительную линию между вершиной и левым потомком
                graphics.DrawLine(new Pen(Color.Black), x_center_child, y_center_child - d, x_center - d, y_center + d);

                // рекурсивный вызов для левого потомка
                DrawTree(graphics, root.left, Level, radius, rchild_left, rchild_right,
                rchild_top, NodesColor, LeavesColor, NodesLabel);
            }

            // если есть правое поддерево (аналогично левому)
            if (root.right != null) 
            {
                rchild_left = (left + right) / 2;
                rchild_right = right;
                x_center_child = (rchild_left + rchild_right) / 2;
                graphics.DrawLine(new Pen(Color.Black), x_center + d, y_center + d, x_center_child, y_center_child - d);
                DrawTree(graphics, root.right, Level, radius, rchild_left, rchild_right,
                rchild_top, NodesColor, LeavesColor, NodesLabel);
            }
        }
  
        // вычисляем количество уровней в поддереве
        private int LevelsCount(BinaryTreeNode<Data> root)
        {
            int level_left_sub = 0, level_right_sub = 0;

            // если левое поддерево непустое, считаем количество уровней
            if (root.left != null) level_left_sub = LevelsCount(root.left);

            // если правое поддерево непустое, считаем количество уровней
            if (root.right != null) level_right_sub = LevelsCount(root.right);

            // количество уровней дерева = 1 + количество уровней самого высокого поддерева
            // если левое поддерево выше правого
            if (level_left_sub >= level_right_sub)
                return level_left_sub + 1;

            // если правое поддерево выше левого
            return level_right_sub + 1; 
        }

        // рисуем дерево - главная функция
        public void DrawTree(Graphics graphics, int radius, int width, int height,
        Color NodesColor, Color LeavesColor, Font NodesLabel)
        {
            // для пустого дерева
            if (this.root == null) 
            {
                graphics.DrawString("Дерево пустое ", NodesLabel, Brushes.Black,
                (float)0.0, (float)0.0);
                return;
            }

            // для непустого дерева
            int countLevels = LevelsCount(this.root); // вычисляем количество уровней
            DrawTree(graphics, this.root, height / countLevels, radius, 0, width, 0,
            NodesColor, LeavesColor, NodesLabel); // рисуем дерево
        }

        // поиск родителя для вершины
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

        // поиск в бинарном дереве
        public bool binFind(Data FindItem)
        {
            BinaryTreeNode<Data> nodeFindItem = root;
            BinaryTreeNode<Data> parent = null;

            // спуск по дереву с поиском вершины
            while ((nodeFindItem != null) && (FindItem.CompareTo(nodeFindItem.data) != 0))
            {
                parent = nodeFindItem;
                if (FindItem.CompareTo(nodeFindItem.data) < 0)
                    nodeFindItem = nodeFindItem.left;
                else nodeFindItem = nodeFindItem.right;
            }

            // если запрашиваемая вершина отсутствует
            if (nodeFindItem == null) return false;

            // если вершина - корень, и он единственный
            if (nodeFindItem == root && root.IsLeaf() == true)
            {
               return true;
            }

            // если вершина является листом
            if (nodeFindItem.left == null && nodeFindItem.right == null)
            {
                // если вершина - левый потомок
                if (nodeFindItem.data.CompareTo(parent.data) < 0)
                    return true;

                // если он - правый ребёнок своего родителя
                else return true;
            }

            // завершаем поиск
            return true;
        }
   
        // удаление вершины 
        public bool Remove(Data ToRemove) 
        {
            BinaryTreeNode<Data> nodeToRemove = root;
            BinaryTreeNode<Data> parent = null;

            // спуск с поиском удаляемой вершины
            while ((nodeToRemove != null) && (ToRemove.CompareTo(nodeToRemove.data) != 0))
            {
                parent = nodeToRemove;
                if (ToRemove.CompareTo(nodeToRemove.data) < 0)
                    nodeToRemove = nodeToRemove.left;
                else nodeToRemove = nodeToRemove.right;
            }

            // если запрашиваемая вершина отсутствует
            if (nodeToRemove == null) return false;

            // если удаляемая вершина - корень, и он единственный
            if (nodeToRemove == root && root.IsLeaf() == true)
            {
                root = null;
                return true;
            }

            // если удаляемая вершина является листом
            if (nodeToRemove.left == null && nodeToRemove.right == null)
            {
                // если вершина - левый потомок
                if (nodeToRemove.data.CompareTo(parent.data) < 0)
                    parent.left = null;

                // если вершина - правый потомок
                else parent.right = null; 
                return true;
            }

            // если у удаляемой вершины есть только правое поддерево
            if (nodeToRemove.left == null && nodeToRemove.right != null)
            {
                // если удаляемая вершина - корень
                if (nodeToRemove == root) root = root.right;

                // если удаляемая вершина - не корень
                else 
                {
                    // если удаляемая вершина - левый потомок
                    if (nodeToRemove.data.CompareTo(parent.data) < 0)
                        parent.left = nodeToRemove.right;

                    // если вершина правый потомок
                    else parent.right = nodeToRemove.right;
                }
                return true;
            }

            // если у удаляемой вершины есть только левое поддерево
            if (nodeToRemove.left != null && nodeToRemove.right == null)
            {
                // если удаляемая вершина - корень
                if (nodeToRemove == root) root = root.left;

                // если удаляемая вершина - не корень
                else 
                {
                    // если удаляемая вершина - левый потомок
                    if (nodeToRemove.data.CompareTo(parent.data) < 0)
                        parent.left = nodeToRemove.left;

                    // если удаляемая вершина - правый потомок
                    else parent.right = nodeToRemove.left;
                }
                return true;
            }

            // если у удаляемой вершины есть оба поддерева
            // ищем наибольшую вершину в левом поддереве удаляемой вершины
            BinaryTreeNode<Data> biggestItem = nodeToRemove.left;
            while (biggestItem.right != null)
                biggestItem = biggestItem.right;

            // ищем родителя наибольшей вершины в левом поддереве
            BinaryTreeNode<Data> biggestItem_parent = FindParent(biggestItem.data);

            // если этот родитель - не удаляемая вершина
            if (nodeToRemove.left != biggestItem) 
            {
                // если у наибольшей вершины есть левое поддерево
                if (biggestItem.left != null) biggestItem_parent.right = biggestItem.left;

                // если у нее нет левого поддерева
                else biggestItem_parent.right = null; 
            }

            // если этот родитель - удаляемая вершина
            else nodeToRemove.left = biggestItem.left;

            // заменяем вершину удаляемой вершины на наибольшую вершину в левом поддереве
            nodeToRemove.data = biggestItem.data;
            return true;
        }
    }
}
