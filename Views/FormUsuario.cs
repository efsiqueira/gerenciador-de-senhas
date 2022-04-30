using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using lib;

namespace Views
{
    public class FormUsuario : FormBase
    {
        public List<Field> fields;
        Button btConfirm;
        Button btEdit;
        Button btCancel;
        public FormUsuario(string titleUsuario) : base()
        {
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = titleUsuario;

            base.fields.Add(new Field("name", 10, 20, "Nome", 280, 15));
            base.fields.Add(new Field("email", 10, 80, "Email", 280, 15));
            base.fields.Add(new Field("senha", 10, 140, "Senha", 280, 15, '*'));

            btConfirm = new Button();
            btConfirm.Text = "Confirmar";
            btConfirm.Size = new Size(80, 25);
            btConfirm.Location = new Point(110, 220);
            btConfirm.Click += new EventHandler(this.btConfirmClick);

            btEdit = new Button();
            btEdit.Text = "Alterar";
            btEdit.Size = new Size(80, 25);
            btEdit.Location = new Point(110, 220);
            btEdit.Click += new EventHandler(this.btConfirmClick);
        
            btCancel = new Button();
            btCancel.Text = "Cancelar";
            btCancel.Size = new Size(80, 25);
            btCancel.Location = new Point(110, 255);
            btCancel.Click += new EventHandler(this.btCancelClick);

            foreach (Field field in base.fields)
            {
                this.Controls.Add(field.label);
                this.Controls.Add(field.textBox);
            }

            if (titleUsuario == "Cadastrar")
            {
                this.Controls.Add(btConfirm);
            }
            else
            {
                this.Controls.Add(btEdit);
            }

            this.Controls.Add(btCancel);
        }

        private void btConfirmClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btEditClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}