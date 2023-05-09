﻿namespace Watermeter.Project.API
{
    public static class EnviromentConfig
    {
        public class Hosts
        {
            public static readonly string MainDb = "Server=localhost;Port=5432;Database=WatermeterDB;User Id=postgres;Password=postgres;";
            public static readonly string Localhost = "https://localhost:7169";
        }
    }
}
