
using DemoLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormMiniProject
{
    public partial class PersonEntry : Form, ISaveAddress
    {
        BindingList<AddressModel> addresses = new BindingList<AddressModel>();
        public PersonEntry()
        {
            InitializeComponent();
            addressesList.DataSource = addresses;
            addressesList.DisplayMember = nameof(AddressModel.AddressDisplayValue);
        }

        public void SaveAddress(AddressModel address)
        {
            addresses.Add(address);
        }

        private void addNewAddress_Click(object sender, EventArgs e)
        {
            AddressEntry entry = new AddressEntry(this);
            entry.Show();
        }

        private void saveRecord_Click(object sender, EventArgs e)
        {
            PersonModel person = new PersonModel
            {
                FirstName = firstNameText.Text,
                LastName = lastNameText.Text,
                IsActive = isActive.Checked,
                Addresses = addresses.ToList(),
            };
        }
    }
}
