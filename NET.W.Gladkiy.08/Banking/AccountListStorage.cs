namespace Logic.BankingSystem
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class AccountListStorage
    {
        /// <summary>List of accounts in database</summary>
        public List<Account> Database { get; } = new List<Account>();

        /// <summary>bool empty database state</summary>
        public bool IsEmpty { get => Database.Count == 0; }

        /// <summary>Load database from disk</summary>
        /// <param name="pathToLoad">path to load file</param>
        public bool LoadFromDisk(string pathToLoad)
        {
            FileStream fs;
            try
            {
                using (fs = new FileStream(pathToLoad, FileMode.Open))
                {
                    if (fs.CanRead)
                    {
                        var br = new BinaryReader(fs);
                        int accountID, balance, bonuses;
                        Account.EType type;
                        string name, surname;
                        while (fs.Position != fs.Length)
                        {
                            accountID = br.ReadInt32();
                            name = br.ReadString();
                            surname = br.ReadString();
                            type = (Account.EType)Enum.Parse(typeof(Account.EType), br.ReadString());
                            balance = br.ReadInt32();
                            bonuses = br.ReadInt32();
                            Database.Add(new Account(accountID, name, surname, type, balance, bonuses));
                        }

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (IOException)
            {
                return false;
            }
        }

        /// <summary>Save database to disk</summary>
        /// <param name="pathToSave">path to save file</param>
        public bool SaveToDisk(string pathToSave)
        {
            FileStream fs;
            try
            {
                using (fs = new FileStream(pathToSave, FileMode.Create))
                {
                    if (fs.CanWrite)
                    {
                        var bw = new BinaryWriter(fs);
                        foreach (Account account in Database)
                        {
                            bw.Write(account.AccountID);
                            bw.Write(account.Name);
                            bw.Write(account.Surname);
                            bw.Write(account.Type.ToString());
                            bw.Write(account.Balance);
                            bw.Write(account.Bonuses);
                        }

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (IOException)
            {
                return false;
            }
        }
    }
}
