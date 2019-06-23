using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;

namespace BlueBirdSystem.data
{
    class DB
    {
        public static IObjectContainer conn = Db4oFactory.OpenFile("db.yap");
    }
}