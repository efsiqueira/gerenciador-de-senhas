using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using lib;
using Controllers;
using Models;

namespace Views
{
    public class FormTag : FormBase
    {
        public static Operation option;
        public static int uid;
        Button btConfirm;
        Button btCancel;
        TagView parent;
        public FormTag(
            TagView parent,
            Operation operation,
            int id = 0
        ) : base()
        {
            this.parent = parent;
            option = operation;
            uid = id;

            Tag tag = null;
            if (id > 0)
            {
                tag = TagController.GetTag(id);
            }

            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = operation == Operation.Create
                ? "Criar"
                : "Alterar";

            base.fields.Add(new Field("description", 10, 90, "Descrição", 280, 15, ' ', tag != null ? tag.Descricao : null));
        
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
            
            Field fieldDescription = base.fields.Find((Field field) => field.id == "description");
            try
            {
                if (option == Operation.Create)
                {
                    TagController.IncluirTag(
                        fieldDescription.textBox.Text
                    );
                    MessageBox.Show("Tag criada com sucesso");
                    this.parent.loadList();
                    this.Close();
                }
                else if (option == Operation.Update)
                {
                   TagController.AlterarTag(
                        uid,
                        fieldDescription.textBox.Text
                    );
                    MessageBox.Show("Tag alterada com sucesso");
                    this.parent.loadList();
                    this.Close();
                }
            }
            catch (Exception err)
            {
                ErrorMessage.Show(err.Message);
            }
        }

        private void btCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}