using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAppConsole.Entities
{
    public abstract class Class1
    {
        #region Java
        private int monInt;

        public void setInt(int monInt) {
            this.monInt = monInt;
        }

        public virtual int getInt() {
            return this.monInt;
        }
        #endregion

        #region C# property full snippet (propfull)
        private int myVar;

        public int MyProperty
        {
            get { return this.myVar; }
            set {
                if (value > 0)
                {
                    this.myVar = value;
                }
                else
                {
                    this.myVar = 0;
                }
            }
        }
        #endregion

        #region Auto property snippet (prop)
        public int MyProperty1 { get; }
        #endregion

        #region Constante
        //public final static String MA_CONSTANTE => Java
        public const String MA_CONSTANTE = "";
        //public static String MA_CONSTANTE1 = "";
        #endregion

        #region Constructors
        public Class1()
        {
        }

        public Class1(int monInt)
        {
            this.MyProperty = monInt;
        }
        #endregion

        #region Variables
        int int1 = 0;
        int? nullableInt = null;

        bool monBool = true;
        bool? nullableBool = null;

        String monString = null;
        #endregion

        public abstract void do1();
    }
}
