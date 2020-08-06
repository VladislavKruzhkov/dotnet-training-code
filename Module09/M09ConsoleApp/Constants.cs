using System;
using Newtonsoft.Json.Converters;

namespace M09ConsoleApp
{
    public static class Constants
    {
        public static readonly string Path = Environment.CurrentDirectory + @"/../../../StudentData.json";

        public static readonly IsoDateTimeConverter DateFormat = new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" };

        public static readonly string DateTimeFormat = "dd/MM/yyyy";
    }
}
