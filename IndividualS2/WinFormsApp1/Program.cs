using Autofac;
using DALClassLibrary.DALs;
using DALClassLibrary.Interfaces;
using Desktop_App.Forms;
using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
using Service_Layer.Interfaces_PL_to_LL;
using System.ComponentModel;
using System.Windows.Forms;

namespace WinFormsApp1
{
    internal static class Program
    {
        private static Autofac.IContainer Container { get; set; } 

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var builder = new ContainerBuilder();
            builder.RegisterType<ReviewDAL>().As<IReviewManagerDAL>();
            builder.RegisterType<MediaDAL>().As<IMediaManagerDAL>();
            builder.RegisterType<MovieDAL>().As<IMovieManagerDAL>();
            builder.RegisterType<TvSeriesDAL>().As<ITvSeriesManagerDAL>();
            builder.RegisterType<ReviewManager>().As<IReviewManager>();
            builder.RegisterType<MediaManager>().As<IMediaManager>();
            builder.RegisterType<TvSeriesManager>().As<ITvSeriesManager>();
            builder.RegisterType<MovieManager>().As<IMovieManager>();

            Container = builder.Build();

            var reviewManager = Container.Resolve<IReviewManager>();
            var mediaManager = Container.Resolve<IMediaManager>();
            var tvSeriesManager = Container.Resolve<ITvSeriesManager>();
            var movieManager = Container.Resolve<IMovieManager>();

            Application.Run(new Login(reviewManager, mediaManager, tvSeriesManager, movieManager));
        }
    }
}
