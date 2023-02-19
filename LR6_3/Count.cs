using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR6_3
{
    /*
     * Класс для подсчета стипендии студентов
     * Служит для ввода базовой стипендии и расчета стипендии для студентов в зависимости от оценок
     */
    class Count
    {
        TabPage tabCount; // вкладка, на которую будут добавлены элементы формы
        TextBox tbx; // объявление поля ввода базовой стипендии
        DataGridView dgv; // таблица с вкладки "Ведомость"

        public Count(TabPage tabCount, DataGridView dgv)
        {
            /*
             * Конструктор класса, выполняется при создании экземпляра класса
             */
            this.tabCount = tabCount;
            this.dgv = dgv;
            StartTab();
        }

        private void StartTab()
        {
            /*
             * Метод реализует расстановку элементов управления на вкладке
             */
            Label label = new Label(); // создание экземпляра метки
            label.Text = "Введите размер обычной стипендии"; // текст метки
            label.AutoSize = true; // автоматическое изменение размера метки
            label.Location = new System.Drawing.Point(10, 10); // положение метки на вкладке
            tabCount.Controls.Add(label); // добавление метки на вкладку

            tbx = new TextBox(); // создание экземпляра ввода
            tbx.Location = new System.Drawing.Point(250, 10); // положение поля ввода на вкладке
            tbx.KeyPress += new KeyPressEventHandler(this.tbx_KeyPress); // добавление обработчика события ввода символа в поле ввода
            tabCount.Controls.Add(tbx); // добавление поля ввода на вкладку

            Button btn = new Button(); // создание экземпляра кнопки
            btn.Text = "Расчет"; // текст кнопки
            btn.Width = 340; // ширина кнопки
            btn.Height = 40; // высота кнопки
            btn.Location = new System.Drawing.Point(10, 40); // положение кнопки на вкладке
            btn.Click += new EventHandler(this.btnEvent_Click); // добавление обработчика события нажатия кнопки
            tabCount.Controls.Add(btn); // добавление кнопки на вкладку
        }

        private void tbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
             * Метод реализует проверку, что пользователь вводит цифры в поле ввода
             */
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
                e.Handled = true;
        }

        private void btnEvent_Click(object sender, EventArgs e)
        {
            if (tbx.Text != "") // проверка, что поле ввода не пустое
            {
                // для каждого студента рассчитывается размер стипендии
                foreach (Student s in MainForm.students)
                    CountSalary(s);
                FillTable(); // заполнение таблицы по обновленному списку студентов (обновлен атрибут "Стипендия")
            }
            else
                MessageBox.Show("Введите значение стипендии", "Ошибка"); // сообщение об ошибке, если поле ввода пустое
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

        private void CountSalary(Student s)
        {
            int count_5 = 0; // счетчик пятерок
            int count_4 = 0; // счетчик четверок
            int count_2 = 0; // счетчик двоек
            foreach (byte mark in s.getMark())
            {
                // подсчет числа пятерок, чертверок и двоек для студента
                switch (mark)
                {
                    case 5:
                        count_5++;
                        break;
                    case 4:
                        count_4++;
                        break;
                    case 2:
                        count_2++;
                        break;
                    default:
                        break;
                }
                if (count_5 == 5)
                {
                    // установка двойной стипендии для студента, имеющего все оценки отлично
                    s.setSalary(Convert.ToInt32(tbx.Text) * 2);
                    return; // возврат из метода
                }
                if ((count_5 + count_4) == 5)
                {
                    // установка стипендии 130% от базовой для студента, не имеющего троек и двоек
                    s.setSalary(Convert.ToInt32(Convert.ToInt32(tbx.Text) * 1.3));
                    return; // возврат из метода
                }
                if (count_2 != 0)
                {
                    // установка нулевой стипендии для студента, имеющего от одной и более двоек
                    s.setSalary(0);
                    return; // возврат из метода
                }
                // установка базовой стипендии для студента, не удовлетворяющего вышеобозначенным критериям
                s.setSalary(Convert.ToInt32(tbx.Text));
            }
        }
    }
}
