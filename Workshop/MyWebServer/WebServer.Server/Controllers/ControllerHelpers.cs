﻿namespace WebServer.Server.Controllers
{
    using System;

    public static class ControllerHelpers
    {
        public static string GetControllerName(this Type type)
            => type.Name.Replace(nameof(Controller), string.Empty);
    }
}
