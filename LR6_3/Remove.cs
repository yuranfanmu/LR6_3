using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR6_3
{
    /*
     * Класс вкладки удаления студентов
     * Служит для удаления студентов, имеющих более двух двоек за экзамены
     */
    class Remove
    {
        TabPage tabRemove; // вкладка, на которую будут добавлены элементы формы

        DataGridView dgv; // таблица с вкладки "Ведомость"

        public Remove(TabPage tabRemove, DataGridView dgv)
        {
            /*
             * Конструктор класса, выполняется при создании экземпляра класса
             */
            this.tabRemove = tabRemove;
            this.dgv = dgv;
            StartTab();
        }

        private void StartTab()
        {
            /*
             * Метод реализует расстановку элементов управления на вкладке
             */
            Label label = new Label(); // создание экземпляра метки
            label.Text = "Будут удалены студенты, имеющие более двух двоек по экзаменам"; // текст метки
            label.AutoSize = true; // автоматическое изменение размера метки
            label.Location = new System.Drawing.Point(10, 10); // положение метки на вкладке
            tabRemove.Controls.Add(label); // добавление метки на вкладку

            Button btn = new Button(); // создание экземпляра кнопки
            btn.Text = "Удалить"; // текст кнопки
            btn.Width = 340; // ширина кнопки
            btn.Height = 40; // высота кнопки
            btn.Location = new System.Drawing.Point(10, 40); // положение кнопки на вкладке
            btn.Click += new EventHandler(this.btnEvent_Click); // добавление обработчика события нажатия кнопки
            tabRemove.Controls.Add(btn); // добавление кнопки на вкладку
        }

        public void FillTable()
        {
            /*
             *  Метод реализует обновление таблицы студентами на вкладке "Ведомость"
             */
            dgv.Rows.Clear(); // очистка таблицы

            foreach (Student s in MainForm.students)
            {
                dgv.Rows.Add(s.getGroup(), s.getName(), s.getMark()[0], s.getMark()[1], s.getMark()[2], s.getMark()[3], s.getMark()[4]);
                // Для каждого студента в списке добавляются в таблицу группа, фамилия и оценки
            }

        }

        private void btnEvent_Click(object sender, EventArgs e)
        {
            List<string> removeStudents = new List<string>(); // список студентов, предлагаемых к удалению. Массив не используется, так как количество студентов заранее неизвестно
            foreach (Student s in MainForm.students)
            {
                // для каждого студента считается количество двоек. Если двоек больше двух, фамилия студента заносится в список удаляемых студентов
                int count = 0; // счетчик двоек
                foreach (byte mark in s.getMark())
                    if (mark == 2)
                        count++;
                if (count > 2) // в условии указано, что удаляются студенты, имеющие более двух двоек по экзамену (строгое неравенство)
                    removeStudents.Add(s.getName());
            }
            removeStudents.Reverse(); // изменение порядка студентов. Удаление студентов будет производиться с конца для упрощения алгоритма
            int counter = 0; // счетчик удаленных студентов
            for (int i = MainForm.students.Count - 1; i >= 0; i--)
            {
                // для каждого студента проверяется наличие его фамилии в списке удаляемых студентов, если выполняется - студент удаляется из общего списка
                if (counter != removeStudents.Count && MainForm.students[i].getName() == removeStudents[counter])
                {
                    counter++;
                    MainForm.students.RemoveAt(i);
                }
            }
            MessageBox.Show($"Удалено {removeStudents.Count} строк", "Удаление"); // сообщение о количестве удаленных студентов
            FillTable(); // заполнение таблицы по обновленному списку студентов
        }
    }
}
