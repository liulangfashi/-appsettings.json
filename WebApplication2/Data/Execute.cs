using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Data
{
    public class Execute
    {

       
        public DataSet ExecuteQuery(string sqrstr)
        {
            NpgsqlConnection SqlConn = new NpgsqlConnection(ConfigManager.Configuration["AppSettings:ConnectionString"]);
            DataSet ds = new DataSet();
            try
            {
                using (NpgsqlDataAdapter sqldap = new NpgsqlDataAdapter(sqrstr, SqlConn))
                {
                    sqldap.Fill(ds);
                }
                return ds;
            }
            catch (System.Exception ex)
            {
                SqlConn.Close();
                SqlConn.Dispose();
                return ds;
            }
        }

        public int ExecuteNonQuery(string sqrstr)
        {
            NpgsqlConnection SqlConn = new NpgsqlConnection(ConfigManager.Configuration["AppSettings:ConnectionString"]);
            try
            {
              
                SqlConn.Open();
                using (NpgsqlCommand SqlCommand = new NpgsqlCommand(sqrstr, SqlConn))
                {
                    int r = SqlCommand.ExecuteNonQuery();  //执行查询并返回受影响的行数
                    SqlConn.Close();
                    return r; //r如果是>0操作成功！ 
                }
            }
            catch (System.Exception ex)
            {
               SqlConn.Close();
                SqlConn.Dispose();
                return 0;
            }

        }
    }
}
