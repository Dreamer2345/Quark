using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarkPhysicsEngine.Vec2
{
    public struct vector2 : IEquatable<vector2>
    {
        public float X;
        public float Y;

        public float MagnitudeSquared
        {
            get
            {
                return (X * X) + (Y * Y);
            }
        }
        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(Magnitude);
            }
        }


        public void Set(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public vector2(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public vector2(float Mag)
        {
            this.X = Mag;
            this.Y = Mag;
        }

        public static vector2 operator +(vector2 a, vector2 b)
        {
            return new vector2(a.X + b.X, a.Y + b.Y);
        }

        public static vector2 operator -(vector2 a)
        {
            a.X = -a.X;
            a.Y = -a.Y;
            return a;
        }

        public static vector2 operator -(vector2 a, vector2 b)
        {
            return new vector2(a.X - b.X, a.Y - b.Y);
        }

        public static vector2 operator *(vector2 a, vector2 b)
        {
            return new vector2(a.X * b.X, a.Y * b.Y);
        }

        public static vector2 operator /(vector2 a, vector2 b)
        {
            return new vector2(a.X / b.X, a.Y / b.Y);
        }

        public static vector2 operator *(vector2 a, float b)
        {
            return new vector2(a.X * b, a.Y * b);
        }

        public static vector2 operator *(float b, vector2 a)
        {
            return new vector2(a.X * b, a.Y * b);
        }

        public static vector2 operator /(vector2 a, float b)
        {
            return new vector2(a.X / b, a.Y / b);
        }


        public bool Equals(vector2 other)
        {
            return (this.X == other.X) && (this.Y == other.Y);
        }

        public void Normalize()
        {
            float mag = Magnitude;
            if (mag > float.Epsilon) 
            { 
                X /= mag;
                Y /= mag;
            }
        }
    }

    public static class Vector2
    {
        public static float Dot(vector2 a, vector2 b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        public static float Cross(vector2 a, vector2 b)
        {
            return a.X * b.Y + a.Y * b.X;
        }

        public static vector2 Cross(vector2 a, float b)
        {
            return new vector2(a.Y * b, a.X * -b);
        }

        public static vector2 Cross(float a, vector2 b)
        {
            return new vector2(b.Y * -a, b.X * a);
        }

        public static float DistanceEuclid(vector2 a, vector2 b)
        {
            return (float)Math.Sqrt(Math.Pow(a.X - b.X,2) + Math.Pow(a.Y - b.Y,2));
        }

        public static float DistanceManhattan(vector2 a, vector2 b)
        {
            return (float)Math.Abs((a.X - b.X) + (a.Y - b.Y));
        }
    }
}
