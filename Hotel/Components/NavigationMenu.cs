using Microsoft.AspNetCore.Mvc;

namespace Hotel.Components
{
    public class NavigationMenu:ViewComponent
    {
        public string Invoke()
        { return "Hello from the Nav View Component"; }
    }
}
