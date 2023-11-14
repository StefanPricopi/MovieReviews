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
    public class MovieUnitTest
    {
        [TestMethod]
        public void AddMovie()
        {
            // Arrange
            var media = new Dictionary<int, MediaDTO>();
            var movies = new Dictionary<int, MovieDTO>();

            var testMovieDAL = new TESTMovieDAL(media, movies);

            var validMediaDTO = new MediaDTO { Id = 1, Title="abra",Director="cadabra",Actor="jesu",Description="dtest",Genre=Genre.SF};
            var validMovieDTO = new MovieDTO { Id=1, Duration=120, Date = new DateTime(2003, 2, 12) };

            // Act
            bool result = testMovieDAL.AddMovie(validMediaDTO, validMovieDTO);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(testMovieDAL.media.ContainsKey(validMediaDTO.Id));
            Assert.AreEqual(validMediaDTO, testMovieDAL.media[validMediaDTO.Id]);
            Assert.IsTrue(testMovieDAL.movies.ContainsKey(validMediaDTO.Id));
            Assert.AreEqual(validMovieDTO, testMovieDAL.movies[validMediaDTO.Id]);
        }
        
    }
}
