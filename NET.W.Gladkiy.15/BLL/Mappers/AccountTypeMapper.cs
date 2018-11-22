namespace BLL.Mappers
{
    using BLL.Interface.Entities;
    using DAL.Interface.DTO;

    public static class AccountTypeMapper
    {
        public static AccountType MapAccountTypeFromDTO(AccountTypeDTO accountTypeDTO)
        {
            return (AccountType)accountTypeDTO;
        }

        public static AccountTypeDTO MapAccountTypeToDTO(AccountType accountType)
        {
            return (AccountTypeDTO)accountType;
        }
    }
}
