using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAppConsole.Entities
{
    public class Class2 : Class1
    {
        public Class2() : base(10)
        {
            // super(10);
        }

        public Class2(String data) : this(10)
        {

        }

        public Class2(int data)
        {

        }

        // Masquage
        public new void setInt(int monInt)
        {
            //base.setInt(monInt);
            this.MyProperty = monInt;
        }

        // Override avec virtual dans la mère
        public override int getInt()
        {
            return base.getInt();
        }

        public override void do1()
        {
            throw new NotImplementedException();
        }
    }
}
