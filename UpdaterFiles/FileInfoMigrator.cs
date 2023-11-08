using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdaterFiles
{
    public class FileInfoMigrator
    {
        public FileInfoMigrator(string Name, string Source, string DestinationFolder) 
        {
            this.Name = Name;
            this.Source = Source;
            this.DestinationFolder = DestinationFolder;
        }
          
        public string Name
        { get; set; }   
        public string Source 
        {
            get;
            set;
        }        
        
        public string DestinationFolder 
        {
            get;
            set;
        }
    }
}
