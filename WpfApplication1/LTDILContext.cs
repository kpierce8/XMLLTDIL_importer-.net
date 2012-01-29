using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace XMLImportLTDILWPF
{
    public class LTDILContext: DbContext
    {
        public DbSet<question> questions {get; set;}
    }
}
