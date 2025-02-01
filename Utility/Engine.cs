using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Engine
    {
        private double Time { get; set; }
        private double GravityForce { get; set; }

        private Vector NetForce { get; set; }

        private double springCoefficient;

        private double unstretchedSpringLength;
        private List<Projectile> Projectiles;

        public Engine(double gravityForce, double springCoefficient, double unstretchedSpringLength)
        {
            Projectiles = new List<Projectile>();
            GravityForce = gravityForce;
            NetForce = new Vector(0, 0, 0);
            this.springCoefficient = springCoefficient;
            this.unstretchedSpringLength = unstretchedSpringLength;
            Time = 0;
        }
        
        public void addProjectile(Projectile projectile)
        {
            Projectiles.Add(projectile);
        }
        public void removeProjectile(Projectile projectile)
        {
            Projectiles.Remove(projectile);
        }
        public Projectile getProjectile(int id)
        {
            return Projectiles[id];
        }

        public Vector CalculateForce(Projectile projectile)
        {
            Vector airResistanceForce = -1 * projectile.Velocity.Magnitude * projectile.DragCoefficient * projectile.Velocity;
            Vector gravityForce = new Vector(0, 0, -GravityForce * projectile.Mass);
            Vector springForce = new Vector(0, 0, 0);
            if (springCoefficient != 0) { 
                springForce = -springCoefficient * (projectile.Position.Magnitude - unstretchedSpringLength) * projectile.Position.MakeUnitVector();
            }
            NetForce = airResistanceForce + springForce + gravityForce;
            return NetForce;
        }
        
        public void Tick(Projectile projectile, double tickLength)
        {
            NetForce = CalculateForce(projectile);
            projectile.Move(tickLength, NetForce);
            Time += tickLength;
            

        }

        public void SimulateWorld(Projectile projectile, double tickLength, double runTime)
        {
            while (Time < runTime)
            {
                Tick(projectile, tickLength);
                Console.WriteLine($"{Math.Round(Time, 3)}\t\t{Math.Round(projectile.Position.X, 4)}\t\t{Math.Round(projectile.Position.Y, 4)}" +
                $"\t\t{Math.Round(projectile.Position.Z, 4)}\t\t{Math.Round(projectile.Velocity.Magnitude, 4)}\t\t{Math.Round(projectile.Acceleration.Magnitude, 4)}");
            }
        }




    }
}
