using System;

namespace Event_20._02._2023
{
    public delegate void MyDelegate();

    public class Card
    {
        public static event MyDelegate CardsRefill;
        public static event MyDelegate CardsSpendingOfMoney;
        public static event MyDelegate CardsStartusingCreditCard;
        public static event MyDelegate CardsReachingAGivenAmountOfMoney;
        

        public static string NamePerson { set; get; }
        public static string CardExpirationDate { set; get; }
        public static int PinCard { set; get; }
        public static string CreditLimit { set; get; }
        public static int SummMoney { set; get; }

        public Card() { }
        public Card(string NP, string CED, int PC, string CL, int SM)
        {
            NamePerson = NP;
            CardExpirationDate = CED;
            PinCard = PC;
            CreditLimit = CL;
            SummMoney = SM;
        }
        public void Print()
        {
            Console.WriteLine($"Имя владельца карты:{NamePerson}\nСрок истечения годности карты:{CardExpirationDate}\nПин код карты:{PinCard}\nKредитный лимит карты:{CreditLimit}\nСумма денег:{SummMoney}\n\n");
        }
        public override string ToString()
        {
            return $"Имя владельца карты:{NamePerson}\nСрок истечения годности карты:{CardExpirationDate}\nПин код карты:{PinCard}\nКредитный лимит карты:{CreditLimit}\nСумма денег:{SummMoney}\n\n";
        }
        // когда я делаю метод статическим , у меня жалуется на имя Собятия, и я его делаю статическим 
        public  static void Refill()//пополнение счета
        {
            Console.Write("Введиет сумму на которую вы ходите полнить вашу карту:");
            int A = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Вы пополнили карту на = "+A+"грн");
            int Monye = 0;
            Monye = SummMoney + A;
            Console.WriteLine("Общая сумма на карте = " + Monye + "грн");
            CardsRefill?.Invoke();
        }
        public static void SpendingOfMoney()
        {
            Console.Write("Введиет сумму которую ви хотите снять с карты:");
            int A = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Вы сняли с карты = " + A + "грн");
            int Monye = 0;
            Monye = SummMoney - A;
            Console.WriteLine("Общая сумма на карте = " + Monye + "грн");
            CardsSpendingOfMoney?.Invoke();
        }
        public static void StartusingCreditCard()
        {
            Console.WriteLine("Вы начали использовать кридитные деньги");
            Console.Write("Введиет сумму которую ви хотите взять с кридитных денег:");
            int A = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Вы сняли с кридитных средств = " + A + "грн");
            CardsStartusingCreditCard?.Invoke();
        }
        public static void ReplacementPinCode()
        {
            Console.WriteLine("Вы выбрали пункт смены PIN");
            Console.WriteLine("Введите стрый PIN для смены на новый");
            int A = Convert.ToInt32(Console.ReadLine());
            if (A != PinCard)
            {
                Console.WriteLine("Вы ввели не правельный PIN!!!!!!");
            }
            else
            {
                Console.WriteLine("Введите новый пин PIN");
                int D = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ваш новый PIN = "+D);
            }
            CardsReachingAGivenAmountOfMoney?.Invoke();
        }
        
        
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Card obj = new Card("Petro", "12.08.2032", 123, "123000", 1253);
            obj.Print();
            Console.WriteLine("1)Пополнить счет на карте\n2)Снять деньги со счета\n3)Начать использовать кредитные деньги\n4)смена PIN\n");
            int T = Convert.ToInt32(Console.ReadLine());
            MyDelegate obj1 = new MyDelegate(Card.Refill);
            obj1 += Card.Refill;
            obj1 += Card.SpendingOfMoney;
            obj1 += Card.StartusingCreditCard;
            obj1 += Card.ReplacementPinCode;
            if (T==1)
            {
                Card.Refill();
            }
            if (T==2)
            {
                Card.SpendingOfMoney();
            }
            if (T==3)
            {
                Card.StartusingCreditCard();
            }
            if (T==4)
            {
                Card.ReplacementPinCode();
            }
        }
    }
   
}
