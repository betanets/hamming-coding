namespace HammingCoding
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.построитьКодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.декодироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.operationStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.richTextBox_data = new System.Windows.Forms.RichTextBox();
            this.внестиОшибкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_error = new System.Windows.Forms.Label();
            this.numericUpDown_error = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_error)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.действияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(754, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.открытьToolStripMenuItem.Text = "Открыть...";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.построитьКодToolStripMenuItem,
            this.внестиОшибкиToolStripMenuItem,
            this.декодироватьToolStripMenuItem});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.действияToolStripMenuItem.Text = "Операции";
            // 
            // построитьКодToolStripMenuItem
            // 
            this.построитьКодToolStripMenuItem.Name = "построитьКодToolStripMenuItem";
            this.построитьКодToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.построитьКодToolStripMenuItem.Text = "Построить код";
            this.построитьКодToolStripMenuItem.Click += new System.EventHandler(this.построитьКодToolStripMenuItem_Click);
            // 
            // декодироватьToolStripMenuItem
            // 
            this.декодироватьToolStripMenuItem.Name = "декодироватьToolStripMenuItem";
            this.декодироватьToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.декодироватьToolStripMenuItem.Text = "Декодировать";
            this.декодироватьToolStripMenuItem.Click += new System.EventHandler(this.декодироватьToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operationStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 409);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(754, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // operationStatusLabel
            // 
            this.operationStatusLabel.Name = "operationStatusLabel";
            this.operationStatusLabel.Size = new System.Drawing.Size(193, 17);
            this.operationStatusLabel.Text = "Ожидание выполнения операции";
            // 
            // richTextBox_data
            // 
            this.richTextBox_data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_data.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_data.Location = new System.Drawing.Point(12, 59);
            this.richTextBox_data.Name = "richTextBox_data";
            this.richTextBox_data.Size = new System.Drawing.Size(730, 347);
            this.richTextBox_data.TabIndex = 4;
            this.richTextBox_data.Text = "";
            // 
            // внестиОшибкиToolStripMenuItem
            // 
            this.внестиОшибкиToolStripMenuItem.Name = "внестиОшибкиToolStripMenuItem";
            this.внестиОшибкиToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.внестиОшибкиToolStripMenuItem.Text = "Внести ошибки";
            this.внестиОшибкиToolStripMenuItem.Click += new System.EventHandler(this.внестиОшибкиToolStripMenuItem_Click);
            // 
            // label_error
            // 
            this.label_error.AutoSize = true;
            this.label_error.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_error.Location = new System.Drawing.Point(9, 36);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(230, 13);
            this.label_error.TabIndex = 5;
            this.label_error.Text = "Вероятность возникновения ошибки:";
            // 
            // numericUpDown_error
            // 
            this.numericUpDown_error.DecimalPlaces = 2;
            this.numericUpDown_error.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_error.Location = new System.Drawing.Point(245, 33);
            this.numericUpDown_error.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_error.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_error.Name = "numericUpDown_error";
            this.numericUpDown_error.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_error.TabIndex = 6;
            this.numericUpDown_error.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(754, 431);
            this.Controls.Add(this.numericUpDown_error);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.richTextBox_data);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(770, 470);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Построение кода Хэмминга";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem построитьКодToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem декодироватьToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel operationStatusLabel;
        private System.Windows.Forms.RichTextBox richTextBox_data;
        private System.Windows.Forms.ToolStripMenuItem внестиОшибкиToolStripMenuItem;
        private System.Windows.Forms.Label label_error;
        private System.Windows.Forms.NumericUpDown numericUpDown_error;
    }
}

