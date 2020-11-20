using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_List__Assign5
{
    class ShoppingItem
    {
        //class Instance variables for object data
        private string description;// Name or descripion of the item
        private double amount;     //Quantity of the item
        private UnitTypes unit;    // Measurement unit of the item

        //Constructor creating a shoppingItem with all specified inputs
        public ShoppingItem(string name, double amount, UnitTypes unit)
        {
            this.description = name;
            this.amount = amount;
            this.unit = unit;
        }

        //Default constructor-make chain call
        public ShoppingItem(): this("unknown", 1.0, UnitTypes.piece)
        {

        }
        //Constructor with parameter
        public ShoppingItem(string description): this(description,1.0, UnitTypes.piece)
        {

        }
        public ShoppingItem(string description, double amount): this(description, amount, UnitTypes.piece)
        {

        }
        //property to get/set the Unit
        public UnitTypes Unit
        {
            get { return unit; }
            set
            {
                //check if the value is defined in the enum
                if (Enum.IsDefined(typeof(UnitTypes), value))
                    unit = value;
            }
        }
        //property  to get/set Description
            public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    description = value;
            }
        }
           // property to get/set the amount
           public double Amount
        {
            get
            {
                return amount;
            }
            set
            {   // checking if amout is not less than zero
                if (value >= 0)
                    amount = value;
            }

        }
        public override string ToString()
        {
            string textout = string.Empty;
            textout = $"{description,-45} {amount,6:f2} {unit,-6}";
            return textout;
        }



    }
}
