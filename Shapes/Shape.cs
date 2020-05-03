using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuarkPhysicsEngine.AABB;
using QuarkPhysicsEngine.rigidBody;
using QuarkPhysicsEngine.Vec2;

namespace QuarkPhysicsEngine.Shapes
{
    public abstract class Shape
    {
        
        internal RigidBody rigidBody;
        public abstract vector2 Center();
        public abstract BoundingBox GetAABB();
        public abstract void CalculateMass(float Density);

        public virtual void Initialize() { }
        public virtual void SetOrientation(float Radians) { }

    }
}
