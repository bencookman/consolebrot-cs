public static class UsefulMath
{
    public static float Map(float minStart, float maxStart, float minEnd, float maxEnd, float value)
    {
        return (value - minStart) * (maxEnd - minEnd) / (maxStart - minStart) + minEnd;
    }

    public static double Map(double minStart, double maxStart, double minEnd, double maxEnd, double value)
    {
        return (value - minStart) * (maxEnd - minEnd) / (maxStart - minStart) + minEnd;
    }

}
