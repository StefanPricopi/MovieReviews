namespace WinFormsApp1
{
    partial class MainForm
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
            tCMain = new TabControl();
            tpMovieManager = new TabPage();
            label7 = new Label();
            lbMovieColletion = new ListBox();
            label1 = new Label();
            tbSearchMovieTitle = new TextBox();
            btnSearchMovie = new Button();
            btnViewAllMovies = new Button();
            btnUpdateMovie = new Button();
            btnAddMovie = new Button();
            tpTvSeriesManager = new TabPage();
            label6 = new Label();
            lbTvSeriesCollection = new ListBox();
            label2 = new Label();
            tbSearchTvSeriesTitle = new TextBox();
            btnSearchTvSeries = new Button();
            btnViewAllTvSeries = new Button();
            btnUpdateTvSeries = new Button();
            btnAddTvSeries = new Button();
            tpReviewManager = new TabPage();
            label5 = new Label();
            label4 = new Label();
            lbMediaCollection = new ListBox();
            label3 = new Label();
            tbSearchReviewTitle = new TextBox();
            btnSearchReview = new Button();
            btnViewAllReview = new Button();
            btnUpdateReview = new Button();
            btnAddReview = new Button();
            lbReviewCollection = new ListBox();
            tCMain.SuspendLayout();
            tpMovieManager.SuspendLayout();
            tpTvSeriesManager.SuspendLayout();
            tpReviewManager.SuspendLayout();
            SuspendLayout();
            // 
            // tCMain
            // 
            tCMain.Controls.Add(tpMovieManager);
            tCMain.Controls.Add(tpTvSeriesManager);
            tCMain.Controls.Add(tpReviewManager);
            tCMain.Location = new Point(12, 3);
            tCMain.Name = "tCMain";
            tCMain.SelectedIndex = 0;
            tCMain.Size = new Size(856, 435);
            tCMain.TabIndex = 0;
            // 
            // tpMovieManager
            // 
            tpMovieManager.Controls.Add(label7);
            tpMovieManager.Controls.Add(lbMovieColletion);
            tpMovieManager.Controls.Add(label1);
            tpMovieManager.Controls.Add(tbSearchMovieTitle);
            tpMovieManager.Controls.Add(btnSearchMovie);
            tpMovieManager.Controls.Add(btnViewAllMovies);
            tpMovieManager.Controls.Add(btnUpdateMovie);
            tpMovieManager.Controls.Add(btnAddMovie);
            tpMovieManager.Location = new Point(4, 29);
            tpMovieManager.Name = "tpMovieManager";
            tpMovieManager.Padding = new Padding(3);
            tpMovieManager.Size = new Size(848, 402);
            tpMovieManager.TabIndex = 0;
            tpMovieManager.Text = "MovieManager";
            tpMovieManager.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(379, 12);
            label7.Name = "label7";
            label7.Size = new Size(121, 20);
            label7.TabIndex = 7;
            label7.Text = "Movie Collection";
            // 
            // lbMovieColletion
            // 
            lbMovieColletion.FormattingEnabled = true;
            lbMovieColletion.ItemHeight = 20;
            lbMovieColletion.Location = new Point(379, 35);
            lbMovieColletion.Name = "lbMovieColletion";
            lbMovieColletion.Size = new Size(445, 344);
            lbMovieColletion.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(127, 311);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 5;
            label1.Text = "Title";
            // 
            // tbSearchMovieTitle
            // 
            tbSearchMovieTitle.Location = new Point(36, 334);
            tbSearchMovieTitle.Name = "tbSearchMovieTitle";
            tbSearchMovieTitle.Size = new Size(215, 27);
            tbSearchMovieTitle.TabIndex = 4;
            // 
            // btnSearchMovie
            // 
            btnSearchMovie.Location = new Point(71, 248);
            btnSearchMovie.Name = "btnSearchMovie";
            btnSearchMovie.Size = new Size(149, 29);
            btnSearchMovie.TabIndex = 3;
            btnSearchMovie.Text = "Search Movie";
            btnSearchMovie.UseVisualStyleBackColor = true;
            // 
            // btnViewAllMovies
            // 
            btnViewAllMovies.Location = new Point(71, 181);
            btnViewAllMovies.Name = "btnViewAllMovies";
            btnViewAllMovies.Size = new Size(149, 29);
            btnViewAllMovies.TabIndex = 2;
            btnViewAllMovies.Text = "View All Movies";
            btnViewAllMovies.UseVisualStyleBackColor = true;
            // 
            // btnUpdateMovie
            // 
            btnUpdateMovie.Location = new Point(71, 110);
            btnUpdateMovie.Name = "btnUpdateMovie";
            btnUpdateMovie.Size = new Size(149, 29);
            btnUpdateMovie.TabIndex = 1;
            btnUpdateMovie.Text = "Update Movie";
            btnUpdateMovie.UseVisualStyleBackColor = true;
            btnUpdateMovie.Click += btnUpdateMovie_Click;
            // 
            // btnAddMovie
            // 
            btnAddMovie.Location = new Point(71, 45);
            btnAddMovie.Name = "btnAddMovie";
            btnAddMovie.Size = new Size(149, 29);
            btnAddMovie.TabIndex = 0;
            btnAddMovie.Text = "Add Movie";
            btnAddMovie.UseVisualStyleBackColor = true;
            btnAddMovie.Click += btnAddMovie_Click_1;
            // 
            // tpTvSeriesManager
            // 
            tpTvSeriesManager.Controls.Add(label6);
            tpTvSeriesManager.Controls.Add(lbTvSeriesCollection);
            tpTvSeriesManager.Controls.Add(label2);
            tpTvSeriesManager.Controls.Add(tbSearchTvSeriesTitle);
            tpTvSeriesManager.Controls.Add(btnSearchTvSeries);
            tpTvSeriesManager.Controls.Add(btnViewAllTvSeries);
            tpTvSeriesManager.Controls.Add(btnUpdateTvSeries);
            tpTvSeriesManager.Controls.Add(btnAddTvSeries);
            tpTvSeriesManager.Location = new Point(4, 29);
            tpTvSeriesManager.Name = "tpTvSeriesManager";
            tpTvSeriesManager.Padding = new Padding(3);
            tpTvSeriesManager.Size = new Size(848, 402);
            tpTvSeriesManager.TabIndex = 1;
            tpTvSeriesManager.Text = "TvSeriesManager";
            tpTvSeriesManager.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(373, 16);
            label6.Name = "label6";
            label6.Size = new Size(133, 20);
            label6.TabIndex = 14;
            label6.Text = "TvSeries Collection";
            // 
            // lbTvSeriesCollection
            // 
            lbTvSeriesCollection.FormattingEnabled = true;
            lbTvSeriesCollection.ItemHeight = 20;
            lbTvSeriesCollection.Location = new Point(373, 39);
            lbTvSeriesCollection.Name = "lbTvSeriesCollection";
            lbTvSeriesCollection.Size = new Size(445, 344);
            lbTvSeriesCollection.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(121, 315);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 12;
            label2.Text = "Title";
            // 
            // tbSearchTvSeriesTitle
            // 
            tbSearchTvSeriesTitle.Location = new Point(30, 338);
            tbSearchTvSeriesTitle.Name = "tbSearchTvSeriesTitle";
            tbSearchTvSeriesTitle.Size = new Size(215, 27);
            tbSearchTvSeriesTitle.TabIndex = 11;
            // 
            // btnSearchTvSeries
            // 
            btnSearchTvSeries.Location = new Point(65, 252);
            btnSearchTvSeries.Name = "btnSearchTvSeries";
            btnSearchTvSeries.Size = new Size(149, 29);
            btnSearchTvSeries.TabIndex = 10;
            btnSearchTvSeries.Text = "Search TvSeries";
            btnSearchTvSeries.UseVisualStyleBackColor = true;
            // 
            // btnViewAllTvSeries
            // 
            btnViewAllTvSeries.Location = new Point(65, 185);
            btnViewAllTvSeries.Name = "btnViewAllTvSeries";
            btnViewAllTvSeries.Size = new Size(149, 29);
            btnViewAllTvSeries.TabIndex = 9;
            btnViewAllTvSeries.Text = "View All TvSeries";
            btnViewAllTvSeries.UseVisualStyleBackColor = true;
            // 
            // btnUpdateTvSeries
            // 
            btnUpdateTvSeries.Location = new Point(65, 114);
            btnUpdateTvSeries.Name = "btnUpdateTvSeries";
            btnUpdateTvSeries.Size = new Size(149, 29);
            btnUpdateTvSeries.TabIndex = 8;
            btnUpdateTvSeries.Text = "Update TvSeries";
            btnUpdateTvSeries.UseVisualStyleBackColor = true;
            btnUpdateTvSeries.Click += btnUpdateTvSeries_Click;
            // 
            // btnAddTvSeries
            // 
            btnAddTvSeries.Location = new Point(65, 49);
            btnAddTvSeries.Name = "btnAddTvSeries";
            btnAddTvSeries.Size = new Size(149, 29);
            btnAddTvSeries.TabIndex = 7;
            btnAddTvSeries.Text = "Add TvSeries";
            btnAddTvSeries.UseVisualStyleBackColor = true;
            btnAddTvSeries.Click += btnAddTvSeries_Click;
            // 
            // tpReviewManager
            // 
            tpReviewManager.Controls.Add(label5);
            tpReviewManager.Controls.Add(label4);
            tpReviewManager.Controls.Add(lbMediaCollection);
            tpReviewManager.Controls.Add(lbReviewCollection);
            tpReviewManager.Controls.Add(label3);
            tpReviewManager.Controls.Add(tbSearchReviewTitle);
            tpReviewManager.Controls.Add(btnSearchReview);
            tpReviewManager.Controls.Add(btnViewAllReview);
            tpReviewManager.Controls.Add(btnUpdateReview);
            tpReviewManager.Controls.Add(btnAddReview);
            tpReviewManager.Location = new Point(4, 29);
            tpReviewManager.Name = "tpReviewManager";
            tpReviewManager.Padding = new Padding(3);
            tpReviewManager.Size = new Size(848, 402);
            tpReviewManager.TabIndex = 2;
            tpReviewManager.Text = "ReviewManager";
            tpReviewManager.UseVisualStyleBackColor = true;
            tpReviewManager.Click += MainForm_Load;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(379, 198);
            label5.Name = "label5";
            label5.Size = new Size(127, 20);
            label5.TabIndex = 23;
            label5.Text = "Review Collection";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(379, 4);
            label4.Name = "label4";
            label4.Size = new Size(122, 20);
            label4.TabIndex = 22;
            label4.Text = "Media Collection";
            // 
            // lbMediaCollection
            // 
            lbMediaCollection.FormattingEnabled = true;
            lbMediaCollection.ItemHeight = 20;
            lbMediaCollection.Location = new Point(378, 31);
            lbMediaCollection.Name = "lbMediaCollection";
            lbMediaCollection.Size = new Size(445, 164);
            lbMediaCollection.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(121, 315);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 19;
            label3.Text = "Title";
            // 
            // tbSearchReviewTitle
            // 
            tbSearchReviewTitle.Location = new Point(30, 338);
            tbSearchReviewTitle.Name = "tbSearchReviewTitle";
            tbSearchReviewTitle.Size = new Size(215, 27);
            tbSearchReviewTitle.TabIndex = 18;
            // 
            // btnSearchReview
            // 
            btnSearchReview.Location = new Point(65, 252);
            btnSearchReview.Name = "btnSearchReview";
            btnSearchReview.Size = new Size(149, 29);
            btnSearchReview.TabIndex = 17;
            btnSearchReview.Text = "Search Review";
            btnSearchReview.UseVisualStyleBackColor = true;
            // 
            // btnViewAllReview
            // 
            btnViewAllReview.Location = new Point(65, 185);
            btnViewAllReview.Name = "btnViewAllReview";
            btnViewAllReview.Size = new Size(149, 29);
            btnViewAllReview.TabIndex = 16;
            btnViewAllReview.Text = "View All Review";
            btnViewAllReview.UseVisualStyleBackColor = true;
            // 
            // btnUpdateReview
            // 
            btnUpdateReview.Location = new Point(65, 114);
            btnUpdateReview.Name = "btnUpdateReview";
            btnUpdateReview.Size = new Size(149, 29);
            btnUpdateReview.TabIndex = 15;
            btnUpdateReview.Text = "Update Review";
            btnUpdateReview.UseVisualStyleBackColor = true;
            btnUpdateReview.Click += btnUpdateReview_Click;
            // 
            // btnAddReview
            // 
            btnAddReview.Location = new Point(65, 49);
            btnAddReview.Name = "btnAddReview";
            btnAddReview.Size = new Size(149, 29);
            btnAddReview.TabIndex = 14;
            btnAddReview.Text = "Add Review";
            btnAddReview.UseVisualStyleBackColor = true;
            btnAddReview.Click += btnAddReview_Click;
            // 
            // lbReviewCollection
            // 
            lbReviewCollection.FormattingEnabled = true;
            lbReviewCollection.ItemHeight = 20;
            lbReviewCollection.Location = new Point(378, 232);
            lbReviewCollection.Name = "lbReviewCollection";
            lbReviewCollection.Size = new Size(445, 164);
            lbReviewCollection.TabIndex = 20;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 450);
            Controls.Add(tCMain);
            Name = "MainForm";
            Text = "Form1";
            tCMain.ResumeLayout(false);
            tpMovieManager.ResumeLayout(false);
            tpMovieManager.PerformLayout();
            tpTvSeriesManager.ResumeLayout(false);
            tpTvSeriesManager.PerformLayout();
            tpReviewManager.ResumeLayout(false);
            tpReviewManager.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tCMain;
        private TabPage tpMovieManager;
        private TabPage tpTvSeriesManager;
        private TabPage tpReviewManager;
        private Button btnAddMovie;
        private ListBox lbMovieColletion;
        private Label label1;
        private TextBox tbSearchMovieTitle;
        private Button btnSearchMovie;
        private Button btnViewAllMovies;
        private Button btnUpdateMovie;
        private ListBox lbTvSeriesCollection;
        private Label label2;
        private TextBox tbSearchTvSeriesTitle;
        private Button btnSearchTvSeries;
        private Button btnViewAllTvSeries;
        private Button btnUpdateTvSeries;
        private Button btnAddTvSeries;
        private Label label3;
        private TextBox tbSearchReviewTitle;
        private Button btnSearchReview;
        private Button btnViewAllReview;
        private Button btnUpdateReview;
        private Button btnAddReview;
        private Label label5;
        private Label label4;
        private ListBox lbMediaCollection;
        private Label label7;
        private Label label6;
        private ListBox lbReviewCollection;
    }
}