namespace GetCountryInfo
{
    partial class Form1
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
            this.SendNameButton = new System.Windows.Forms.Button();
            this.GetAllFromDbButton = new System.Windows.Forms.Button();
            this.tbCountryInfo = new System.Windows.Forms.TextBox();
            this.tbCountryTitle = new System.Windows.Forms.TextBox();
            this.AddToBdButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SendNameButton
            // 
            this.SendNameButton.Location = new System.Drawing.Point(24, 72);
            this.SendNameButton.Name = "SendNameButton";
            this.SendNameButton.Size = new System.Drawing.Size(166, 50);
            this.SendNameButton.TabIndex = 0;
            this.SendNameButton.Text = "Найти страну по названию";
            this.SendNameButton.UseVisualStyleBackColor = true;
            this.SendNameButton.Click += new System.EventHandler(this.SendCntryNameButton_Click);
            // 
            // GetAllFromDbButton
            // 
            this.GetAllFromDbButton.Location = new System.Drawing.Point(577, 71);
            this.GetAllFromDbButton.Name = "GetAllFromDbButton";
            this.GetAllFromDbButton.Size = new System.Drawing.Size(211, 52);
            this.GetAllFromDbButton.TabIndex = 1;
            this.GetAllFromDbButton.Text = "Вывести все сохраненные страны";
            this.GetAllFromDbButton.UseVisualStyleBackColor = true;
            this.GetAllFromDbButton.Click += new System.EventHandler(this.GetAllFromDBbutton_Click);
            // 
            // tbCountryInfo
            // 
            this.tbCountryInfo.Location = new System.Drawing.Point(24, 143);
            this.tbCountryInfo.Multiline = true;
            this.tbCountryInfo.Name = "tbCountryInfo";
            this.tbCountryInfo.ReadOnly = true;
            this.tbCountryInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbCountryInfo.Size = new System.Drawing.Size(764, 240);
            this.tbCountryInfo.TabIndex = 2;
            // 
            // tbCountryTitle
            // 
            this.tbCountryTitle.Location = new System.Drawing.Point(248, 88);
            this.tbCountryTitle.Name = "tbCountryTitle";
            this.tbCountryTitle.Size = new System.Drawing.Size(270, 20);
            this.tbCountryTitle.TabIndex = 3;
            // 
            // AddToBdButton
            // 
            this.AddToBdButton.Location = new System.Drawing.Point(649, 389);
            this.AddToBdButton.Name = "AddToBdButton";
            this.AddToBdButton.Size = new System.Drawing.Size(139, 43);
            this.AddToBdButton.TabIndex = 4;
            this.AddToBdButton.Text = "Добавить в БД";
            this.AddToBdButton.UseVisualStyleBackColor = true;
            this.AddToBdButton.Visible = false;
            this.AddToBdButton.Click += new System.EventHandler(this.AddToBDbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(207, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "Получи информацию о странах мира!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 436);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddToBdButton);
            this.Controls.Add(this.tbCountryTitle);
            this.Controls.Add(this.tbCountryInfo);
            this.Controls.Add(this.GetAllFromDbButton);
            this.Controls.Add(this.SendNameButton);
            this.Name = "Form1";
            this.Text = "Get countries info";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendNameButton;
        private System.Windows.Forms.Button GetAllFromDbButton;
        private System.Windows.Forms.TextBox tbCountryInfo;
        private System.Windows.Forms.TextBox tbCountryTitle;
        private System.Windows.Forms.Button AddToBdButton;
        private System.Windows.Forms.Label label1;
    }
}

