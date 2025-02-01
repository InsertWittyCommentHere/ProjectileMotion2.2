namespace Utility
{
    public struct Vector(double x, double y, double z)
    {
        // Define the components with getter and setter values, to be initialized with the values of x, y, and z when a new vector is created
        public double X { get; set; } = x;
        public double Y { get; set; } = y;
        public double Z { get; set; } = z;

        // Overload operators for vector addition, subtraction, scalar multiplication, scalar division, negation, and equality
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector operator *(Vector vector, double scalar)
        {
            return new Vector(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);
        }

        public static Vector operator *(double scalar, Vector vector)
        {
            return vector * scalar;
        }

        public static Vector operator -(Vector vector)
        {
            return -1 * vector;
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return a + (-b);
        }

        public static Vector operator /(Vector vector, double scalar)
        {
            return vector * (1 / scalar);
        }

        public static bool operator ==(Vector vector1, Vector vector2)
        {
            return vector1.X == vector2.X && vector1.Y == vector2.Y && vector1.Z == vector2.Z;
        }

        public static bool operator !=(Vector vector1, Vector vector2)
        {
            return !(vector1 == vector2);
        }

        // General methods that are important. Magnitude, Unit Vector, Find Angle between Two Vectors, Dot, Cross, and Projections
        public double Magnitude => Math.Sqrt(X * X + Y * Y + Z * Z);

        public Vector MakeUnitVector()
        {
            return this / this.Magnitude;
        }

        public static double AngleBetween(Vector a, Vector b)
        {
            return Math.Acos(a.Dot(b) / (a.Magnitude * b.Magnitude));
        }

        public double Dot(Vector other)
        {
            return X * other.X + Y * other.Y + Z * other.Z;
        }

        public Vector Cross(Vector other)
        {
            return new Vector(Y * other.Z - Z * other.Y, Z * other.X - X * other.Z, X * other.Y - Y * other.X);
        }

        public static Vector Project(Vector actualVector, Vector baseVector)
        {
            return baseVector * (actualVector.Dot(baseVector) / baseVector.Dot(baseVector));
        }
        // ToString method override to print out the vector in a readable format (x, y, z)
        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }

    }


}