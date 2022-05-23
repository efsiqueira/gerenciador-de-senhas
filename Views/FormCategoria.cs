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
        public static Operation option;
        public static int uid;
        public List<Field> fields;
        Button btConfirm;
        Button btCancel;
        public FormCategoria(
            Operation operation,
            int id = 0
        ) : base()
        {
            option = operation;
            uid = id;
            
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

            this.Controls.Add(btConfirm);
            this.Controls.Add(btCancel);
        }

        private void btConfirmClick(object sender, EventArgs e)
        {
            
            Field fieldName = base.fields.Find((Field field) => field.id == "name");
            Field fieldDescription = base.fields.Find((Field field) => field.id == "description");
            try
            {
                if (option == Operation.Create)
                {
                    CategoriaController.IncluirCategoria(
                        fieldName.textBox.Text,
                        fieldDescription.textBox.Text
                    );
                    MessageBox.Show("Categoria criada com sucesso");
                }
                else if (option == Operation.Update)
                {
                   CategoriaController.AlterarCategoria(
                        uid,
                        fieldName.textBox.Text,
                        fieldDescription.textBox.Text
                    );
                    MessageBox.Show("Categoria alterada com sucesso");
                }
            }
            catch (Exception)
            {
                ErrorMessage.Show();
            }
        }

        private void btCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}