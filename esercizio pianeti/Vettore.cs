﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_pianeti
{
    internal class Vettore
    {
        public readonly double _x;
        public readonly double _y;
        public double X { get { return _x; } }
        public double Y { get { return _y; } }
        public Vettore()
        {

        }
        public Vettore(double x, double y)
        {
            _x = x;
            _y = y;
        }
        public override string ToString()
        {
            return string.Format("{0};{1}", X, Y);
        }
        public static Vettore Parse(string s)
        {
            String[] parts = s.Split(';');
            return new Vettore(double.Parse(parts[0]), double.Parse(parts[1]));
        }
        public static bool TryParse(string s, out Vettore v)
        {
            try
            {
                v = Vettore.Parse(s);
                return true;
            }
            catch
            {
                v = null;
                return false;


            }

        }
        public static Vettore operator +(Vettore v1, Vettore v2)
        {
            return new Vettore(v1.X + v2.X, v1.Y + v2.Y);
        }
        public static Vettore operator -(Vettore v1, Vettore v2)
        {
            return new Vettore(v1.X - v2.X, v1.Y - v2.Y);
        }
        public static double operator *(Vettore v1, Vettore v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }
        public static Vettore operator *(Vettore v1, double a)
        {
            return new Vettore(v1.X * a, v1.Y * a);
        }
        public static Vettore operator *(double a, Vettore v1)
        {
            return new Vettore(a * v1.X, a * v1.Y);
        }
        public static Vettore operator /(Vettore v1, double a)
        {
            return new Vettore(v1.X * (1 / a), v1.Y * (1 / a));
        }
        public static Vettore operator +(Vettore v1)
        {
            return new Vettore(v1.X, v1.Y);
        }
        public static Vettore operator -(Vettore v1)
        {

            return new Vettore(-v1.X, -v1.Y);

        }
        public static bool operator ==(Vettore v1, Vettore v2)
        {
            if (object.ReferenceEquals(v1, null))
            {
                return object.ReferenceEquals(v2, null);

            }
            else if (object.ReferenceEquals(v2, null))
            {
                return false;
            }
            else
            {
                return v1.X == v2.X && v1.Y == v2.Y;
            }
        }
        public static bool operator !=(Vettore v1, Vettore v2)
        {
            return !(v1 == v2);
        }
        public double Modulo()
        {
            return Math.Sqrt(Math.Pow(2, this.X) + Math.Pow(2, this.Y)); 
        }

        public  Vettore versore()
        {
            return this / this.Modulo();
        }

        public Vettore distanza(Vettore v2)
        {
            if (v2.Modulo() > this.Modulo())
                return v2 - this;
            else
                return this -v2;
        }

    }
}
