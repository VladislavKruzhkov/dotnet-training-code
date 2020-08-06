using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace M09ConsoleApp
{
    public class DataReceiver
    {
        public List<Student> DeserializeData(string dataPath)
        {
            var students = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(dataPath),
                Constants.DateFormat);

            if (students == null)
                throw new ArgumentNullException();

            return students;
        }
    }
}
