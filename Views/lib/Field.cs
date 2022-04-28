using System;
using System.Windows.Forms;
using System.Drawing;

namespace lib {
    public class Field 
    {
        public string id;
        public TextBox textBox;
        public Label label;

        public Field(
            string id,
            int x,
            int y,
            string label,
            char passwordChar = ' '
        ){
            this.id = id;
            
            this.label = new Label();
            this.label.Text = label;
            this.label.Location = new Point(x, y);
            // this.label.Size = new Size();

            this.textBox = new TextBox();
            this.textBox.Location = new Point(x, y + 25);
            this.textBox.Size = new Size(240,15);

            if (!Char.IsWhiteSpace(passwordChar)) {
                this.textBox.PasswordChar = passwordChar;
            }
        }
    }
}