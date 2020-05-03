using QuarkPhysicsEngine.Collision.manafold;
using QuarkPhysicsEngine.GrowList;
using QuarkPhysicsEngine.rigidBody;
using QuarkPhysicsEngine.Vec2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarkPhysicsEngine.world
{
    public sealed class World
    {
        public static vector2 Gravity = new vector2(0,0);

        GrowList<RigidBody> bodys = new GrowList<RigidBody>();
        List<Manafold> collisions = new List<Manafold>();
        public void Step()
        {
            
        }
        public RigidBody getID (int ID)
        {
            return bodys.GetValue(ID);
        }
    }
}
