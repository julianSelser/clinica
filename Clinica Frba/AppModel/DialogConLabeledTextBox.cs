using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//Dialog reutilizable que sirve para forzar el flujo de ejecucion por el mismo para continuar,
//se completa un campo texto que luego puede ser recuperado por el componente que lo llama

namespace Clinica_Frba.AppModel
{
    public partial class DialogConLabeledTextBox : Form
    {
        public string texto { get; set; }

        public DialogConLabeledTextBox(string label)
        {
            InitializeComponent();
            this.label.Text = label;
            okButton.DialogResult = DialogResult.OK;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            this.texto = textBox.Text;
        }
    }
}
