using System;

namespace OsmiumEngine {

    public struct Vector3d {

        public double x;
        public double y;
        public double z;

        public Vector3d (double x, double y, double z) { this.x = x; this.y = y; this.z = z; }

        public static Vector3d operator + (in Vector3d a, in Vector3d b) { return new Vector3d(a.x + b.x, a.y + b.y, a.z + b.z); }
        public static Vector3d operator - (in Vector3d a, in Vector3d b) { return new Vector3d(a.x - b.x, a.y - b.y, a.z - b.z); }
        public static Vector3d operator - (in Vector3d a) { return new Vector3d(-a.x, -a.y, -a.z); }
        public static Vector3d operator * (in Vector3d a, in double b) { return new Vector3d(a.x * b, a.y * b, a.z * b); }
        public static Vector3d operator * (in double b, in Vector3d a) { return new Vector3d(a.x * b, a.y * b, a.z * b); }
        public static Vector3d operator / (in Vector3d a, in double b) { return new Vector3d(a.x / b, a.y / b, a.z / b); }
        public static bool operator == (in Vector3d a, in Vector3d b) { return a.x == b.x && a.y == b.y && a.z == b.z; }
        public static bool operator != (in Vector3d a, in Vector3d b) { return !(a == b); }

        public static Vector3d Cross (in Vector3d a, in Vector3d b) { return new Vector3d(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x); }
        public static Vector3d Scale (in Vector3d a, in Vector3d b) { return new Vector3d(a.x * b.x, a.y * b.y, a.z * b.z); }
        public static double Dot (in Vector3d a, in Vector3d b) { return a.x * b.x + a.y * b.y + a.z * b.z; }

        public static double Distance (in Vector3d a, in Vector3d b) {
            double diff_x = a.x - b.x;
            double diff_y = a.y - b.y;
            double diff_z = a.z - b.z;
            return Math.Sqrt(diff_x * diff_x + diff_y * diff_y + diff_z * diff_z);
        }

        public static readonly Vector3d Zero = new Vector3d(0D, 0D, 0D);
        public static readonly Vector3d One = new Vector3d(1D, 1D, 1D);
        public static readonly Vector3d PositiveInfinity = new Vector3d(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity);
        public static readonly Vector3d NegativeInfinity = new Vector3d(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity);

        public readonly double SqrMagnitude { get { return x * x + y * y + z * z; } }
        public readonly double Magnitude { get { return Math.Sqrt(x * x + y * y + z * z); } }

        public readonly Vector3d Normalized {
            get {
                double sqrMag = x * x + y * y + z * z;
                if (sqrMag > 0D) {
                    double invMag = 1D / Math.Sqrt(sqrMag);
                    return new Vector3d(x * invMag, y * invMag, z * invMag);
                } else {
                    return Zero;
                }
            }
        }

        public readonly bool Equals (in Vector3d other) { return x == other.x && y == other.y && z == other.z; }

        public override readonly bool Equals (object obj) { return obj is Vector3d v && Equals(v); }
        public override readonly int GetHashCode () { return HashCode.Combine(x, y, z); }
        public override readonly string ToString () { return $"({x}, {y}, {z})"; }

        public void NormalizeInPlace () {
            double sqrMag = x * x + y * y + z * z;
            if (sqrMag > 0D) {
                double invMag = 1D / Math.Sqrt(sqrMag);
                x *= invMag;
                y *= invMag;
                z *= invMag;
            } else {
                x = y = z = 0D;
            }
        }
    }
}