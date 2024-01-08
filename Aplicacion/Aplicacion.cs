using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;
using System.IO;

// Para usar la carpeta Resources
using Aplicacion.Properties;

// Para crear el PDF 
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace Aplicacion
{
    public partial class Aplicacion : Form
    {
        List<Registro> listaRegistros;
        List<Categoria> listaCategorias;
        GestorNegocio negocio = new GestorNegocio();
        decimal totalGastado;

        public Aplicacion()
        {
            InitializeComponent();
        }

        private void Aplicacion_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Registro nuevoRegistro = new Registro();
            string nombre = txtNombreRegistro.Text;
            decimal monto = nunMonto.Value;
            string categoria = cboCategoria.Text;
            DateTime fecha = DateTime.Now;

            if (!string.IsNullOrWhiteSpace(nombre) && !string.IsNullOrWhiteSpace(categoria))
            {
                if (monto > 0)
                {
                    nuevoRegistro.NombreRegistro = nombre;
                    nuevoRegistro.Monto = monto;
                    nuevoRegistro.FechaRegistro = fecha;
                    nuevoRegistro.Categoria = (Categoria)cboCategoria.SelectedItem;

                    negocio.AgregarRegistro(nuevoRegistro);
                    MessageBox.Show("Registro agrgado.");

                    txtNombreRegistro.Clear();
                    nunMonto.Value = 0;

                    Refrescar();
                }
                else
                {
                    MessageBox.Show("Ingrese un monto válido.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Llene todos los campos.");
                return;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDescargarRegistroPDF_Click(object sender, EventArgs e)
        {
            if (listaRegistros.Count > 0)
            {
                if (dgvRegistroDatos.SelectedRows.Count > 0)
                {
                    Registro reg = (Registro)dgvRegistroDatos.CurrentRow.DataBoundItem;
                    CrearPDF(reg);
                    Refrescar();
                }
                else
                {
                    MessageBox.Show("Seleccione un registro.");
                }
            }
            else
            {
                MessageBox.Show("¡No hay registros!");
            }
        }

        private void btnTodosRegistros_Click(object sender, EventArgs e)
        {
            if (listaRegistros.Count > 0)
            {
                DescargarTodosLosRegistros();
                Refrescar();
            }
            else
            {
                MessageBox.Show("¡No hay registros!");
            }
        }

        private void Refrescar()
        {
            listaRegistros = negocio.ListarRegistros();
            listaCategorias = negocio.ListarCategorias();
            dgvRegistroDatos.DataSource = listaRegistros;

            // Carga la el cboCategoria con las categorías
            cboCategoria.DataSource = listaCategorias;
            // Sirve para que cboCategoria no inicie con una categoría seleccionada
            cboCategoria.SelectedItem = null;

            // Suma todos los montos y los muestra en nunTotalGastado
            decimal maximo = 1000000000M;
            if (listaRegistros.Count > 0)
            {
                totalGastado = listaRegistros.Sum(r => r.Monto);
            }
            else
            {
                totalGastado = 0;
            }
            nunTotalGastado.Maximum = maximo;
            nunTotalGastado.Value = totalGastado;
            OcultarColumnas();
        }

        private void OcultarColumnas()
        {
            dgvRegistroDatos.Columns["ID"].Visible = false;
        }

        private void CrearPDF(Registro registro)
        {
            string rutaArchivo;

            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Archivos PDF|*.pdf";
            guardar.Title = "Guardar archivo PDF";
            guardar.FileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf";

            string plantillaHtml = Resources.plantilla.ToString();
            plantillaHtml = plantillaHtml.Replace("@nombre", registro.NombreRegistro);
            plantillaHtml = plantillaHtml.Replace("@monto", registro.Monto.ToString());
            plantillaHtml = plantillaHtml.Replace("@categoria", registro.Categoria.Descripcion);
            plantillaHtml = plantillaHtml.Replace("@fecha", registro.FechaRegistro.ToString());

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                rutaArchivo = guardar.FileName;

                try
                {
                    // Verifica si el archivo ya existe
                    if (File.Exists(rutaArchivo))
                    {
                        MessageBox.Show("El archivo ya existe. Por favor, seleccione otro nombre o ubicación.");
                        return;
                    }

                    using (FileStream stream = new FileStream(rutaArchivo, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                        PdfWriter escritor = PdfWriter.GetInstance(pdfDoc, stream);

                        pdfDoc.Open();
                        pdfDoc.Add(new Paragraph(""));

                        using (StringReader reader = new StringReader(plantillaHtml))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(escritor, pdfDoc, reader);
                        }

                        pdfDoc.Close();
                        stream.Close();
                    }

                    MessageBox.Show("PDF descargado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error creando el PDF: {ex.Message}\n\nDetalles: {ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new Exception(ex.Message, ex);
                }
            } 
        }

        private void DescargarTodosLosRegistros()
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Archivos PDF|*.pdf";
            guardar.Title = "Guardar archivo PDF";
            guardar.FileName = "registros.pdf";
            if (guardar.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = guardar.FileName;

                try
                {
                    // Verifica si el archivo ya existe
                    if (File.Exists(rutaArchivo))
                    {
                        MessageBox.Show("El archivo ya existe. Por favor, seleccione otro nombre o ubicación.");
                        return;
                    }

                    using (FileStream stream = new FileStream(rutaArchivo, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                        PdfWriter escritor = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        foreach (var registro in listaRegistros)
                        {
                            string plantillaHtml = Resources.plantilla.ToString();
                            plantillaHtml = plantillaHtml.Replace("@nombre", registro.NombreRegistro);
                            plantillaHtml = plantillaHtml.Replace("@monto", registro.Monto.ToString());
                            plantillaHtml = plantillaHtml.Replace("@categoria", registro.Categoria.Descripcion);
                            plantillaHtml = plantillaHtml.Replace("@fecha", registro.FechaRegistro.ToString());
                            plantillaHtml = plantillaHtml.Replace("@titulo", registro.NombreRegistro);

                            using (StringReader reader = new StringReader(plantillaHtml))
                            {
                                XMLWorkerHelper.GetInstance().ParseXHtml(escritor, pdfDoc, reader);
                            }

                            //pdfDoc.NewPage(); // Agrega una nueva página para cada registro
                        }

                        pdfDoc.Close();
                        stream.Close();
                    }

                    MessageBox.Show("Registros descargados.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creando el PDF: {ex.Message}\n\nDetalles: {ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
        }
    }
}

