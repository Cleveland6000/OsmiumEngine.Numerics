using System;
using System.Runtime.CompilerServices;

namespace OsmiumEngine {

    public readonly struct Vector3d : IEquatable<Vector3d> {

        public readonly double x;
        public readonly double y;
        public readonly double z;

        public static readonly Vector3d Zero = new Vector3d(0.0, 0.0, 0.0);
        public static readonly Vector3d UnitX = new Vector3d(1.0, 0.0, 0.0);
        public static readonly Vector3d UnitY = new Vector3d(0.0, 1.0, 0.0);
        public static readonly Vector3d UnitZ = new Vector3d(0.0, 0.0, 1.0);
        public static readonly Vector3d PositiveInfinity = new Vector3d(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity);
        public static readonly Vector3d NegativeInfinity = new Vector3d(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3d (double x, double y, double z) { this.x = x; this.y = y; this.z = z; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3d operator + (in Vector3d a, in Vector3d b) { return new Vector3d(a.x + b.x, a.y + b.y, a.z + b.z); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3d operator - (in Vector3d a, in Vector3d b) { return new Vector3d(a.x - b.x, a.y - b.y, a.z - b.z); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3d operator - (in Vector3d a) { return new Vector3d(-a.x, -a.y, -a.z); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3d operator * (in Vector3d a, in double b) { return new Vector3d(a.x * b, a.y * b, a.z * b); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3d operator * (in double b, in Vector3d a) { return new Vector3d(a.x * b, a.y * b, a.z * b); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3d operator / (in Vector3d a, in double b) { return new Vector3d(a.x / b, a.y / b, a.z / b); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (in Vector3d a, in Vector3d b) { return a.x == b.x && a.y == b.y && a.z == b.z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (in Vector3d a, in Vector3d b) { return a.x != b.x || a.y != b.y || a.z != b.z; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals (Vector3d other) { return x == other.x && y == other.y && z == other.z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals (in Vector3d other) { return x == other.x && y == other.y && z == other.z; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly bool Equals (object obj) { return obj is Vector3d v && x == v.x && y == v.y && z == v.z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode () { return HashCode.Combine(x, y, z); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString () { return $"({x}, {y}, {z})"; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly double GetSqrMagnitude () { return x * x + y * y + z * z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly double GetMagnitude () { return Math.Sqrt(x * x + y * y + z * z); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector3d GetNormalized () {
            double sqrMag = x * x + y * y + z * z;
            if (sqrMag > 0.0) {
                double invMag = 1.0 / Math.Sqrt(sqrMag);
                return new Vector3d(x * invMag, y * invMag, z * invMag);
            } else {
                return new Vector3d(0.0, 0.0, 0.0);
            }
        }
    }
}
