using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_2
    {
        public struct Participant
        {
            //поля
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;
            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public int Distance => _distance;
            public int[] Marks
            {
                get
                {
                    if (_marks == null) return null;

                    int[] copy = new int[_marks.Length];
                    Array.Copy(_marks, copy, copy.Length);
                    return copy;
                }
            }
            public int Result
            {
                get
                {
                    if (_marks == null || _distance==-1) return 0;
                    
                        int worst = 0;
                        int best = 0;
                        int ans = 0;
                    for (int j = 0; j < _marks.Length; j++)
                    {
                        ans+=_marks[j];
                        if (_marks[j] > _marks[best])
                            best = j;
                        if (_marks[j] < _marks[worst])
                            worst = j;
                    }
                    ans -= (_marks[best] + _marks[worst]);
                        ans += 60 + (_distance - 120) * 2;
                    return ans;

                }
            }
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _distance = -1;
                _marks = new int[5] { 0, 0, 0, 0, 0 };

            }
            public void Jump(int distance, int[] marks)
            {
                if (marks == null || _marks == null || marks.Length != _marks.Length) return;
                _distance = distance;
                Array.Copy(marks, _marks, marks.Length);
            }
            public static void Sort(Participant[] array)
            {
                {
                    if (array == null) return;

                    var a = array.OrderByDescending((x) => x.Result).ToArray();
                    Array.Copy(a, array, array.Length);
                }
            }
                public void Print()
                {

                System.Console.WriteLine($"{_name} {_surname} {_marks}");
            } 
            
            
        }
    }
}
