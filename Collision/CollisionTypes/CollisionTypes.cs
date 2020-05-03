using QuarkPhysicsEngine.AABB;
using QuarkPhysicsEngine.Collision.manafold;
using QuarkPhysicsEngine.ShapeResolve;
using QuarkPhysicsEngine.Vec2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarkPhysicsEngine.Collision.CollisionTypes
{
    public class CollisionTypes
    {
        public static void BoundingBoxvsBoundingBox(Manafold manafold)
        {
            BoundingBox A = manafold.bodyA.shape.GetAABB();
            BoundingBox B = manafold.bodyB.shape.GetAABB();

            vector2 ABVector = B.Position - A.Position;

            vector2 AMid = A.Center();
            vector2 BMid = B.Center();

            float OverlapX = AMid.X + BMid.X - Math.Abs(ABVector.X);
            if(OverlapX > 0)
            {
                float OverlapY = AMid.Y + BMid.Y - Math.Abs(ABVector.Y);

                if(OverlapY > 0)
                {
                    if (OverlapX > OverlapY)
                    {
                        if (ABVector.X > 0)
                        {
                            manafold.Normal = new vector2(1, 0);
                        }
                        else
                        {
                            manafold.Normal = new vector2(-1, 0);
                        }
                        manafold.Penetration = OverlapX;
                    }
                    else
                    {
                        if (ABVector.Y > 0)
                        {
                            manafold.Normal = new vector2(0, 1);
                        }
                        else
                        {
                            manafold.Normal = new vector2(0, -1);
                        }
                        manafold.Penetration = OverlapY;
                    }
                }

            }

            //if ((A.Max.X < B.Min.X) || (A.Min.X > B.Max.X)) return;
            //if ((A.Max.Y < B.Min.Y) || (A.Min.Y > B.Max.Y)) return;
        }    
    }
}
