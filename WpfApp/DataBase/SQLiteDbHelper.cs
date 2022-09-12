using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace WpfApp.DataBase
{
    /// <summary>
    /// SQLite数据库帮助类
    /// </summary>
    public class SQLiteDbHelper
    {
        /// <summary>
        /// 链接套接字
        /// </summary>
        private static SQLiteConnection m_dbConnection { get; set; }

        /// <summary>
        /// 创建连接字符串
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        private static string CreateConnectionString(string db)
        {
            SQLiteConnectionStringBuilder connectionStr = new SQLiteConnectionStringBuilder();
            connectionStr.DataSource = @"data/" + db; //此处文件名可以使用变量表示
            string conStr = connectionStr.ToString();

            return conStr;
        }

        /// <summary>
        /// 链接到数据库
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static SQLiteConnection dbConnection(string db)
        {
            m_dbConnection = new SQLiteConnection(CreateConnectionString(db));
            m_dbConnection.Open();

            return m_dbConnection;
        }

        /// <summary>
        /// 创建数据库文件
        /// </summary>
        /// <param name="fileName"></param>
        public static string CreateDBFile(string fileName)
        {
            string path = Environment.CurrentDirectory + @"\data\";
            string dataBaseFileName = path+fileName;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(dataBaseFileName))
            {
                SQLiteConnection.CreateFile(dataBaseFileName);
                return $"成功创建数据库{dataBaseFileName}";
            }
            else
            {
                return $"操作失败，已存在数据库{dataBaseFileName}";
            }
        }

        /// <summary>
        /// 在指定数据库中创建一个table
        /// </summary>
        /// 如：create table myTable(ID INT PRIMARY KEY NOT NULL,TEXT TEXT NOT NULL);
        /// <param name="db"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool CreateTable(string db, string sql)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection(db));
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ExecuteNonQuery({sql})Err:{ex}");
                return false;
            }
            finally
            {
                closeConn();
            }
        }

        /// <summary>
        /// 返回查询记录集
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sql"></param>
        /// <returns>返回查询结果集</returns>
        public static DataTable SqlTable(string db, string sql)
        {
            try
            {
                SQLiteCommand sqlCmd = new SQLiteCommand(sql, dbConnection(db)); //sql语句
                sqlCmd.CommandTimeout = 120;
                SQLiteDataReader reader = sqlCmd.ExecuteReader();
                DataTable dt = new DataTable();
                if (reader != null)
                {
                    dt.Load(reader, LoadOption.PreserveChanges, null);
                }

                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"sqlReader({sql})Err:{ex}");
                return null;
            }
            finally
            {
                closeConn();
            }
        }

        /// <summary>
        /// 执行增删改查操作
        /// </summary>
        /// <param name="db">数据库</param>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public static int ExcuteNonQuery(string db, string sql)
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, dbConnection(db));
                cmd.ExecuteNonQuery().ToString();
                return 1;
            }
            catch (Exception ex)
            {
                string exInfo = $"ExecuteNonQuery({sql})Err:{ex.Message}";
                string dateInfo = $"出现应用程序未处理异常：{DateTime.Now}\r\n";
                string str = $"{dateInfo}异常类型：{ex.GetType().Name}\r\n异常消息：{ex.Message}异常消息：{ex.StackTrace}";
                WriteLog(str);
                return 0;
            }
            finally
            {
                closeConn();
            }
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="str"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void WriteLog(string str)
        {
            if (!Directory.Exists("ErrorLog"))
            {
                Directory.CreateDirectory("ErrorLog");
            }
            string createTime = DateTime.Now.ToString("yyyy-MM");
            using (var sw = new StringWriter(new StringBuilder($"ErrorLog\\{createTime}.txt")))
            {
                sw.WriteLine(str);
                sw.WriteLine("--------------------------------------------------");
                sw.Close();
            }
        }

        /// <summary>
        /// 删除数据库
        /// </summary>
        /// <param name="fileName">文件名</param>
        public static bool DeleteDbFile(string fileName)
        {
            string path = Environment.CurrentDirectory + @"\\data\\" + fileName;
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 在指定数据库中删除一个table
        /// </summary>
        /// <param name="db"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static bool DeleteTable(string db, string tableName)
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand($"DROP TABLE IF EXISTS {tableName}", dbConnection(db));
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ExecuteNonQuery(DROP TABLE IF EXISTS {tableName})Err:{ex}");
                return false;
            }
            finally
            {
                closeConn();
            }
        }

        /// <summary>
        /// 返回一条查询记录
        /// </summary>
        /// <param name="db">数据库</param>
        /// <param name="sql">sql查询语句</param>
        /// <returns>返回字符串数组</returns>
        public static List<string> SqlRow(string db, string sql)
        {
            try
            {
                SQLiteCommand sqlCmd = new SQLiteCommand(sql, dbConnection(db)); //sql语句
                SQLiteDataReader reader = sqlCmd.ExecuteReader();
                if (!reader.Read())
                {
                    return null;
                }
                List<string> row = new List<string>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row.Add(reader[i].ToString());
                }
                reader.Close();
                return row;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SqlRow({sql})Err:{ex}");
                throw;
            }
            finally
            {
                closeConn();
            }
        }

        /// <summary>
        /// 在指定表中添加列
        /// </summary>
        /// <param name="db">数据库</param>
        /// <param name="tableName">表名</param>
        /// <param name="columnName">列名</param>
        /// <param name="cType">列的数值类型</param>
        /// <returns></returns>
        public static bool AddColumn(string db,string tableName,string columnName,string cType)
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand($"ALTER TABLE {tableName} ADD COLUMN {columnName} {cType}");
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ExecuteNonQuery(ALTER TABLE {tableName} ADD COLUMN {columnName} {cType})Err:{ex}");
                return false;
            }
            finally
            {
                closeConn();
            }
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private static void closeConn()
        {
            try
            {
                if (m_dbConnection.State == ConnectionState.Open)
                {
                    m_dbConnection.Close();
                }
                else if (m_dbConnection.State == ConnectionState.Broken)
                {
                    m_dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"closeConnErr:{ex}");
            }
        }
    }
}
