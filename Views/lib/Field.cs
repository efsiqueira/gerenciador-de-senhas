using System;
using System.Windows.Forms;
using System.Drawing;

namespace lib {
    public class Field 
    {
        public TextBox textBox;
        public Label label;

        public Field(
            int x,
            int y,
            string label,
            char passwordChar = ' '
        ){
            this.label = new Label();
            this.label.Text = label;
            this.label.Location = new Point(x, y);

            this.textBox = new TextBox();
            this.textBox.Location = new Point(x, y + 25);
            this.textBox.Size = new Size(240,15);

            if (!Char.IsWhiteSpace(passwordChar)) {
                this.textBox.PasswordChar = passwordChar;
            }
        }
    }
}