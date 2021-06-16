using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    class MealStatusDAO
    {
        private static MealStatusDAO instance;

        public static MealStatusDAO Instance
        {
            get { if (instance == null) instance = new MealStatusDAO(); return MealStatusDAO.instance; }
            private set { MealStatusDAO.instance = value; }
        }

        private MealStatusDAO() { }

        public List<MealStatusDTO> GetListMealStatuses()
        {
            List<MealStatusDTO> listMealStatuses = new List<MealStatusDTO>();

            string query = "SELECT bi.id as idbillinfo, fc.name as category, f.name, bi.count,ms.des,ms.status from BillInfo as bi, Bill as b,FoodCategory as fc , Food as f , MealStatus ms where bi.idBill = b.id and bi.idFood = f.id and fc.id=f.idCategory and bi.id = ms.idBillInfo";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                MealStatusDTO mealStatus = new MealStatusDTO(item);
                listMealStatuses.Add(mealStatus);
            }

            return listMealStatuses;
        }

        public List<MealStatusDTO> GetListMealStatusesByTable(int id)
        {
            List<MealStatusDTO> listMealStatuses = new List<MealStatusDTO>();

            string query = "SELECT bi.id as idbillinfo, fc.name as category, f.name, bi.count,ms.des,ms.status from BillInfo as bi, Bill as b,FoodCategory as fc , Food as f , MealStatus ms where bi.idBill = b.id and bi.idFood = f.id and fc.id=f.idCategory and bi.id = ms.idBillInfo and b.idTable =" + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                MealStatusDTO mealStatus = new MealStatusDTO(item);
                listMealStatuses.Add(mealStatus);
            }

            return listMealStatuses;
        }

        public void InsertMealStatus(int id, string des)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_InsertMealStatus @idBillInfo , @des", new object[] { id, des });
        }

        public void UpdateDes(int idBillInfo, string des)
        {
            string query = string.Format("Update dbo.MealStatus set des = N'{0}' where idBillInfo = {1}",des,idBillInfo);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void UpdateStatus(int idBillInfo, int status)
        {
            string query = string.Format("Update dbo.MealStatus set status = {0}  where idBillInfo = {1}", status, idBillInfo);
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void DeleteMealStatusByBillInfo(int idBillInfo)
        {
            string query = "DELETE dbo.MealStatus WHERE idBillInfo =" + idBillInfo;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void DeleteMealStatusByTable(int idTable)
        {
            string query = "DELETE dbo.MealStatus FROM BillInfo as bi, Bill as b , Food as f , MealStatus ms WHERE bi.idBill = b.id and bi.idFood = f.id and bi.id = ms.idBillInfo and b.idTable = " + idTable;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
