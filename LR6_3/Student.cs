using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR6_3
{
    public class Student
    {
        private string group; // группа студента
        private string name; // фамилия студента
        private byte[] mark; // массив оценок студента
        private int salary; // стипедия студента

        public Student(string group, string name, byte[] mark)
        {
            /*
             * Конструктор класса реализует инициализацию объекта класса Student с переданными в него параметрами
             */
            this.group = group;
            this.name = name;
            this.mark = mark;
        }

        /*
         * Методы ниже реализуют контроль доступа к приватным полям класса (запись и чтение)
         */
        public string getGroup()
        {
            return group;
        }

        public void setGroup(string group)
        {
            this.group = group;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public byte[] getMark()
        {
            return mark;
        }

        public void setMark(byte[] mark)
        {
            this.mark = mark;
        }

        public void setMark(int index, byte value)
        {
            mark[index] = value;
        }
        public int getSalary()
        {
            return salary;
        }

        public void setSalary(int salary)
        {
            this.salary = salary;
        }
    }
}
