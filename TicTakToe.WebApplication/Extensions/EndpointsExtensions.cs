namespace TicTakToe.WebApplication.Extensions
{
    internal static class EndpointsExtensions
    {
        public static void MapRoutes(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapDefaultRoute();
        }

        private static void MapDefaultRoute(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapControllerRoute("default", "api/{controller=Home}/{action=Index}/{id?}");
        }
    }
}
