using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalkulator_2._0
{
    public class RoundedTextBox : TextBox
    {
        public int CornerRadius { get; set; } = 10; // Радиус закругления углов

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Создаем закругленный прямоугольник для TextBox
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, CornerRadius * 2, CornerRadius * 2, 180, 90); // Верхний левый угол
            path.AddArc(Width - CornerRadius * 2, 0, CornerRadius * 2, CornerRadius * 2, 270, 90); // Верхний правый угол
            path.AddArc(Width - CornerRadius * 2, Height - CornerRadius * 2, CornerRadius * 2, CornerRadius * 2, 0, 90); // Нижний правый угол
            path.AddArc(0, Height - CornerRadius * 2, CornerRadius * 2, CornerRadius * 2, 90, 90); // Нижний левый угол
            path.CloseFigure();

            Region = new Region(path);
        }
    }

    public class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            RoundedTextBox roundedTextBox = new RoundedTextBox();
            roundedTextBox.Location = new Point(50, 50);
            roundedTextBox.Size = new Size(200, 30);
            Controls.Add(roundedTextBox);
        }

        
        
    }
}
