using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProjectGreen_Repo
{
    enum EngineType { thermal, hybrid, electric };
    public class Car
    {
        public ushort Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Propulsion { get; set; }
        public double Collision { get; set; }
        public double Comprehensive { get; set; }
        public double PersonalInjury { get; set; }

        public Car() { }
        public Car(ushort id, string make, string model, string propulsion, double collision, double comprehensive, double injury)
        {
            Id = id;
            Make = make;
            Model = model;
            Propulsion = propulsion;
            Collision = collision;
            Comprehensive = comprehensive;
            PersonalInjury = injury;
        }
    }
    
}
