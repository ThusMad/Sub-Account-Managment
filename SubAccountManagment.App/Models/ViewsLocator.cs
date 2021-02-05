using System.Collections.Generic;
using System.Linq;

namespace SubAccountManagement.App.Models
{
    public static class ViewsLocator
    {
        public static readonly Stack<object> ViewsOrder;
        public static readonly List<object> Views;

        static ViewsLocator()
        {
            ViewsOrder = new Stack<object>();
        }

        public static void Push(object view)
        {
            ViewsOrder.Push(view);
        }

        public static object Pop()
        {
            return ViewsOrder.Pop();
        }
    }
}