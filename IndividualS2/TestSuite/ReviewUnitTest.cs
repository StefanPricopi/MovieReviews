using DALClassLibrary.DALs;
using LogicLayerClassLibrary.ManagerClasses;
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
            TESTReviewDAL reviewDAL = new TESTReviewDAL(reviewDictionary);
            ReviewManager reviewManager = new ReviewManager(reviewDAL);

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
            bool isAdded = reviewManager.AddArchiveReview(reviewToAdd);

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
            var reviewManager = new ReviewManager(reviewDAL);

            var existingReview = new ReviewDTO
            {
                Id = 1,
                Title = "Test",
                Description = "Test",
                Score = 1,
                MediaID = 1,
                UserID = 1,
            };

            reviewManager.AddArchiveReview(existingReview); 

            // Act
            bool isAdded = reviewManager.AddArchiveReview(existingReview); 

            // Assert
            Assert.IsFalse(isAdded);
            Assert.IsTrue(reviewDAL.archiveReviews.ContainsKey(existingReview.Id));
            Assert.AreEqual(existingReview, reviewDAL.archiveReviews[existingReview.Id]);
        }
        [TestMethod]
        
        public void TryAddReviewWithNegativeID_LogicLayer()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            var reviewManager = new ReviewManager(reviewDAL);

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
            bool isAdded = reviewManager.AddArchiveReview(reviewWithNegativeId);

            // Assert
            Assert.IsFalse(isAdded);
            Assert.IsFalse(reviewDAL.archiveReviews.ContainsKey(reviewWithNegativeId.Id)); 
        }

        [TestMethod]
        public void TryAddReviewWithIDZero_LogicLayer()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            var reviewManager = new ReviewManager(reviewDAL);

            var reviewWithZeroId = new ReviewDTO
            {
                Id = 0,
                Title = "ID Zero Test",
                Description = "ID Zero Test",
                Score = 1,
                MediaID = 1,
                UserID = 1,
            };

            // Act
            bool isAdded = reviewManager.AddArchiveReview(reviewWithZeroId);

            // Assert
            Assert.IsFalse(isAdded); 
            Assert.IsFalse(reviewDAL.archiveReviews.ContainsKey(reviewWithZeroId.Id)); 
        }

        [TestMethod]
        public void TryAddNullReview_LogicLayer()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            var reviewManager = new ReviewManager(reviewDAL);

            ReviewDTO nullReview = null;
            int initialArchiveCount = reviewDAL.archiveReviews.Count;

            // Act
            bool isAdded = reviewManager.AddArchiveReview(nullReview);

            // Assert
            Assert.IsFalse(isAdded); 
            Assert.AreEqual(initialArchiveCount, reviewDAL.archiveReviews.Count); 
        }

        [TestMethod]
        public void AddReview_LogicLayer()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            var reviewManager = new ReviewManager(reviewDAL);

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
            bool isAdded = reviewManager.AddReview(reviewToAdd);

            // Assert
            Assert.IsTrue(isAdded);
            Assert.IsTrue(reviewDAL.reviews.ContainsKey(reviewToAdd.Id)); 
            Assert.AreEqual(reviewToAdd, reviewDAL.reviews[reviewToAdd.Id]);
        }

        [TestMethod]
        public void TryDuplicateReview_LogicLayer()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            var reviewManager = new ReviewManager(reviewDAL);

            var existingReview = new ReviewDTO
            {
                Id = 1,
                Title = "Test",
                Description = "Test",
                Score = 1,
                MediaID = 1,
                UserID = 1,
            };

            reviewManager.AddReview(existingReview);

            // Act
            bool isAdded = reviewManager.AddReview(existingReview);

            // Assert
            Assert.IsFalse(isAdded); 
            Assert.IsTrue(reviewDAL.reviews.ContainsKey(existingReview.Id)); 
            Assert.AreEqual(existingReview, reviewDAL.reviews[existingReview.Id]); 
        }

        [TestMethod]
        public void AddReviewNegativeID_LogicLayer()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            var reviewManager = new ReviewManager(reviewDAL);

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
            bool isAdded = reviewManager.AddReview(reviewWithNegativeId);

            // Assert
            Assert.IsFalse(isAdded); 
            Assert.IsFalse(reviewDAL.reviews.ContainsKey(reviewWithNegativeId.Id)); 
        }

        [TestMethod]
        public void AddReview0ID_LogicLayer()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            var reviewManager = new ReviewManager(reviewDAL);

            var reviewWithZeroId = new ReviewDTO
            {
                Id = 0,
                Title = "ID Zero Test",
                Description = "ID Zero Test",
                Score = 1,
                MediaID = 1,
                UserID = 1,
            };

            // Act
            bool isAdded = reviewManager.AddReview(reviewWithZeroId);

            // Assert
            Assert.IsFalse(isAdded);
            Assert.IsFalse(reviewDAL.reviews.ContainsKey(reviewWithZeroId.Id)); 
        }

        [TestMethod]
        public void AddReviewNull_LogicLayer()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            var reviewManager = new ReviewManager(reviewDAL);

            ReviewDTO nullReview = null;
            int initialArchiveCount = reviewDAL.archiveReviews.Count;

            // Act
            bool isAdded = reviewManager.AddReview(nullReview);

            // Assert
            Assert.IsFalse(isAdded); 
            Assert.AreEqual(initialArchiveCount, reviewDAL.reviews.Count); 
        }

       

        [TestMethod]
        public void DeleteReviewByID0_LogicLayer()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>
    {
        { 1, new ReviewDTO { Id = 1, Title = "test", Description = "test", Score = 1, MediaID = 1, UserID = 1 } },
        { 2, new ReviewDTO { Id = 2, Title = "test2", Description = "test2", Score = 1, MediaID = 1, UserID = 1 } },
    };

            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            var reviewManager = new ReviewManager(reviewDAL);

            int idToDelete = 0;

            // Act
            bool isDeleted = reviewManager.DeleteReview(idToDelete);

            // Assert
            Assert.IsFalse(isDeleted);
            Assert.IsFalse(reviewDAL.reviews.ContainsKey(idToDelete)); 
        }

        [TestMethod]
        public void DeleteReviewByIDThatDoesntExist_LogicLayer()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>
        {
            { 1, new ReviewDTO { Id = 1, Title = "test", Description = "test", Score = 1, MediaID = 1, UserID = 1 } },
            { 2, new ReviewDTO { Id = 2, Title = "test2", Description = "test2", Score = 1, MediaID = 1, UserID = 1 } },
        };

            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            var reviewManager = new ReviewManager(reviewDAL);

            int idToDelete = 3;

            // Act
            bool isDeleted = reviewManager.DeleteReview(idToDelete);

            // Assert
            Assert.IsFalse(isDeleted); 
            Assert.IsFalse(reviewDAL.reviews.ContainsKey(idToDelete)); 
        }

       
        [TestMethod]
        public void GetReviewByValidId0_LogicLayer()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>
    {
        { 1, new ReviewDTO { Id = 1, Title = "test", Description = "test", Score = 1, MediaID = 1, UserID = 1 } },
        { 2, new ReviewDTO { Id = 2, Title = "test2", Description = "test2", Score = 1, MediaID = 1, UserID = 1 } }
    };

            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            var reviewManager = new ReviewManager(reviewDAL);

            int validId = 0;

            // Act
            ReviewDTO result = reviewManager.GetActualReviewByMedia(validId);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetReviewByValidIdThatDoesntExist_LogicLayer()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>
    {
        { 1, new ReviewDTO { Id = 1, Title = "test", Description = "test", Score = 1, MediaID = 1, UserID = 1 } },
        { 2, new ReviewDTO { Id = 2, Title = "test2", Description = "test2", Score = 1, MediaID = 1, UserID = 1 } }
    };

            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            var reviewManager = new ReviewManager(reviewDAL);

            int validId = 3;

            // Act
            ReviewDTO result = reviewManager.GetActualReviewByMedia(validId);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetAllArchivedReview_LogicLayer()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>
    {
        { 1, new ReviewDTO { Id = 1, Title = "test1", Description = "desc1", Score = 1, MediaID = 1, UserID = 1 } },
        { 2, new ReviewDTO { Id = 2, Title = "test2", Description = "desc2", Score = 2, MediaID = 2, UserID = 2 } }
    };

            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            var reviewManager = new ReviewManager(reviewDAL);
            reviewDAL.archiveReviews = reviewDictionary;

            // Act
            DataTable result = reviewManager.GetAllArchivedReview();

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
        public void GetAllArchivedReviewNoReviews_LogicLayer()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            var reviewManager = new ReviewManager(reviewDAL);
            reviewDAL.archiveReviews = null;

            // Act
            DataTable result = reviewManager.GetAllArchivedReview();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rows.Count);
        }

        [TestMethod]
        public void GetAllReview_LogicLayer()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>
    {
        { 1, new ReviewDTO { Id = 1, Title = "test1", Description = "desc1", Score = 1, MediaID = 1, UserID = 1 } },
        { 2, new ReviewDTO { Id = 2, Title = "test2", Description = "desc2", Score = 2, MediaID = 2, UserID = 2 } }
    };

            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            var reviewManager = new ReviewManager(reviewDAL);
            reviewDAL.reviews = reviewDictionary;

            // Act
            DataTable result = reviewManager.GetAllReview();

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
        public void GetAllReviewNoReviews_LogicLayer()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            var reviewManager = new ReviewManager(reviewDAL);
            reviewDAL.reviews = null;

            // Act
            DataTable result = reviewManager.GetAllReview();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rows.Count);
        }

        [TestMethod]
        public void GetAllReviewTitles_LogicLayer()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>
    {
        { 1, new ReviewDTO { Id = 1, Title = "test1", Description = "desc1", Score = 1, MediaID = 1, UserID = 1 } },
        { 2, new ReviewDTO { Id = 2, Title = "test2", Description = "desc2", Score = 2, MediaID = 2, UserID = 2 } }
    };

            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            var reviewManager = new ReviewManager(reviewDAL);
            reviewDAL.reviews = reviewDictionary;

            // Act
            List<string> titles = reviewManager.GetAllReviewTitles();

            // Assert
            Assert.IsNotNull(titles);
            Assert.AreEqual(2, titles.Count);
            Assert.IsTrue(titles.Contains("test1"));
            Assert.IsTrue(titles.Contains("test2"));
        }

        [TestMethod]
        public void GetAllReviewTitlesEmptyDictionary_LogicLayer()
        {
            var reviewDictionary = new Dictionary<int, ReviewDTO>();
            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            var reviewManager = new ReviewManager(reviewDAL);
            reviewDAL.reviews = reviewDictionary;

            // Act
            List<string> titles = reviewManager.GetAllReviewTitles();

            // Assert
            Assert.IsNotNull(titles);
            Assert.AreEqual(0, titles.Count);
        }

        [TestMethod]
        public void GetAllReviewTitlesNullDict_LogicLayer()
        {
            // Arrange
            var reviewDAL = new TESTReviewDAL(null);
            var reviewManager = new ReviewManager(reviewDAL);
            reviewDAL.reviews = null; // Set the dictionary to null

            // Act
            List<string> titles = reviewManager.GetAllReviewTitles();

            // Assert
            Assert.IsNotNull(titles);
            Assert.AreEqual(0, titles.Count);
        }

        [TestMethod]
        public void GetReviewById_LogicLayer()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>
    {
        { 1, new ReviewDTO { Id = 1, Title = "test1", Description = "desc1", Score = 1, MediaID = 1, UserID = 1 } },
        { 2, new ReviewDTO { Id = 2, Title = "test2", Description = "desc2", Score = 2, MediaID = 2, UserID = 2 } },
    };

            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            var reviewManager = new ReviewManager(reviewDAL);
            reviewDAL.reviews = reviewDictionary;

            int existingId = 1;

            // Act
            DataTable result = reviewManager.GetReviewByID(existingId);

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
        public void GetReviewByWrongID_LogicLayer()
        {
            // Arrange
            var reviewDictionary = new Dictionary<int, ReviewDTO>
    {
        { 1, new ReviewDTO { Id = 1, Title = "test1", Description = "desc1", Score = 1, MediaID = 1, UserID = 1 } },
        { 2, new ReviewDTO { Id = 2, Title = "test2", Description = "desc2", Score = 2, MediaID = 2, UserID = 2 } },
    };

            var reviewDAL = new TESTReviewDAL(reviewDictionary);
            var reviewManager = new ReviewManager(reviewDAL);
            reviewDAL.reviews = reviewDictionary;

            int nonExistingId = 3;

            // Act
            DataTable result = reviewManager.GetReviewByID(nonExistingId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rows.Count);
        }

        [TestMethod]
        public void GetReviewByMediaID_LogicLayer()
        {
            // Arrange
            var reviewList = new List<ReviewDTO>
        {
            new ReviewDTO { Id = 1, Title = "Title 1", Description = "desc", Score = 1, MediaID = 1, UserID = 1 },
            new ReviewDTO { Id = 2, Title = "Title 2", Description = "desc2", Score = 7, MediaID = 2, UserID = 1 },
            new ReviewDTO { Id = 3, Title = "Title 3", Description = "desc3", Score = 8, MediaID = 1, UserID = 2 },
        };

            var reviewDAL = new TESTReviewDAL(null);
            var reviewManager = new ReviewManager(reviewDAL);
            reviewDAL.reviews = reviewList.ToDictionary(review => review.Id);

            int existingMediaId = 1;

            // Act
            DataTable result = reviewManager.GetReviewByMedia(existingMediaId);

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
        public void GetReviewByInvalidMediaID_LogicLayer()
        {
            // Arrange
            var reviewList = new List<ReviewDTO>
        {
            new ReviewDTO { Id = 1, Title = "Title 1", Description = "desc", Score = 1, MediaID = 1, UserID = 1 },
            new ReviewDTO { Id = 2, Title = "Title 2", Description = "desc2", Score = 7, MediaID = 2, UserID = 1 },
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
        public void GetReviewByTitle_LogicLayer()
        {
            // Arrange
            var reviewList = new List<ReviewDTO>
        {
            new ReviewDTO { Id = 1, Title = "Title 1", Description = "desc", Score = 1, MediaID = 1, UserID = 1 },
            new ReviewDTO { Id = 2, Title = "Title 2", Description = "desc2", Score = 7, MediaID = 2, UserID = 1 },
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
        public void GetReviewByTitle_NonExistingTitle_ShouldReturnNegativeOne_LogicLayer()
        {
            // Arrange
            var reviewList = new List<ReviewDTO>
        {
            new ReviewDTO { Id = 1, Title = "Title 1", Description = "desc", Score = 1, MediaID = 1, UserID = 1 },
            new ReviewDTO { Id = 2, Title = "Title 2", Description = "desc2", Score = 7, MediaID = 2, UserID = 1 },
        };

            var reviewDAL = new TESTReviewDAL(null);
            reviewDAL.reviews = reviewList.ToDictionary(review => review.Id);

            string nonExistingTitle = "Non-existing Title";

            // Act
            int result = reviewDAL.GetReviewByTitle(nonExistingTitle);

            // Assert
            Assert.AreEqual(-1, result);
        }

    }
}