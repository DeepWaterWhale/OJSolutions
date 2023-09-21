namespace Shared.Utils
{
    public class ArrayUtils
    {
        public static T[] MakeArray<T>(int length, T defaultValue)
        {
            T[] array = new T[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = defaultValue;
            }

            return array;
        }
    }
}
