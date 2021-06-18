using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    class StaffDAO
    {
        private static StaffDAO instance;

        public static StaffDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new StaffDAO();
                return instance;
            }
            private set => instance = value;
        }
        private StaffDAO() { }

        public List<StaffDTO> GetListStaff()
        {
            List<StaffDTO> listStaff = new List<StaffDTO>();

            string query = "select * from Staff";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                StaffDTO staff = new StaffDTO(item);
                listStaff.Add(staff);
            }

            return listStaff;
        }

        public StaffDTO GetStaffById(int id)
        {

            string query = "select * from Staff where id = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                StaffDTO staff = new StaffDTO(data.Rows[0]);
                return staff;
            }
            return null;
        }

        public bool DeleteStaff(int id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Delete FROM Staff where id = "+id);

            return result > 0;
        }

        public int CheckPhoneExist(string phone)
        {

            string query = string.Format("select * from Staff where phone = '{0}'",phone);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                StaffDTO staff = new StaffDTO(data.Rows[0]);
                return staff.Id;
            }
            return 0;
        }

        public int CheckEmailExist(string email)
        {

            string query = string.Format("select * from Staff where email = '{0}'", email);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                StaffDTO staff = new StaffDTO(data.Rows[0]);
                return staff.Id;
            }
            return 0;
        }

        public void UpdateStaff(string name, int sex, string email, string phone, int salary, int position)
        {

        }

        public void InsertStaff(string  name,int sex, string email,string phone,int salary,int position)
        {
            DataProvider.Instance.ExecuteQuery("exec USP_InsertStaff @name , @sex , @email , @phone , @salary , @position ", new object[] { name, sex, email, phone, salary,position });
        }


        public int GetMaxIdStaff()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(id) FROM dbo.Staff");
            }
            catch
            {
                return 1;
            }
        }
    }
}
