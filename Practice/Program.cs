using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Practice
{
    class Interval
    {
        private int start, end;
        private bool isInclude;

        public Interval(int start, int end, bool isInclude)
        {
            this.start = start;
            this.end = end;
            this.isInclude = isInclude;
        }

        private int getStart()
        {
            return start;
        }

        private int getEnd()
        {
            return end;
        }

        public string toString()
        {
            string s1, s2;
            if (isInclude)
            {
                s1 = "[";
                s2 = "]";
            }
            else
            {
                s1 = "(";
                s2 = ")";
            }
            return s1 + start + "; " + end + s2;
        }

        public void combine(Interval inter)
        {
            if (start < inter.getEnd() && inter.getStart() < end)
            {
                int x = Math.Min(start, inter.getStart());
                int y = Math.Max(end, inter.getEnd());
                WriteLine("Объединение интервалов: " + x + "..." + y);
            }
            else WriteLine("Интервалы не пересекаются");
        }

        public void crossing(Interval inter)
        {
            int x = Math.Max(start, inter.getStart());
            int y = Math.Min(end, inter.getEnd());
            if (x < y) WriteLine("Пересечение интервалов: " + x + "..." + y);
            else WriteLine("Интервалы не пересекаются");
        }
    }

    class Three
    {
        List<Branch> branchList;
        static Random rand = new Random();

        int numberOfBranch;
        int numberOfLeaf = 0;
        public Three(int numberOfBranch)
        {
            this.numberOfBranch = numberOfBranch > 0 ? numberOfBranch : 5;

            branchList = new List<Branch>();

            for (int i = 0; i < numberOfBranch; i++)
            {
                branchList.Add(new Branch(rand.Next(10, 100)));
                numberOfLeaf += branchList[i].GetLeafsOnBranch();
            }
        }

        public void Зацвести()
        {
            for (int i = 0; i < branchList.Count; i++)
            {
                branchList[i].Зацвести();
            }
        }
        public void Опасть()
        {
            for (int i = 0; i < branchList.Count; i++)
            {
                branchList[i].Опасть();
            }
        }
        public void ПокрыстьсяИнием()
        {
            for (int i = 0; i < branchList.Count; i++)
            {
                branchList[i].ПокрыстьсяИнием();
            }
        }
        public void Пожелтеть()
        {
            for (int i = 0; i < branchList.Count; i++)
            {
                branchList[i].Пожелтеть();
            }
        }

        public int GetBranchCount() => numberOfBranch;
        public int GetLeafCount() => numberOfLeaf;
        class Branch
        {
            List<Leaf> leafList;

            int numberOfLeaf;

            public Branch(int numberOfLeaf)
            {
                this.numberOfLeaf = numberOfLeaf > 0 ? numberOfLeaf : 10;

                leafList = new List<Leaf>();

                for (int i = 0; i < numberOfLeaf; i++)
                {
                    leafList.Add(new Leaf());
                }
            }

            public int GetLeafsOnBranch()
            {
                return numberOfLeaf;
            }

            public void Зацвести()
            {
                for (int i = 0; i < leafList.Count; i++)
                {
                    leafList[i].Зацвести();
                }
            }
            public void Опасть()
            {
                for (int i = 0; i < leafList.Count; i++)
                {
                    leafList[i].Опасть();
                }
            }
            public void ПокрыстьсяИнием()
            {
                for (int i = 0; i < leafList.Count; i++)
                {
                    leafList[i].ПокрыстьсяИнием();
                }
            }
            public void Пожелтеть()
            {
                for (int i = 0; i < leafList.Count; i++)
                {
                    leafList[i].Пожелтеть();
                }
            }

            class Leaf
            {
                string status = "Начало";
                public void Зацвести()
                {
                    status = "Зацвел";
                }
                public void Опасть()
                {
                    status = "Опал";
                }
                public void ПокрыстьсяИнием()
                {
                    status = "Покрыт инеем";
                }
                public void Пожелтеть()
                {
                    status = "Пожелтел";
                }

                public string GetStatus() => status;
            }
        }
    }

    class Cinema
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Привет, дорогой друг, выбери задачку!\n");

            bool mainLoop = true;

            while (mainLoop)
            {

                WriteLine("Задачи:\n" +
                    "1. стр. 50\n" +
                    "2. стр. 87\n" +
                    "3. стр. 124\n" +
                    "4. стр. 145\n" +
                    "5. стр. 194\n" +
                    "6. Вариант А\n" +
                    "0 - EXIT\n");

                bool isLoop = true;

                while (isLoop)
                {
                    Write("Выберите задание: ");
                    int choise;
                    bool isParsed = int.TryParse(ReadLine(), out choise);

                    if (isParsed && choise >= 0 && choise <= 6)
                    {
                        isLoop = false;

                        switch (choise)
                        {
                            case 1:
                                Clear();
                                int n, m;
                                int skipN = 3, skipM = 3, skip = 1;

                                Write($"Введите n (пропуск = {skipN}): ");

                                bool parseN = int.TryParse(ReadLine(), out n);
                                if (!parseN) n = skipN;

                                Write($"Введите m (пропуск = {skipM}): ");

                                bool parseM = int.TryParse(ReadLine(), out m);
                                if (!parseM) m = skipM;

                                int[,] matrix = new int[n, m];

                                WriteLine("Заполните матрицу: ");

                                for (int i = 0; i < n; i++)
                                {
                                    for (int j = 0; j < m; j++)
                                    {
                                        Write($"Введите {i + 1}, {j + 1} (пропуск = {skip}): ");
                                        bool parse = int.TryParse(ReadLine(), out matrix[i, j]);
                                        if (!parse) matrix[i, j] = skip;
                                    }
                                }

                                WriteLine("Матрица: ");

                                for (int i = 0; i < n; i++)
                                {
                                    for (int j = 0; j < m; j++)
                                    {
                                        Write($"\t{matrix[i, j]}");
                                    }
                                    WriteLine();
                                }

                                for (int i = 0; i < n; i++)
                                {
                                    for (int j = 0; j < m; j++)
                                    {
                                        for (int k = 0; k < m - 1; k++)
                                        {
                                            if (matrix[j, k] == 0)
                                            {
                                                var temp = matrix[j, k];
                                                matrix[j, k] = matrix[j, k + 1];
                                                matrix[j, k + 1] = temp;
                                            }
                                        }
                                    }
                                }

                                WriteLine("Отредактированная матрица: ");

                                for (int i = 0; i < n; i++)
                                {
                                    for (int j = 0; j < m; j++)
                                    {
                                        Write($"\t{matrix[i, j]}");
                                    }
                                    WriteLine();
                                }

                                WriteLine($"\nКонец {choise} задания!\n");

                                break;
                            case 2:
                                Clear();
                                int q;
                                int skipQ = 3;

                                Write($"Введите количество интервалов (пропуск = {skipQ}): ");
                                bool parseK = int.TryParse(ReadLine(), out q);
                                if (!parseK) q = skipQ;

                                Interval[] intervals = new Interval[q];

                                for (int i = 0; i < q; i++)
                                {
                                    int a = 0, b = 0, incl = 0;
                                    bool isIncl;
                                    Write($"Введите начало интервала {i + 1} (пропуск = 0): ");
                                    int.TryParse(ReadLine(), out a);
                                    Write($"Введите конец интервала {i + 1} (пропуск = 0): ");
                                    int.TryParse(ReadLine(), out b);
                                    Write($"Включаем концы для интервала {i + 1}? (0 = Нет, 1 = Да) (пропуск = нет): ");
                                    int.TryParse(ReadLine(), out incl); isIncl = incl > 0;
                                    intervals[i] = new Interval(a, b, isIncl);
                                }

                                for (int i = 0; i < intervals.Length - 1; i++)
                                {
                                    intervals[i].combine(intervals[i + 1]);
                                    intervals[i].crossing(intervals[i + 1]);
                                }

                                WriteLine($"\nКонец {choise} задания!\n");

                                break;
                            case 3:

                                Three three = new Three(7);
                                three.Зацвести();

                                WriteLine($"\nКонец {choise} задания!\n");

                                break;
                            case 4:



                                WriteLine($"\nКонец {choise} задания!\n");

                                break;
                            case 5:

                                WriteLine($"\nКонец {choise} задания!\n");

                                break;
                            case 6:

                                WriteLine($"\nКонец {choise} задания!\n");

                                break;
                            case 0:
                                mainLoop = false;
                                break;
                        }
                    }
                    else
                    {
                        WriteLine("Ошибка!");
                    }
                }
            }

            WriteLine("Exit...");
            ReadKey(false);
        }
    }
}
