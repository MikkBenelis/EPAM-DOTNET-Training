namespace Logic.BankingSystem
{
    using System;
    using System.Text;
    
    public class Account
    {
        #region Fields

        private static int _lastID = 0;
        private int _balance;
        private int _bonuses;

        #endregion Fields

        #region Constructors

        /// <summary>Account constructor</summary>
        /// <param name="name">account name</param>
        /// <param name="surname">account surname</param>
        /// <param name="type">account type</param>
        public Account(string name, string surname, EType type)
        {
            AccountID = ++_lastID;
            Type = type;
            Name = name;
            Surname = surname;
            Balance = 0;
            Bonuses = 0;
        }

        internal Account(int accountID, string name, string surname, EType type, int balance, int bonuses)
        {
            if (accountID > _lastID)
            {
                _lastID = accountID;
            }

            Name = name;
            Surname = surname;
            Type = type;
            _balance = balance;
            _bonuses = bonuses;
        }

        #endregion Constructors

        #region Enums

        /// <summary>Account type enum</summary>
        public enum EType
        {
            BASE, GOLD, PLATINUM
        }

        #endregion Enums

        #region Properties

        /// <summary>Account ID</summary>
        public int AccountID { get; private set; }

        /// <summary>Account name</summary>
        public string Name { get; private set; }

        /// <summary>Account surname</summary>
        public string Surname { get; private set; }

        /// <summary>Account type</summary>
        public EType Type { get; private set; }

        /// <summary>Account balance</summary>
        public int Balance
        {
            get => _balance;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                
                _balance = value;
            }
        }

        /// <summary>Account bonuses</summary>
        public int Bonuses
        {
            get => _bonuses;
            private set
            {
                if (value < 0)
                {
                    _bonuses = 0;
                }
                else
                {
                    _bonuses = value;
                }
            }
        }

        #endregion Properties

        #region PublicAPI

        /// <summary>Add amount to balance</summary>
        /// <param name="amount">int amount to add</param>
        public void AddBalance(int amount)
        {
            Balance += amount;
            Bonuses += CalculateBonus(amount);
        }

        /// <summary>Withdraw amount from balance</summary>
        /// <param name="amount">int amount to withdraw</param>
        public void Withdraw(int amount)
        {
            if (_balance - amount < 0)
            {
                throw new ArgumentException();
            }

            _balance -= amount;
            Bonuses -= CalculateBonus(amount / 2);
        }

        /// <summary>Calculate account bonus</summary>
        /// <param name="value">added value to balance</param>
        /// <returns></returns>
        public int CalculateBonus(int value)
        {
            switch (Type)
            {
                case EType.BASE:
                    return 0;
                case EType.GOLD:
                    return value * 10 / 100;
                case EType.PLATINUM:
                    return value * 25 / 100;
            }

            return 0;
        }

        /// <summary>ToString</summary>
        /// <returns>string representation</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("AccountID: " + AccountID);
            sb.Append(", Type: " + Type);
            sb.Append(", Name: " + Name);
            sb.Append(", Surname: " + Surname);
            sb.Append(", Balance: " + Balance);
            sb.Append(", Bonuses: " + Bonuses);
            return sb.ToString();
        }

        #endregion PublicAPI
    }
}
