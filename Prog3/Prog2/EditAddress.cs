// Program 3
// CIS 200-01
// Fall 2017
// Due: 11/13/2017
// By: C2518

// File: EditAddress.cs
//This is a class for tehe EditAddress form.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPVApp
{
    public partial class EditAddress : Form
    {
  

        private List<Address> addressList;  // List of addresses used to fill combo boxes

        public EditAddress(List<Address> addresses)
        {
            InitializeComponent();
            addressList = addresses;
        }

        internal int EditIndex
        {
            // Precondition:  User has selected from originAddCbo
            // Postcondition: The index of the selected origin address returned
            get
            {
                return editAddressCombo.SelectedIndex;
            }

            // Precondition:  -1 <= value < addressList.Count
            // Postcondition: The specified index is selected in originAddCbo
            set
            {
                if ((value >= -1) && (value < addressList.Count))
                    editAddressCombo.SelectedIndex = value;
                else
                    throw new ArgumentOutOfRangeException("AddressIndex", value,
                        "Index must be valid");
            }
        }



        // Precondition:  User clicked on okBtn
        // Postcondition: If invalid field on dialog, keep form open and give first invalid
        //                field the focus. Else return OK and close form.
        private void okBtn_Click(object sender, EventArgs e)
        {
                // Raise validating event for all enabled controls on form
                // If all pass, ValidateChildren() will be true
                if (ValidateChildren())
                    this.DialogResult = DialogResult.OK;
        }

        // Precondition:  User pressed on cancelBtn
        // Postcondition: Form closes and sends Cancel result
        private void cancelBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Was it a left-click?
                this.DialogResult = DialogResult.Cancel;
        }

        private void edit_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(editAddressCombo, "");
        }

        private void edit_Validating(object sender, CancelEventArgs e)
        {
            if (editAddressCombo.SelectedIndex == -1) //No index selecteed
            {
                e.Cancel = true;
                errorProvider1.SetError(editAddressCombo, "Must select Address");
            }
        }

        private void EditAddress_Load(object sender, EventArgs e)
        {
            foreach (Address address in addressList)
                editAddressCombo.Items.Add(address.Name);
        }
    }
}

