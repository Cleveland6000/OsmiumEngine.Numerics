using System;
using System.Runtime.CompilerServices;

namespace OsmiumEngine.Numerics {

    public readonly struct Vector3i : IEquatable<Vector3i> {

        public readonly int X;
        public readonly int Y;
        public readonly int Z;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3i (int x, int y, int z) { X = x; Y = y; Z = z; }

        public static readonly Vector3i Zero = new Vector3i(0, 0, 0);
        public static readonly Vector3i UnitX = new Vector3i(1, 0, 0);
        public static readonly Vector3i UnitY = new Vector3i(0, 1, 0);
        public static readonly Vector3i UnitZ = new Vector3i(0, 0, 1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector3d (in Vector3i v) { return new Vector3d(v.X, v.Y, v.Z); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i operator + (in Vector3i a, in Vector3i b) { return new Vector3i(a.X + b.X, a.Y + b.Y, a.Z + b.Z); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i operator - (in Vector3i a, in Vector3i b) { return new Vector3i(a.X - b.X, a.Y - b.Y, a.Z - b.Z); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i operator - (in Vector3i a) { return new Vector3i(-a.X, -a.Y, -a.Z); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i operator * (in Vector3i a, int b) { return new Vector3i(a.X * b, a.Y * b, a.Z * b); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i operator * (int b, in Vector3i a) { return new Vector3i(a.X * b, a.Y * b, a.Z * b); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3d operator * (in Vector3i a, double b) { return new Vector3d(a.X * b, a.Y * b, a.Z * b); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3d operator * (double b, in Vector3i a) { return new Vector3d(a.X * b, a.Y * b, a.Z * b); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3d operator / (in Vector3i a, double b) { return new Vector3d(a.X / b, a.Y / b, a.Z / b); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (in Vector3i a, in Vector3i b) { return a.X == b.X && a.Y == b.Y && a.Z == b.Z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (in Vector3i a, in Vector3i b) { return a.X != b.X || a.Y != b.Y || a.Z != b.Z; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly double GetSqrMagnitude () { return (long)X * X + (long)Y * Y + (long)Z * Z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly double GetMagnitude () { return Math.Sqrt((long)X * X + (long)Y * Y + (long)Z * Z); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector3d GetNormalized () {
            double sqrMag = (long)X * X + (long)Y * Y + (long)Z * Z;
            if (sqrMag == 0.0) {
                return new Vector3d(0.0, 0.0, 0.0);
            }
            double invMag = 1.0 / Math.Sqrt(sqrMag);
            return new Vector3d(X * invMag, Y * invMag, Z * invMag);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals (Vector3i other) { return X == other.X && Y == other.Y && Z == other.Z; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly bool Equals (object obj) { return obj is Vector3i v && X == v.X && Y == v.Y && Z == v.Z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode () { return HashCode.Combine(X, Y, Z); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString () { return $"X:{X}, Y:{Y}, Z:{Z}"; }

    }
}
