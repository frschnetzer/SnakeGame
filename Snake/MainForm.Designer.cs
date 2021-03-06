namespace SnakeGame
{
    partial class FormSnakeGame
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

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBoxBoard = new System.Windows.Forms.PictureBox();
            this.labelScore = new System.Windows.Forms.Label();
            this.labelPoints = new System.Windows.Forms.Label();
            this.labelEndText = new System.Windows.Forms.Label();
            this.timerSnakeGame = new System.Windows.Forms.Timer(this.components);
            this.buttonStart = new System.Windows.Forms.Button();
            this.LabelLoginName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxBoard
            // 
            this.pictureBoxBoard.BackColor = System.Drawing.Color.Silver;
            this.pictureBoxBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBoard.Location = new System.Drawing.Point(10, 9);
            this.pictureBoxBoard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxBoard.Name = "pictureBoxBoard";
            this.pictureBoxBoard.Size = new System.Drawing.Size(474, 420);
            this.pictureBoxBoard.TabIndex = 0;
            this.pictureBoxBoard.TabStop = false;
            this.pictureBoxBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdateGraphics);
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelScore.Location = new System.Drawing.Point(552, 28);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(67, 25);
            this.labelScore.TabIndex = 1;
            this.labelScore.Text = "Score:";
            // 
            // labelPoints
            // 
            this.labelPoints.AutoSize = true;
            this.labelPoints.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPoints.Location = new System.Drawing.Point(632, 28);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(34, 25);
            this.labelPoints.TabIndex = 2;
            this.labelPoints.Text = "00";
            // 
            // labelEndText
            // 
            this.labelEndText.AutoSize = true;
            this.labelEndText.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEndText.Location = new System.Drawing.Point(188, 170);
            this.labelEndText.Name = "labelEndText";
            this.labelEndText.Size = new System.Drawing.Size(83, 25);
            this.labelEndText.TabIndex = 3;
            this.labelEndText.Text = "EndText";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(216, 436);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(82, 22);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // LabelLoginName
            // 
            this.LabelLoginName.AutoSize = true;
            this.LabelLoginName.Location = new System.Drawing.Point(715, 9);
            this.LabelLoginName.Name = "LabelLoginName";
            this.LabelLoginName.Size = new System.Drawing.Size(38, 15);
            this.LabelLoginName.TabIndex = 5;
            this.LabelLoginName.Text = "label1";
            // 
            // FormSnakeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 467);
            this.Controls.Add(this.LabelLoginName);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelEndText);
            this.Controls.Add(this.labelPoints);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.pictureBoxBoard);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormSnakeGame";
            this.Text = "FormSnakeGame";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormSnakeGame_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormSnakeGame_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBoxBoard;
        private Label labelScore;
        private Label labelPoints;
        private Label labelEndText;
        private System.Windows.Forms.Timer timerSnakeGame;
        private Button buttonStart;
        private Label LabelLoginName;
    }
}