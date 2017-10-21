using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecretIngredients
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        GetSecretIngredient ingredientMethod = null;
        Suzanne suzanne = new Suzanne();
        Amy amy = new Amy();

        private void useIngredient_Click(object sender, EventArgs e)
        {
            if (ingredientMethod != null)
                MessageBox.Show("I'll add " + ingredientMethod((int)amount.Value));
            else
                MessageBox.Show("I don't have a secret ingredient!");
        }

        private void getSuzanne_Click(object sender, EventArgs e)
        {
            ingredientMethod = new GetSecretIngredient(suzanne.MySecretIngredientMethod);
        }

        private void getAmy_Click(object sender, EventArgs e)
        {
            ingredientMethod = new GetSecretIngredient(amy.AmysSecretIngredientMethod);
        }
    }
}
