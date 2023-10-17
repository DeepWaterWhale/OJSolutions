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

        public static T[, ] Make2DArray<T>(int height, int width, T defaultValue)
        {
            T[, ] array = new T[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    array[i, j] = defaultValue;
                }
            }

            return array;
        }
    }
}
