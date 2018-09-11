using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication_PracticeDAL.DAL
{
    public class T0001Dal:CommonDAL
    {
        public DataTable GetddlCity()
        {
            return Query("Select * from test");
        }
    }
}