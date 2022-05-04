using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using lib;
using Controllers;
using Models;

namespace Views
{
    public class FormCategoria : FormBase
    {

        public List<Field> fields;
        Button btConfirm;
        Button btEdit;
        Button btCancel;
        public FormCategoria(
            Operation operation,
            int id = 0
        ) : base()
        {
            Categoria categoria = null;
            if (id > 0) {
                categoria = CategoriaController.GetCategoria(id);
            }

            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = operation == Operation.Create 
                ? "Criar"
                : "Alterar";

            base.fields.Add(new Field("name", 10, 20, "Nome", 280, 15, ' ', categoria != null ? categoria.Nome : null));
            base.fields.Add(new Field("description", 10, 90, "Descrição", 280, 15, ' ', categoria != null ? categoria.Descricao : null));

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

            if (operation == Operation.Create)
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