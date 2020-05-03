using QuarkPhysicsEngine.Shapes;
using QuarkPhysicsEngine.Vec2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarkPhysicsEngine.AABB
{
    public class BoundingBox : Shape
    {
        public vector2 Size
        {
            get
            {
                return new vector2(Math.Abs(max.X - rigidBody.Postition.X),Math.Abs(max.Y - rigidBody.Postition.Y));
            }

            set
            {
                max = rigidBody.Postition + value;
            }
        }     
        public vector2 Position
        {
            get { return rigidBody.Postition; }
            set
            {
                vector2 TempSize = Size;
                rigidBody.Postition = value;
                max = rigidBody.Postition + TempSize;
            }
        }

        public vector2 Min { get => rigidBody.Postition; set => rigidBody.Postition = value; }
        public vector2 Max { get => max; set => max = value; }

        vector2 max;

        public override vector2 Center()
        {
            vector2 HalfSize = Size / 2;
            return Position + HalfSize;

        }

        public override BoundingBox GetAABB()
        {
            return this;
        }

        public override void CalculateMass(float Density)
        {
            float Width = Size.X;
            float Height = Size.Y;
            
            rigidBody.Mass = rigidBody.material.Density * Width * Height;
        }
    }
}
