using System;
using System.Windows.Forms;
using System.Drawing;
using Models;
using Controllers;
using lib;

namespace Views
{
    public class TagView : Form
    {
        ListView listView;
        ListViewItem newLine;
        Button btIncluir;
        Button btAlterar;
        Button btExcluir;
        Button btVoltar;

        public TagView()
        {
            this.ClientSize = new System.Drawing.Size(470, 470);
            this.Text = "Tags";

            btIncluir = new Button();
            btIncluir.Text = "Incluir";
            btIncluir.Location = new Point(15, 430);
            btIncluir.Size = new Size(80, 25);
            btIncluir.Click += new EventHandler(this.btIncluirClick);

            btAlterar = new Button();
            btAlterar.Text = "Alterar";
            btAlterar.Location = new Point(135, 430);
            btAlterar.Size = new Size(80, 25);
            btAlterar.Click += new EventHandler(this.btAlterarClick);

            btExcluir = new Button();
            btExcluir.Text = "Excluir";
            btExcluir.Location = new Point(255, 430);
            btExcluir.Size = new Size(80, 25);
            btExcluir.Click += new EventHandler(this.btExcluirClick);

            btVoltar = new Button();
            btVoltar.Text = "Voltar";
            btVoltar.Location = new Point(375, 430);
            btVoltar.Size = new Size(80, 25);
            btVoltar.Click += new EventHandler(this.btVoltarClick);

            listView = new ListView();
            listView.Location = new Point(10, 15);
            listView.Size = new Size(450, 400);
            listView.View = View.Details;

            listView.Columns.Add("Id", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Descrição", -2, HorizontalAlignment.Left);

            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.AllowColumnReorder = true;
            listView.Sorting = SortOrder.Ascending;

            this.loadList();

            this.Controls.Add(listView);
            this.Controls.Add(btIncluir);
            this.Controls.Add(btAlterar);
            this.Controls.Add(btExcluir);
            this.Controls.Add(btVoltar);
        }
        public void loadList()
        {
            this.listView.Items.Clear();

            foreach (Tag item in TagController.VisualizarTag())
            {
                newLine = new ListViewItem(item.Id.ToString());
                newLine.SubItems.Add(item.Descricao);

                listView.Items.Add(newLine);
            }
        }

        private void btIncluirClick(object sender, EventArgs e)
        {
            new FormTag(this, Operation.Create).Show();
        }

        private void btAlterarClick(object sender, EventArgs e)
        {
            try
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                new FormTag(this, Operation.Update, Convert.ToInt32(selectedItem.Text)).Show();
            }
            catch (Exception)
            {
                ErrorMessage.Show();
            }
        }

        private void btExcluirClick(object sender, EventArgs e)
        {
            try
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                int tagId = Convert.ToInt32(selectedItem.Text);
                DialogResult result = MessageBox.Show($"Deseja excluir a tag {tagId}?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    TagController.RemoverItem(tagId);
                }
                this.loadList();
            }
            catch (Exception)
            {
                ErrorMessage.Show();
            }
        }

        private void btVoltarClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}