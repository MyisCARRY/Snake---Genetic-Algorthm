namespace SnakeGA
{
    partial class InputFormNewSnake
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxHiddenLayers = new System.Windows.Forms.TextBox();
            this.textBoxHiddenNodes = new System.Windows.Forms.TextBox();
            this.textBoxPopulationSize = new System.Windows.Forms.TextBox();
            this.textBoxMutationRate = new System.Windows.Forms.TextBox();
            this.textBoxTopPopulation = new System.Windows.Forms.TextBox();
            this.textBoxMovesAtStart = new System.Windows.Forms.TextBox();
            this.textBoxMovesForFood = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(168, 24);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // textBoxHiddenLayers
            // 
            this.textBoxHiddenLayers.Location = new System.Drawing.Point(168, 50);
            this.textBoxHiddenLayers.Name = "textBoxHiddenLayers";
            this.textBoxHiddenLayers.Size = new System.Drawing.Size(100, 20);
            this.textBoxHiddenLayers.TabIndex = 1;
            // 
            // textBoxHiddenNodes
            // 
            this.textBoxHiddenNodes.Location = new System.Drawing.Point(168, 76);
            this.textBoxHiddenNodes.Name = "textBoxHiddenNodes";
            this.textBoxHiddenNodes.Size = new System.Drawing.Size(100, 20);
            this.textBoxHiddenNodes.TabIndex = 2;
            // 
            // textBoxPopulationSize
            // 
            this.textBoxPopulationSize.Location = new System.Drawing.Point(168, 102);
            this.textBoxPopulationSize.Name = "textBoxPopulationSize";
            this.textBoxPopulationSize.Size = new System.Drawing.Size(100, 20);
            this.textBoxPopulationSize.TabIndex = 3;
            // 
            // textBoxMutationRate
            // 
            this.textBoxMutationRate.Location = new System.Drawing.Point(168, 128);
            this.textBoxMutationRate.Name = "textBoxMutationRate";
            this.textBoxMutationRate.Size = new System.Drawing.Size(100, 20);
            this.textBoxMutationRate.TabIndex = 4;
            // 
            // textBoxTopPopulation
            // 
            this.textBoxTopPopulation.Location = new System.Drawing.Point(168, 154);
            this.textBoxTopPopulation.Name = "textBoxTopPopulation";
            this.textBoxTopPopulation.Size = new System.Drawing.Size(100, 20);
            this.textBoxTopPopulation.TabIndex = 5;
            // 
            // textBoxMovesAtStart
            // 
            this.textBoxMovesAtStart.Location = new System.Drawing.Point(168, 180);
            this.textBoxMovesAtStart.Name = "textBoxMovesAtStart";
            this.textBoxMovesAtStart.Size = new System.Drawing.Size(100, 20);
            this.textBoxMovesAtStart.TabIndex = 6;
            // 
            // textBoxMovesForFood
            // 
            this.textBoxMovesForFood.Location = new System.Drawing.Point(168, 206);
            this.textBoxMovesForFood.Name = "textBoxMovesForFood";
            this.textBoxMovesForFood.Size = new System.Drawing.Size(100, 20);
            this.textBoxMovesForFood.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "No. of hidden layers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "No. of hidden nodes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Size of population";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Mutation rate [%]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "% of population to multiply";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Moves at start";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 206);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Moves for food";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(12, 231);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(256, 23);
            this.buttonSubmit.TabIndex = 16;
            this.buttonSubmit.Text = "OK";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // InputFormNewSnake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 264);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMovesForFood);
            this.Controls.Add(this.textBoxMovesAtStart);
            this.Controls.Add(this.textBoxTopPopulation);
            this.Controls.Add(this.textBoxMutationRate);
            this.Controls.Add(this.textBoxPopulationSize);
            this.Controls.Add(this.textBoxHiddenNodes);
            this.Controls.Add(this.textBoxHiddenLayers);
            this.Controls.Add(this.textBoxName);
            this.Name = "InputFormNewSnake";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parameters for training";
            this.Load += new System.EventHandler(this.InputFormNewSnake_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxHiddenLayers;
        private System.Windows.Forms.TextBox textBoxHiddenNodes;
        private System.Windows.Forms.TextBox textBoxPopulationSize;
        private System.Windows.Forms.TextBox textBoxMutationRate;
        private System.Windows.Forms.TextBox textBoxTopPopulation;
        private System.Windows.Forms.TextBox textBoxMovesAtStart;
        private System.Windows.Forms.TextBox textBoxMovesForFood;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonSubmit;
    }
}