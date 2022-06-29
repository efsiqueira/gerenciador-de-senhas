using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using lib;
using Controllers;
using Models;

namespace Views
{
    public class FormUsuario : FormBase
    {
        public static Operation option;
        public static int uid;
        public List<Field> fields;
        Button btConfirm;
        Button btCancel;
        UsuarioView parent;
        public FormUsuario(
            UsuarioView parent,
            Operation operation,
            int id = 0
        ) : base()
        {
            this.parent = parent;
            option = operation;
            uid = id;

            Usuario usuario = null;
            if (id > 0)
            {
                usuario = UsuarioController.GetUsuario(id);
            }

            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = operation == Operation.Create
                ? "Criar"
                : "Alterar";

            base.fields.Add(new Field("name", 10, 20, "Nome", 280, 15, ' ', usuario != null ? usuario.Nome : null));
            base.fields.Add(new Field("email", 10, 80, "Email", 280, 15, ' ', usuario != null ? usuario.Email : null));
            base.fields.Add(new Field("senha", 10, 140, "Senha", 280, 15, '*', usuario != null ? usuario.Senha : null));

            btConfirm = new Button();
            btConfirm.Text = "Confirmar";
            btConfirm.Size = new Size(80, 25);
            btConfirm.Location = new Point(110, 220);
            btConfirm.Click += new EventHandler(this.btConfirmClick);
        
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

            this.Controls.Add(btConfirm);
            this.Controls.Add(btCancel);
        }

        private void btConfirmClick(object sender, EventArgs e)
        {
            Field fieldName = base.fields.Find((Field field) => field.id == "name");
            Field fieldEmail = base.fields.Find((Field field) => field.id == "email");
            Field fieldSenha = base.fields.Find((Field field) => field.id == "senha");
            try
            {
                if (option == Operation.Create)
                {
                    UsuarioController.IncluirUsuario(
                        fieldName.textBox.Text,
                        fieldEmail.textBox.Text,
                        fieldSenha.textBox.Text
                    );
                    MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK);
                    this.parent.loadList();
                    this.Close();
                }
                else if (option == Operation.Update)
                {
                   UsuarioController.AlterarUsuario(
                        uid,
                        fieldName.textBox.Text,
                        fieldEmail.textBox.Text,
                        fieldSenha.textBox.Text
                    );
                    MessageBox.Show("Usuário alterado com sucesso!", "Sucesso", MessageBoxButtons.OK);
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