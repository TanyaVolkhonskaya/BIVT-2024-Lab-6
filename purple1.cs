using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_1
    {
        public struct Participant
        {
            //поля
            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;
            private int _ind;
            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs
            {
                get
                {
                    if (_coefs == null) return null;
                    double[] copy = new double[_coefs.Length];
                    Array.Copy(_coefs, copy, _coefs.Length);
                    return copy;
                }
            }
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int[,] copy_m = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    Array.Copy(_marks, copy_m, _marks.Length);
                    return copy_m;
                }
            }
            public double TotalScore
            {
                get
                {
                    double score = 0.0;
                    for (int i = 0; i < 4; i++)
                    {
                        int worst = int.MaxValue;
                        int best = int.MinValue;
                        int ans = 0;
                        for (int j = 0; j < 7; j++)
                        {
                            if (_marks[i, j] > best)
                                best = _marks[i, j];
                            if (_marks[i, j] < worst)
                                worst = _marks[i, j];
                            ans += _marks[i, j];
                        }
                        ans -= worst;
                        ans -= best;
                        score += ans * _coefs[i];
                    }
                    return score;
                }
            }
            
            //конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[4] { 2.5, 2.5, 2.5, 2.5 };
                _marks = new int[4, 7];
                _ind = 0;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        _marks[i, j] = 0;
                    }
                }
            }
            //main методы
            public void SetCriterias(double[] coefs)
            {
                if (coefs == null || _coefs == null || coefs.Length != _coefs.Length) return;
                
                {
                    Array.Copy(coefs, _coefs,4);
                }
            }
            public void Jump(int[] marks) 
            {
                if (marks == null || _marks == null || _ind >= _marks.GetLength(0) || marks.Length != _marks.GetLength(1)) return;
                for (int i = 0; i < marks.Length; i++)
                {
                    _marks[_ind, i] = marks[i];
                    
                }
                _ind++;
            }
            public static void Sort(Participant[] array)
            {
                if (array == null) return;

                var a= array.OrderByDescending((x) => x.TotalScore).ToArray();//OrderByDescending - linq-выражение для упорядочивания
                Array.Copy(a, array, array.Length);
            }

            public void Print()
            {
                System.Console.WriteLine($"{_name} {_surname} {TotalScore}");
            }
        }
    }
}
                
                

