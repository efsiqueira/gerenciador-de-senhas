using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using lib;
using Controllers;

namespace Views
{
    public class FormCategoria : FormBase
    {

        public List<Field> fields;
        Button btConfirm;
        Button btEdit;
        Button btCancel;
        public FormCategoria(string titleCategoria) : base()
        {
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = titleCategoria;

            base.fields.Add(new Field("name", 10, 20, "Nome", 280, 15));
            base.fields.Add(new Field("description", 10, 90, "Descrição", 280, 15));

            btConfirm = new Button();
            btConfirm.Text = "Confirmar";
            btConfirm.Size = new Size(80, 25);
            btConfirm.Location = new Point(110, 205);
            btConfirm.Click += new EventHandler(this.btConfirmClick);

            btEdit = new Button();
            btEdit.Text = "Alterar";
            btEdit.Size = new Size(80, 25);
            btEdit.Location = new Point(110, 205);
            btEdit.Click += new EventHandler(this.btConfirmClick);
        
            btCancel = new Button();
            btCancel.Text = "Cancelar";
            btCancel.Size = new Size(80, 25);
            btCancel.Location = new Point(110, 240);
            btCancel.Click += new EventHandler(this.btCancelClick);

            foreach (Field field in base.fields)
            {
                this.Controls.Add(field.label);
                this.Controls.Add(field.textBox);
            }

            if (titleCategoria == "Alterar")
            {
                this.Controls.Add(btEdit);
            }
            else
            {
                this.Controls.Add(btConfirm);
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