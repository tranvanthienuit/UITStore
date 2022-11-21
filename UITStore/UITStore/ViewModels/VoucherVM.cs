using System;
using System.Collections.Generic;
using System.Text;
using UITStore.Models;

namespace UITStore.ViewModels
{
    class VoucherVM
    {
        public List<Vouchers> GetVoucher()
        {
            return new List<Vouchers>()
            {
                new Vouchers
                {
                    id = 1, name = "Ưu đãi thành viên mới", date = "15/01/2023", discount = "20%", tag = "%", order = 20
                },
                new Vouchers
                {
                    id = 2, name = "Ưu đãi thành viên mới", date = "15/01/2023", discount = "50,000 VNĐ", tag = "đ", order = 50000
                },
                new Vouchers
                {
                    id = 3, name = "Ưu đãi tháng 12", date = "1/01/2023", discount = "15%", tag = "%", order = 15
                },
                new Vouchers
                {
                    id = 4, name = "Ưu đãi tháng 12", date = "15/01/2023", discount = "40,000 VNĐ", tag = "đ", order = 40000
                }
            };
        }
    }
}
