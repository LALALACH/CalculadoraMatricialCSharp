using MaterialSkin;
using MaterialSkin.Controls;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace CalculadoraMatricial
{
    public partial class Form1 : MaterialForm
    {
        calcularSoloDet calcularSD3 = new calcularSoloDet();
        calcularSoloDetMatriz2x2 calcularDet2x2 = new calcularSoloDetMatriz2x2();
        Matriz2x2 matriz2X2 = new Matriz2x2();

        double detX, detY, detZ, detA;
        byte cantidadDecimales = 5;
        bool decimalesInfinitos = false;
        bool fracciones = false;

        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyPreview = true;  // habilita KeyPreview
            box11.KeyPress += new KeyPressEventHandler(box11_KeyPress);
            box12.KeyPress += new KeyPressEventHandler(box12_KeyPress);
            box13.KeyPress += new KeyPressEventHandler(box13_KeyPress);
            box14.KeyPress += new KeyPressEventHandler(box14_KeyPress);

            box21.KeyPress += new KeyPressEventHandler(box21_KeyPress);
            box22.KeyPress += new KeyPressEventHandler(box22_KeyPress);
            box23.KeyPress += new KeyPressEventHandler(box23_KeyPress);
            box24.KeyPress += new KeyPressEventHandler(box24_KeyPress);

            box31.KeyPress += new KeyPressEventHandler(box31_KeyPress);
            box32.KeyPress += new KeyPressEventHandler(box32_KeyPress);
            box33.KeyPress += new KeyPressEventHandler(box33_KeyPress);
            box34.KeyPress += new KeyPressEventHandler(box34_KeyPress);

            deta.KeyPress += new KeyPressEventHandler(deta_KeyPress);
            detx.KeyPress += new KeyPressEventHandler(detx_KeyPress);
            dety.KeyPress += new KeyPressEventHandler(dety_KeyPress);
            detz.KeyPress += new KeyPressEventHandler(detz_KeyPress);
            valorX.KeyPress += new KeyPressEventHandler(valorX_KeyPress);
            valorY.KeyPress += new KeyPressEventHandler(valorY_KeyPress);
            valorZ.KeyPress += new KeyPressEventHandler(valorZ_KeyPress);

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void instrucciones_Click(object sender, EventArgs e)
        {
            MessageBox.Show("GRACIAS POR USAR NUESTRA CALCULADORA..." +
                "Bien, ingresa tu matriz tal y cual te la dan" +
                "Nosotros detectamos si es de 3x3 o 2x2, o si tienes la columna inicial para resolver el sistema de ecuaciones" +
                "Si el valor es 0, no ingreses ningún número, eso sí, si tienes 0 en orillas y te da errores, puedes ingresar" +
                "manualmente la proporción de tu matriz.", "Bienvenido!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void calcular_Click(object sender, EventArgs e)
        {
            calcularTodo();
        }

        private void calcularTodo()
        {
            if (box33.Text != "" && box34.Text == "")
            {
                CalcularDetA();
                deta.Text = Convert.ToString(detA);
            }
            else if (box22.Text != "" && box23.Text == "")
            {
                CalcularDetA(1);
                deta.Text = Convert.ToString(detA);
            }
            else if (box22.Text != "" && box23.Text != "" && box34.Text == "")
            {
                CalcularDetA(1);
                detX = matriz2X2.DetX2x2(Convert.ToDouble(box13.Text), Convert.ToDouble(box12.Text),
                    Convert.ToDouble(box23.Text), Convert.ToDouble(box22.Text));

                detY = matriz2X2.DetY2x2(Convert.ToDouble(box11.Text), Convert.ToDouble(box13.Text),
                    Convert.ToDouble(box21.Text), Convert.ToDouble(box23.Text));
                display();
            }
            else if (box33.Text != "" && box34.Text != "")
            {
                CalcularDetA();
                CalcularDetX();
                CalcularDetY();
                CalcularDetZ();
                display(1);

            }

        }

        private void CalcularDetA()
        {
            detA = calcularSD3.soloDet3x3(Convert.ToDouble(box11.Text), Convert.ToDouble(box12.Text), Convert.ToDouble(box13.Text),
                    Convert.ToDouble(box21.Text), Convert.ToDouble(box22.Text), Convert.ToDouble(box23.Text),
                    Convert.ToDouble(box31.Text), Convert.ToDouble(box32.Text), Convert.ToDouble(box33.Text));
        }
        private void CalcularDetA(byte x)
        {
            detA = calcularDet2x2.soloDet2x2(Convert.ToDouble(box11.Text), Convert.ToDouble(box12.Text),
                    Convert.ToDouble(box21.Text), Convert.ToDouble(box22.Text));
        }
        private void CalcularDetX()
        {
            detX = calcularSD3.soloDet3x3(Convert.ToDouble(box14.Text), Convert.ToDouble(box12.Text), Convert.ToDouble(box13.Text),
                    Convert.ToDouble(box24.Text), Convert.ToDouble(box22.Text), Convert.ToDouble(box23.Text),
                    Convert.ToDouble(box34.Text), Convert.ToDouble(box32.Text), Convert.ToDouble(box33.Text));
        }
        private void CalcularDetY()
        {
            detY = calcularSD3.soloDet3x3(Convert.ToDouble(box11.Text), Convert.ToDouble(box14.Text), Convert.ToDouble(box13.Text),
                    Convert.ToDouble(box21.Text), Convert.ToDouble(box24.Text), Convert.ToDouble(box23.Text),
                    Convert.ToDouble(box31.Text), Convert.ToDouble(box34.Text), Convert.ToDouble(box33.Text));
        }
        private void CalcularDetZ()
        {
            detZ = calcularSD3.soloDet3x3(Convert.ToDouble(box11.Text), Convert.ToDouble(box12.Text), Convert.ToDouble(box14.Text),
                    Convert.ToDouble(box21.Text), Convert.ToDouble(box22.Text), Convert.ToDouble(box24.Text),
                    Convert.ToDouble(box31.Text), Convert.ToDouble(box32.Text), Convert.ToDouble(box34.Text));
        }
        private void display()
        {
            if (decimalesInfinitos)
            {
                deta.Text = Convert.ToString(detA);
                detx.Text = Convert.ToString(detX);
                dety.Text = Convert.ToString(detY);
                valorX.Text = Convert.ToString(detX / detA);
                valorY.Text = Convert.ToString(detY / detA);
            }
            else
            {
                deta.Text = Convert.ToString(Math.Round(detA, cantidadDecimales));
                detx.Text = Convert.ToString(Math.Round(detX, cantidadDecimales));
                dety.Text = Convert.ToString(Math.Round(detY, cantidadDecimales));
                valorX.Text = Convert.ToString(Math.Round((detX / detA), cantidadDecimales));
                valorY.Text = Convert.ToString(Math.Round((detY / detA), cantidadDecimales));
            }

        }
        private void display(byte x)
        {
            display();
            if (decimalesInfinitos)
            {
                detz.Text = Convert.ToString(detZ);
                valorZ.Text = Convert.ToString(detZ / detA);
            }
            else
            {
                detz.Text = Convert.ToString(Math.Round(detZ, cantidadDecimales));
                valorZ.Text = Convert.ToString(Math.Round((detZ / detA), cantidadDecimales));

            }

        }

        private void reset_Click(object sender, EventArgs e)
        {
            vaciar();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Usamos un switch para manejar las teclas presionadas
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    calcularTodo();
                    break;
                case Keys.Delete:
                    vaciar();
                    break;
                default:
                    //
                    break;
            }
        }


        private void vaciar()
        {
            box11.Text = "";
            box12.Text = "";
            box13.Text = "";
            box14.Text = "";
            box21.Text = "";
            box22.Text = "";
            box23.Text = "";
            box24.Text = "";
            box31.Text = "";
            box32.Text = "";
            box33.Text = "";
            box34.Text = "";
            detx.Text = "";
            dety.Text = "";
            detz.Text = "";
            deta.Text = "";
            valorX.Text = "";
            valorY.Text = "";
            valorZ.Text = "";
        }


        private void box11_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, signo más, signo menos, y la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número, +, -, o retroceso, se cancela el evento
                e.Handled = true;
            }
        }

        private void box12_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, signo más, signo menos, y la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número, +, -, o retroceso, se cancela el evento
                e.Handled = true;
            }
        }
        private void box13_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, signo más, signo menos, y la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número, +, -, o retroceso, se cancela el evento
                e.Handled = true;
            }
        }
        private void box14_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, signo más, signo menos, y la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número, +, -, o retroceso, se cancela el evento
                e.Handled = true;
            }
        }
        private void box21_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, signo más, signo menos, y la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número, +, -, o retroceso, se cancela el evento
                e.Handled = true;
            }
        }

        private void box22_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, signo más, signo menos, y la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número, +, -, o retroceso, se cancela el evento
                e.Handled = true;
            }
        }
        private void box23_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, signo más, signo menos, y la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número, +, -, o retroceso, se cancela el evento
                e.Handled = true;
            }
        }
        private void box24_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, signo más, signo menos, y la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número, +, -, o retroceso, se cancela el evento
                e.Handled = true;
            }
        }
        private void box31_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, signo más, signo menos, y la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número, +, -, o retroceso, se cancela el evento
                e.Handled = true;
            }
        }

        private void box32_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, signo más, signo menos, y la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número, +, -, o retroceso, se cancela el evento
                e.Handled = true;
            }
        }
        private void box33_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, signo más, signo menos, y la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número, +, -, o retroceso, se cancela el evento
                e.Handled = true;
            }
        }
        private void box34_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, signo más, signo menos, y la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número, +, -, o retroceso, se cancela el evento
                e.Handled = true;
            }
        }
        private void deta_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, signo más, signo menos, y la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número, +, -, o retroceso, se cancela el evento
                e.Handled = true;
            }
        }
        private void detx_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, signo más, signo menos, y la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número, +, -, o retroceso, se cancela el evento
                e.Handled = true;
            }
        }
        private void dety_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, signo más, signo menos, y la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número, +, -, o retroceso, se cancela el evento
                e.Handled = true;
            }
        }
        private void detz_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, signo más, signo menos, y la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número, +, -, o retroceso, se cancela el evento
                e.Handled = true;
            }
        }
        private void valorX_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, signo más, signo menos, y la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número, +, -, o retroceso, se cancela el evento
                e.Handled = true;
            }
        }
        private void valorY_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, signo más, signo menos, y la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número, +, -, o retroceso, se cancela el evento
                e.Handled = true;
            }
        }

        private void valorZ_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, signo más, signo menos, y la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número, +, -, o retroceso, se cancela el evento
                e.Handled = true;
            }
        }

        private void aplicarredondear_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(valorredondear.Text) >= 0 && Convert.ToInt32(valorredondear.Text) <= 10)
                {
                    cantidadDecimales = Convert.ToByte(valorredondear.Text);
                }
                else
                {
                    MessageBox.Show("Ingresa un valor de decimales entre 0 y 10", "ERROR!");
                    valorredondear.Text = "5";
                    cantidadDecimales = 5;
                }
            }
            catch
            {
                MessageBox.Show("No metas cadenas de texto", "ERROR!!");
                valorredondear.Text = "5";
                cantidadDecimales = 5;
            }

        }

        private void activarDesactivar_Click(object sender, EventArgs e)
        {
            if (decimalesInfinitos)
            {
                decimalesInfinitos = false;
                activarDesactivar.Text = "Desactivar redondeo";
            }
            else
            {
                decimalesInfinitos = true;
                activarDesactivar.Text = "Activar redondeo";
            }
        }

        private void fraccionesDecimales_Click(object sender, EventArgs e)
        {
            if (fracciones)
            {
                fracciones = false;
                fraccionesDecimales.Text = "Fracciones";
                MessageBox.Show("Si apoyas este proyecto en su última versión tendrás esta funcionalidad");
            }
            else
            {
                fracciones = true;
                fraccionesDecimales.Text = "Decimales";
                MessageBox.Show("Si apoyas este proyecto en su última versión tendrás esta funcionalidad","IMPORTANTE!");
            }
        }

    }
}
