using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shopping_List__Assign5
{
    
    public partial class MainForm : Form
    {
        //This object that holds the data and operations of the application
        ItemManager itemManager = new ItemManager();
        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }
        //After the user selection on the list box change 
        // this method fetches the current ShoppingItem object from
        //the list
      private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedindex = checkedListBox1.SelectedIndex;
            ShoppingItem item = null;

            item = itemManager.GetItem(selectedindex);

            if (item != null)
            {
                txtDescription.Text = item.Description;
                txtAmount.Text = item.Amount.ToString();
                cmbUnit.SelectedIndex = (int)item.Unit;
            }
        }
        // This method sets up the GUI for the first time when the form loads
        private void InitializeGUI()
        {
            cmbUnit.Items.AddRange(Enum.GetNames(typeof(UnitTypes)));
            cmbUnit.SelectedIndex = (int)UnitTypes.piece;
        }
        // After the user clicks on the add button, it first validates
        //the text box entries before creating a shoppingItem
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool success = false;
            //Read data for the new item
            //if error ReadInput provides messages the user
            //item is created in the ReadInput
            ShoppingItem item = ReadInput(out success);
            if (success)
            {
                itemManager.AddItem(item);
                UpdateGUI();
            }
        }
        //Method for creating a new ShoppingItem object for the program
        //After it validates the user input data on the GUI
        private ShoppingItem ReadInput(out bool success)
        {
            success = false;
            ShoppingItem item = new ShoppingItem();
            item.Description = ReadDescription(out success);

            if (!success)
                return null;
            item.Amount = ReadAmount(out success);

            if (!success)
                return null;
            item.Unit = ReadUnit(out success);
            return item;
        }
        //This validates the data entry of the user input on the 
        //GUI for the amount text box.
        private double ReadAmount(out bool success)
        {
            double amount = 0.0;
            success = false;
            if(!double.TryParse(txtAmount.Text, out amount))
            {
                GiveMessage("Wrong Amount");
                txtAmount.Focus();
                txtAmount.SelectionStart = 0;
                txtAmount.SelectionLength = txtAmount.TextLength;
            }
            else
            {
                success = true;
            }
            return amount;
        }
        //This validate the data entry of the use on the GUI
        // in the description text box
        private string ReadDescription(out bool success)
        {
            string name = string.Empty;
            success = false;
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                GiveMessage("Please Enter a descriptive name");
                txtDescription.Focus();
                txtDescription.SelectionStart = 0;
                txtDescription.SelectionLength = txtDescription.TextLength;
            }
            else
            {
                name = txtDescription.Text;
                success = true;
            }
            return name;
        }
        //Method to valid data selection of the user input on the GUI
        //for the combo selection box
        private UnitTypes ReadUnit(out bool success)
        {
            UnitTypes unit = UnitTypes.piece;
            success = false;
            if (!Enum.IsDefined(typeof(UnitTypes), cmbUnit.SelectedIndex))
            {
                GiveMessage("Please select a valid unit type");
                cmbUnit.Focus();
            }
            else
            {
                unit = (UnitTypes)cmbUnit.SelectedIndex;
                success = true;
            }
            return unit;
        }
        private void GiveMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //Update the GUI for the user including the list box of items
        public void UpdateGUI()
        {
            string[] list = itemManager.GetItemsInfostrings();
            checkedListBox1.Items.Clear();

            if (list == null)
                return;
            for (int i = 0; i < list.Length; i++)
            {
                checkedListBox1.Items.Add(list[i]);
            }
        }
        // This method validates the user data entry, validates
        //validates an existing shopping item
        private void btnChange_Click(object sender, EventArgs e)
        {
            int selectedindex = checkedListBox1.SelectedIndex;
            ShoppingItem item = null;
            bool success = false;
            item = ReadInput(out success);

            if (success && (item != null) && itemManager.changeItem(item, selectedindex))
            {
                UpdateGUI();
            }
            else
            {
                GiveMessage("Error: Did not change, Please First select item to change");
            }
        }
        //When the user clicks on the delete button,
        //calls the business logic on the itemManager object
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedindex = checkedListBox1.SelectedIndex;
            if (itemManager.DeleteItem(selectedindex))
            {
                UpdateGUI();
            }
            else
            {
                GiveMessage("Error: Did not delete, First select the Item to Delete");
            }
        }
        //When the user clicks the delete button, 


    }
}
