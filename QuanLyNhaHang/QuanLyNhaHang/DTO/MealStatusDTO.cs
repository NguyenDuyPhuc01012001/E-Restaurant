using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    class MealStatusDTO
    {
        private int idbillinfo;
        private String foodname;
        private int count;
        private String description;
        private int status;
        private String category;

        public MealStatusDTO()
        {
        }

        public MealStatusDTO(int idbillinfo,String foodname, int count, String des, int status, string category )
        {
            this.idbillinfo = idbillinfo;
            this.foodname = foodname;
            this.count = count;
            this.description = des;
            this.status = status;
            this.category = category;
            
        }

        public MealStatusDTO(DataRow row)
        {
            this.idbillinfo = (int)row["idbillinfo"];
            this.foodname = (String)row["name"];
            this.count = (int)row["count"];
            this.description = (String)row["des"];
            this.status = (int)row["status"];
            this.category = (String)row["category"];
        }
        public string Description { get => description; set => description = value; }
        public int Status { get => status; set => status = value; }
        public string Foodname { get => foodname; set => foodname = value; }
        public int Count { get => count; set => count = value; }
        public string Category { get => category; set => category = value; }
        public int IdBillInfo { get => idbillinfo; set => idbillinfo = value; }
    }
}
