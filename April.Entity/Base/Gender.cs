namespace April.Entity.Base
{
    public enum Gender
    {
        Male,
        Female
    }
    public static class GenderEx
    {
        public static string ToLabel(this Gender gender)
        {
            switch (gender)
            {
                case Gender.Male:
                    return "男";
                case Gender.Female:
                    return "女";
                default:
                    return "男";
            }
        }
    }
}