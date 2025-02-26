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
            public int TopPlace => Places.Min();
            public double TotalMark => Marks.Sum();
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
                    Array.Sort(participants, (x, y) =>
                    {
                        double a = x.Marks[i] - y.Marks[i];
                        if (a < 0) return 1;
                        else if (a > 0) return -1;
                        else return 0;
                    });
                    for (int j = 0; j < participants.Length; j++)
                    {

                        participants[j].SetPlace(i, j + 1);
                    }

                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                var arr = array.OrderByDescending((x) => x.Score).ThenBy((x) => x.TopPlace).ThenByDescending((x) => x.TotalMark).ToArray();
                for (int i = 0; i < arr.Length; i++)
                {
                    array[i] = arr[arr.Length - i - 1];
                }
            }
            public void Print()
            {
                System.Console.WriteLine($"{_name} {_surname} {Score}");
            }
        }
    }
}
    


