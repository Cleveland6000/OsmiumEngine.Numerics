using System;

namespace OsmiumEngine {

    public readonly struct Vector3d {

        public readonly double x;
        public readonly double y;
        public readonly double z;

        public Vector3d (double x, double y, double z) { this.x = x; this.y = y; this.z = z; }

        public static Vector3d operator + (in Vector3d a, in Vector3d b) { return new Vector3d(a.x + b.x, a.y + b.y, a.z + b.z); }
        public static Vector3d operator - (in Vector3d a, in Vector3d b) { return new Vector3d(a.x - b.x, a.y - b.y, a.z - b.z); }
        public static Vector3d operator - (in Vector3d a) { return new Vector3d(-a.x, -a.y, -a.z); }
        public static Vector3d operator * (in Vector3d a, in double b) { return new Vector3d(a.x * b, a.y * b, a.z * b); }
        public static Vector3d operator * (in double b, in Vector3d a) { return new Vector3d(a.x * b, a.y * b, a.z * b); }
        public static Vector3d operator / (in Vector3d a, in double b) { return new Vector3d(a.x / b, a.y / b, a.z / b); }
        public static bool operator == (in Vector3d a, in Vector3d b) { return a.Equals(b); }
        public static bool operator != (in Vector3d a, in Vector3d b) { return !(a == b); }

        public static readonly Vector3d Zero = new Vector3d(0.0, 0.0, 0.0);
        public static readonly Vector3d UnitX = new Vector3d(1.0, 0.0, 0.0);
        public static readonly Vector3d UnitY = new Vector3d(0.0, 1.0, 0.0);
        public static readonly Vector3d UnitZ = new Vector3d(0.0, 0.0, 1.0);
        public static readonly Vector3d PositiveInfinity = new Vector3d(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity);
        public static readonly Vector3d NegativeInfinity = new Vector3d(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity);

        public override readonly bool Equals (object obj) { return obj is Vector3d v && Equals(v); }
        public override readonly int GetHashCode () { return HashCode.Combine(x, y, z); }
        public override readonly string ToString () { return $"({x}, {y}, {z})"; }

        public readonly bool Equals (in Vector3d other) { return x == other.x && y == other.y && z == other.z; }

    }
}
