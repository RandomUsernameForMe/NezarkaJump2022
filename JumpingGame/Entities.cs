using NezarkaBookstoreWeb;
using System;
using System.Drawing;

namespace JumpingPlatformGame
{

    class Entity
    {
        public virtual Color Color => Color.Black;
        public WorldPoint Location;

        public virtual void Update(Time sec) { }

    }
    class MovableEntity : Entity
    {
        public Move Horizontal;
        public MovableEntity()
        {
            Horizontal = new Move();
        }
        public override void Update(Time sec)
        {
            Physics.Move(sec, Horizontal.Speed, Horizontal.LowerBound.Meters, Horizontal.UpperBound.Meters, Location.X, false);
        }
    }

    class MovableJumpingEntity : MovableEntity
    {
        public Move Vertical;

        public MovableJumpingEntity()
        {
            Vertical = new Move();
        }
        public override void Update(Time sec)
        {
            Physics.Move(sec, Horizontal.Speed, Horizontal.LowerBound.Meters, Horizontal.UpperBound.Meters, Location.X, false);
            Physics.Move(sec, Vertical.Speed, Vertical.LowerBound.Meters, Vertical.UpperBound.Meters, Location.Y, true);
        }
    }

    class CustomerEntity : MovableEntity
    {
        int years;
        string name;
        public override Color Color
        {
            get
            {
                if (years == -1) return Color.Gold;
                switch (years)
                {
                    case 0:
                        return Color.Black;
                    case 1:
                        return Color.DarkRed;
                    case 2:
                        return Color.Red;
                    case 3:
                        return Color.IndianRed;
                    default:
                        return Color.OrangeRed;
                }
            }
        }

        public CustomerEntity(Customer customer)
        {
            name = customer.ToString();
            if (customer.DateJoined == null)
            {
                years = -1;
                return;
            }
            TimeSpan? timespan = DateTime.Now - customer.DateJoined;
            years = (int)(timespan.Value.TotalDays) / 365;
        }

    }
}