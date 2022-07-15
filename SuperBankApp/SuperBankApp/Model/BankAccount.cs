using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBankApp.Model
{
    public class BankAccount
    {
        private static int InitialNumber = 12345678;        
        
        /// <summary>
        /// 账户名称
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 拥有者
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// 账户余额
        /// </summary>
        public Decimal Balance
        {
            get 
            {
                decimal balance = 0M;    
                foreach (var item in TransitionLst)
                {
                    balance += item.Amount;
                }

                return balance;
            }
            set
            {
                Balance = value;
            }
        }

        public BankAccount(string owner,decimal intialBalance)
        { 
            Number = InitialNumber.ToString();
            InitialNumber++;
            Owner = owner;
            MakeDeposit(intialBalance, DateTime.Now, "初始化余额");
        }

        private List<Transaction> TransitionLst = new List<Transaction>();

        /// <summary>
        /// 存入资金
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="dateTime"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        public void MakeDeposit(decimal amount,DateTime dateTime,string note) {
            if (amount <= 0)
            {
                throw new Exception("存入的金额必须为正数！");
            }
            TransitionLst.Add(new Transaction(amount, dateTime, note));
        }

        /// <summary>
        /// 取出资金
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="dateTime"></param>
        /// <param name="notes"></param>
        /// <returns></returns>
        public void MakeWithdraw(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "取出的金额必须为正数！");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("账户没有足够的资金供取出！");
            }
            var withdrawal = new Transaction(-amount, date, note);
            TransitionLst.Add(withdrawal);
        }

        public void getHistory() {
            var builder = new StringBuilder();
            builder.Append("交易时间   交易金额   交易记录\t\n");
            foreach (var item in TransitionLst)
            {
                builder.Append(item.TransitDate + "   " + item.Amount + "   " +item.Notes + "\t\n");
            }

            Console.WriteLine(builder);
        }
    }
}
