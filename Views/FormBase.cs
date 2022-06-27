using System.Collections.Generic;
using System.Windows.Forms;
using lib;

namespace Views
{

    public abstract class FormBase : Form
    {
        public List<Field> fields;

        public FormBase()
        {
            this.fields = new List<Field>();
        }
    }
}