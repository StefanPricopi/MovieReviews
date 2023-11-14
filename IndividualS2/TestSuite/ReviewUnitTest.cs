using DALClassLibrary.DALs;
using ModelLibrary.DTO;
using System.Data;
using System.Reflection;

namespace TestSuite
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddArchiveReview()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);

            var reviewToAdd = new ReviewDTO
            {
                Id = 1,
                Title = "Test",
                Description = "Test",
                Score = 1,
                MediaID = 1,
                UserID = 1,
            };

            // Act
            bool isAdded = reviewDAL.AddArchiveReview(reviewToAdd);

            // Assert
            Assert.IsTrue(isAdded);
            Assert.IsTrue(reviewDAL.archiveReviews.ContainsKey(reviewToAdd.Id));
            Assert.AreEqual(reviewToAdd, reviewDAL.archiveReviews[reviewToAdd.Id]);
        }
        [TestMethod]
        public void TryDuplicateArchivedReview()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);

            var existingReview = new ReviewDTO
            {
                Id = 1,
                Title = "Test",
                Description = "Test",
                Score = 1,
                MediaID = 1,
                UserID = 1,
            };

            reviewDAL.AddArchiveReview(existingReview);

            // Act
            bool isAdded = reviewDAL.AddArchiveReview(existingReview);

            // Assert
            Assert.IsFalse(isAdded);
            Assert.IsTrue(reviewDAL.archiveReviews.ContainsKey(existingReview.Id));
            Assert.AreEqual(existingReview, reviewDAL.archiveReviews[existingReview.Id]);
        }
        [TestMethod]
        public void AddArchiveReviewNegativeID()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);

            var reviewWithNegativeId = new ReviewDTO
            {
                Id = -1,
                Title = "Negative ID Test",
                Description = "Negative ID Test",
                Score = 1,
                MediaID = 1,
                UserID = 1,
            };

            // Act
            bool isAdded = reviewDAL.AddArchiveReview(reviewWithNegativeId);

            // Assert
            Assert.IsFalse(isAdded);


            Assert.IsFalse(reviewDAL.archiveReviews.ContainsKey(reviewWithNegativeId.Id));
        }
        [TestMethod]
        public void AddArchiveReview0ID()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);

            var reviewWithNegativeId = new ReviewDTO
            {
                Id = 0,
                Title = "Negative ID Test",
                Description = "Negative ID Test",
                Score = 1,
                MediaID = 1,
                UserID = 1,
            };

            // Act
            bool isAdded = reviewDAL.AddArchiveReview(reviewWithNegativeId);

            // Assert
            Assert.IsFalse(isAdded);


            Assert.IsFalse(reviewDAL.archiveReviews.ContainsKey(reviewWithNegativeId.Id));
        }
        [TestMethod]
        public void AddArchiveReviewNull()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            ReviewDTO nullReview = null;
            int initialArchiveCount = reviewDAL.archiveReviews.Count;
            // Act
            bool isAdded = reviewDAL.AddArchiveReview(nullReview);
            // Assert
            Assert.IsFalse(isAdded);
            Assert.AreEqual(initialArchiveCount, reviewDAL.archiveReviews.Count);
        }
        [TestMethod]
        public void AddReview()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);

            var reviewToAdd = new ReviewDTO
            {
                Id = 1,
                Title = "Test",
                Description = "Test",
                Score = 1,
                MediaID = 1,
                UserID = 1,
            };

            // Act
            bool isAdded = reviewDAL.AddReview(reviewToAdd);

            // Assert
            Assert.IsTrue(isAdded);
            Assert.IsTrue(reviewDAL.reviews.ContainsKey(reviewToAdd.Id));
            Assert.AreEqual(reviewToAdd, reviewDAL.reviews[reviewToAdd.Id]);
        }
        [TestMethod]
        public void TryDuplicateReview()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);

            var existingReview = new ReviewDTO
            {
                Id = 1,
                Title = "Test",
                Description = "Test",
                Score = 1,
                MediaID = 1,
                UserID = 1,
            };

            reviewDAL.AddReview(existingReview);

            // Act
            bool isAdded = reviewDAL.AddReview(existingReview);

            // Assert
            Assert.IsFalse(isAdded);
            Assert.IsTrue(reviewDAL.reviews.ContainsKey(existingReview.Id));
            Assert.AreEqual(existingReview, reviewDAL.reviews[existingReview.Id]);
        }
        [TestMethod]
        public void AddReviewNegativeID()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);

            var reviewWithNegativeId = new ReviewDTO
            {
                Id = -1,
                Title = "Negative ID Test",
                Description = "Negative ID Test",
                Score = 1,
                MediaID = 1,
                UserID = 1,
            };

            // Act
            bool isAdded = reviewDAL.AddReview(reviewWithNegativeId);

            // Assert
            Assert.IsFalse(isAdded);


            Assert.IsFalse(reviewDAL.reviews.ContainsKey(reviewWithNegativeId.Id));
        }
        [TestMethod]
        public void AddReview0ID()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);


            var reviewWithNegativeId = new ReviewDTO
            {
                Id = 0,
                Title = "Negative ID Test",
                Description = "Negative ID Test",
                Score = 1,
                MediaID = 1,
                UserID = 1,
            };

            // Act
            bool isAdded = reviewDAL.AddReview(reviewWithNegativeId);

            // Assert
            Assert.IsFalse(isAdded);


            Assert.IsFalse(reviewDAL.reviews.ContainsKey(reviewWithNegativeId.Id));
        }
        [TestMethod]
        public void AddReviewNull()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            ReviewDTO nullReview = null;
            int initialArchiveCount = reviewDAL.archiveReviews.Count;
            // Act
            bool isAdded = reviewDAL.AddReview(nullReview);
            // Assert
            Assert.IsFalse(isAdded);
            Assert.AreEqual(initialArchiveCount, reviewDAL.reviews.Count);
        }
        [TestMethod]

        public void DeleteReviewByID()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>
        {
            { 1, new ReviewDTO { Id = 1, Title = "test",Description = "test",Score = 1,MediaID = 1,UserID = 1 } },
            { 2, new ReviewDTO { Id = 2, Title = "test2",Description = "test2",Score = 1,MediaID = 1,UserID = 1 } },

        };
            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            reviewDAL.reviews = reviewDictionary;

            int idToDelete = 1;

            // Act
            bool isDeleted = reviewDAL.DeleteReview(idToDelete);

            // Assert
            Assert.IsTrue(isDeleted);
            Assert.IsFalse(reviewDAL.reviews.ContainsKey(idToDelete));
        }
        [TestMethod]
        public void DeleteReviewByID0()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>
        {
            { 1, new ReviewDTO { Id = 1, Title = "test",Description = "test",Score = 1,MediaID = 1,UserID = 1 } },
            { 2, new ReviewDTO { Id = 2, Title = "test2",Description = "test2",Score = 1,MediaID = 1,UserID = 1 } },

        };
            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            reviewDAL.reviews = reviewDictionary;

            int idToDelete = 0;

            // Act
            bool isDeleted = reviewDAL.DeleteReview(idToDelete);

            // Assert
            Assert.IsFalse(isDeleted);
            Assert.IsFalse(reviewDAL.reviews.ContainsKey(idToDelete));
        }
        [TestMethod]
        public void DeleteReviewByIDThatDoesntExist()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>
        {
            { 1, new ReviewDTO { Id = 1, Title = "test",Description = "test",Score = 1,MediaID = 1,UserID = 1 } },
            { 2, new ReviewDTO { Id = 2, Title = "test2",Description = "test2",Score = 1,MediaID = 1,UserID = 1 } },

        };
            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            reviewDAL.reviews = reviewDictionary;

            int idToDelete = 3;

            // Act
            bool isDeleted = reviewDAL.DeleteReview(idToDelete);

            // Assert
            Assert.IsFalse(isDeleted);
            Assert.IsFalse(reviewDAL.reviews.ContainsKey(idToDelete));
        }
        [TestMethod]
        public void DeleteReviewWithNullId_ShouldNotAffectDictionary()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>
        {
             { 1, new ReviewDTO { Id = 1, Title = "test",Description = "test",Score = 1,MediaID = 1,UserID = 1 } },
             { 2, new ReviewDTO { Id = 2, Title = "test2",Description = "test2",Score = 1,MediaID = 1,UserID = 1 } }
        };
            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            reviewDAL.reviews = reviewDictionary;
            int? nullId = null;

            // Act
            bool isDeleted = reviewDAL.DeleteReview(nullId ?? 0);

            // Assert
            Assert.IsFalse(isDeleted);
            Assert.AreEqual(2, reviewDAL.reviews.Count);
        }
        [TestMethod]
        public void GetReviewByValidId()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>
        {
            { 1, new ReviewDTO { Id = 1, Title = "test",Description = "test",Score = 1,MediaID = 1,UserID = 1 } },
            { 2, new ReviewDTO { Id = 2, Title = "test2",Description = "test2",Score = 1,MediaID = 1,UserID = 1 } }
        };
            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            reviewDAL.reviews = reviewDictionary;
            int validId = 1;

            // Act
            ReviewDTO result = reviewDAL.GetActualReviewByMedia(validId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(validId, result.Id);
            Assert.AreEqual("test", result.Title);
            Assert.AreEqual("test", result.Description);
            Assert.AreEqual(1, result.Score);
            Assert.AreEqual(1, result.MediaID);
            Assert.AreEqual(1, result.UserID);

        }
        [TestMethod]
        public void GetReviewByValidId0()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>
        {
            { 1, new ReviewDTO { Id = 1, Title = "test",Description = "test",Score = 1,MediaID = 1,UserID = 1 } },
            { 2, new ReviewDTO { Id = 2, Title = "test2",Description = "test2",Score = 1,MediaID = 1,UserID = 1 } }
        };
            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            reviewDAL.reviews = reviewDictionary;
            int validId = 0;

            // Act
            ReviewDTO result = reviewDAL.GetActualReviewByMedia(validId);

            // Assert
            Assert.IsNull(result);


        }
        [TestMethod]
        public void GetReviewByValidIdThatDoesntExist()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>
        {
            { 1, new ReviewDTO { Id = 1, Title = "test",Description = "test",Score = 1,MediaID = 1,UserID = 1 } },
            { 2, new ReviewDTO { Id = 2, Title = "test2",Description = "test2",Score = 1,MediaID = 1,UserID = 1 } }
        };
            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            reviewDAL.reviews = reviewDictionary;
            int validId = 3;

            // Act
            ReviewDTO result = reviewDAL.GetActualReviewByMedia(validId);

            // Assert
            Assert.IsNull(result);


        }
        [TestMethod]
        public void GetAllArchivedReview()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>
    {
        { 1, new ReviewDTO { Id = 1, Title = "test1", Description = "desc1", Score = 1, MediaID = 1, UserID = 1 } },
        { 2, new ReviewDTO { Id = 2, Title = "test2", Description = "desc2", Score = 2, MediaID = 2, UserID = 2 } }

    };

            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            reviewDAL.archiveReviews = reviewDictionary;
            // Act
            DataTable result = reviewDAL.GetAllArchivedReview();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Rows.Count);
            Assert.AreEqual(1, result.Rows[0]["Id"]);
            Assert.AreEqual("test1", result.Rows[0]["Title"]);
            Assert.AreEqual("desc1", result.Rows[0]["Description"]);
            Assert.AreEqual(1, result.Rows[0]["Score"]);
            Assert.AreEqual(1, result.Rows[0]["MediaID"]);
            Assert.AreEqual(1, result.Rows[0]["UserID"]);
            Assert.AreEqual(2, result.Rows[1]["Id"]);
            Assert.AreEqual("test2", result.Rows[1]["Title"]);
            Assert.AreEqual("desc2", result.Rows[1]["Description"]);
            Assert.AreEqual(2, result.Rows[1]["Score"]);
            Assert.AreEqual(2, result.Rows[1]["MediaID"]);
            Assert.AreEqual(2, result.Rows[1]["UserID"]);

        }
        [TestMethod]
        public void GetAllArchivedReviewNoReviews()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            reviewDAL.archiveReviews = null;

            // Act
            DataTable result = reviewDAL.GetAllArchivedReview();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rows.Count);
        }
        [TestMethod]
        public void GetAllReview()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>
    {
        { 1, new ReviewDTO { Id = 1, Title = "test1", Description = "desc1", Score = 1, MediaID = 1, UserID = 1 } },
        { 2, new ReviewDTO { Id = 2, Title = "test2", Description = "desc2", Score = 2, MediaID = 2, UserID = 2 } }

    };

            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            reviewDAL.reviews = reviewDictionary; //

            // Act
            DataTable result = reviewDAL.GetAllReview();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Rows.Count);
            Assert.AreEqual(1, result.Rows[0]["Id"]);
            Assert.AreEqual("test1", result.Rows[0]["Title"]);
            Assert.AreEqual("desc1", result.Rows[0]["Description"]);
            Assert.AreEqual(1, result.Rows[0]["Score"]);
            Assert.AreEqual(1, result.Rows[0]["MediaID"]);
            Assert.AreEqual(1, result.Rows[0]["UserID"]);
            Assert.AreEqual(2, result.Rows[1]["Id"]);
            Assert.AreEqual("test2", result.Rows[1]["Title"]);
            Assert.AreEqual("desc2", result.Rows[1]["Description"]);
            Assert.AreEqual(2, result.Rows[1]["Score"]);
            Assert.AreEqual(2, result.Rows[1]["MediaID"]);
            Assert.AreEqual(2, result.Rows[1]["UserID"]);

        }
        [TestMethod]
        public void GetAllReviewNoReviews()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            reviewDAL.reviews = null;

            // Act
            DataTable result = reviewDAL.GetAllReview();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rows.Count);
        }
        [TestMethod]
        public void GetAllReviewTitles()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>
        {
            { 1, new ReviewDTO { Id = 1, Title = "test1", Description = "desc1", Score = 1, MediaID = 1, UserID = 1 } },
            { 2, new ReviewDTO { Id = 2, Title = "test2", Description = "desc2", Score = 2, MediaID = 2, UserID = 2 } },

        };

            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            reviewDAL.reviews = reviewDictionary;

            // Act
            List<string> titles = reviewDAL.GetAllReviewTitles();

            // Assert
            Assert.IsNotNull(titles);
            Assert.AreEqual(2, titles.Count);
            Assert.IsTrue(titles.Contains("test1"));
            Assert.IsTrue(titles.Contains("test2"));
        }
        [TestMethod]
        public void GetAllReviewTitlesEmptyDictionary()
        {
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            reviewDAL.reviews = reviewDictionary;

            // Act
            List<string> titles = reviewDAL.GetAllReviewTitles();

            // Assert
            Assert.IsNotNull(titles);
            Assert.AreEqual(0, titles.Count);
        }
        [TestMethod]
       
        public void GetAllReviewTitlesNullDict()
        {
            {
                // Arrange
                var reviewDAL = new TESTReviewDAL(null);
                reviewDAL.reviews = null; // Set the dictionary to null

                // Act
                List<string> titles = reviewDAL.GetAllReviewTitles();

                // Assert
                Assert.IsNotNull(titles);
                Assert.AreEqual(0, titles.Count);
            }
        }
        [TestMethod]
        public void GetReviewById()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>
        {
            { 1, new ReviewDTO { Id = 1, Title = "test1", Description = "desc1", Score = 1, MediaID = 1, UserID = 1 } },
            { 2, new ReviewDTO { Id = 2, Title = "test2", Description = "desc2", Score = 2, MediaID = 2, UserID = 2 } },
        
        };

            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            reviewDAL.reviews = reviewDictionary;

            int existingId = 1;

            // Act
            DataTable result = reviewDAL.GetReviewById(existingId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Rows.Count, "Expected a DataTable with a single review");
            Assert.AreEqual(1, result.Rows[0]["Id"]); 
            Assert.AreEqual("test1", result.Rows[0]["Title"]);
            Assert.AreEqual("desc1", result.Rows[0]["Description"]);
            Assert.AreEqual(1, result.Rows[0]["Score"]);
            Assert.AreEqual(1, result.Rows[0]["MediaID"]);
            Assert.AreEqual(1, result.Rows[0]["UserID"]);
        }
        [TestMethod]
        public void GetReviewByWrongID()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>
        {
           { 1, new ReviewDTO { Id = 1, Title = "test1", Description = "desc1", Score = 1, MediaID = 1, UserID = 1 } },
           { 2, new ReviewDTO { Id = 2, Title = "test2", Description = "desc2", Score = 2, MediaID = 2, UserID = 2 } },
        
        };

            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            reviewDAL.reviews = reviewDictionary;

            int nonExistingId = 3;

            // Act
            DataTable result = reviewDAL.GetReviewById(nonExistingId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rows.Count);
        }
        [TestMethod]
        
        public void GetReviewByMediaID()
        {
            // Arrange
            var reviewList = new List<ReviewDTO>
        {
            new ReviewDTO { Id = 1, Title = "Title 1",Description="desc",Score=1, MediaID = 1,UserID = 1 },
            new ReviewDTO { Id = 2, Title = "Title 2",Description="desc2",Score=7, MediaID = 2, UserID =1},
            new ReviewDTO { Id = 3, Title = "Title 3",Description="desc3",Score=8, MediaID = 1, UserID =2},
        
        };

            var reviewDAL = new TESTReviewDAL(null);
            reviewDAL.reviews = reviewList.ToDictionary(review => review.Id);

            int existingMediaId = 1;

            // Act
            DataTable result = reviewDAL.GetReviewByMedia(existingMediaId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Rows.Count);
            Assert.AreEqual(1, result.Rows[0]["Id"]);
            Assert.AreEqual("Title 1", result.Rows[0]["Title"]);
            Assert.AreEqual("desc", result.Rows[0]["Description"]);
            Assert.AreEqual(1, result.Rows[0]["Score"]);
            Assert.AreEqual(1, result.Rows[0]["MediaID"]);
            Assert.AreEqual(1, result.Rows[0]["UserID"]);
            Assert.AreEqual("Title 3", result.Rows[1]["Title"]);
            Assert.AreEqual("desc3", result.Rows[1]["Description"]);
            Assert.AreEqual(8, result.Rows[1]["Score"]);
            Assert.AreEqual(1, result.Rows[1]["MediaID"]);
            Assert.AreEqual(2, result.Rows[1]["UserID"]);
        }
        [TestMethod]
        public void GetReviewByInvalidMediaID()
        {
            // Arrange
            var reviewList = new List<ReviewDTO>
        {
            new ReviewDTO { Id = 1, Title = "Title 1",Description="desc",Score=1, MediaID = 1,UserID = 1 },
            new ReviewDTO { Id = 2, Title = "Title 2",Description="desc2",Score=7, MediaID = 2, UserID =1},

        };

            var reviewDAL = new TESTReviewDAL(null);
            reviewDAL.reviews = reviewList.ToDictionary(review => review.Id);
            
            int nonExistingMediaId = 3;

            // Act
            DataTable result = reviewDAL.GetReviewByMedia(nonExistingMediaId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rows.Count);
        }
        [TestMethod]
        public void GetReviewByTitle()
        {
            // Arrange
            var reviewList = new List<ReviewDTO>
        {
            new ReviewDTO { Id = 1, Title = "Title 1",Description="desc",Score=1, MediaID = 1,UserID = 1 },
            new ReviewDTO { Id = 2, Title = "Title 2",Description="desc2",Score=7, MediaID = 2, UserID =1},

        };

            var reviewDAL = new TESTReviewDAL(null);
            reviewDAL.reviews = reviewList.ToDictionary(review => review.Id);

            string existingTitle = "Title 1";

            // Act
            int result = reviewDAL.GetReviewByTitle(existingTitle);

            // Assert
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void GetReviewByTitle_NonExistingTitle_ShouldReturnNegativeOne()
        {
            // Arrange
            var reviewList = new List<ReviewDTO>
        {
            new ReviewDTO { Id = 1, Title = "Title 1",Description="desc",Score=1, MediaID = 1,UserID = 1 },
            new ReviewDTO { Id = 2, Title = "Title 2",Description="desc2",Score=7, MediaID = 2, UserID =1},

        };

            var reviewDAL = new TESTReviewDAL(null);
            reviewDAL.reviews = reviewList.ToDictionary(review => review.Id);

            string nonExistingTitle = "Non-existing Title";

            // Act
            int result = reviewDAL.GetReviewByTitle(nonExistingTitle);

            // Assert
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void UpdateReview_ExistingReview_ShouldReturnTrueAndUpdateReview()
        {
            // Arrange
            var reviewList = new List<ReviewDTO>
        {
            new ReviewDTO { Id = 1, Title = "Title 1",Description="desc",Score=1, MediaID = 1,UserID = 1 },
            new ReviewDTO { Id = 2, Title = "Title 2",Description="desc2",Score=7, MediaID = 2, UserID =1},

        };

            var reviewDAL = new TESTReviewDAL(null);
            reviewDAL.reviews = reviewList.ToDictionary(review => review.Id);

            ReviewDTO updatedReview = new ReviewDTO { Id = 1, Title = "Updated Title 1", Description = "desc23", Score = 9, MediaID = 1, UserID = 1 };

            // Act
            bool result = reviewDAL.UpdateReview(updatedReview);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual("Updated Title 1", reviewDAL.reviews[1].Title);
            Assert.AreEqual("desc23", reviewDAL.reviews[1].Description);
            Assert.AreEqual(9, reviewDAL.reviews[1].Score);
            Assert.AreEqual(1, reviewDAL.reviews[1].MediaID);
            Assert.AreEqual(1, reviewDAL.reviews[1].UserID);
        }
        [TestMethod]
        public void UpdateReviewByInvalidID()
        {
            // Arrange
            var reviewList = new List<ReviewDTO>
        {
            new ReviewDTO { Id = 1, Title = "Title 1",Description="desc",Score=1, MediaID = 1,UserID = 1 },
            new ReviewDTO { Id = 2, Title = "Title 2",Description="desc2",Score=7, MediaID = 2, UserID =1},

        };

            var reviewDAL = new TESTReviewDAL(null);
            reviewDAL.reviews = reviewList.ToDictionary(review => review.Id);

            ReviewDTO nonExistingReview = new ReviewDTO { Id = 3, Title = "New Title", Description = "desc23", Score = 9, MediaID = 1, UserID = 1 };

            // Act
            bool result = reviewDAL.UpdateReview(nonExistingReview);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(reviewDAL.reviews.ContainsKey(3));
        }
        [TestMethod]
        public void UpdateReviewByID0()
        {
            // Arrange
            var reviewList = new List<ReviewDTO>
        {
            new ReviewDTO { Id = 1, Title = "Title 1",Description="desc",Score=1, MediaID = 1,UserID = 1 },
            new ReviewDTO { Id = 2, Title = "Title 2",Description="desc2",Score=7, MediaID = 2, UserID =1},

        };

            var reviewDAL = new TESTReviewDAL(null);
            reviewDAL.reviews = reviewList.ToDictionary(review => review.Id);

            ReviewDTO nonExistingReview = new ReviewDTO { Id = 0, Title = "New Title", Description = "desc23", Score = 9, MediaID = 1, UserID = 1 };

            // Act
            bool result = reviewDAL.UpdateReview(nonExistingReview);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(reviewDAL.reviews.ContainsKey(0));
        }
        [TestMethod]
        public void ConvertToDataTable()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>
        {
            { 1, new ReviewDTO { Id = 1, Title = "Title 1", Description = "Desc 1", Score = 5, UserID = 123, MediaID = 456 } },
            { 2, new ReviewDTO { Id = 2, Title = "Title 2", Description = "Desc 2", Score = 4, UserID = 456, MediaID = 789 } },
        
        };
            var reviewDAL = new TESTReviewDAL(null);
            reviewDAL.reviews = reviewDictionary;

            // Act
            DataTable result = reviewDAL.ConvertToDataTable(reviewDAL.reviews);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Rows.Count);
            Assert.AreEqual(1, result.Rows[0]["Id"]);
            Assert.AreEqual("Title 1", result.Rows[0]["Title"]);
            Assert.AreEqual("Desc 1", result.Rows[0]["Description"]);
            Assert.AreEqual(5, result.Rows[0]["Score"]);
            Assert.AreEqual(123, result.Rows[0]["UserID"]);
            Assert.AreEqual(456, result.Rows[0]["MediaID"]);

            Assert.AreEqual(2, result.Rows[1]["Id"]);
            Assert.AreEqual("Title 2", result.Rows[1]["Title"]);
            Assert.AreEqual("Desc 2", result.Rows[1]["Description"]);
            Assert.AreEqual(4, result.Rows[1]["Score"]);
            Assert.AreEqual(456, result.Rows[1]["UserID"]);
            Assert.AreEqual(789, result.Rows[1]["MediaID"]);
        }
        [TestMethod]
        public void ConvertToDataTableNullDictionary()
        {
            // Arrange
            Dictionary<int, ReviewDTO> nullDictionary = null;
            var reviewDAL = new TESTReviewDAL(null);
            reviewDAL.reviews = nullDictionary;

            // Act
            DataTable result = reviewDAL.ConvertToDataTable(reviewDAL.reviews);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rows.Count);
        }
        [TestMethod]
        public void ConvertToDataTableEmptyDictionary()
        {
            // Arrange
            Dictionary<int, ReviewDTO> emptyDictionary = new Dictionary<int, ReviewDTO>();

            // Act
            var reviewDAL = new TESTReviewDAL(null);
            reviewDAL.reviews = emptyDictionary;
            DataTable result =reviewDAL.ConvertToDataTable(reviewDAL.reviews);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rows.Count);
        }
    }
}