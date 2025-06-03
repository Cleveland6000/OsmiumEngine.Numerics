using System;
using System.Runtime.CompilerServices;

namespace OsmiumEngine.Numerics {

    public readonly struct AABBd : IEquatable<AABBd> {

        public readonly double MinX;
        public readonly double MinY;
        public readonly double MinZ;
        public readonly double MaxX;
        public readonly double MaxY;
        public readonly double MaxZ;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AABBd (double minX, double minY, double minZ, double maxX, double maxY, double maxZ) {
            MinX = Math.Min(minX, maxX);
            MinY = Math.Min(minY, maxY);
            MinZ = Math.Min(minZ, maxZ);
            MaxX = Math.Max(minX, maxX);
            MaxY = Math.Max(minY, maxY);
            MaxZ = Math.Max(minZ, maxZ);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private AABBd (double minX, double minY, double minZ, double maxX, double maxY, double maxZ, bool _) {
            MinX = minX;
            MinY = minY;
            MinZ = minZ;
            MaxX = maxX;
            MaxY = maxY;
            MaxZ = maxZ;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (in AABBd a, in AABBd b) {
            return
                a.MinX == b.MinX &&
                a.MinY == b.MinY &&
                a.MinZ == b.MinZ &&
                a.MaxX == b.MaxX &&
                a.MaxY == b.MaxY &&
                a.MaxZ == b.MaxZ;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (in AABBd a, in AABBd b) {
            return
                a.MinX != b.MinX ||
                a.MinY != b.MinY ||
                a.MinZ != b.MinZ ||
                a.MaxX != b.MaxX ||
                a.MaxY != b.MaxY ||
                a.MaxZ != b.MaxZ;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AABBd UnsafeCreate (double minX, double minY, double minZ, double maxX, double maxY, double maxZ) {
            return new AABBd(minX, minY, minZ, maxX, maxY, maxZ, false);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AABBd UnsafeCreateFromCenterAndSize (in Vector3d center, in Vector3d size) {
            double halfX = size.X * 0.5;
            double halfY = size.Y * 0.5;
            double halfZ = size.Z * 0.5;
            return new AABBd(
                center.X - halfX,
                center.Y - halfY,
                center.Z - halfZ,
                center.X + halfX,
                center.Y + halfY,
                center.Z + halfZ,
                false);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AABBd UnsafeCreateFromTwoPoint (in Vector3d a, in Vector3d b) {
            return new AABBd(a.X, a.Y, a.Z, b.X, b.Y, b.Z, false);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AABBd CreateFromCenterAndSize (in Vector3d center, in Vector3d size) {
            double halfX = Math.Abs(size.X) * 0.5;
            double halfY = Math.Abs(size.Y) * 0.5;
            double halfZ = Math.Abs(size.Z) * 0.5;
            return new AABBd(
                center.X - halfX,
                center.Y - halfY,
                center.Z - halfZ,
                center.X + halfX,
                center.Y + halfY,
                center.Z + halfZ,
                false);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AABBd CreateFromTwoPoint (in Vector3d a, in Vector3d b) {
            return new AABBd(
                Math.Min(a.X, b.X),
                Math.Min(a.Y, b.Y),
                Math.Min(a.Z, b.Z),
                Math.Max(a.X, b.X),
                Math.Max(a.Y, b.Y),
                Math.Max(a.Z, b.Z),
                false);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals (AABBd other) {
            return
                MinX == other.MinX &&
                MinY == other.MinY &&
                MinZ == other.MinZ &&
                MaxX == other.MaxX &&
                MaxY == other.MaxY &&
                MaxZ == other.MaxZ;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals (in AABBd other) {
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
                obj is AABBd aabb &&
                MinX == aabb.MinX &&
                MinY == aabb.MinY &&
                MinZ == aabb.MinZ &&
                MaxX == aabb.MaxX &&
                MaxY == aabb.MaxY &&
                MaxZ == aabb.MaxZ;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode () { return HashCode.Combine(MinX, MinY, MinZ, MaxX, MaxY, MaxZ); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString () { return $"({MinX}, {MinY}, {MinZ},{MaxX}, {MaxY}, {MaxZ})"; }

    }
}
