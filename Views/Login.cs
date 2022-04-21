using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using lib;
using System.Diagnostics;
using System.Threading;
using Models;

namespace Views
{
    public class FormLogin : FormBase
    {
        public List<Field> fields;
        Button buttonConfirmar;
        Button buttonFechar;
        Button buttonCadastrar;

        public FormLogin(): base()
        {
            this.ClientSize = new System.Drawing.Size(280, 220);
            this.Text = "Login";

            base.fields.Add(new Field(20, 20, "Login"));
            base.fields.Add(new Field(20, 90, "Senha", '*'));;

            buttonConfirmar = new Button();
            buttonConfirmar.Text = "Confirmar";
            buttonConfirmar.Size = new Size(80,25);
            buttonConfirmar.Location = new Point(20,170);
            buttonConfirmar.Click += new EventHandler(this.buttonConfirmarClick);
            
            buttonCadastrar = new Button();
            buttonCadastrar.Text = "Cadastrar";
            buttonCadastrar.Size = new Size(80,25);
            buttonCadastrar.Location = new Point(100,170);
            buttonCadastrar.Click += new EventHandler(this.buttonCadastrarClick);

            buttonFechar = new Button();
            buttonFechar.Text = "Fechar";
            buttonFechar.Size = new Size(80,25);
            buttonFechar.Location = new Point(180,170);
            buttonFechar.Click += new EventHandler(this.buttonFecharClick);

            foreach (Field field in base.fields)
            {
                this.Controls.Add(field.label);
                this.Controls.Add(field.textBox);
            }
            this.Controls.Add(buttonConfirmar);
            this.Controls.Add(buttonFechar);
            this.Controls.Add(buttonCadastrar);
        }

        private void buttonConfirmarClick(object sender, EventArgs e)
        {
            
        }

        private void buttonFecharClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCadastrarClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}