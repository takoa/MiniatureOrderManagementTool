using System;

namespace MinitureOrderManagementTool.Helpers
{
    public static class Int32Converter
    {
        public static int FromString(string str)
        {
            int i;

            if (Int32.TryParse(str, out i))
            {
                return i;
            }
            else if (str == "" || i < 0)
            {
                return 0;
            }
            else
            {
                return int.MaxValue;
            }
        }
    }
}
