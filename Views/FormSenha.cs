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
        public static int categoriaId;
        public static Operation option;
        public static int uid;
        Label lblCategoria;
        Label lblProcedimento;
        Label lblTags;
        TextBox txtProcedimento;
        CheckedListBox cListBoxTags;
        ComboBox cbCategoria;
        Button btConfirm;
        Button btCancel;
        SenhaView parent;
        public FormSenha(
            SenhaView parent,
            Operation operation,
            int id = 0
        ) : base()
        {
            this.parent = parent;
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
            base.fields.Add(new Field("url", 10, 90, "Url", 280, 15, ' ', senha != null ? senha.Url : null));
            base.fields.Add(new Field("user", 10, 160, "Usuário", 280, 15, ' ', senha != null ? senha.Usuario : null));
            base.fields.Add(new Field("pass", 10, 230, "Senha", 280, 15, '*', senha != null ? senha.SenhaEncrypt : null));

            this.lblCategoria = new Label();
            this.lblCategoria.Text = "Categoria";
            this.lblCategoria.Location = new Point(10, 300);
            this.lblCategoria.Size = new Size(280, 15);

            string[] categoria = {};
			this.cbCategoria = new ComboBox();
			foreach (Categoria item in CategoriaController.VisualizarCategoria())
			{
				this.cbCategoria.Items.Add(item.ToString());
			}
			this.cbCategoria.Location = new Point(10, 325);
			this.cbCategoria.Size = new Size(280, 15);

            this.lblProcedimento = new Label();
            this.lblProcedimento.Text = "Procedimento";
            this.lblProcedimento.Location = new Point(10, 370);
            this.lblProcedimento.Size = new Size(280, 15);

            this.txtProcedimento = new TextBox();
            this.txtProcedimento.Multiline = true;
            this.txtProcedimento.ScrollBars = ScrollBars.Vertical;
            this.txtProcedimento.AcceptsReturn = true;
            this.txtProcedimento.WordWrap = true;
            this.txtProcedimento.Location = new Point(10, 400);
            this.txtProcedimento.Size = new Size(280, 100);

            this.lblTags = new Label();
            this.lblTags.Text = "Tags";
            this.lblTags.Location = new Point(10, 525);
            this.lblTags.Size = new Size(280, 15);

            this.cListBoxTags = new CheckedListBox();
            this.cListBoxTags.Location = new Point(10, 550);
            this.cListBoxTags.Size = new Size(280, 100);
            int index = 0;
            foreach (Tag item in TagController.VisualizarTag())
            {
                this.cListBoxTags.Items.Add(item.ToString());
                if (senha != null)
                {
                    SenhaTag hasSenhaTag = SenhaTagController.GetBySenhaTagId(senha.Id, item.Id);
                    if (hasSenhaTag != null)
                    {   
                        this.cListBoxTags.SetItemChecked(index, true);
                    }
                }
                index++;
            }
            this.cListBoxTags.SelectionMode = SelectionMode.One;
            this.cListBoxTags.CheckOnClick = true;

            btConfirm = new Button();
            btConfirm.Text = "Confirmar";
            btConfirm.Size = new Size(80, 25);
            btConfirm.Location = new Point(110, 680);
            btConfirm.Click += new EventHandler(this.btConfirmClick);
        
            btCancel = new Button();
            btCancel.Text = "Cancelar";
            btCancel.Size = new Size(80, 25);
            btCancel.Location = new Point(110, 710);
            btCancel.Click += new EventHandler(this.btCancelClick);

            foreach (Field field in base.fields)
            {
                this.Controls.Add(field.label);
                this.Controls.Add(field.textBox);
            }

            if (senha != null) 
            {
                this.cbCategoria.Text = senha.Categoria.ToString();
                this.txtProcedimento.Text = senha.Procedimento;
            }

            this.Controls.Add(lblCategoria);
            this.Controls.Add(cbCategoria);
            this.Controls.Add(lblProcedimento);
            this.Controls.Add(txtProcedimento);
            this.Controls.Add(lblTags);
            this.Controls.Add(cListBoxTags);
            this.Controls.Add(btConfirm);
            this.Controls.Add(btCancel);
        }

        private void btConfirmClick(object sender, EventArgs e)
        {
            
            Field fieldName = base.fields.Find((Field field) => field.id == "name");
            Field fieldUrl = base.fields.Find((Field field) => field.id == "url");
            Field fieldUsuario = base.fields.Find((Field field) => field.id == "user");
            Field fieldSenhaEncrypt = base.fields.Find((Field field) => field.id == "pass");
            int categoriaId = 0;
            try
            {
                string categoria = cbCategoria.SelectedItem.ToString();
                int inicioId = categoria.IndexOf("- ");
                categoriaId = Convert.ToInt32(categoria.Substring(0, inicioId - 1));
            }
            catch (Exception)
            {
                ErrorMessage.Show("Categoria não pode ser vazio.");
            }
            try
            {
                if (option == Operation.Create)
                {
                    Senha senha = SenhaController.IncluirSenha(
                        fieldName.textBox.Text,
                        Convert.ToInt32(categoriaId),
                        fieldUrl.textBox.Text,
                        fieldUsuario.textBox.Text,
                        fieldSenhaEncrypt.textBox.Text,
                        txtProcedimento.Text
                    );
                    foreach (var item in cListBoxTags.CheckedItems)
                    {
                        var tag = item.ToString();
                        var idInicial = tag.IndexOf("- ");
                        var tagId = tag.Substring(0, idInicial - 1);
                        SenhaTagController.IncluirSenhaTag(
                            senha.Id,
                            Convert.ToInt32(tagId)
                        );
                    }
                    MessageBox.Show("Senha cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK);
                    this.parent.loadList();
                    this.Close();
                }
                else if (option == Operation.Update)
                {
                    Senha senha = SenhaController.AlterarSenha(
                        uid,
                        fieldName.textBox.Text,
                        Convert.ToInt32(categoriaId),
                        fieldUrl.textBox.Text,
                        fieldUsuario.textBox.Text,
                        fieldSenhaEncrypt.textBox.Text,
                        txtProcedimento.Text
                    );
                    foreach (var item in cListBoxTags.CheckedItems)
                    {
                        var tag = item.ToString();
                        var idInicial = tag.IndexOf("- ");
                        var tagId = tag.Substring(0, idInicial - 1);
                        SenhaTagController.IncluirSenhaTag(
                            senha.Id,
                            Convert.ToInt32(tagId)
                        );
                    }
                    MessageBox.Show("Senha alterada com sucesso!", "Sucesso", MessageBoxButtons.OK);
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