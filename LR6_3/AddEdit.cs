using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR6_3
{
    class AddEdit
    {
        /*
         * Класс для добавления и редактирования студентов
         * Служит для добавления в ведомость новых студентов с введенными параметрами и редактирования параметров студентов
         * Правильным решением было бы создать два разных класса и применить механизм наследования (так как основные элементы управления одинаковые)
         * Но компилятор ругается на конструктор в классе-наследнике. Изучение механизма наследования в С# оставлено на потом
         * Разделение функциональности классов реализовано с помощью механизма перегрузки
         */
        TabPage tab; // вкладка, на которую будут добавлены элементы формы
        ComboBox cbxGroup; // выпадающий список с индексом группы
        TextBox tbxName; // текстовое поле фамилии студента (для добавления)
        ComboBox cbxName; // выпадающий список с фамилиями студентов (для редактирования)
        ComboBox[] cbxMark; // выпадающие списки с оценками за экзамены
        Button[] btn; // массив кнопок

        DataGridView dgv; // таблица с вкладки "Ведомость"

        public AddEdit(TabPage tab, Boolean isAdd, DataGridView dgv)
        {
            /*
             * Конструктор класса, выполняется при создании экземпляра класса
             */
            this.tab = tab;
            this.dgv = dgv;
            StartTab(this.tab, isAdd);
        }

        private void StartTab(TabPage tab, Boolean isAdd)
        {
            Label[] label = new Label[4]; // обявление и инициализация массива меток
            string[] lblText = { "Индекс группы", "Фамилия студента", "Оценки"}; // массив текстов меток
            for (int i = 0; i < 3; i++)
            {
                label[i] = new Label(); // создание экземпляра метки 
                label[i].Text = lblText[i]; // текст метки
                label[i].AutoSize = true; // автоматическое изменение размера метки
                label[i].Location = new System.Drawing.Point(10, 10 + 50 * i); // положение метки на вкладке
                tab.Controls.Add(label[i]); // добавление метки на вкладку
            }

            cbxGroup = new ComboBox(); // создание экземпляра выпадающего списка группы
            cbxGroup.Items.Add("УТР02А"); // заполнение данных выпадающего списка
            cbxGroup.Items.Add("УТР02Б"); // заполнение данных выпадающего списка
            cbxGroup.Location = new System.Drawing.Point(150, 10); // положение выпадающего списка на вкладке
            cbxGroup.DropDownStyle = ComboBoxStyle.DropDownList; // запрет ввода собственных значений
            tab.Controls.Add(cbxGroup); // добавление выпадающего списка на вкладку

            // значение переданного в метод параметра isAdd определяет, какой тип объекта будет использован для фамилии студента
            if (isAdd)
            {
                // для фамилии студента применяется текстовое поле
                tbxName = new TextBox(); // создание экземпляра текстового поля
                tbxName.Location = new System.Drawing.Point(150, 60); // положение текстового поля на вкладке
                tab.Controls.Add(tbxName); // добавление текстового поля на вкладку
            }
            else
            {
                // для фамилии студента применяется выпадающий список
                cbxName = new ComboBox(); // создание экземпляра выпадающего списка
                cbxName.Location = new System.Drawing.Point(150, 60); // положение выпадающего списка на вкладке
                cbxName.SelectedIndexChanged += new EventHandler(this.cbxName_SelectedIndexChange); // добавление обработчика события изменения индекса выбранного элемента выпадающего списка
                tab.Controls.Add(cbxName); // добавление выпадающего списка на вкладку
            }

            cbxMark = new ComboBox[5]; // создание массива выпадающих списков оценок

            for (int i = 0; i < 5; i++)
            {
                Label lbl = new Label(); // создание экземпляра метки 
                lbl.Text = $"Экз{i + 1}"; // текст метки
                lbl.AutoSize = true; // автоматическое изменение размера метки
                lbl.Location = new System.Drawing.Point(150 + i * 50, 90); // положение метки на вкладке
                tab.Controls.Add(lbl); // добавление метки на вкладку

                cbxMark[i] = new ComboBox(); // создание экземпляра выпадающего списка
                cbxMark[i].Items.Add(5); // заполнение данных выпадающего списка
                cbxMark[i].Items.Add(4); // заполнение данных выпадающего списка
                cbxMark[i].Items.Add(3); // заполнение данных выпадающего списка
                cbxMark[i].Items.Add(2); // заполнение данных выпадающего списка
                cbxMark[i].Location = new System.Drawing.Point(150 + i * 50, 110); // положение выпадающего списка на вкладке
                cbxMark[i].Width = 40; // ширина выпадающего списка
                cbxMark[i].DropDownStyle = ComboBoxStyle.DropDownList; // запрет ввода собственных значений
                tab.Controls.Add(cbxMark[i]); // добавление выпадающего списка на вкладку
            }

            btn = new Button[2]; // массив кнопок
            string[] btnText = { "Ввод", "Очистить"}; // массив текста кнопок
            if (!isAdd)
                btnText[0] = "Изменить"; // если это вкладка для редактирования, то текст первой кнопки меняем на "Изменить"
            for (int i = 0; i < 2; i++)
            {
                btn[i] = new Button(); // создание экземпляра кнопки
                btn[i].Text = btnText[i]; // текст кнопки
                btn[i].Location = new System.Drawing.Point(10 + i * 100, 160); // положение кнопки на вкладке
                btn[i].Width = 90; // ширина кнопки
                btn[i].Height = 30; // высота кнопки
                btn[i].Click += new EventHandler(this.btnEvent_Click); // добавление обработчика события нажатия кнопки
                tab.Controls.Add(btn[i]); // добавление кнопки на вкладку
            }
        }

        private void btnEvent_Click(object sender, EventArgs e)
        {
            // в зависимости от текста на кнопке вызываются различные методы
            switch ((sender as Button).Text)
            {
                case "Ввод":
                    AddStudent();
                    break;
                case "Изменить":
                    // экземпляр студента, передаваемого в метод, определяется по имени в поле "Фамилия студента" с помошью лямбда-выражения
                    EditStudent(MainForm.students.Find(x => x.getName() == cbxName.Text));
                    break;
                case "Очистить":
                    ClearAll();
                    break;
                default:
                    break;
            }
        }

        private void cbxName_SelectedIndexChange(object sender, EventArgs e)
        {
            /*
             * Метод обрабатывает событие изменения индекса выбранного элемента cbxName и вызывает метод заполнения вкладки данными студента
             */
            FillTab(MainForm.students.Find(x => x.getName() == cbxName.Text));
        }

        private void AddStudent()
        {
            // проверка, все ли поля заполнены
            if (cbxGroup.Text != "" && tbxName.Text != "" &&
                cbxMark[0].Text != "" &&
                cbxMark[1].Text != "" &&
                cbxMark[2].Text != "" &&
                cbxMark[3].Text != "" &&
                cbxMark[4].Text != "")
            {
                //добавление в список студентов нового экземпляра с введенными параметрами
                MainForm.students.Add(new Student(cbxGroup.Text, tbxName.Text,
                    new byte[] { Convert.ToByte(cbxMark[0].Text),
                    Convert.ToByte(cbxMark[1].Text),
                    Convert.ToByte(cbxMark[2].Text),
                    Convert.ToByte(cbxMark[3].Text),
                    Convert.ToByte(cbxMark[4].Text)}));
                FillTable(); // заполнение таблицы по обновленному списку студентов
            }
            else
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK); // сообщение об ошибке, если не все поля заполнены
        }

        private void EditStudent(Student s)
        {
            /*
             * Метод реализует изменение данных студента, выбранного в cbxName
             */
            if (s != null) // проверка наличия студента с выбранной фамилией в списке студентов
            {
                s.setGroup(cbxGroup.Text); // изменение группы для выбранного студента
                s.setMark(new byte[] { Convert.ToByte(cbxMark[0].Text),
                    Convert.ToByte(cbxMark[1].Text),
                    Convert.ToByte(cbxMark[2].Text),
                    Convert.ToByte(cbxMark[3].Text),
                    Convert.ToByte(cbxMark[4].Text)}); // изменение оценок для выбранного студента
                FillTable(); // заполнение таблицы по обновленному списку студентов
            }
        }

        private void FillTable()
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

        private void ClearAll()
        {
            /*
             * Метод реализует очистку всех полей ввода и выпадающих списков
             */
            cbxGroup.SelectedIndex = -1; // очистка поля "Индекс группы"
            if (cbxName is null) // проверка наличия на вкладке выпадающего списка с фамилиями студентов
                tbxName.Text = ""; // если на вкладке нет выпадающего списка, значит есть текстовое поле с фамилией студента, и его содержимое очищается
            else
                cbxName.Text = ""; // если на вкладке есть выпадающий список, то его содержимое очищается
            for (int i = 0; i < 5; i++)
            {
                cbxMark[i].SelectedIndex = -1; // очистка выпадающих списков с оценками
            }
        }

        private void FillTab(Student student)
        {
            /*
             * Метод реализует заполнение формы данными выбранного в cbxName студента
             */
            cbxGroup.Text = student.getGroup();
            for (int i = 0; i < cbxMark.Length; i++)
                cbxMark[i].Text = student.getMark()[i].ToString();
        }

        public void UpdateStudentsList()
        {
            /*
             * Метод реализует обновление списка студентов в выпадающем списке
             */
            cbxName.Items.Clear(); // очистка списка

            foreach (Student s in MainForm.students)
                cbxName.Items.Add(s.getName()); // для каждого студента из списка добавляется его имя в выпадающий список
        }

    }
}
