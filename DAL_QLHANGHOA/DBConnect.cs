using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL_QLHANGHOA
{
    public class DBConnect
    {
        protected SqlConnection cnn=new SqlConnection(@"Data Source=DESKTOP-2BIAERK\SQLSERVER2012;Initial Catalog=DE4QLHANGHOA;Integrated Security=True");
    }
}
