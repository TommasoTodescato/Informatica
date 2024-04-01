using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GiocoVita
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private TextBox RowsInput;
        private Button StartButton;

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            StartButton = new Button();
            RowsInput = new TextBox();
            label1 = new Label();
            label2 = new Label();
            Table = new TableLayoutPanel();
            Table.SuspendLayout();
            SuspendLayout();

            //
            // Table
            //
            Table.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Table.Dock = DockStyle.Fill;
            Table.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            Table.Name = "table";

            // 
            // StartButton
            // 
            StartButton.BackColor = Color.RosyBrown;
            StartButton.BackgroundImageLayout = ImageLayout.None;
            StartButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            StartButton.Location = new Point(434, 651);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(109, 50);
            StartButton.TabIndex = 3;
            StartButton.Text = "START";
            StartButton.UseVisualStyleBackColor = false;
            StartButton.Click += Start;
            // 
            // RowsInput
            // 
            RowsInput.Location = new Point(434, 611);
            RowsInput.Name = "RowsInput";
            RowsInput.Size = new Size(109, 23);
            RowsInput.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(395, 574);
            label1.Name = "label1";
            label1.Size = new Size(201, 25);
            label1.TabIndex = 4;
            label1.Text = "Grandezza del campo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.IndianRed;
            label2.Location = new Point(197, 220);
            label2.Name = "label2";
            label2.Size = new Size(611, 86);
            label2.TabIndex = 5;
            label2.Text = "GIOCO DELLA VITA";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(999, 713);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(StartButton);
            Controls.Add(RowsInput);
            Controls.Add(Table);
            Name = "Main";
            Text = "Gioco Vita";
            CenterToScreen();
            Table.ResumeLayout(false);
            Table.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        #region Generazione del campo in base alla dimensione in input

        private void InitTable(int Size = 8)
        {
            Table.ColumnCount = Size;
            Table.RowCount = Size;

            for (int i = 0; i < Size; i++)
            {
                Table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / Size));
                Table.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / Size));
            }

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    PictureBox p = new PictureBox();
                    p.Name = p.Name = "Casella" + i.ToString() + j.ToString();
                    p.AutoSize = true;
                    p.Dock = DockStyle.Fill;
                    p.BackColor = Color.Moccasin;
                    p.TabStop = false;
                    p.SizeMode = PictureBoxSizeMode.Zoom;

                    Table.Controls.Add(p, i, j);
                }
            }
            RowsInput.Visible = false;
            StartButton.Visible = false;
            label1.Visible = false; label2.Visible = false;
        }

        #endregion

        private Label label1;
        private Label label2;
    }
}