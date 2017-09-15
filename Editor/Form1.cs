using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("texto.txt"))
            {
                Stream entrada = File.Open("texto.txt", FileMode.Open);
                StreamReader leitor = new StreamReader(entrada);
                string linha = leitor.ReadLine();
                while (linha != null)
                {
                    textoConteudo.Text += linha;
                    linha = leitor.ReadLine();
                }
                leitor.Close();
                entrada.Close();
            }
            else
            {
                MessageBox.Show("Não rolou");
            }
        }

        private void botaoGrava_Click(object sender, EventArgs e)
        {
            Stream saida = File.Open("texto.txt", FileMode.Create);
            StreamWriter escritor = new StreamWriter(saida);
            escritor.Write(textoConteudo.Text);
            escritor.Close();
            saida.Close();
        }

        private void botaoBusca_Click(object sender, EventArgs e)
        {
            string busca = textoBusca.Text;
            string textoDoEditor = textoConteudo.Text;
            int resultado = textoDoEditor.IndexOf(busca);
            if (resultado >= 0)
            {
                MessageBox.Show("achei o texto " + busca);
            }
            else
            {
                MessageBox.Show("não achei");
            }
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            string busca = textoBusca.Text;
            string textoDoEditor = textoConteudo.Text;
            string replace = textReplace.Text;
              
            int resultado = textoDoEditor.IndexOf(busca);

            if (resultado >= 0)
            {
                textoConteudo.Text = textoDoEditor.Replace(busca, replace);
                MessageBox.Show("Texto: " + busca + " trocado por: " + replace);
            }
            else
            {
                MessageBox.Show("não achei");
            }
            
        }
    }
}
