using System.Windows.Forms;

namespace lib {
    public class ConfirmMessage
    {
        public static DialogResult Show(string Message = "Deseja realmente confirmar a ação?")
        {
            return MessageBox.Show(
                "Confirmar",
                Message,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
        }
    }

    public class CancelMessage {
        public static DialogResult Show(string Message = "Deseja realmente cancelar a ação?")
        {
            return MessageBox.Show(
                "Cancelar",
                Message,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
        }
    }

    public class ErrorMessage {
        public static DialogResult Show(string Message = "Erro desconhecido")
        {
            return MessageBox.Show(
                "Erro",
                $"Ocorreu um erro ao executar a ação: {Message}",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }
}