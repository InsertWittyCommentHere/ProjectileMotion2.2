using Utility;
using Vector = Utility.Vector;

public class Program
{

    public static void Level1()
    {
        double gravityForce = 9.8;
        double springCoefficient = 0;
        double unstretchedSpringLength = 0;
        Engine World = new Engine(gravityForce, springCoefficient, unstretchedSpringLength, Level.ONE);

        double velocityMagnitude = 4;
        double angle = 45;
        Vector Position = new Vector(0, 0, 0);
        Vector Velocity = new Vector(velocityMagnitude * Math.Cos(angle * Math.PI/180), 0, velocityMagnitude * Math.Sin(angle * Math.PI/180));
        double Mass = 3;
        double DragCoefficient = 0;
        Projectile Projectile = new Projectile(Position, Velocity, Mass, DragCoefficient);
        World.addProjectile(Projectile);
        Console.WriteLine("Time (s)\tX (m)\t\tY (m)\t\tZ (m)\t\t Velocity (m/s)\t\t Acceleration (m/s^2)");

        double maxRunTime = 2;
        double deltaT = 0.001;
        World.SimulateWorld(deltaT, maxRunTime);
    }

    public static void Level2()
    {
        double gravityForce = 9.8;
        double springCoefficient = 0;
        double unstretchedSpringLength = 0;
        Engine World = new Engine(gravityForce, springCoefficient, unstretchedSpringLength, Level.TWO);

        double velocityMagnitude = 4;
        double angle = 45;
        Vector Position = new Vector(0, 0, 0);
        Vector Velocity = new Vector(velocityMagnitude * Math.Cos(angle * Math.PI / 180), 0, velocityMagnitude * Math.Sin(angle * Math.PI / 180));
        double Mass = 3;
        double DragCoefficient = 0.6;
        Projectile Projectile = new Projectile(Position, Velocity, Mass, DragCoefficient);
        World.addProjectile(Projectile);
        Console.WriteLine("Time (s)\tX (m)\t\tY (m)\t\tZ (m)\t\t Velocity (m/s)\t\t Acceleration (m/s^2)");

        double maxRunTime = 2;
        double deltaT = 0.001;
        World.SimulateWorld(deltaT, maxRunTime);
    }

    public static void Level3()
    {
        double gravityForce = 9.8;
        double springCoefficient = 9;
        double unstretchedSpringLength = 2;
        Engine World = new Engine(gravityForce, springCoefficient, unstretchedSpringLength, Level.THREE);

        Vector Position = new Vector(-1, 1, -1);
        Vector Velocity = new Vector(5, -1, -3);
        double Mass = 3;
        double DragCoefficient = 0.6;
        Projectile Projectile = new Projectile(Position, Velocity, Mass, DragCoefficient);
        World.addProjectile(Projectile);
        Console.WriteLine("Time (s)\tX (m)\t\tY (m)\t\tZ (m)\t\t Velocity (m/s)\t\t Acceleration (m/s^2)");

        double maxRunTime = 20;
        double deltaT = 0.01;

        World.SimulateWorld(deltaT, maxRunTime);
    }

    public static void Main(string[] args)
    {
        Level1();
        Console.WriteLine("\n\n\n");
        Level2();
        Console.WriteLine("\n\n\n");
        Level3();
    }
}
