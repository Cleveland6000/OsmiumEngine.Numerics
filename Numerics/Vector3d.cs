using System;
using System.Runtime.CompilerServices;

namespace OsmiumEngine.Numerics {

    public readonly struct Vector3d : IEquatable<Vector3d> {

        public readonly double X;
        public readonly double Y;
        public readonly double Z;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3d (double x, double y, double z) { X = x; Y = y; Z = z; }

        public static readonly Vector3d Zero = new Vector3d(0.0, 0.0, 0.0);
        public static readonly Vector3d UnitX = new Vector3d(1.0, 0.0, 0.0);
        public static readonly Vector3d UnitY = new Vector3d(0.0, 1.0, 0.0);
        public static readonly Vector3d UnitZ = new Vector3d(0.0, 0.0, 1.0);
        public static readonly Vector3d PositiveInfinity = new Vector3d(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity);
        public static readonly Vector3d NegativeInfinity = new Vector3d(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3d operator + (in Vector3d a, in Vector3d b) { return new Vector3d(a.X + b.X, a.Y + b.Y, a.Z + b.Z); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3d operator - (in Vector3d a, in Vector3d b) { return new Vector3d(a.X - b.X, a.Y - b.Y, a.Z - b.Z); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3d operator - (in Vector3d a) { return new Vector3d(-a.X, -a.Y, -a.Z); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3d operator * (in Vector3d a, double b) { return new Vector3d(a.X * b, a.Y * b, a.Z * b); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3d operator * (double b, in Vector3d a) { return new Vector3d(a.X * b, a.Y * b, a.Z * b); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3d operator / (in Vector3d a, double b) { return new Vector3d(a.X / b, a.Y / b, a.Z / b); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (in Vector3d a, in Vector3d b) { return a.X == b.X && a.Y == b.Y && a.Z == b.Z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (in Vector3d a, in Vector3d b) { return a.X != b.X || a.Y != b.Y || a.Z != b.Z; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly double GetSqrMagnitude () { return X * X + Y * Y + Z * Z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly double GetMagnitude () { return Math.Sqrt(X * X + Y * Y + Z * Z); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector3i GetFloorToInt () { return new Vector3i((int)Math.Floor(X), (int)Math.Floor(Y), (int)Math.Floor(Z)); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector3d GetNormalized () {
            double sqrMag = X * X + Y * Y + Z * Z;
            if (sqrMag == 0.0) {
                return new Vector3d(0.0, 0.0, 0.0);
            }
            double invMag = 1.0 / Math.Sqrt(sqrMag);
            return new Vector3d(X * invMag, Y * invMag, Z * invMag);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals (Vector3d other) { return X == other.X && Y == other.Y && Z == other.Z; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly bool Equals (object obj) { return obj is Vector3d v && X == v.X && Y == v.Y && Z == v.Z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode () { return HashCode.Combine(X, Y, Z); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString () { return $"({X}, {Y}, {Z})"; }

    }
}
