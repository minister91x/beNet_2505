using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.DALImpl
{
    public class AccountADO_ImplDAL : IAccountADO_DAL
    {
        public async Task<ReturnData> Account_Insert(AccountInsertRequestData requestData)
        {
            var returnData = new ReturnData();
            try
            {
                if (requestData == null
                    || string.IsNullOrEmpty(requestData.UserName)
                     || string.IsNullOrEmpty(requestData.Password)
                      || string.IsNullOrEmpty(requestData.FullName))
                {
                    returnData.ResponseCode = -1;
                    returnData.ResponseMessenger = "Dữ liệu đầu vào không hợp lệ!";
                    return returnData;
                }

                // Bước 1 Mở connection
                var connection = DbHepler.DbHelper.GetSqlConnection();
                //Bước 2:sử dụng Sqlcommand để thao tác với db

                // var cmd = new SqlCommand("SELECT * FROM USER WHERE ID = 1=1; DROP", connection);
                // cmd.CommandType = System.Data.CommandType.Text;

                var cmd = new SqlCommand("SP_Account_Insert", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // Truyền dữ liệu qua parameter
                cmd.Parameters.AddWithValue("@UserName", requestData.UserName);
                cmd.Parameters.AddWithValue("@Password", requestData.Password);
                cmd.Parameters.AddWithValue("@FullName", requestData.FullName);
                cmd.Parameters.Add("@ResponseCode", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;

                // Bước 3: Trả kết quả 
                cmd.ExecuteNonQuery();

                connection.Close();
                var rs = cmd.Parameters["@ResponseCode"].Value != (object)DBNull.Value ? Convert.ToInt32(cmd.Parameters["@ResponseCode"].Value.ToString()) : 0;
                if (rs < 0)
                {
                    switch (rs)
                    {
                        case -1:
                            returnData.ResponseCode = -1;
                            returnData.ResponseMessenger = "Đã tồn tại tài khoản!";
                            return returnData;
                        default:
                            returnData.ResponseCode = -99;
                            returnData.ResponseMessenger = "Hệ thống đang bận!";
                            return returnData;
                    }

                }

                returnData.ResponseCode = rs;
                returnData.ResponseMessenger = "Thêm mới thành công!";
                return returnData;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Account>> GetAccounts(AccountGetListRequestData requestData)
        {
            var list = new List<Account>();
            try
            {
                // Bước 1 Mở connection
                var connection = DbHepler.DbHelper.GetSqlConnection();
                //Bước 2:sử dụng Sqlcommand để thao tác với db

                // var cmd = new SqlCommand("SELECT * FROM USER WHERE ID = 1=1; DROP", connection);
                // cmd.CommandType = System.Data.CommandType.Text;

                var cmd = new SqlCommand("SP_Account_GetAll", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", requestData.UserName);

                // Bước 3: Trả kết quả 
                var rs = cmd.ExecuteReader();
                // COnvert data từ ExecuteReader -> List<Account>
                while (rs.Read())
                {
                    var account = new Account();
                    account.ID = rs["ID"] != DBNull.Value ? Convert.ToInt32(rs["ID"].ToString()) : 0;
                    account.UserName = rs["UserName"] != DBNull.Value ? rs["UserName"]?.ToString() : "";
                    account.FullName = rs["FullName"] != DBNull.Value ? rs["FullName"]?.ToString() : "";
                    list.Add(account);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return list;
        }
    }
}
