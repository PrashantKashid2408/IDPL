using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDPL.Core.Helper
{
    public class NavigationHelper
    {
        /// <summary>
        /// This method is help to find the which URL is active in navigation bar
        /// </summary>
        /// <param name="controller"> Supply the controller name </param>
        /// <param name="action"> Supply the action name </param>
        /// <param name="currentController"> Supply the current controller name </param>
        /// <param name="currentAction"> Supply the current action name </param>
        /// <returns></returns>
        public static string IsActive(string controller, string action, string currentController, string currentAction)
        {
            // Check for null values and return an empty string if any parameter is null
            if (controller == null || action == null || currentController == null || currentAction == null)
            {
                return "";
            }

            return controller.Equals(currentController, StringComparison.OrdinalIgnoreCase) &&
                action.Equals(currentAction, StringComparison.OrdinalIgnoreCase) ? "active" : "";
        }
    }
}