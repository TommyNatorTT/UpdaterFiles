using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdaterFiles;
using System.Text.Json;
using static UpdaterFiles.JsonReaderDB;

namespace TestMigrator
{
    public class JsonreaderTest
    {
     
        private DBInfo _fileInfowait = new DBInfo();
        private JsonreaderTestClass _jsonTesteClass;
        private JsonreaderTestClass _jsonTesteClassNull;

        [SetUp]
        public void Setup()
        {
            _fileInfowait.dbFileInfo.Add(new FileInfoMigrator("name","ciaoFileSorgente", "ciaoFileDestinazione"));

            string jsonString = JsonSerializer.Serialize(_fileInfowait);

            _jsonTesteClass = new JsonreaderTestClass(jsonString);
            _jsonTesteClassNull = new JsonreaderTestClass(null);
        }

        [Test]
        public void Test1()
        {
            var getInfo = _jsonTesteClass.GetFiles();
            Assert.IsTrue(getInfo.Count == 1);
        } 
        
        [Test]
        public void TestNull()
        {
            _fileInfowait.dbFileInfo = null;

            var getInfo = _jsonTesteClassNull.GetFiles();
            Assert.IsTrue(getInfo == null);
        }

        private class JsonreaderTestClass : JsonReaderDB
        {
            public JsonreaderTestClass(string s) : base(s)
            { }

            protected override void PopulateFiles()
            {

                if (_pathFile != null)
                {
                    _myDb = JsonSerializer.Deserialize<DBInfo>(_pathFile);
                }
            }
        }
    }
}