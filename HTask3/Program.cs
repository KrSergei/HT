/*
 Есть лабиринт описанный в виде двумерного массива где 1 это стены, 0 - проход, 2 - искомая цель.
Пример лабиринта:
1 1 1 1 1 1 1
1 0 0 0 0 0 1
1 0 1 1 1 0 1
0 0 0 0 1 0 2
1 1 0 0 1 1 1
1 1 1 1 1 1 1
1 1 1 1 1 1 1
Напишите алгоритм определяющий наличие выхода из лабиринта и 
выводящий на экран координаты точки выхода если таковые имеются.
 */

using HTask3;

class Programm
{
    private static int[,] _labirynth = new int[,]
    {
        {1, 1, 1, 1, 1, 1, 1 },
        {1, 0, 0, 0, 0, 0, 1 },
        {1, 0, 1, 1, 1, 0, 1 },
        {0, 0, 0, 0, 1, 0, 2 },
        {1, 1, 0, 0, 1, 1, 1 },
        {1, 1, 1, 1, 1, 1, 1 },
        {1, 1, 1, 1, 1, 1, 1 }
    };

    private static int[,] _labirynth1 = new int[,]
    {
        {1, 1, 1, 1, 1, 1, 1 },
        {1, 0, 0, 0, 0, 0, 1 },
        {1, 0, 1, 1, 1, 0, 1 },
        {0, 0, 0, 0, 1, 0, 0 },
        {1, 1, 0, 0, 1, 1, 1 },
        {1, 1, 1, 0, 1, 1, 1 },
        {1, 1, 1, 0, 1, 1, 1 }
    };

    private static int exitCount = 0;

    static Stack<Tuple<int, int>> _path = new Stack<Tuple<int, int>>();

    static void Main(string[] args)
    {
        #region task2
        //foreach (var x in new CustomEnumerable()) 
        //{
        //    Console.WriteLine(x);
        //}
        #endregion
        //FindPath(3, 6);
        //HomeTask 3
        Console.WriteLine("Count exit = " + HasExit(1, 1, _labirynth1));
    }
    #region Task3
    static bool FindPath(int i, int j)
    {
        if (_labirynth[i, j] != 1) _path.Push(new Tuple<int, int>(i, j));

        while (_path.Count > 0)
        {
            var current = _path.Pop();
            Console.WriteLine($"{current.Item1}, {current.Item2}");
            if (_labirynth[current.Item1, current.Item2] == 2)
            {
                Console.WriteLine($"The path is found {current.Item1}, {current.Item2}");
                return true;
            }

            _labirynth[current.Item1, current.Item2] = 1;

            if (current.Item1 + 1 < _labirynth.GetLength(0) && _labirynth[current.Item1 + 1, current.Item2] != 1)
                _path.Push(new Tuple<int, int>(current.Item1 + 1, current.Item2));

            if ( current.Item2 + 1 < _labirynth.GetLength(1) && _labirynth[current.Item1, current.Item2 + 1] != 1)
                _path.Push(new Tuple<int, int>(current.Item1, current.Item2 + 1));

            if (current.Item1 > 0 && _labirynth[current.Item1 - 1, current.Item2] != 1) 
                _path.Push(new Tuple<int, int>(current.Item1 - 1, current.Item2));

            if (current.Item2 > 0 && _labirynth[current.Item1, current.Item2 - 1] !=1 )
                _path.Push(new Tuple<int, int>(current.Item1, current.Item2 - 1));
        }
        Console.WriteLine("The path not found");
        return false;
    }
    #endregion
    #region HTask3
    /// <summary>
    /// Определение количества выходов из лабиринта
    /// </summary>
    /// <param name="startI"></param>
    /// <param name="startJ"></param>
    /// <param name="lab"></param>
    /// <returns></returns>
    static int HasExit(int startI, int startJ, int[,] lab)
    {       
        //временный стек для хранения пути
        Stack<Tuple<int, int>> tempStack = new Stack<Tuple<int, int>>();
        if (lab[startI, startJ] != 1) { 
            _path.Push(new Tuple<int, int>(startI, startJ));
            tempStack.Push(new Tuple<int, int>(startI, startJ));
        } 

        while (_path.Count > 0)
        {
            var current = _path.Pop();           
            Console.WriteLine($"{current.Item1}, {current.Item2}");
            //Сравнение текущей клетки на 0 и является ли выходом.
            //Если значение текущей клетки равно 0 и идекс клетки по строке и столбцу <= 0 или >= длине строк/столбцов
            //то эта клетка является выходом
            if (lab[current.Item1, current.Item2] == 0 
                && (current.Item1 >= lab.GetLength(0) - 1 || current.Item2 >= lab.GetLength(1) - 1
                || current.Item1  <= 0 || current.Item2 <= 0))
            {
                exitCount++;                
                var countStep = tempStack.Count;
                _path.Clear();
                //возврат пройденных клеток в значение 0
                for (global::System.Int32 i = 0; i < countStep; i++)
                {
                    var step = tempStack.Pop();
                    lab[step.Item1, step.Item2] = 0;
                }
                //закрытие найденного выхода
                lab[current.Item1, current.Item2] = 1;
                Console.WriteLine($"A way out has been found {current.Item1}, {current.Item2}");
                //рекурсивный вызов функции поиска выхода
                HasExit(startI, startJ, lab);
            }
            //установка пройденной клетки в 1
            lab[current.Item1, current.Item2] = 1;

            if (current.Item1 + 1 < lab.GetLength(0) && lab[current.Item1 + 1, current.Item2] != 1)
            {
                _path.Push(new Tuple<int, int>(current.Item1 + 1, current.Item2));
                tempStack.Push(new Tuple<int, int>(current.Item1 + 1, current.Item2));
            }

            if (current.Item2 + 1 < lab.GetLength(1) && lab[current.Item1, current.Item2 + 1] != 1)
            {
                _path.Push(new Tuple<int, int>(current.Item1, current.Item2 + 1));
                tempStack.Push(new Tuple<int, int>(current.Item1, current.Item2 + 1));
            }

            if (current.Item1 > 0 && lab[current.Item1 - 1, current.Item2] != 1)
            {
                _path.Push(new Tuple<int, int>(current.Item1 - 1, current.Item2));
                tempStack.Push(new Tuple<int, int>(current.Item1 - 1, current.Item2));
            }

            if (current.Item2 > 0 && lab[current.Item1, current.Item2 - 1] != 1)
            {
                _path.Push(new Tuple<int, int>(current.Item1, current.Item2 - 1));
                tempStack.Push(new Tuple<int, int>(current.Item1, current.Item2 - 1));
            }
        }
        return exitCount;
    }
    #endregion
}