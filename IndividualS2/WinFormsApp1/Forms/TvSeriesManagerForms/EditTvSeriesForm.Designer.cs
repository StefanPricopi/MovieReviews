namespace Desktop_App.Forms.TvSeriesManagerForms
{
    partial class EditTvSeriesForm
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
            label9 = new Label();
            dtpLastEpDate = new DateTimePicker();
            label8 = new Label();
            cbStatus = new ComboBox();
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
            btnEditTvSeries = new Button();
            rtbDescription = new RichTextBox();
            dgvTvSeriesCollection = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTvSeriesCollection).BeginInit();
            SuspendLayout();
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(53, 487);
            label9.Name = "label9";
            label9.Size = new Size(126, 20);
            label9.TabIndex = 63;
            label9.Text = "Last episode date";
            // 
            // dtpLastEpDate
            // 
            dtpLastEpDate.Location = new Point(53, 510);
            dtpLastEpDate.Name = "dtpLastEpDate";
            dtpLastEpDate.Size = new Size(250, 27);
            dtpLastEpDate.TabIndex = 62;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(274, 99);
            label8.Name = "label8";
            label8.Size = new Size(49, 20);
            label8.TabIndex = 61;
            label8.Text = "Status";
            // 
            // cbStatus
            // 
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "Running", "Finished" });
            cbStatus.Location = new Point(274, 122);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(151, 28);
            cbStatus.TabIndex = 60;
            // 
            // tbNumberOfSeasons
            // 
            tbNumberOfSeasons.Location = new Point(53, 378);
            tbNumberOfSeasons.Name = "tbNumberOfSeasons";
            tbNumberOfSeasons.Size = new Size(130, 27);
            tbNumberOfSeasons.TabIndex = 59;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(53, 345);
            label7.Name = "label7";
            label7.Size = new Size(136, 20);
            label7.TabIndex = 58;
            label7.Text = "Number of seasons";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(53, 422);
            label6.Name = "label6";
            label6.Size = new Size(73, 20);
            label6.TabIndex = 57;
            label6.Text = "Pilot date";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(274, 37);
            label5.Name = "label5";
            label5.Size = new Size(85, 20);
            label5.TabIndex = 56;
            label5.Text = "Main Genre";
            // 
            // dtpPilotDate
            // 
            dtpPilotDate.Location = new Point(53, 447);
            dtpPilotDate.Name = "dtpPilotDate";
            dtpPilotDate.Size = new Size(250, 27);
            dtpPilotDate.TabIndex = 55;
            // 
            // cbGenre
            // 
            cbGenre.FormattingEnabled = true;
            cbGenre.Items.AddRange(new object[] { "Action", "Comedy", "Drama", "Science Fiction" });
            cbGenre.Location = new Point(274, 60);
            cbGenre.Name = "cbGenre";
            cbGenre.Size = new Size(151, 28);
            cbGenre.TabIndex = 54;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(48, 223);
            label4.Name = "label4";
            label4.Size = new Size(85, 20);
            label4.TabIndex = 52;
            label4.Text = "Description";
            // 
            // tbActors
            // 
            tbActors.Location = new Point(53, 191);
            tbActors.Name = "tbActors";
            tbActors.Size = new Size(125, 27);
            tbActors.TabIndex = 51;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 168);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 50;
            label3.Text = "Actors";
            // 
            // tbDirector
            // 
            tbDirector.Location = new Point(53, 124);
            tbDirector.Name = "tbDirector";
            tbDirector.Size = new Size(125, 27);
            tbDirector.TabIndex = 49;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 99);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 48;
            label2.Text = "Director";
            // 
            // tbTitle
            // 
            tbTitle.Location = new Point(53, 60);
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(125, 27);
            tbTitle.TabIndex = 47;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 35);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 46;
            label1.Text = "Title";
            // 
            // btnEditTvSeries
            // 
            btnEditTvSeries.Location = new Point(744, 487);
            btnEditTvSeries.Name = "btnEditTvSeries";
            btnEditTvSeries.Size = new Size(208, 50);
            btnEditTvSeries.TabIndex = 64;
            btnEditTvSeries.Text = "EditTvSeries";
            btnEditTvSeries.UseVisualStyleBackColor = true;
            btnEditTvSeries.Click += btnEditTvSeries_Click;
            // 
            // rtbDescription
            // 
            rtbDescription.Location = new Point(53, 254);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new Size(372, 88);
            rtbDescription.TabIndex = 65;
            rtbDescription.Text = "";
            // 
            // dgvTvSeriesCollection
            // 
            dgvTvSeriesCollection.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTvSeriesCollection.Location = new Point(477, 35);
            dgvTvSeriesCollection.Name = "dgvTvSeriesCollection";
            dgvTvSeriesCollection.RowHeadersWidth = 51;
            dgvTvSeriesCollection.RowTemplate.Height = 29;
            dgvTvSeriesCollection.Size = new Size(780, 439);
            dgvTvSeriesCollection.TabIndex = 66;
            dgvTvSeriesCollection.SelectionChanged += dgvTvSeriesCollection_SelectionChanged;
            // 
            // EditTvSeriesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1279, 611);
            Controls.Add(dgvTvSeriesCollection);
            Controls.Add(rtbDescription);
            Controls.Add(btnEditTvSeries);
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
            Name = "EditTvSeriesForm";
            Text = "EditTvSeriesForm";
            ((System.ComponentModel.ISupportInitialize)dgvTvSeriesCollection).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label9;
        private DateTimePicker dtpLastEpDate;
        private Label label8;
        private ComboBox cbStatus;
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
        private Button btnEditTvSeries;
        private RichTextBox rtbDescription;
        private DataGridView dgvTvSeriesCollection;
    }
}