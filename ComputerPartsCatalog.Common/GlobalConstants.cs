namespace ComputerPartsCatalog.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "ComputerPartsCatalog";

        public const string AdministratorRoleName = "Administrator";

        public static class AccountsSeeding
        {
            public const string Password = "123456";

            public const string AdminEmail = "admin@gmail.com";

            public const string UserEmail = "user@gmail.com";
        }

        public static class DataValidations
        {
            public const int NameMinLength = 5;

            public const int BrandMinLength = 2;

            public const string MinPrice = "0";

            public const string MaxPrice = "79228162514264337593543950335";

            public const int DescriptionMaxLenght = 1500;

            public const int MaxFileLength = 5242880; // 5 * 1024 * 1024 = 5MB
        }
    }
}
