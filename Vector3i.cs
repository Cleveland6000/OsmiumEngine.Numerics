using System;
using System.Runtime.CompilerServices;

namespace OsmiumEngine {

    public readonly struct Vector3i : IEquatable<Vector3i> {

        public readonly int x;
        public readonly int y;
        public readonly int z;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3i (int x, int y, int z) { this.x = x; this.y = y; this.z = z; }

        public static readonly Vector3i Zero = new Vector3i(0, 0, 0);
        public static readonly Vector3i UnitX = new Vector3i(1, 0, 0);
        public static readonly Vector3i UnitY = new Vector3i(0, 1, 0);
        public static readonly Vector3i UnitZ = new Vector3i(0, 0, 1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector3d (in Vector3i v) { return new Vector3d(v.x, v.y, v.z); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i operator + (in Vector3i a, in Vector3i b) { return new Vector3i(a.x + b.x, a.y + b.y, a.z + b.z); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i operator - (in Vector3i a, in Vector3i b) { return new Vector3i(a.x - b.x, a.y - b.y, a.z - b.z); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i operator - (in Vector3i a) { return new Vector3i(-a.x, -a.y, -a.z); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i operator * (in Vector3i a, in int b) { return new Vector3i(a.x * b, a.y * b, a.z * b); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3i operator * (in int b, in Vector3i a) { return new Vector3i(a.x * b, a.y * b, a.z * b); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3d operator * (in Vector3i a, in double b) { return new Vector3d(a.x * b, a.y * b, a.z * b); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3d operator * (in double b, in Vector3i a) { return new Vector3d(a.x * b, a.y * b, a.z * b); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3d operator / (in Vector3i a, in double b) { return new Vector3d(a.x / b, a.y / b, a.z / b); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (in Vector3i a, in Vector3i b) { return a.x == b.x && a.y == b.y && a.z == b.z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (in Vector3i a, in Vector3i b) { return a.x != b.x || a.y != b.y || a.z != b.z; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals (Vector3i other) { return x == other.x && y == other.y && z == other.z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals (in Vector3i other) { return x == other.x && y == other.y && z == other.z; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly bool Equals (object obj) { return obj is Vector3i v && x == v.x && y == v.y && z == v.z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode () { return HashCode.Combine(x, y, z); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString () { return $"({x}, {y}, {z})"; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly double GetSqrMagnitude () { return (double)x * x + (double)y * y + (double)z * z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly double GetMagnitude () { return Math.Sqrt((double)x * x + (double)y * y + (double)z * z); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector3d GetNormalized () {
            double sqrMag = (double)x * x + (double)y * y + (double)z * z;
            if (sqrMag > 0.0) {
                double invMag = 1.0 / Math.Sqrt(sqrMag);
                return new Vector3d(x * invMag, y * invMag, z * invMag);
            } else {
                return new Vector3d(0.0, 0.0, 0.0);
            }
        }
    }
}
