namespace SnakeGA
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.buttonNewSnake = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHiddenLayers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHiddenNodes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnMutationrate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPopSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTopPopulation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnBestScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonReload = new System.Windows.Forms.Button();
            this.initListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.initListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonNewSnake
            // 
            this.buttonNewSnake.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewSnake.Location = new System.Drawing.Point(214, 12);
            this.buttonNewSnake.Name = "buttonNewSnake";
            this.buttonNewSnake.Size = new System.Drawing.Size(402, 93);
            this.buttonNewSnake.TabIndex = 0;
            this.buttonNewSnake.Text = "Train New Snake";
            this.buttonNewSnake.UseVisualStyleBackColor = true;
            this.buttonNewSnake.Click += new System.EventHandler(this.buttonNewSnake_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnID,
            this.columnName,
            this.columnHiddenLayers,
            this.columnHiddenNodes,
            this.columnMutationrate,
            this.columnPopSize,
            this.columnTopPopulation,
            this.columnBestScore});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(13, 111);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(603, 272);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // columnID
            // 
            this.columnID.Tag = "ID";
            this.columnID.Text = "ID";
            this.columnID.Width = 28;
            // 
            // columnName
            // 
            this.columnName.Tag = "Name";
            this.columnName.Text = "Name";
            this.columnName.Width = 95;
            // 
            // columnHiddenLayers
            // 
            this.columnHiddenLayers.Tag = "HiddenLayers";
            this.columnHiddenLayers.Text = "H. Layers";
            this.columnHiddenLayers.Width = 69;
            // 
            // columnHiddenNodes
            // 
            this.columnHiddenNodes.Tag = "Hidden Nodes";
            this.columnHiddenNodes.Text = "H. Nodes";
            this.columnHiddenNodes.Width = 74;
            // 
            // columnMutationrate
            // 
            this.columnMutationrate.Tag = "Mutation rate";
            this.columnMutationrate.Text = "Mutation rate";
            this.columnMutationrate.Width = 90;
            // 
            // columnPopSize
            // 
            this.columnPopSize.Tag = "Population";
            this.columnPopSize.Text = "Pop. size";
            this.columnPopSize.Width = 71;
            // 
            // columnTopPopulation
            // 
            this.columnTopPopulation.Tag = "Top population %";
            this.columnTopPopulation.Text = "Top pop. %";
            this.columnTopPopulation.Width = 85;
            // 
            // columnBestScore
            // 
            this.columnBestScore.Text = "Best Score";
            this.columnBestScore.Width = 101;
            // 
            // buttonReload
            // 
            this.buttonReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReload.Location = new System.Drawing.Point(13, 13);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(182, 92);
            this.buttonReload.TabIndex = 2;
            this.buttonReload.Text = "Reload";
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.buttonReload_Click);
            // 
            // initListBindingSource
            // 
            this.initListBindingSource.DataSource = typeof(SnakeGA.InitList);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 404);
            this.Controls.Add(this.buttonReload);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.buttonNewSnake);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.initListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNewSnake;
        private System.Windows.Forms.BindingSource initListBindingSource;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnID;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnHiddenLayers;
        private System.Windows.Forms.ColumnHeader columnHiddenNodes;
        private System.Windows.Forms.ColumnHeader columnMutationrate;
        private System.Windows.Forms.ColumnHeader columnPopSize;
        private System.Windows.Forms.ColumnHeader columnTopPopulation;
        private System.Windows.Forms.ColumnHeader columnBestScore;
        private System.Windows.Forms.Button buttonReload;
    }
}

