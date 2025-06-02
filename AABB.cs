using System;
using System.Runtime.CompilerServices;

namespace OsmiumEngine.Numerics {

    public readonly struct AABB : IEquatable<AABB> {

        public readonly double MinX;
        public readonly double MinY;
        public readonly double MinZ;
        public readonly double MaxX;
        public readonly double MaxY;
        public readonly double MaxZ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AABB (in double minX, in double minY, in double minZ, in double maxX, in double maxY, in double maxZ) {
            MinX = Math.Min(minX, maxX);
            MinY = Math.Min(minY, maxY);
            MinZ = Math.Min(minZ, maxZ);
            MaxX = Math.Max(minX, maxX);
            MaxY = Math.Max(minY, maxY);
            MaxZ = Math.Max(minZ, maxZ);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private AABB (in double minX, in double minY, in double minZ, in double maxX, in double maxY, in double maxZ, in bool _) {
            MinX = minX;
            MinY = minY;
            MinZ = minZ;
            MaxX = maxX;
            MaxY = maxY;
            MaxZ = maxZ;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (in AABB a, in AABB b) {
            return
                a.MinX == b.MinX &&
                a.MinY == b.MinY &&
                a.MinZ == b.MinZ &&
                a.MaxX == b.MaxX &&
                a.MaxY == b.MaxY &&
                a.MaxZ == b.MaxZ;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (in AABB a, in AABB b) {
            return
                a.MinX != b.MinX ||
                a.MinY != b.MinY ||
                a.MinZ != b.MinZ ||
                a.MaxX != b.MaxX ||
                a.MaxY != b.MaxY ||
                a.MaxZ != b.MaxZ;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AABB UnsafeCreate (in double minX, in double minY, in double minZ, in double maxX, in double maxY, in double maxZ) {
            return new AABB(minX, minY, minZ, maxX, maxY, maxZ, false);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AABB UnsafeCreateFromCenterAndSize (in Vector3d center, in Vector3d size) {
            double halfX = size.X * 0.5;
            double halfY = size.Y * 0.5;
            double halfZ = size.Z * 0.5;
            return new AABB(
                center.X - halfX,
                center.Y - halfY,
                center.Z - halfZ,
                center.X + halfX,
                center.Y + halfY,
                center.Z + halfZ,
                false);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AABB UnsafeCreateFromTwoPoint (in Vector3d a, in Vector3d b) {
            return new AABB(a.X, a.Y, a.Z, b.X, b.Y, b.Z, false);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AABB CreateFromCenterAndSize (in Vector3d center, in Vector3d size) {
            double halfX = Math.Abs(size.X) * 0.5;
            double halfY = Math.Abs(size.Y) * 0.5;
            double halfZ = Math.Abs(size.Z) * 0.5;
            return new AABB(
                center.X - halfX,
                center.Y - halfY,
                center.Z - halfZ,
                center.X + halfX,
                center.Y + halfY,
                center.Z + halfZ,
                false);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AABB CreateFromTwoPoint (in Vector3d a, in Vector3d b) {
            return new AABB(
                Math.Min(a.X, b.X),
                Math.Min(a.Y, b.Y),
                Math.Min(a.Z, b.Z),
                Math.Max(a.X, b.X),
                Math.Max(a.Y, b.Y),
                Math.Max(a.Z, b.Z),
                false);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals (AABB other) {
            return
                MinX == other.MinX &&
                MinY == other.MinY &&
                MinZ == other.MinZ &&
                MaxX == other.MaxX &&
                MaxY == other.MaxY &&
                MaxZ == other.MaxZ;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals (in AABB other) {
            return
                MinX == other.MinX &&
                MinY == other.MinY &&
                MinZ == other.MinZ &&
                MaxX == other.MaxX &&
                MaxY == other.MaxY &&
                MaxZ == other.MaxZ;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly bool Equals (object obj) {
            return
                obj is AABB v &&
                MinX == v.MinX &&
                MinY == v.MinY &&
                MinZ == v.MinZ &&
                MaxX == v.MaxX &&
                MaxY == v.MaxY &&
                MaxZ == v.MaxZ;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode () { return HashCode.Combine(MinX, MinY, MinZ, MaxX, MaxY, MaxZ); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString () { return $"({MinX}, {MinY}, {MinZ},{MaxX}, {MaxY}, {MaxZ})"; }

    }
}
