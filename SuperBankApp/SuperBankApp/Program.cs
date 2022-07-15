// See https://aka.ms/new-console-template for more information
using SuperBankApp.Model;

//Console.WriteLine("Hello, World!");
BankAccount bankAcount = new BankAccount("小明",900);
Console.WriteLine($"您已成功创建账户{bankAcount.Number}，拥有者{bankAcount.Owner},账户余额{bankAcount.Balance}");
int times = 5;
while (times > 0)
{
    try
    {
        times--;
        Console.WriteLine("请输入取出金额：");
        string input = Console.ReadLine();
        decimal amount = decimal.TryParse(input, out decimal res) ? res : -1;
        bankAcount.MakeWithdraw(amount, DateTime.Now, $"取出{amount}元");
      
        Console.WriteLine($"当前交易记录：账户{bankAcount.Number}，拥有者{bankAcount.Owner},账户余额{bankAcount.Balance}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"取出操作失败,原因：{ex.Message}");
    }
}

bankAcount.getHistory();

