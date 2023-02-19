using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR6_3
{
    /*
     * Класс вкладки сортировки студентов
     * Служит для сортировки студентов в таблице по выбранному критерию
     */
    class Sort
    {
        TabPage tabSort; // вкладка, на которую будут добавлены элементы формы
        ComboBox cbxCriterion; // выпадающий список с критерием сортировки
        DataGridView dgv; // таблица с вкладки "Ведомость"


        public Sort(TabPage tabSort, DataGridView dgv)
        {
            /*
             * Конструктор класса, выполняется при создании экземпляра класса
             */
            this.tabSort = tabSort;
            this.dgv = dgv;
            StartTab();
        }

        private void StartTab()
        {
            Label label = new Label(); // создание экземпляра метки
            label.Text = "Выберите критерий сортировки"; // текст метки
            label.AutoSize = true; // автоматическое изменение размера метки
            label.Location = new System.Drawing.Point(10, 10); // положение метки на вкладке
            tabSort.Controls.Add(label); // добавление метки на вкладку

            cbxCriterion = new ComboBox(); // создание экземпляра выпадающего списка
            foreach (DataGridViewColumn column in dgv.Columns)
                cbxCriterion.Items.Add(column.HeaderText); // заполнение данных выпадающего списка
            cbxCriterion.Location = new System.Drawing.Point(10, 40);// положение выпадающего списка на вкладке
            cbxCriterion.DropDownStyle = ComboBoxStyle.DropDownList; // запрет ввода собственных значений
            tabSort.Controls.Add(cbxCriterion); // добавление выпадающего списка на вкладку

            Button btn = new Button(); // создание экземпляра кнопки
            btn.Text = "Сортировать"; // текст кнопки
            btn.Width = 340; // ширина кнопки
            btn.Height = 40; // высота кнопки
            btn.Location = new System.Drawing.Point(10, 70); // положение кнопки на вкладке
            btn.Click += new EventHandler(this.btnEvent_Click); // добавление обработчика события нажатия кнопки
            tabSort.Controls.Add(btn); // добавление кнопки на вкладку
        }

        private void btnEvent_Click(object sender, EventArgs e)
        {
            // в зависимости от текста на кнопке вызываются различные методы
            switch (cbxCriterion.Text)
            {
                // используется метод сортировки, определенный в классе List<> с помошью лямбда-выражения
                case "Индекс группы":
                    MainForm.students.Sort((x, y) => x.getGroup().CompareTo(y.getGroup()));
                    break;
                case "ФИО студента":
                    MainForm.students.Sort((x, y) => x.getName().CompareTo(y.getName()));
                    break;
                case "Экзамен 1":
                    MainForm.students.Sort((x, y) => x.getMark()[0].CompareTo(y.getMark()[0]));
                    break;
                case "Экзамен 2":
                    MainForm.students.Sort((x, y) => x.getMark()[1].CompareTo(y.getMark()[1]));
                    break;
                case "Экзамен 3":
                    MainForm.students.Sort((x, y) => x.getMark()[2].CompareTo(y.getMark()[2]));
                    break;
                case "Экзамен 4":
                    MainForm.students.Sort((x, y) => x.getMark()[3].CompareTo(y.getMark()[3]));
                    break;
                case "Экзамен 5":
                    MainForm.students.Sort((x, y) => x.getMark()[4].CompareTo(y.getMark()[4]));
                    break;
                case "Стипендия":
                    MainForm.students.Sort((x, y) => x.getSalary().CompareTo(y.getSalary()));
                    break;
                default:
                    break;
            }
            FillTable(); // заполнение таблицы по отсортированному списку студентов
        }

        private void FillTable()
        {
            /*
             *  Метод реализует обновление таблицы студентами на вкладке "Ведомость"
             */
            dgv.Rows.Clear(); // очистка таблицы

            foreach (Student s in MainForm.students)
            {
                dgv.Rows.Add(s.getGroup(), s.getName(), s.getMark()[0], s.getMark()[1], s.getMark()[2], s.getMark()[3], s.getMark()[4], s.getSalary());
                // Для каждого студента в списке добавляются в таблицу группа, фамилия, оценки и стипендия
            }
        }
    }
}
