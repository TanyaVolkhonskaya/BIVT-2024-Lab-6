using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_3
    {
        public struct Participant
        {
            //поля
            private string _name;
            private string _surname;
            private double[] _marks;
            private int[] _places;
            private int _ind;
            //свойства
            public string Name => _name;
            public string Surname => _surname;
            private double TotalMark
            {
                get
                {
                    if (_marks == null) return 0;
                    double sum = 0;
                    foreach (double m in _marks)
                        sum += m;
                    return sum;
                }
            }

            private int TopPlace
            {
                get
                {
                    if (_places == null) return 0;
                    int minim = 0;
                    for (int i = 0; i < _places.Length; i++)
                        if (_places[i] < _places[minim])
                            minim = i;
                    return _places[minim];
                }
            }

            public double[] Marks

            {
                get
                {
                    if (_marks == null) return null;
                    double[] copy = new double[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }
            public int[] Places
            {
                get
                {
                    if (_places == null) return null;
                    int[] copy = new int[_places.Length];
                    Array.Copy(_places, copy, _places.Length);
                    return copy;
                }
            }
            public int Score
            {
                get
                {
                    if (_places == null) return 0;
                    int result = 0;
                    for (int i = 0; i < _places.Length; i++)
                    {
                        result += _places[i];

                    }
                    return result;
                }
            }

            //конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _places = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
                _marks = new double[7] { 0, 0, 0, 0, 0, 0, 0 };
                _ind = 0;
            }
            //доп методы
            private void SetPlace(int i, int j)
            {
                if (_places == null || i < 0 || i >= _places.Length) return;

                _places[i] = j;
            }
            //методы
            public void Evaluate(double result)
            {
                if (_marks == null || _ind >= _marks.Length) return;
                _marks[_ind] = result;
                _ind++;

            }
            //main методы
            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null) return;
                for (int i = 0; i < 7; i++)
                {
                    Array.Sort(participants, (x,y) =>
                    {
                        double a = 0, b = 0;

                        if (x.Marks == null) 
                            a = 0;
                        else 
                         a = x.Marks[i]; 
                        if (y.Marks == null) 
                            b = 0; 
                        else 
                            b = y.Marks[i];
                        double dif = a - b;
                        if (dif < 0) 
                            return 1;
                        else if (dif > 0) 
                            return -1;
                        else 
                            return 0;
                    });

                    for (int j = 0; j < participants.Length; j++)
                        participants[j].SetPlace(i, j + 1);
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                foreach(var x in array)
                {
                    if (x.Places == null) return;
                }
                Array.Sort(array, (x, y) =>
                {
                    if (x.Score == y.Score)
                    {
                        if (x.TopPlace == y.TopPlace)
                        {
                            double xy = x.TotalMark - y.TotalMark;
                            if (xy < 0) return 1;
                            else if (xy > 0) return -1;
                            else return 0;
                        }
                        return x.TopPlace - y.TopPlace;
                    }
                    return x.Score - y.Score;
                });
            }
            public void Print()
            {
                System.Console.WriteLine($"{_name} {_surname} {Score}");
            }
        }
    }
}
    


