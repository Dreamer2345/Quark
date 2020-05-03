using QuarkPhysicsEngine.rigidBody;
using QuarkPhysicsEngine.Vec2;
using QuarkPhysicsEngine.ShapeResolve;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuarkPhysicsEngine.world;

namespace QuarkPhysicsEngine.Collision.manafold
{
    public class Manafold
    {
        const float AllowedPenetration = 0.05f;
        const float CorrectionPercentage = 0.45f;

        public RigidBody bodyA;
        public RigidBody bodyB;

        public Manafold(RigidBody A, RigidBody B)
        {
            bodyA = A;
            bodyB = B;
        }



        public float Penetration;
        public vector2 Normal;
        public List<vector2> Contacts;
        public float CombinedRestitution;
        public float DynamicFriction;
        public float StaticFriction;


        public void Solve()
        {
            CollisionDispachCollection.RunDispach(this, bodyA.shape, bodyB.shape);
        }
        public void Initialise(float Delta)
        {
            CombinedRestitution = Math.Min(bodyA.material.Restitution, bodyB.material.Restitution);
            StaticFriction = (float)Math.Sqrt(bodyA.material.StaticFriction * bodyA.material.StaticFriction);
            DynamicFriction = (float)Math.Sqrt(bodyA.material.DynamicFriction * bodyA.material.DynamicFriction);


            for(int i = 0; i < Contacts.Count; i++)
            {
                vector2 rada = Contacts[i] - bodyA.Postition;
                vector2 radb = Contacts[i] - bodyB.Postition;

                vector2 rev = bodyB.Velocity + Vector2.Cross(bodyB.AngularVelocity, radb) - bodyB.Velocity - Vector2.Cross(bodyA.AngularVelocity, rada);


                if (rev.MagnitudeSquared > (Delta * World.Gravity).MagnitudeSquared + float.Epsilon)
                {
                    CombinedRestitution = 0;
                }
            }

        }
        public void ApplyImpulse(float Delta)
        {
            if ((bodyA.Mass + bodyB.Mass) == 0)
            {
                InfiniteMassCorrection();
                return;
            }



            for (int i = 0; i < Contacts.Count; i++)
            {
                vector2 rada = Contacts[i] - bodyA.Postition;
                vector2 radb = Contacts[i] - bodyB.Postition;

                vector2 rev = bodyB.Velocity + Vector2.Cross(bodyB.AngularVelocity, radb) - bodyB.Velocity - Vector2.Cross(bodyA.AngularVelocity, rada);

                float ContactVelocity = Vector2.Dot(rev, Normal);

                if (ContactVelocity > 0)
                    return;
                ///Apply Impulse
                float radaCrossN = Vector2.Cross(rada, Normal);
                float radbCrossN = Vector2.Cross(radb, Normal);
                float InverseMassSum = bodyA.Mass + bodyB.Mass + (float)Math.Sqrt(radaCrossN) * bodyA.InverseInertia + (float)Math.Sqrt(radbCrossN) * bodyB.InverseInertia;

                float ImpulseScaler = -(1 + CombinedRestitution) * ContactVelocity;
                ImpulseScaler = (ImpulseScaler / InverseMassSum) / (float)Contacts.Count;
                vector2 Impulse = Normal * ImpulseScaler;

                bodyA.ApplyImpulse(-Impulse, rada);
                bodyB.ApplyImpulse(Impulse, radb);

                ///Apply Friction Impulse
                vector2 Tangent = rev - (Normal * Vector2.Dot(rev, Normal));
                Tangent.Normalize();

                float TangentScalar = -Vector2.Dot(rev, Tangent);
                TangentScalar = (TangentScalar / InverseMassSum) / (float)Contacts.Count;
                if (TangentScalar < 0.00f)
                    return;

                vector2 TangentImpulse;
                if (Math.Abs(TangentScalar) < ImpulseScaler * StaticFriction)
                    TangentImpulse = Tangent * TangentScalar;
                else
                    TangentImpulse = Tangent * -ImpulseScaler * DynamicFriction;

                bodyA.ApplyImpulse(-TangentImpulse, rada);
                bodyB.ApplyImpulse(TangentImpulse, radb);
            }
        }
        public void PositionCorrection()
        {
            vector2 Correction = (Math.Max(Penetration - AllowedPenetration, 0) / (bodyA.InverseMass + bodyB.InverseMass)) * Normal * CorrectionPercentage;
            bodyA.Postition -= Correction * bodyA.InverseMass;
            bodyB.Postition += Correction * bodyB.InverseMass;
        }
        public void InfiniteMassCorrection()
        {
            bodyA.Velocity.Set(0, 0);
            bodyB.Velocity.Set(0, 0);
        }

    }
}
