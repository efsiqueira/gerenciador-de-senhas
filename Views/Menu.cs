using System;
using System.Windows.Forms;
using System.Drawing;
using Models;

namespace Views
{
    public class FormMenu : Form
    {
        Label labelMenu;
        Button btCategorias;
        Button btTags;
        Button btSenhas;
        Button btUsuario;
        Button btSair;
        public FormMenu()
        {
            this.ClientSize = new System.Drawing.Size(220, 220);
            this.Text = "Menu";

            labelMenu = new Label();
            labelMenu.Text = $"Olá, {Usuario.UsuarioAuth.Nome}";
            labelMenu.Location = new Point(0, 20);
            labelMenu.Size = new Size(220, 20);
            labelMenu.TextAlign = ContentAlignment.MiddleCenter;

            btCategorias = new Button();
            btCategorias.Text = "Categorias";
            btCategorias.Size = new Size(80, 25);
            btCategorias.Location = new Point(70, 60);
            btCategorias.Click += new EventHandler(this.btCategoriasClick);

            btTags = new Button();
            btTags.Text = "Tags";
            btTags.Size = new Size(80, 25);
            btTags.Location = new Point(70, 90);
            btTags.Click += new EventHandler(this.btTagsClick);

            btSenhas = new Button();
            btSenhas.Text = "Senhas";
            btSenhas.Size = new Size(80, 25);
            btSenhas.Location = new Point(70, 120);
            btSenhas.Click += new EventHandler(this.btSenhasClick);

            btUsuario = new Button();
            btUsuario.Text = "Usuário";
            btUsuario.Size = new Size(80, 25);
            btUsuario.Location = new Point(70, 150);
            btUsuario.Click += new EventHandler(this.btUsuarioClick);

            btSair = new Button();
            btSair.Text = "Sair";
            btSair.Size = new Size(80, 25);
            btSair.Location = new Point(70, 180);
            btSair.Click += new EventHandler(this.btSairClick);

            this.Controls.Add(labelMenu);
            this.Controls.Add(btCategorias);
            this.Controls.Add(btTags);
            this.Controls.Add(btSenhas);
            this.Controls.Add(btUsuario);
            this.Controls.Add(btSair);
        }

        private void btCategoriasClick(object sender, EventArgs e)
        {
            (new FormCategoria()).Show();
        }

        private void btTagsClick(object sender, EventArgs e)
        {
            
        }

        private void btSenhasClick(object sender, EventArgs e)
        {
            
        }

        private void btUsuarioClick(object sender, EventArgs e)
        {
            
        }

        private void btSairClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}