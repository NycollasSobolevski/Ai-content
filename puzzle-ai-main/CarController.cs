using System;
using System.Drawing;

public class CarController
{
    public CarController(float x0, float y0)
    {
        this.Car = new Car(x0, y0)
        {
            Color = Color.FromArgb(
                Random.Shared.Next(255),
                Random.Shared.Next(255),
                Random.Shared.Next(255)
            )
        };
        this.Gene = new byte[256];
        Random.Shared.NextBytes(this.Gene);
    }
    public CarController(float x0, float y0, byte[] genes)
    {
        this.Car = new Car(x0, y0)
        {
            Color = Color.FromArgb(
                Random.Shared.Next(255),
                Random.Shared.Next(255),
                Random.Shared.Next(255)
            )
        };
        this.Gene = genes;
    }

    public Car Car { get; set; }
    public byte[] Gene { get; set; }

    public void Control()
    {
        Car.StartAccelerate();
        Car.Move(-0.001f);
        Car.TurnLeft();
    }

    public float FitnessFunction()
    {
        // ??
        return 0f;
    }
}