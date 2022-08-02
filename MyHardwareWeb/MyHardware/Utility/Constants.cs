namespace MyHardware.Utility
{
    public class Constants
    {
        public class StatusActive
        {
            public const string Active = "1";
            public const string Inactive = "0";
        }

        public class ProductType
        {
            public const string PersonalComputer = "1";
            public const string Microphone = "2";
            public const string Screen = "3";
            public const string Speaker = "4";
            public const string Keyboard = "5";
            public const string Mouse = "6";

            public string GetName(string productName)
            {
                switch (productName)
                {
                    case ProductType.PersonalComputer: return "Computador";
                    case ProductType.Microphone: return "Microfone";
                    case ProductType.Screen: return "Monitor";
                    case ProductType.Speaker: return "Caixa de som";
                    case ProductType.Keyboard: return "Teclado";
                    case ProductType.Mouse: return "Mouse";
                    default: return "";
                }
            }
        }
    }
}
