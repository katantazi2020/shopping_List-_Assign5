using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_List__Assign5
{
    
    class ItemManager
    {
        // Declare a list object to hold shopping items
        private List<ShoppingItem> itemList;

        //Constructor of the ItemManager class
        public ItemManager()
        {
            itemList = new List<ShoppingItem>();
        }
        //The method finds and returns the shoppingitem object
        // in the list itemList based on the index of the of
        //which it validates first
        public ShoppingItem GetItem(int index)
        {
            if (!checkIndex(index))
                return null;
            return itemList[index];
        }
        // property to return the total items on the list
        public int Count
        {
            get { return itemList.Count;}
        }
        //Takes the input shoppingitem object and adds
        //it to the end of the master list itemList after it checks
        //the validity of the input object
        public bool AddItem(ShoppingItem itemIn)
        {
            bool ok = false;
            if(itemIn != null)
            {
                itemList.Add(itemIn);
                ok = true;
            }
            return ok;
        }
        

        //Checking for the validity of the input index
        private bool checkIndex(int index)
        {
            bool ok = false;
            if((index >= 0) && index < Count)
            {
                ok = true;
            }
            return ok;
        }

        // The method to change the shoppingItem object data
        // at a specific index
        public bool changeItem(ShoppingItem itemIn, int index)
        {
            bool ok = false;
            if (checkIndex(index))
            {
                itemList[index].Description = itemIn.Description;
                itemList[index].Amount = itemIn.Amount;
                itemList[index].Unit = itemIn.Unit;
                ok = true;
            }
            return ok;
        }
        // The method to delete the shoppingItem object data
        // at a specified index
        public bool DeleteItem(int index)
        {
            bool ok = false;
            if (checkIndex(index))
            {
                itemList.RemoveAt(index);
                ok = true;
            }
            return ok;
        }
        //Method  for converting ShoppingItem object data into a string
        //and for each object and string value is added to an array.
        public string[] GetItemsInfostrings()
        {
            string[] stringInfostrings = new string[itemList.Count];
            int i = 0;
            foreach (ShoppingItem itemobj in itemList)
            {
                stringInfostrings[i++] = itemobj.ToString();
            }
            return stringInfostrings;
        }
    }
}
