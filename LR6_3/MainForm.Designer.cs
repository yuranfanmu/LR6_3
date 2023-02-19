
namespace LR6_3
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabStatement = new System.Windows.Forms.TabPage();
            this.btnDefaultStudents = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mark1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mark2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mark3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mark4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mark5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabAdd = new System.Windows.Forms.TabPage();
            this.tabCount = new System.Windows.Forms.TabPage();
            this.tabSort = new System.Windows.Forms.TabPage();
            this.tabEdit = new System.Windows.Forms.TabPage();
            this.tabRemove = new System.Windows.Forms.TabPage();
            this.btnExit = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabStatement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabStatement);
            this.tabControl1.Controls.Add(this.tabAdd);
            this.tabControl1.Controls.Add(this.tabCount);
            this.tabControl1.Controls.Add(this.tabSort);
            this.tabControl1.Controls.Add(this.tabEdit);
            this.tabControl1.Controls.Add(this.tabRemove);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1097, 440);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabStatement
            // 
            this.tabStatement.Controls.Add(this.btnDefaultStudents);
            this.tabStatement.Controls.Add(this.dgv);
            this.tabStatement.Location = new System.Drawing.Point(4, 25);
            this.tabStatement.Name = "tabStatement";
            this.tabStatement.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatement.Size = new System.Drawing.Size(1089, 411);
            this.tabStatement.TabIndex = 0;
            this.tabStatement.Text = " Ведомость";
            this.tabStatement.UseVisualStyleBackColor = true;
            // 
            // btnDefaultStudents
            // 
            this.btnDefaultStudents.Location = new System.Drawing.Point(6, 363);
            this.btnDefaultStudents.Name = "btnDefaultStudents";
            this.btnDefaultStudents.Size = new System.Drawing.Size(408, 42);
            this.btnDefaultStudents.TabIndex = 1;
            this.btnDefaultStudents.Text = "Заполнить таблицу значениями по умолчанию";
            this.btnDefaultStudents.UseVisualStyleBackColor = true;
            this.btnDefaultStudents.Click += new System.EventHandler(this.btnDefaultStudents_Click);
            // 
            // dgv
            // 
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Group,
            this.StudentName,
            this.Mark1,
            this.Mark2,
            this.Mark3,
            this.Mark4,
            this.Mark5,
            this.Salary});
            this.dgv.Location = new System.Drawing.Point(6, 6);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(1077, 351);
            this.dgv.TabIndex = 0;
            // 
            // Group
            // 
            this.Group.HeaderText = "Индекс группы";
            this.Group.MinimumWidth = 6;
            this.Group.Name = "Group";
            this.Group.ReadOnly = true;
            // 
            // StudentName
            // 
            this.StudentName.HeaderText = "ФИО студента";
            this.StudentName.MinimumWidth = 6;
            this.StudentName.Name = "StudentName";
            this.StudentName.ReadOnly = true;
            // 
            // Mark1
            // 
            this.Mark1.HeaderText = "Экзамен 1";
            this.Mark1.MinimumWidth = 6;
            this.Mark1.Name = "Mark1";
            this.Mark1.ReadOnly = true;
            // 
            // Mark2
            // 
            this.Mark2.HeaderText = "Экзамен 2";
            this.Mark2.MinimumWidth = 6;
            this.Mark2.Name = "Mark2";
            this.Mark2.ReadOnly = true;
            // 
            // Mark3
            // 
            this.Mark3.HeaderText = "Экзамен 3";
            this.Mark3.MinimumWidth = 6;
            this.Mark3.Name = "Mark3";
            this.Mark3.ReadOnly = true;
            // 
            // Mark4
            // 
            this.Mark4.HeaderText = "Экзамен 4";
            this.Mark4.MinimumWidth = 6;
            this.Mark4.Name = "Mark4";
            this.Mark4.ReadOnly = true;
            // 
            // Mark5
            // 
            this.Mark5.HeaderText = "Экзамен 5";
            this.Mark5.MinimumWidth = 6;
            this.Mark5.Name = "Mark5";
            this.Mark5.ReadOnly = true;
            // 
            // Salary
            // 
            this.Salary.HeaderText = "Стипендия";
            this.Salary.MinimumWidth = 6;
            this.Salary.Name = "Salary";
            this.Salary.ReadOnly = true;
            // 
            // tabAdd
            // 
            this.tabAdd.Location = new System.Drawing.Point(4, 25);
            this.tabAdd.Name = "tabAdd";
            this.tabAdd.Size = new System.Drawing.Size(1089, 411);
            this.tabAdd.TabIndex = 2;
            this.tabAdd.Text = "Добавить";
            this.tabAdd.UseVisualStyleBackColor = true;
            // 
            // tabCount
            // 
            this.tabCount.Location = new System.Drawing.Point(4, 25);
            this.tabCount.Name = "tabCount";
            this.tabCount.Size = new System.Drawing.Size(1089, 411);
            this.tabCount.TabIndex = 3;
            this.tabCount.Text = "Расчет";
            this.tabCount.UseVisualStyleBackColor = true;
            // 
            // tabSort
            // 
            this.tabSort.Location = new System.Drawing.Point(4, 25);
            this.tabSort.Name = "tabSort";
            this.tabSort.Size = new System.Drawing.Size(1089, 411);
            this.tabSort.TabIndex = 4;
            this.tabSort.Text = "Сортировка";
            this.tabSort.UseVisualStyleBackColor = true;
            // 
            // tabEdit
            // 
            this.tabEdit.Location = new System.Drawing.Point(4, 25);
            this.tabEdit.Name = "tabEdit";
            this.tabEdit.Size = new System.Drawing.Size(1089, 411);
            this.tabEdit.TabIndex = 5;
            this.tabEdit.Text = "Корректировка";
            this.tabEdit.UseVisualStyleBackColor = true;
            // 
            // tabRemove
            // 
            this.tabRemove.Location = new System.Drawing.Point(4, 25);
            this.tabRemove.Name = "tabRemove";
            this.tabRemove.Size = new System.Drawing.Size(1089, 411);
            this.tabRemove.TabIndex = 6;
            this.tabRemove.Text = "Удаление";
            this.tabRemove.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(948, 458);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(157, 42);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 512);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.tabControl1.ResumeLayout(false);
            this.tabStatement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabStatement;
        private System.Windows.Forms.TabPage tabAdd;
        private System.Windows.Forms.TabPage tabCount;
        private System.Windows.Forms.TabPage tabSort;
        private System.Windows.Forms.TabPage tabEdit;
        private System.Windows.Forms.TabPage tabRemove;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mark1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mark2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mark3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mark4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mark5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary;
        private System.Windows.Forms.Button btnDefaultStudents;
    }
}

