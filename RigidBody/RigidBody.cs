using QuarkPhysicsEngine.material;
using QuarkPhysicsEngine.Shapes;
using QuarkPhysicsEngine.Vec2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarkPhysicsEngine.rigidBody
{
    public class RigidBody
    {
        vector2 force;
        vector2 postition;
        vector2 velocity;

        float angularVelocity = 0;
        float torque = 0;
        float rotation = 0;


        float mass = 0;
        float imass = 0;
        float inertia = 0;
        float iinertia = 0;
        public Material material;

        public float InverseMass 
        {
            get
            {
                return imass;
            }
        }

        public float InverseInertia
        {
            get
            {
                return iinertia;
            }
        }

        public float Mass
        {
            get => mass;
            set
            {
                if (value <= 0)
                {
                    mass = 0;
                    imass = 0;
                }
                else
                {
                    mass = value;
                    imass = 1 / value;
                }
            }
        }

        public float Inertia
        {
            get => inertia;
            set
            {
                if (value <= 0)
                {
                    inertia = 0;
                    iinertia = 0;
                }
                else
                {
                    inertia = value;
                    iinertia = 1 / value;
                }
            }
        }

        public vector2 Force { get => force; set => force = value; }
        public vector2 Postition { get => postition; set => postition = value; }
        public vector2 Velocity { get => velocity; set => velocity = value; }
        public float AngularVelocity { get => angularVelocity; set => angularVelocity = value; }
        public float Torque { get => torque; set => torque = value; }
        public float Rotation { get => rotation; set => rotation = value; }

        public Shape shape;

        public void ApplyForce(vector2 force)
        {
            this.force += force;
        }

        public void ApplyImpulse(vector2 impulse, vector2 contact)
        {
            velocity += imass * impulse;

            angularVelocity += iinertia * Vector2.Cross(contact, impulse );
        }

}
}
