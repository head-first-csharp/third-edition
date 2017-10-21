using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryInAction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> wordDefinition =
                new Dictionary<string, string>();
            wordDefinition.Add("Dictionary", "A book that lists the words of a "
                              + "language in alphabetical order and gives their meaning");
            wordDefinition.Add("Key", "A thing that provides a means of gaining access to "
                              + "our understanding something.");
            wordDefinition.Add("Value", "A quantity, number, string, or reference.");
            if (wordDefinition.ContainsKey("Key"))
            {
                MessageBox.Show(wordDefinition["Key"]);
            }
        }
    }
}
