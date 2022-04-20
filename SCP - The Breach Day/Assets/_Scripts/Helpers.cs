public static class Helpers
{
    public static bool IntToBool(int i) {
        return i switch
        {
            0 => false,
            1 => true,
            _ => false
        };
    }

    public static int BoolToInt(bool b) {
        return b ? 1 : 0;
    }
}
