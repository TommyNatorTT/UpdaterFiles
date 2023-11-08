using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UpdaterFiles
{
    public class JsonReaderDB : IGetterInfoFiles
    {
        protected string _pathFile;
        protected DBInfo _myDb;

        public JsonReaderDB(string path) 
        { 
            _pathFile = path;
            PopulateFiles();
        }

        public List<FileInfoMigrator> GetFiles()
        {
            return _myDb?.dbFileInfo ?? null;
        }

        protected virtual void PopulateFiles()
        {
            if (File.Exists(_pathFile))
            {
                _myDb = (DBInfo)DeserializeClassFromJson<DBInfo>(File.ReadAllText(_pathFile));
            }      
        }

        private object DeserializeClassFromJson<Q>(string jsonstring)
        {
            object o = null;

            if (jsonstring != null)
            {
                //Here making network call with above json and getting correct response_josn
                try
                {
                    o = JsonConvert.DeserializeObject<Q>(jsonstring);
                }
                catch
                {

                    // to do..
                }
            }
            return o;
        }

        public class DBInfo
        {
            public DBInfo() 
            {
                dbFileInfo = new List<FileInfoMigrator>();
            }
            public List<FileInfoMigrator> dbFileInfo
            {
                get;

                set;
            }

        }

    }
}
