namespace ConsoleApp38
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector3D v1 = new Vector3D(1, 2, 3);
            Vector3D v2 = new Vector3D(4, 5, 6);
            Console.WriteLine("v1: " + v1);
            Console.WriteLine("v2: " + v2);
            Vector3D v3 = v1.MultiplyByScalar(2);
            Console.WriteLine("v1 * 2: " + v3);
            Vector3D v4 = v1.Add(v2);
            Console.WriteLine("v1 + v2: " + v4);
            Vector3D v5 = v1.Subtract(v2);
            Console.WriteLine("v1 - v2: " + v5);

            DecimalNumber num = new DecimalNumber(255);
            Console.WriteLine(num);
            Console.WriteLine(num.ToBinary());
            Console.WriteLine(num.ToOctal());
            Console.WriteLine(num.ToHexadecimal());

            RGBColor color = new RGBColor(255, 0, 0);
            Console.WriteLine(color);
            Console.WriteLine(color.ToHex());
            var (h, s, l) = color.ToHSL();
            Console.WriteLine($"H={h}, S={s}, L={l}");
            var (c, m, y, k) = color.ToCMYK();
            Console.WriteLine($"CMYK формат: C={c}, M={m}, Y={y}, K={k}");
        }
    }
}
public struct Vector3D
{
    public double X { get; }
    public double Y { get; }
    public double Z { get; }
    public Vector3D(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    public Vector3D MultiplyByScalar(double scalar)
    {
        return new Vector3D(X * scalar, Y * scalar, Z * scalar);
    }
    public Vector3D Add(Vector3D other)
    {
        return new Vector3D(X + other.X, Y + other.Y, Z + other.Z);
    }
    public Vector3D Subtract(Vector3D other)
    {
        return new Vector3D(X - other.X, Y - other.Y, Z - other.Z);
    }
    public override string ToString()
    {
        return $"Vector3D({X}, {Y}, {Z})";
    }
}
public struct DecimalNumber
{
    public int num { get; }
    public DecimalNumber(int n)
    {
        num = n;
    }
    public string ToBinary()
    {
        return Convert.ToString(num, 2);
    }

    public string ToOctal()
    {
        return Convert.ToString(num, 8);
    }

    public string ToHexadecimal()
    {
        return Convert.ToString(num, 16);
    }

    public override string ToString()
    {
        return num.ToString();
    }
}
public struct RGBColor
{
    public int R { get; }
    public int G { get; }
    public int B { get; }
    public RGBColor(int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
    }
    public string ToHex()
    {
        return $"#{R:X2}{G:X2}{B:X2}";
    }
    public (double H, double S, double L) ToHSL()
    {
        double r = R / 255.0;
        double g = G / 255.0;
        double b = B / 255.0;
        double max = Math.Max(r, Math.Max(g, b));
        double min = Math.Min(r, Math.Min(g, b));
        double h, s, l;
        l = (max + min) / 2.0;
        if (max == min)
        {
            h = s = 0;
        }
        else
        {
            double delta = max - min;
            s = l > 0.5 ? delta / (2.0 - max - min) : delta / (max + min);

            if (max == r)
            {
                h = (g - b) / delta + (g < b ? 6 : 0);
            }
            else if (max == g)
            {
                h = (b - r) / delta + 2;
            }
            else
            {
                h = (r - g) / delta + 4;
            }

            h /= 6;
        }
        return (h * 360, s * 100, l * 100);
    }
    public (double C, double M, double Y, double K) ToCMYK()
    {
        double r = R / 255.0;
        double g = G / 255.0;
        double b = B / 255.0;
        double k = 1 - Math.Max(r, Math.Max(g, b));
        if (k == 1)
        {
            return (0, 0, 0, 1);
        }
        double c = (1 - r - k) / (1 - k);
        double m = (1 - g - k) / (1 - k);
        double y = (1 - b - k) / (1 - k);
        return (c, m, y, k);
    }
    public override string ToString()
    {
        return $"RGBColor({R}, {G}, {B})";
    }
}
