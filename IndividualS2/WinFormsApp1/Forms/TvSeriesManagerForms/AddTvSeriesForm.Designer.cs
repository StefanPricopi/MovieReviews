namespace Desktop_App.Forms.TvSeriesManagerForms
{
    partial class AddTvSeriesForm
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
            tbNumberOfSeasons = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            dtpPilotDate = new DateTimePicker();
            cbGenre = new ComboBox();
            label4 = new Label();
            tbActors = new TextBox();
            label3 = new Label();
            tbDirector = new TextBox();
            label2 = new Label();
            tbTitle = new TextBox();
            label1 = new Label();
            label8 = new Label();
            cbStatus = new ComboBox();
            label9 = new Label();
            dtpLastEpDate = new DateTimePicker();
            btnAddTvSeries = new Button();
            rtbDescription = new RichTextBox();
            SuspendLayout();
            // 
            // tbNumberOfSeasons
            // 
            tbNumberOfSeasons.Location = new Point(40, 376);
            tbNumberOfSeasons.Name = "tbNumberOfSeasons";
            tbNumberOfSeasons.Size = new Size(125, 27);
            tbNumberOfSeasons.TabIndex = 41;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(40, 341);
            label7.Name = "label7";
            label7.Size = new Size(136, 20);
            label7.TabIndex = 40;
            label7.Text = "Number of seasons";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(505, 31);
            label6.Name = "label6";
            label6.Size = new Size(73, 20);
            label6.TabIndex = 39;
            label6.Text = "Pilot date";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(266, 30);
            label5.Name = "label5";
            label5.Size = new Size(85, 20);
            label5.TabIndex = 38;
            label5.Text = "Main Genre";
            // 
            // dtpPilotDate
            // 
            dtpPilotDate.Location = new Point(505, 54);
            dtpPilotDate.Name = "dtpPilotDate";
            dtpPilotDate.Size = new Size(250, 27);
            dtpPilotDate.TabIndex = 37;
            // 
            // cbGenre
            // 
            cbGenre.FormattingEnabled = true;
            cbGenre.Items.AddRange(new object[] { "Action", "Comedy", "Drama", "Science Fiction" });
            cbGenre.Location = new Point(266, 53);
            cbGenre.Name = "cbGenre";
            cbGenre.Size = new Size(151, 28);
            cbGenre.TabIndex = 36;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 216);
            label4.Name = "label4";
            label4.Size = new Size(85, 20);
            label4.TabIndex = 34;
            label4.Text = "Description";
            // 
            // tbActors
            // 
            tbActors.Location = new Point(45, 184);
            tbActors.Name = "tbActors";
            tbActors.Size = new Size(125, 27);
            tbActors.TabIndex = 33;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 161);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 32;
            label3.Text = "Actors";
            // 
            // tbDirector
            // 
            tbDirector.Location = new Point(45, 117);
            tbDirector.Name = "tbDirector";
            tbDirector.Size = new Size(125, 27);
            tbDirector.TabIndex = 31;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 92);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 30;
            label2.Text = "Director";
            // 
            // tbTitle
            // 
            tbTitle.Location = new Point(45, 53);
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(125, 27);
            tbTitle.TabIndex = 29;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 28);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 28;
            label1.Text = "Title";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(266, 92);
            label8.Name = "label8";
            label8.Size = new Size(49, 20);
            label8.TabIndex = 43;
            label8.Text = "Status";
            // 
            // cbStatus
            // 
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "Running", "Finished" });
            cbStatus.Location = new Point(266, 115);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(151, 28);
            cbStatus.TabIndex = 42;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(505, 106);
            label9.Name = "label9";
            label9.Size = new Size(126, 20);
            label9.TabIndex = 45;
            label9.Text = "Last episode date";
            // 
            // dtpLastEpDate
            // 
            dtpLastEpDate.Location = new Point(505, 129);
            dtpLastEpDate.Name = "dtpLastEpDate";
            dtpLastEpDate.Size = new Size(250, 27);
            dtpLastEpDate.TabIndex = 44;
            // 
            // btnAddTvSeries
            // 
            btnAddTvSeries.Location = new Point(566, 364);
            btnAddTvSeries.Name = "btnAddTvSeries";
            btnAddTvSeries.Size = new Size(120, 51);
            btnAddTvSeries.TabIndex = 46;
            btnAddTvSeries.Text = "AddTvSeries";
            btnAddTvSeries.UseVisualStyleBackColor = true;
            // 
            // rtbDescription
            // 
            rtbDescription.Location = new Point(40, 239);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new Size(450, 88);
            rtbDescription.TabIndex = 47;
            rtbDescription.Text = "";
            // 
            // AddTvSeriesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbDescription);
            Controls.Add(btnAddTvSeries);
            Controls.Add(label9);
            Controls.Add(dtpLastEpDate);
            Controls.Add(label8);
            Controls.Add(cbStatus);
            Controls.Add(tbNumberOfSeasons);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(dtpPilotDate);
            Controls.Add(cbGenre);
            Controls.Add(label4);
            Controls.Add(tbActors);
            Controls.Add(label3);
            Controls.Add(tbDirector);
            Controls.Add(label2);
            Controls.Add(tbTitle);
            Controls.Add(label1);
            Name = "AddTvSeriesForm";
            Text = "AddTvSeriesForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbNumberOfSeasons;
        private Label label7;
        private Label label6;
        private Label label5;
        private DateTimePicker dtpPilotDate;
        private ComboBox cbGenre;
        private Label label4;
        private TextBox tbActors;
        private Label label3;
        private TextBox tbDirector;
        private Label label2;
        private TextBox tbTitle;
        private Label label1;
        private Label label8;
        private ComboBox cbStatus;
        private Label label9;
        private DateTimePicker dtpLastEpDate;
        private Button btnAddTvSeries;
        private RichTextBox rtbDescription;
    }
}