static class Mandlebrot
{
    private static int _maxCount;

    public static int MaxCount { get => _maxCount; set => _maxCount = value; }

    public static int MandlebrotCalc(float realConst, float imagConst)
    {
        int iterCount = 0;
        float a = 0;
        float b = 0;

        do {
            float[] squaredValue = SquareComplex(a, b);
            a = squaredValue[0] + realConst;
            b = squaredValue[1] + imagConst;

            iterCount++;
        } while (!InSet(iterCount) && ComplexMagnitude(a, b) < 2);

        return iterCount;
    }

    public static int MandlebrotCalc(double realConst, double imagConst)
    {
        int iterCount = 0;
        double a = 0;
        double b = 0;

        do {
            double[] squaredValue = SquareComplex(a, b);
            a = squaredValue[0] + realConst;
            b = squaredValue[1] + imagConst;

            iterCount++;
        } while (!InSet(iterCount) && ComplexMagnitude(a, b) < 2);

        return iterCount;
    }

    public static bool InSet(int count)
    {
        return count >= MaxCount;
    }

    public static float[] SquareComplex(float a, float b)
    {
        float[] returnArr = new float[2];
        returnArr[0] = a * a - b * b;
        returnArr[1] = 2 * a * b;
        return returnArr;
    }

    public static float ComplexMagnitude(float a, float b)
    {
        return a * a + b * b;
    }

    public static double[] SquareComplex(double a, double b)
    {
        double[] returnArr = new double[2];
        returnArr[0] = a * a - b * b;
        returnArr[1] = 2 * a * b;
        return returnArr;
    }

    public static double ComplexMagnitude(double a, double b)
    {
        return a * a + b * b;
    }

}
