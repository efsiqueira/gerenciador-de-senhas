using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Views
{
    public class DeleteMessage : Form
    {
        public static System.Drawing.Icon Question { get; }

        Label labelMessage;
        Button btConfirm;
        Button btCancel;
        public DeleteMessage(int item)
        {
            this.ClientSize = new System.Drawing.Size(300, 100);
            this.Text = "EXCLUIR";

            labelMessage = new Label();
            labelMessage.Text = "Deseja realmente excluir o item?";
            labelMessage.Location = new Point(20, 20);
            labelMessage.Size = new Size(200, 20);

            btConfirm = new Button();
            btConfirm.Text = "Sim";
            btConfirm.Location = new Point(65, 55);
            btConfirm.Size = new Size(80, 25);

            btCancel = new Button();
            btCancel.Text = "Não";
            btCancel.Location = new Point(155, 55);
            btCancel.Size = new Size(80, 25);

            this.Controls.Add(labelMessage);
            this.Controls.Add(btConfirm);
            this.Controls.Add(btCancel);
        }
    }
}