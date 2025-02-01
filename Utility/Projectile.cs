using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Projectile
    {
        public Vector Position { get; set; }
        public Vector Velocity { get; set; }
        public double Mass { get; set; }
        public Vector Acceleration { get; set; }
        public double DragCoefficient { get; set; }

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
