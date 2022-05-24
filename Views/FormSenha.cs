using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using lib;
using Controllers;
using Models;

namespace Views
{
    public class FormSenha : FormBase
    {
        public static Operation option;
        public static int uid;
        public List<Field> fields;
        Label lblCategoria;
        ListBox listProcedimento;
        CheckedListBox cListBoxTags;
        ComboBox cbCategoria;
        Button btConfirm;
        Button btEdit;
        Button btCancel;
        public FormSenha(
            Operation operation,
            int id = 0
        ) : base()
        {
            option = operation;
            uid = id;

            Senha senha = null;
            if (id > 0)
            {
                senha = SenhaController.GetSenha(id);
            }

            this.ClientSize = new System.Drawing.Size(300, 770);
            this.Text = operation == Operation.Create
                ? "Criar"
                : "Alterar";

            base.fields.Add(new Field("name", 10, 20, "Nome", 280, 15, ' ', senha != null ? senha.Nome : null));
            base.fields.Add(new Field("url", 10, 160, "Url", 280, 15, ' ', senha != null ? senha.Url : null));
            base.fields.Add(new Field("user", 10, 230, "Usuário", 280, 15, ' ', senha != null ? senha.Usuario : null));
            base.fields.Add(new Field("pass", 10, 300, "Senha", 280, 15, ' ', senha != null ? senha.SenhaEncrypt : null));

            this.lblCategoria = new Label();
            this.lblCategoria.Text = "Categoria";
            this.lblCategoria.Location = new Point(10, 65);
            this.lblCategoria.Size = new Size(280, 15);

            // string[] categoria = {};
			// cbCategoria = new ComboBox();
			// foreach (var categorias in categoria)
			// {
			// 	cbCategoria.Items.Add(categorias);
			// }
			// cbCategoria.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			// cbCategoria.Location = new Point(10, 90);
			// cbCategoria.Size = new Size(280, 15);
			// cbCategoria.Sorted = true;

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
            
            // Field fieldName = base.fields.Find((Field field) => field.id == "name");
            // Field fieldCategory = base.fields.Find((Field field) => field.id == "category");
            // Field fieldUrl = base.fields.Find((Field field) => field.id == "url");
            // Field fieldUsuario;
            // Field fieldSenhaEncrypt;
            // Field fieldProcedimento;
            // try
            // {
            //     if (option == Operation.Create)
            //     {
            //         SenhaController.IncluirSenha(
            //             fieldName.textBox.Text,
            //             Convert.ToInt32(fieldCategory.textBox.Text),
            //             fieldUrl.textBox.Text,
            //             fieldUsuario.textBox.Text,
            //             fieldSenhaEncrypt.textBox.Text,
            //             fieldProcedimento.textBox.Text
            //         );
            //         MessageBox.Show("Senha criada com sucesso");
            //     }
            //     else if (option == Operation.Update)
            //     {
            //        SenhaController.AlterarSenha(
            //             uid,
            //             fieldName.textBox.Text,
            //             fieldDescription.textBox.Text
            //         );
            //         MessageBox.Show("Categoria alterada com sucesso");
            //     }
            // }
            // catch (Exception)
            // {
            //     ErrorMessage.Show();
            // }
        }

        private void btCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}