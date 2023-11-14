using DALClassLibrary.DALs;
using LogicLayerClassLibrary.Enums;
using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSuite
{
    [TestClass]
    public class MediaUnitTest
    {
        [TestMethod]
        public void GetAllReviewTitles()
        {
            // Arrange
            var mediaDict = new Dictionary<int, MediaDTO>
            {
                { 1, new MediaDTO { Id = 1, Title = "test1", Description = "desc1", Actor="pan",Director="bla",Genre=Genre.Action } },
                { 2, new MediaDTO { Id = 1, Title = "test2", Description = "desc2", Actor="pan3",Director="bl3a",Genre=Genre.Action  } },

            };

            var mediaDAL = new TESTMediaDAL(mediaDict);
            mediaDAL.media = mediaDict;

            // Act
            List<string> titles = mediaDAL.GetAllTitles();

            // Assert
            Assert.IsNotNull(titles);
            Assert.AreEqual(2, titles.Count);
            Assert.IsTrue(titles.Contains("test1"));
            Assert.IsTrue(titles.Contains("test2"));
        }
        [TestMethod]
        public void GetAllReviewTitlesEmptyDictionary()
        {
            var mediaDict = new Dictionary<int, MediaDTO>();           
            var mediaDAL = new TESTMediaDAL(mediaDict);
            mediaDAL.media = mediaDict;

            // Act
            List<string> titles = mediaDAL.GetAllTitles();
            // Assert
            Assert.IsNotNull(titles);
            Assert.AreEqual(0, titles.Count);
        }
        [TestMethod]

        public void GetAllReviewTitlesNullDict()
        {
            {
                // Arrange
                var mediaDAL = new TESTMediaDAL(null);
                mediaDAL.media = null; 

                // Act
                List<string> titles = mediaDAL.GetAllTitles();

                // Assert
                Assert.IsNotNull(titles);
                Assert.AreEqual(0, titles.Count);
            }
        }
    }
}
