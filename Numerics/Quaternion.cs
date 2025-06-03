using System;
using System.Runtime.CompilerServices;

namespace OsmiumEngine.Numerics {

    public readonly struct Quaternion : IEquatable<Quaternion> {

        private const double DegreesToRadians = Math.PI / 180.0;

        public readonly double W;
        public readonly double X;
        public readonly double Y;
        public readonly double Z;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Quaternion (double w, double x, double y, double z) { W = w; X = x; Y = y; Z = z; }

        public static readonly Quaternion Identity = new Quaternion(1.0, 0.0, 0.0, 0.0);
        public static readonly Quaternion I = new Quaternion(0.0, 1.0, 0.0, 0.0);
        public static readonly Quaternion J = new Quaternion(0.0, 0.0, 1.0, 0.0);
        public static readonly Quaternion K = new Quaternion(0.0, 0.0, 0.0, 1.0);

        public static Quaternion FromEulerZYX (double zAngleDeg, double yAngleDeg, double xAngleDeg) {
            double xRad = xAngleDeg * DegreesToRadians;
            double yRad = yAngleDeg * DegreesToRadians;
            double zRad = zAngleDeg * DegreesToRadians;
            double sinXHalf = Math.Sin(xRad * 0.5);
            double cosXHalf = Math.Cos(xRad * 0.5);
            double sinYHalf = Math.Sin(yRad * 0.5);
            double cosYHalf = Math.Cos(yRad * 0.5);
            double sinZHalf = Math.Sin(zRad * 0.5);
            double cosZHalf = Math.Cos(zRad * 0.5);
            double w = cosZHalf * cosXHalf * cosYHalf + sinZHalf * sinXHalf * sinYHalf;
            double x = cosZHalf * sinXHalf * cosYHalf - sinZHalf * cosXHalf * sinYHalf;
            double y = cosZHalf * cosXHalf * sinYHalf + sinZHalf * sinXHalf * cosYHalf;
            double z = sinZHalf * cosXHalf * cosYHalf - cosZHalf * sinXHalf * sinYHalf;
            return new Quaternion(w, x, y, z);
        }
        public static Quaternion FromEulerZXY (double zAngleDeg, double xAngleDeg, double yAngleDeg) {
            double xRad = xAngleDeg * DegreesToRadians;
            double yRad = yAngleDeg * DegreesToRadians;
            double zRad = zAngleDeg * DegreesToRadians;
            double sinXHalf = Math.Sin(xRad * 0.5);
            double cosXHalf = Math.Cos(xRad * 0.5);
            double sinYHalf = Math.Sin(yRad * 0.5);
            double cosYHalf = Math.Cos(yRad * 0.5);
            double sinZHalf = Math.Sin(zRad * 0.5);
            double cosZHalf = Math.Cos(zRad * 0.5);
            double w = cosYHalf * cosXHalf * cosZHalf + sinYHalf * sinXHalf * sinZHalf;
            double x = cosYHalf * sinXHalf * cosZHalf - sinYHalf * cosXHalf * sinZHalf;
            double y = sinYHalf * cosXHalf * cosZHalf + cosYHalf * sinXHalf * sinZHalf;
            double z = cosYHalf * cosXHalf * sinZHalf - sinYHalf * sinXHalf * cosZHalf;
            return new Quaternion(w, x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly double GetSqrNorm () { return W * W + X * X + Y * Y + Z * Z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly double GetNorm () { return Math.Sqrt(W * W + X * X + Y * Y + Z * Z); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Quaternion GetConjugate () { return new Quaternion(W, -X, -Y, -Z); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals (Quaternion other) { return W == other.W && X == other.X && Y == other.Y && Z == other.Z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Quaternion GetInverse () {
            double normSq = W * W + X * X + Y * Y + Z * Z;
            if (normSq == 0) {
                return new Quaternion(1.0, 0.0, 0.0, 0.0);
            }
            double invNormSq = 1.0 / normSq;
            return new Quaternion(W * invNormSq, -X * invNormSq, -Y * invNormSq, -Z * invNormSq);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Quaternion GetNormalized () {
            double norm = Math.Sqrt(W * W + X * X + Y * Y + Z * Z);
            if (norm == 0) {
                return Identity;
            }
            double invNorm = 1.0 / norm;
            return new Quaternion(W * invNorm, X * invNorm, Y * invNorm, Z * invNorm);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion operator * (in Quaternion a, in Quaternion b) {
            return new Quaternion(
                a.W * b.W - a.X * b.X - a.Y * b.Y - a.Z * b.Z,
                a.W * b.X + a.X * b.W + a.Y * b.Z - a.Z * b.Y,
                a.W * b.Y - a.X * b.Z + a.Y * b.W + a.Z * b.X,
                a.W * b.Z + a.X * b.Y - a.Y * b.X + a.Z * b.W);
        }
        public static Vector3d operator * (in Quaternion rotation, in Vector3d point) {
            double x2 = rotation.X * 2.0;
            double y2 = rotation.Y * 2.0;
            double z2 = rotation.Z * 2.0;
            double xx = rotation.X * x2;
            double yy = rotation.Y * y2;
            double zz = rotation.Z * z2;
            double xy = rotation.X * y2;
            double xz = rotation.X * z2;
            double yz = rotation.Y * z2;
            double wx = rotation.W * x2;
            double wy = rotation.W * y2;
            double wz = rotation.W * z2;
            return new Vector3d(
                (1.0 - (yy + zz)) * point.X + (xy - wz) * point.Y + (xz + wy) * point.Z,
                (xy + wz) * point.X + (1.0 - (xx + zz)) * point.Y + (yz - wx) * point.Z,
                (xz - wy) * point.X + (yz + wx) * point.Y + (1.0 - (xx + yy)) * point.Z);
        }
        public static Quaternion operator / (in Quaternion a, in Quaternion bDivisor) {
            double normSqr = bDivisor.W * bDivisor.W + bDivisor.X * bDivisor.X + bDivisor.Y * bDivisor.Y + bDivisor.Z * bDivisor.Z;
            if (normSqr == 0) {
                return Identity;
            }
            double invNormSqr = 1.0 / normSqr;
            double tempW = bDivisor.W * invNormSqr;
            double tempX = -bDivisor.X * invNormSqr;
            double tempY = -bDivisor.Y * invNormSqr;
            double tempZ = -bDivisor.Z * invNormSqr;
            return new Quaternion(
                a.W * tempW - a.X * tempX - a.Y * tempY - a.Z * tempZ,
                a.W * tempX + a.X * tempW + a.Y * tempZ - a.Z * tempY,
                a.W * tempY - a.X * tempZ + a.Y * tempW + a.Z * tempX,
                a.W * tempZ + a.X * tempY - a.Y * tempX + a.Z * tempW);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (in Quaternion a, in Quaternion b) { return a.W == b.W && a.X == b.X && a.Y == b.Y && a.Z == b.Z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (in Quaternion a, in Quaternion b) { return a.W != b.W || a.X != b.X || a.Y != b.Y || a.Z != b.Z; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly bool Equals (object obj) { return obj is Quaternion other && W == other.W && X == other.X && Y == other.Y && Z == other.Z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode () { return HashCode.Combine(W, X, Y, Z); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString () { return $"W:{W}, X:{X}, Y:{Y}, Z:{Z}"; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly UnityEngine.Quaternion ToUnityQuaternion () { return new UnityEngine.Quaternion((float)X, (float)Y, (float)Z, (float)W); }

    }
}
