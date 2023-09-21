namespace Shared.Utils
{
    public static class ListUtils
    {
        public static List<T> MakeList<T>(int length, T defaultValue)
        {
            List<T> array = new List<T>(length);
            for (int i = 0; i < length; i++)
            {
                array.Add(defaultValue);
            }

            return array;
        }
    }
}
