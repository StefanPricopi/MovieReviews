namespace Desktop_App.Forms.MovieManagerForms
{
    partial class EditMovieForm
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
            btnEditMovie = new Button();
            tbDuration = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            dtpReleaseDate = new DateTimePicker();
            cbGenre = new ComboBox();
            label4 = new Label();
            tbActors = new TextBox();
            label3 = new Label();
            tbDirector = new TextBox();
            label2 = new Label();
            tbTitle = new TextBox();
            label1 = new Label();
            rtbDescription = new RichTextBox();
            SuspendLayout();
            // 
            // btnEditMovie
            // 
            btnEditMovie.Location = new Point(559, 388);
            btnEditMovie.Name = "btnEditMovie";
            btnEditMovie.Size = new Size(154, 50);
            btnEditMovie.TabIndex = 43;
            btnEditMovie.Text = "EditMovie";
            btnEditMovie.UseVisualStyleBackColor = true;
            // 
            // tbDuration
            // 
            tbDuration.Location = new Point(130, 411);
            tbDuration.Name = "tbDuration";
            tbDuration.Size = new Size(125, 27);
            tbDuration.TabIndex = 42;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(130, 388);
            label7.Name = "label7";
            label7.Size = new Size(67, 20);
            label7.TabIndex = 41;
            label7.Text = "Duration";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(356, 132);
            label6.Name = "label6";
            label6.Size = new Size(94, 20);
            label6.TabIndex = 40;
            label6.Text = "Release date";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(356, 68);
            label5.Name = "label5";
            label5.Size = new Size(85, 20);
            label5.TabIndex = 39;
            label5.Text = "Main Genre";
            // 
            // dtpReleaseDate
            // 
            dtpReleaseDate.Location = new Point(356, 155);
            dtpReleaseDate.Name = "dtpReleaseDate";
            dtpReleaseDate.Size = new Size(250, 27);
            dtpReleaseDate.TabIndex = 38;
            // 
            // cbGenre
            // 
            cbGenre.FormattingEnabled = true;
            cbGenre.Items.AddRange(new object[] { "Action", "Comedy", "Drama", "Science Fiction" });
            cbGenre.Location = new Point(356, 91);
            cbGenre.Name = "cbGenre";
            cbGenre.Size = new Size(151, 28);
            cbGenre.TabIndex = 37;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(130, 254);
            label4.Name = "label4";
            label4.Size = new Size(85, 20);
            label4.TabIndex = 35;
            label4.Text = "Description";
            // 
            // tbActors
            // 
            tbActors.Location = new Point(135, 222);
            tbActors.Name = "tbActors";
            tbActors.Size = new Size(125, 27);
            tbActors.TabIndex = 34;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(135, 199);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 33;
            label3.Text = "Actors";
            // 
            // tbDirector
            // 
            tbDirector.Location = new Point(135, 155);
            tbDirector.Name = "tbDirector";
            tbDirector.Size = new Size(125, 27);
            tbDirector.TabIndex = 32;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(130, 130);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 31;
            label2.Text = "Director";
            // 
            // tbTitle
            // 
            tbTitle.Location = new Point(135, 91);
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(125, 27);
            tbTitle.TabIndex = 30;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(130, 66);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 29;
            label1.Text = "Title";
            // 
            // rtbDescription
            // 
            rtbDescription.Location = new Point(130, 277);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new Size(450, 88);
            rtbDescription.TabIndex = 44;
            rtbDescription.Text = "";
            // 
            // EditMovieForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbDescription);
            Controls.Add(btnEditMovie);
            Controls.Add(tbDuration);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(dtpReleaseDate);
            Controls.Add(cbGenre);
            Controls.Add(label4);
            Controls.Add(tbActors);
            Controls.Add(label3);
            Controls.Add(tbDirector);
            Controls.Add(label2);
            Controls.Add(tbTitle);
            Controls.Add(label1);
            Name = "EditMovieForm";
            Text = "EditMovieForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEditMovie;
        private TextBox tbDuration;
        private Label label7;
        private Label label6;
        private Label label5;
        private DateTimePicker dtpReleaseDate;
        private ComboBox cbGenre;
        private Label label4;
        private TextBox tbActors;
        private Label label3;
        private TextBox tbDirector;
        private Label label2;
        private TextBox tbTitle;
        private Label label1;
        private RichTextBox rtbDescription;
    }
}