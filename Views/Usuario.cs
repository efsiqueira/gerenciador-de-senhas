using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Models;

namespace Views
{
    public class FormUsuario : Form
    {
        public FormUsuario()
        {
            this.ClientSize = new System.Drawing.Size(280, 220);
            this.Text = "Usuário";
        }
    }
}