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
            components = new System.ComponentModel.Container();
            tCMain = new TabControl();
            tpMovieManager = new TabPage();
            cbMovieTitle = new ComboBox();
            dgvMovieCollection = new DataGridView();
            label7 = new Label();
            label1 = new Label();
            btnSearchMovie = new Button();
            btnViewAllMovies = new Button();
            btnUpdateMovie = new Button();
            btnAddMovie = new Button();
            tpTvSeriesManager = new TabPage();
            cbTvSeriesTitle = new ComboBox();
            dgvTvSeriesCollection = new DataGridView();
            label6 = new Label();
            label2 = new Label();
            btnSearchTvSeries = new Button();
            btnViewAllTvSeries = new Button();
            btnUpdateTvSeries = new Button();
            btnAddTvSeries = new Button();
            tpReviewManager = new TabPage();
            BtnViewArchivedReview = new Button();
            btnArchiveReview = new Button();
            btn_SearchReviewForAMedia = new Button();
            MediaTitleReviews = new Label();
            cb_MediaTitleReviews = new ComboBox();
            cbTitleReview = new ComboBox();
            dataGridViewReview = new DataGridView();
            label5 = new Label();
            label3 = new Label();
            btnSearchReview = new Button();
            btnViewAllReview = new Button();
            btnUpdateReview = new Button();
            btnAddReview = new Button();
            tabPage1 = new TabPage();
            reviewBindingSource = new BindingSource(components);
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            tCMain.SuspendLayout();
            tpMovieManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovieCollection).BeginInit();
            tpTvSeriesManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTvSeriesCollection).BeginInit();
            tpReviewManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reviewBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tCMain
            // 
            tCMain.Controls.Add(tpMovieManager);
            tCMain.Controls.Add(tpTvSeriesManager);
            tCMain.Controls.Add(tpReviewManager);
            tCMain.Controls.Add(tabPage1);
            tCMain.Location = new Point(10, 2);
            tCMain.Margin = new Padding(3, 2, 3, 2);
            tCMain.Name = "tCMain";
            tCMain.SelectedIndex = 0;
            tCMain.Size = new Size(1311, 548);
            tCMain.TabIndex = 0;
            // 
            // tpMovieManager
            // 
            tpMovieManager.Controls.Add(cbMovieTitle);
            tpMovieManager.Controls.Add(dgvMovieCollection);
            tpMovieManager.Controls.Add(label7);
            tpMovieManager.Controls.Add(label1);
            tpMovieManager.Controls.Add(btnSearchMovie);
            tpMovieManager.Controls.Add(btnViewAllMovies);
            tpMovieManager.Controls.Add(btnUpdateMovie);
            tpMovieManager.Controls.Add(btnAddMovie);
            tpMovieManager.Location = new Point(4, 24);
            tpMovieManager.Margin = new Padding(3, 2, 3, 2);
            tpMovieManager.Name = "tpMovieManager";
            tpMovieManager.Padding = new Padding(3, 2, 3, 2);
            tpMovieManager.Size = new Size(1303, 520);
            tpMovieManager.TabIndex = 0;
            tpMovieManager.Text = "MovieManager";
            tpMovieManager.UseVisualStyleBackColor = true;
            // 
            // cbMovieTitle
            // 
            cbMovieTitle.FormattingEnabled = true;
            cbMovieTitle.Location = new Point(62, 250);
            cbMovieTitle.Margin = new Padding(3, 2, 3, 2);
            cbMovieTitle.Name = "cbMovieTitle";
            cbMovieTitle.Size = new Size(133, 23);
            cbMovieTitle.TabIndex = 9;
            // 
            // dgvMovieCollection
            // 
            dgvMovieCollection.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovieCollection.Location = new Point(220, 42);
            dgvMovieCollection.Margin = new Padding(3, 2, 3, 2);
            dgvMovieCollection.Name = "dgvMovieCollection";
            dgvMovieCollection.RowHeadersWidth = 51;
            dgvMovieCollection.RowTemplate.Height = 29;
            dgvMovieCollection.Size = new Size(850, 448);
            dgvMovieCollection.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(332, 9);
            label7.Name = "label7";
            label7.Size = new Size(97, 15);
            label7.TabIndex = 7;
            label7.Text = "Movie Collection";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 233);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 5;
            label1.Text = "Title";
            // 
            // btnSearchMovie
            // 
            btnSearchMovie.Location = new Point(62, 186);
            btnSearchMovie.Margin = new Padding(3, 2, 3, 2);
            btnSearchMovie.Name = "btnSearchMovie";
            btnSearchMovie.Size = new Size(130, 22);
            btnSearchMovie.TabIndex = 3;
            btnSearchMovie.Text = "Search Movie";
            btnSearchMovie.UseVisualStyleBackColor = true;
            btnSearchMovie.Click += btnSearchMovie_Click;
            // 
            // btnViewAllMovies
            // 
            btnViewAllMovies.Location = new Point(62, 136);
            btnViewAllMovies.Margin = new Padding(3, 2, 3, 2);
            btnViewAllMovies.Name = "btnViewAllMovies";
            btnViewAllMovies.Size = new Size(130, 22);
            btnViewAllMovies.TabIndex = 2;
            btnViewAllMovies.Text = "View All Movies";
            btnViewAllMovies.UseVisualStyleBackColor = true;
            btnViewAllMovies.Click += btnViewAllMovies_Click;
            // 
            // btnUpdateMovie
            // 
            btnUpdateMovie.Location = new Point(62, 82);
            btnUpdateMovie.Margin = new Padding(3, 2, 3, 2);
            btnUpdateMovie.Name = "btnUpdateMovie";
            btnUpdateMovie.Size = new Size(130, 22);
            btnUpdateMovie.TabIndex = 1;
            btnUpdateMovie.Text = "Update Movie";
            btnUpdateMovie.UseVisualStyleBackColor = true;
            btnUpdateMovie.Click += btnUpdateMovie_Click;
            // 
            // btnAddMovie
            // 
            btnAddMovie.Location = new Point(62, 34);
            btnAddMovie.Margin = new Padding(3, 2, 3, 2);
            btnAddMovie.Name = "btnAddMovie";
            btnAddMovie.Size = new Size(130, 22);
            btnAddMovie.TabIndex = 0;
            btnAddMovie.Text = "Add Movie";
            btnAddMovie.UseVisualStyleBackColor = true;
            btnAddMovie.Click += btnAddMovie_Click_1;
            // 
            // tpTvSeriesManager
            // 
            tpTvSeriesManager.Controls.Add(cbTvSeriesTitle);
            tpTvSeriesManager.Controls.Add(dgvTvSeriesCollection);
            tpTvSeriesManager.Controls.Add(label6);
            tpTvSeriesManager.Controls.Add(label2);
            tpTvSeriesManager.Controls.Add(btnSearchTvSeries);
            tpTvSeriesManager.Controls.Add(btnViewAllTvSeries);
            tpTvSeriesManager.Controls.Add(btnUpdateTvSeries);
            tpTvSeriesManager.Controls.Add(btnAddTvSeries);
            tpTvSeriesManager.Location = new Point(4, 24);
            tpTvSeriesManager.Margin = new Padding(3, 2, 3, 2);
            tpTvSeriesManager.Name = "tpTvSeriesManager";
            tpTvSeriesManager.Padding = new Padding(3, 2, 3, 2);
            tpTvSeriesManager.Size = new Size(1303, 520);
            tpTvSeriesManager.TabIndex = 1;
            tpTvSeriesManager.Text = "TvSeriesManager";
            tpTvSeriesManager.UseVisualStyleBackColor = true;
            // 
            // cbTvSeriesTitle
            // 
            cbTvSeriesTitle.FormattingEnabled = true;
            cbTvSeriesTitle.Location = new Point(57, 254);
            cbTvSeriesTitle.Margin = new Padding(3, 2, 3, 2);
            cbTvSeriesTitle.Name = "cbTvSeriesTitle";
            cbTvSeriesTitle.Size = new Size(140, 23);
            cbTvSeriesTitle.TabIndex = 16;
            // 
            // dgvTvSeriesCollection
            // 
            dgvTvSeriesCollection.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTvSeriesCollection.Location = new Point(276, 55);
            dgvTvSeriesCollection.Margin = new Padding(3, 2, 3, 2);
            dgvTvSeriesCollection.Name = "dgvTvSeriesCollection";
            dgvTvSeriesCollection.RowHeadersWidth = 51;
            dgvTvSeriesCollection.RowTemplate.Height = 29;
            dgvTvSeriesCollection.Size = new Size(966, 410);
            dgvTvSeriesCollection.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(276, 25);
            label6.Name = "label6";
            label6.Size = new Size(105, 15);
            label6.TabIndex = 14;
            label6.Text = "TvSeries Collection";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(106, 236);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 12;
            label2.Text = "Title";
            // 
            // btnSearchTvSeries
            // 
            btnSearchTvSeries.Location = new Point(57, 189);
            btnSearchTvSeries.Margin = new Padding(3, 2, 3, 2);
            btnSearchTvSeries.Name = "btnSearchTvSeries";
            btnSearchTvSeries.Size = new Size(130, 22);
            btnSearchTvSeries.TabIndex = 10;
            btnSearchTvSeries.Text = "Search TvSeries";
            btnSearchTvSeries.UseVisualStyleBackColor = true;
            btnSearchTvSeries.Click += btnSearchTvSeries_Click;
            // 
            // btnViewAllTvSeries
            // 
            btnViewAllTvSeries.Location = new Point(57, 139);
            btnViewAllTvSeries.Margin = new Padding(3, 2, 3, 2);
            btnViewAllTvSeries.Name = "btnViewAllTvSeries";
            btnViewAllTvSeries.Size = new Size(130, 22);
            btnViewAllTvSeries.TabIndex = 9;
            btnViewAllTvSeries.Text = "View All TvSeries";
            btnViewAllTvSeries.UseVisualStyleBackColor = true;
            btnViewAllTvSeries.Click += btnViewAllTvSeries_Click;
            // 
            // btnUpdateTvSeries
            // 
            btnUpdateTvSeries.Location = new Point(57, 86);
            btnUpdateTvSeries.Margin = new Padding(3, 2, 3, 2);
            btnUpdateTvSeries.Name = "btnUpdateTvSeries";
            btnUpdateTvSeries.Size = new Size(130, 22);
            btnUpdateTvSeries.TabIndex = 8;
            btnUpdateTvSeries.Text = "Update TvSeries";
            btnUpdateTvSeries.UseVisualStyleBackColor = true;
            btnUpdateTvSeries.Click += btnUpdateTvSeries_Click;
            // 
            // btnAddTvSeries
            // 
            btnAddTvSeries.Location = new Point(57, 37);
            btnAddTvSeries.Margin = new Padding(3, 2, 3, 2);
            btnAddTvSeries.Name = "btnAddTvSeries";
            btnAddTvSeries.Size = new Size(130, 22);
            btnAddTvSeries.TabIndex = 7;
            btnAddTvSeries.Text = "Add TvSeries";
            btnAddTvSeries.UseVisualStyleBackColor = true;
            btnAddTvSeries.Click += btnAddTvSeries_Click;
            // 
            // tpReviewManager
            // 
            tpReviewManager.Controls.Add(BtnViewArchivedReview);
            tpReviewManager.Controls.Add(btnArchiveReview);
            tpReviewManager.Controls.Add(btn_SearchReviewForAMedia);
            tpReviewManager.Controls.Add(MediaTitleReviews);
            tpReviewManager.Controls.Add(cb_MediaTitleReviews);
            tpReviewManager.Controls.Add(cbTitleReview);
            tpReviewManager.Controls.Add(dataGridViewReview);
            tpReviewManager.Controls.Add(label5);
            tpReviewManager.Controls.Add(label3);
            tpReviewManager.Controls.Add(btnSearchReview);
            tpReviewManager.Controls.Add(btnViewAllReview);
            tpReviewManager.Controls.Add(btnUpdateReview);
            tpReviewManager.Controls.Add(btnAddReview);
            tpReviewManager.Location = new Point(4, 24);
            tpReviewManager.Margin = new Padding(3, 2, 3, 2);
            tpReviewManager.Name = "tpReviewManager";
            tpReviewManager.Padding = new Padding(3, 2, 3, 2);
            tpReviewManager.Size = new Size(1303, 520);
            tpReviewManager.TabIndex = 2;
            tpReviewManager.Text = "ReviewManager";
            tpReviewManager.UseVisualStyleBackColor = true;
            // 
            // BtnViewArchivedReview
            // 
            BtnViewArchivedReview.Location = new Point(61, 466);
            BtnViewArchivedReview.Margin = new Padding(3, 2, 3, 2);
            BtnViewArchivedReview.Name = "BtnViewArchivedReview";
            BtnViewArchivedReview.Size = new Size(118, 32);
            BtnViewArchivedReview.TabIndex = 30;
            BtnViewArchivedReview.Text = "View Archived reviews";
            BtnViewArchivedReview.UseVisualStyleBackColor = true;
            BtnViewArchivedReview.Click += BtnViewArchivedReview_Click;
            // 
            // btnArchiveReview
            // 
            btnArchiveReview.Location = new Point(61, 414);
            btnArchiveReview.Margin = new Padding(3, 2, 3, 2);
            btnArchiveReview.Name = "btnArchiveReview";
            btnArchiveReview.Size = new Size(118, 37);
            btnArchiveReview.TabIndex = 29;
            btnArchiveReview.Text = "Archive Review";
            btnArchiveReview.UseVisualStyleBackColor = true;
            btnArchiveReview.Click += btnArchiveReview_Click;
            // 
            // btn_SearchReviewForAMedia
            // 
            btn_SearchReviewForAMedia.Location = new Point(25, 346);
            btn_SearchReviewForAMedia.Margin = new Padding(3, 2, 3, 2);
            btn_SearchReviewForAMedia.Name = "btn_SearchReviewForAMedia";
            btn_SearchReviewForAMedia.Size = new Size(174, 40);
            btn_SearchReviewForAMedia.TabIndex = 28;
            btn_SearchReviewForAMedia.Text = "Search all reviews for a specific media";
            btn_SearchReviewForAMedia.UseVisualStyleBackColor = true;
            btn_SearchReviewForAMedia.Click += btn_SearchReviewForAMedia_Click;
            // 
            // MediaTitleReviews
            // 
            MediaTitleReviews.AutoSize = true;
            MediaTitleReviews.Location = new Point(71, 268);
            MediaTitleReviews.Name = "MediaTitleReviews";
            MediaTitleReviews.Size = new Size(65, 15);
            MediaTitleReviews.TabIndex = 27;
            MediaTitleReviews.Text = "Media Title";
            // 
            // cb_MediaTitleReviews
            // 
            cb_MediaTitleReviews.FormattingEnabled = true;
            cb_MediaTitleReviews.Location = new Point(57, 286);
            cb_MediaTitleReviews.Margin = new Padding(3, 2, 3, 2);
            cb_MediaTitleReviews.Name = "cb_MediaTitleReviews";
            cb_MediaTitleReviews.Size = new Size(133, 23);
            cb_MediaTitleReviews.TabIndex = 26;
            // 
            // cbTitleReview
            // 
            cbTitleReview.FormattingEnabled = true;
            cbTitleReview.Location = new Point(57, 224);
            cbTitleReview.Margin = new Padding(3, 2, 3, 2);
            cbTitleReview.Name = "cbTitleReview";
            cbTitleReview.Size = new Size(133, 23);
            cbTitleReview.TabIndex = 25;
            // 
            // dataGridViewReview
            // 
            dataGridViewReview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReview.Location = new Point(226, 55);
            dataGridViewReview.Name = "dataGridViewReview";
            dataGridViewReview.RowHeadersWidth = 51;
            dataGridViewReview.RowTemplate.Height = 25;
            dataGridViewReview.Size = new Size(1007, 443);
            dataGridViewReview.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(327, 37);
            label5.Name = "label5";
            label5.Size = new Size(101, 15);
            label5.TabIndex = 23;
            label5.Text = "Review Collection";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(67, 207);
            label3.Name = "label3";
            label3.Size = new Size(100, 15);
            label3.TabIndex = 19;
            label3.Text = "Title of the review";
            // 
            // btnSearchReview
            // 
            btnSearchReview.Location = new Point(57, 166);
            btnSearchReview.Margin = new Padding(3, 2, 3, 2);
            btnSearchReview.Name = "btnSearchReview";
            btnSearchReview.Size = new Size(130, 22);
            btnSearchReview.TabIndex = 17;
            btnSearchReview.Text = "Search Review";
            btnSearchReview.UseVisualStyleBackColor = true;
            btnSearchReview.Click += btnSearchReview_Click;
            // 
            // btnViewAllReview
            // 
            btnViewAllReview.Location = new Point(57, 125);
            btnViewAllReview.Margin = new Padding(3, 2, 3, 2);
            btnViewAllReview.Name = "btnViewAllReview";
            btnViewAllReview.Size = new Size(130, 22);
            btnViewAllReview.TabIndex = 16;
            btnViewAllReview.Text = "View All Review";
            btnViewAllReview.UseVisualStyleBackColor = true;
            btnViewAllReview.Click += btnViewAllReview_Click;
            // 
            // btnUpdateReview
            // 
            btnUpdateReview.Location = new Point(57, 86);
            btnUpdateReview.Margin = new Padding(3, 2, 3, 2);
            btnUpdateReview.Name = "btnUpdateReview";
            btnUpdateReview.Size = new Size(130, 22);
            btnUpdateReview.TabIndex = 15;
            btnUpdateReview.Text = "Update Review";
            btnUpdateReview.UseVisualStyleBackColor = true;
            btnUpdateReview.Click += btnUpdateReview_Click;
            // 
            // btnAddReview
            // 
            btnAddReview.Location = new Point(57, 37);
            btnAddReview.Margin = new Padding(3, 2, 3, 2);
            btnAddReview.Name = "btnAddReview";
            btnAddReview.Size = new Size(130, 22);
            btnAddReview.TabIndex = 14;
            btnAddReview.Text = "Add Review";
            btnAddReview.UseVisualStyleBackColor = true;
            btnAddReview.Click += btnAddReview_Click;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(1303, 520);
            tabPage1.TabIndex = 3;
            tabPage1.Text = "Statistics";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // reviewBindingSource
            // 
            reviewBindingSource.DataSource = typeof(LogicLayerClassLibrary.Classes.Review);
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1333, 572);
            Controls.Add(tCMain);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "Form1";
            tCMain.ResumeLayout(false);
            tpMovieManager.ResumeLayout(false);
            tpMovieManager.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovieCollection).EndInit();
            tpTvSeriesManager.ResumeLayout(false);
            tpTvSeriesManager.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTvSeriesCollection).EndInit();
            tpReviewManager.ResumeLayout(false);
            tpReviewManager.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReview).EndInit();
            ((System.ComponentModel.ISupportInitialize)reviewBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tCMain;
        private TabPage tpMovieManager;
        private TabPage tpTvSeriesManager;
        private TabPage tpReviewManager;
        private Button btnAddMovie;
        private Label label1;
        private Button btnSearchMovie;
        private Button btnViewAllMovies;
        private Button btnUpdateMovie;
        private Label label2;
        private Button btnSearchTvSeries;
        private Button btnViewAllTvSeries;
        private Button btnUpdateTvSeries;
        private Button btnAddTvSeries;
        private Label label3;
        private Button btnSearchReview;
        private Button btnViewAllReview;
        private Button btnUpdateReview;
        private Button btnAddReview;
        private Label label5;
        private Label label7;
        private Label label6;
        private BindingSource reviewBindingSource;
        private DataGridView dataGridViewReview;
        private DataGridView dgvMovieCollection;
        private DataGridView dgvTvSeriesCollection;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private ComboBox cbMovieTitle;
        private ComboBox cbTvSeriesTitle;
        private Button btn_SearchReviewForAMedia;
        private Label MediaTitleReviews;
        private ComboBox cb_MediaTitleReviews;
        private ComboBox cbTitleReview;
        private Button btnArchiveReview;
        private Button BtnViewArchivedReview;
        private TabPage tabPage1;
    }
}