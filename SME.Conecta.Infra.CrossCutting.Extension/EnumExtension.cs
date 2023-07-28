namespace SME.Conecta.Infra.CrossCutting.Extension
{
    public static class EnumExtension
    {
        public static string ToDescription(this Enum value) => value.GetAttribute<DescriptionAttribute>() == null ? value.ToString() : value.GetAttribute<DescriptionAttribute>().Description;

        private static T GetAttribute<T>(this Enum enumType) where T : Attribute => enumType.GetType().GetField(enumType.ToString()).GetCustomAttributes(typeof(T), false).FirstOrDefault() as T;
    }
}