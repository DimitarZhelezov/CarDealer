using Microsoft.AspNetCore.Mvc;

namespace CarDealersWeb.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ViewOrNotFound(this Controller controller, object model)
        {
            if (model == null)
            {
                return controller.NotFound();
            }
            else
            {
                return controller.View(model);
            }
        }
    }
}
