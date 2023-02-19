using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LR6_3
{
    public partial class MainForm : Form
    {
        public static List<Student> students; // список объявляется публичным и статическим, чтоб другие классы имели к нему доступ без создания экземпляра класса MainForm

        Count count; // объявление экземпляра класса расчета стипендии
        Remove remove; // объявление экземпляра класса удаления студентов
        AddEdit add; // объявление экземпляра класса добавления студента
        AddEdit edit; // объявление экземпляра класса редактирования студента
        Sort sort; // объявление экземпляра класса сортировки студентов

        public MainForm()
        {
            InitializeComponent(); // инициализация компонентов формы
            students = new List<Student>(); // создание экземпляра класса студентов
            count = new Count(tabCount, dgv); // создание экземпляра класса расчета стипендии. В конструктор передается соответствующая вкладка и таблица из вкладки "Ведомость"
            remove = new Remove(tabRemove, dgv); // создание экземпляра класса удаления студентов. В конструктор передается соответствующая вкладка и таблица из вкладки "Ведомость"
            add = new AddEdit(tabAdd, true, dgv); // создание экземпляра класса добавления студента. В конструктор передается соответствующая вкладка, параметр isAdd и таблица из вкладки "Ведомость"
            edit = new AddEdit(tabEdit, false, dgv); // создание экземпляра класса редактирования студента. В конструктор передается соответствующая вкладка, параметр isAdd и таблица из вкладки "Ведомость"
            sort = new Sort(tabSort, dgv); // создание экземпляра класса сортировки студентов. В конструктор передается соответствующая вкладка и таблица из вкладки "Ведомость"
        }

        private void SetDefaultStudents()
        {
            /*
             *  Метод реализует заполнение списка студентов значениями по умолчанию (согласно образцу в ЛР №6.3)
             *  Скорректированы оценки студентов таким образом, чтобы студенты попадали под разные критерии начисления стипендии
             */
            students.Clear(); // очистка текущего списка студентов

            // в список добавляются объекты типа Student
            students.Add(new Student("УТР02Б", "Петров", new byte[] { 2, 2, 2, 4, 2 }));
            students.Add(new Student("УТР02А", "Иванов", new byte[] { 4, 5, 3, 3, 3 }));
            students.Add(new Student("УТР02А", "Климова", new byte[] { 5, 5, 5, 5, 5 }));
            students.Add(new Student("УТР02А", "Морозова", new byte[] { 3, 3, 3, 3, 3 }));
            students.Add(new Student("УТР02А", "Абрамова", new byte[] { 4, 4, 5, 4, 5 }));
            students.Add(new Student("УТР02А", "Сидоров", new byte[] { 4, 4, 3, 3, 3 }));
            students.Add(new Student("УТР02Б", "Жуковская", new byte[] { 4, 3, 5, 4, 4 }));
            students.Add(new Student("УТР02А", "Ющенко", new byte[] { 2, 2, 2, 3, 3 }));
            students.Add(new Student("УТР02Б", "Жукова", new byte[] { 2, 3, 5, 5, 5 }));
        }

        private void FillTable()
        {
            /*
             *  Метод реализует обновление таблицы студентами на вкладке "Ведомость"
             */
            dgv.Rows.Clear();

            foreach (Student s in students)
            {
                dgv.Rows.Add(s.getGroup(), s.getName(), s.getMark()[0], s.getMark()[1], s.getMark()[2], s.getMark()[3], s.getMark()[4]);
                // Для каждого студента в списке добавляются в таблицу группа, фамилия и оценки
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // выход из приложения
            Application.Exit();
        }

        private void btnDefaultStudents_Click(object sender, EventArgs e)
        {
            SetDefaultStudents(); // вызов метода заполнения таблицы студентами по образцу
            FillTable(); // заполнение таблицы по обновленному списку студентов
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             * Метод реализует обновление значений в выпадающем списке на вкладке редактирования студентов при переходе на нее
             */
            if (tabControl1.SelectedIndex == 4)
                edit.UpdateStudentsList();
        }
    }
}
