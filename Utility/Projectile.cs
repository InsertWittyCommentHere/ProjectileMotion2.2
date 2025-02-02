using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Projectile
    {
        public Vector Position { get; private set; }
        public Vector Velocity { get; private set; }
        public double Mass { get; private set; }
        public Vector Acceleration { get; private set; }
        public double DragCoefficient { get; private set; }

        public Projectile(Vector position, Vector velocity, double mass, double dragCoefficient)
        {
            Position = position;
            Velocity = velocity;
            Mass = mass;
            DragCoefficient = dragCoefficient;
            Acceleration = new Vector(0, 0, 0);
        }
         
        public void Move(double timeStep, Vector netForce)
        {
            Acceleration = netForce / Mass;
            Velocity = Velocity + Acceleration * timeStep;
            Position = Position + Velocity * timeStep;
        }


    }
}
