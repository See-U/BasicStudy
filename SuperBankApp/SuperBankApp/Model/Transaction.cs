using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBankApp.Model
{
    /// <summary>
    /// 交易类
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        ///交易时间
        /// </summary>
        public DateTime TransitDate { get; set; }

        /// <summary>
        /// 交易记录
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="date"></param>
        /// <param name="notes"></param>
        public Transaction(decimal amount,DateTime date,string notes )
        {
            Amount = amount;
            TransitDate = date;
            Notes = notes;

        }
    }
}
