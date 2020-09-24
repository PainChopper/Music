using System.Collections.Generic;
using System.IO;
using System.Linq;
using Music.Core;
using Music.Data;
using Newtonsoft.Json;

namespace Music.Service.SampleData
{
    public class DataGenerator
    {
        public static void LoadSampleData(MusicContext context, string fileJSON)
        {
            if(context.Musicians.Count() != 0)
                return;

            var json = File.ReadAllText(fileJSON);
            var root = JsonConvert.DeserializeObject<Root>(json);

            context.Musicians.AddRange(root.Musicians);
            context.SaveChanges();
        }

        #region ...

        private class Root
        {
            public List<Musician> Musicians { get; set; }
        }

        #endregion
    }
}
