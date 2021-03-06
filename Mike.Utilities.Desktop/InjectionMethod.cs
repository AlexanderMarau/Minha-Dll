﻿using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Mike.Utilities.Desktop
{
    public static class InjectionMethod
    {
        public static string ToDataCerta(this DateTime data)
        {
            return data.ToString("dd/MM/yyyy HH:mm:ss");
        }
        public static string ToDataCertaSemHora(this DateTime data)
        {
            return data.ToString("dd/MM/yyyy");
        }
        public static bool RetornaErro(this bool retorno, string erro)
        {
            throw new CustomException(erro);
        }
        public static void FocoNoTxt(this Form form, TextBox txt)
        {
            form.ActiveControl = txt;
        }
        public static void FocoNoBotao(this Form form, Button btn)
        {
            form.ActiveControl = btn;
        }
        public static void FocoNoComboBox(this Form form, ComboBox cbb)
        {
            form.ActiveControl = cbb;
        }
        public static void FocoNoRadioButton(this Form form, RadioButton rdb)
        {
            form.ActiveControl = rdb;
        }
        public static Form FormException(this Form form, string erro)
        {
            throw new CustomException(erro);

        }
        public static string UpperCaseOnlyFirst(this string txt)
        {
            return txt != "" ? txt.First().ToString().ToUpper() + String.Join("", txt.Skip(1)).ToLower():"";
        }
        public static bool ValidarCPF(this string cpf)
        {
            string valor = cpf.Replace(".", ""); valor = valor.Replace("-", "");
            if (valor.Length != 11)
            {
                return false;
            }
            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
            {
                if (valor[i] != valor[0])
                {
                    igual = false;
                }
            }

            if (igual || valor == "12345678909")
            {
                return false;
            }
            int[] numeros = new int[11];
            for (int i = 0; i < 11; i++)
            {
                numeros[i] = int.Parse(valor[i].ToString());
            }
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += (10 - i) * numeros[i];
            }
            int resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                {
                    return false;
                }
            }
            else if (numeros[9] != 11 - resultado)
            {
                return false;
            }
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += (11 - i) * numeros[i];
            }
            resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                {
                    return false;
                }
            }
            else if (numeros[10] != 11 - resultado)
            {
                return false;
            }
            return true;

        }

        public static char MostrarSenha(this TextBox txt)
        {
            return txt.PasswordChar = '\0';
        }
        public static void AjustartamanhoDoDataGridView(this DataGridView dgv, List<TamanhoGrid> tamanhoGrid)
        {
            foreach (var item in tamanhoGrid)
            {
                dgv.Columns[item.ColunaNome].Width = item.Tamanho;
            }

        }
        public static decimal SomarColunaDoGrid(this DataGridView dgv, string nomeDaColuna)
        {
            decimal valorTotal = 0;
            if (dgv.Rows.Count > 0)
            {
                for (int contador = 0; contador < dgv.Rows.Count; ++contador)
                {
                    valorTotal += Convert.ToDecimal(dgv.Rows[contador].Cells[nomeDaColuna].Value);
                }
                dgv.Text = valorTotal.ToString("C2");
            }
            return valorTotal;
        }
        public static int ErroCustomForTernary(this int number, string erro)
        {
            throw new CustomException(erro);
        }
        public static void EsconderColuna(this DataGridView dgv, string comunName)
        {
            dgv.Columns[comunName].Visible = false;
        }
        public static void LimparTxtNoEventoChanged(this TextBox txt, EventHandler evento)
        {
            txt.TextChanged -= evento;
            txt.Clear();
            txt.TextChanged += evento;
        }
        public static void LimparTxt(this TextBox txt)
        {
            txt.Text = string.Empty;
        }
        public static TextBox ValidarCampos(this TextBox[] txtArray, string textoAviso = "Todos os campos em amarelo são obrigatórios.", bool exibirMensagem = true, Color? cor = null)
        {
            var lista = txtArray.ToList().Where(c => cor == null ? c.BackColor == Color.Yellow && c.Text.Trim() == "" : c.BackColor == cor && c.Text.Trim() == "");
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(textoAviso, "Aviso");
            }
            return lista.FirstOrDefault();
        }
        public static void LimparTxtList(this List<TextBox> txtList) => txtList.ForEach(c => c.Text = string.Empty);

        public static void PadronizarGrid(this DataGridView dgv)
        {
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            dgv.AllowDrop = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dgv.BackgroundColor = System.Drawing.Color.White;
            cellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            cellStyle.BackColor = System.Drawing.Color.White;
            cellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cellStyle.ForeColor = System.Drawing.Color.Black;
            cellStyle.SelectionBackColor = System.Drawing.Color.Yellow;
            cellStyle.SelectionForeColor = System.Drawing.Color.Black;
            cellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgv.DefaultCellStyle = cellStyle;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = System.Drawing.SystemColors.Window;
            headerStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            headerStyle.ForeColor = System.Drawing.Color.Black;
            headerStyle.SelectionBackColor = System.Drawing.Color.White;
            headerStyle.SelectionForeColor = System.Drawing.Color.Black;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv.TabIndex = 0;
            dgv.TabStop = false;

        }
        public static DateTime DataNoFormatoDate(this DateTime dtt)
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }
        private static LinhaDoGrid GetInformacoesDoGrid(DataGridView dgv)
        {

            try
            {
                LinhaDoGrid linhaDoGrid = null;
                if (dgv.Rows.Count > 0)
                {

                    for (int contador = 0; contador < dgv.Rows.Count; ++contador)
                    {
                        linhaDoGrid = new LinhaDoGrid()
                        {
                            LucroTotal = Convert.ToDecimal(dgv.Rows[contador].Cells[1].Value),
                            ValorTotal = Convert.ToDecimal(dgv.Rows[contador].Cells[0].Value),
                            Quantidade = Convert.ToInt32(dgv.Rows[contador].Cells[2].Value)
                        };
                    }
                }
                return linhaDoGrid;
            }
            catch (CustomException erro)
            {
                throw new CustomException(erro.Message);
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }


        }
        public static string GetFullPath(this string arquivoComExtensao)
        {
            return Directory.GetFiles(System.IO.Path.GetDirectoryName(Path.GetDirectoryName(Application.StartupPath)), arquivoComExtensao, SearchOption.AllDirectories).FirstOrDefault();
        }
        public static void MoveToUp(this DataGridView dgv)
        {
            if (dgv.Rows.Count > 0)
            {
                int indexUp = dgv.SelectedRows[0].Index;
                if (indexUp > 0)
                {
                    dgv.Rows[indexUp].Selected = false;
                    dgv.Rows[indexUp - 1].Selected = true;
                }
            }
        }
        public static void MoveToDown(this DataGridView dgv)
        {
            if (dgv.Rows.Count > 0)
            {
                int indexDown = dgv.SelectedRows[0].Index;
                if (indexDown >= 0 && indexDown < dgv.Rows.Count - 1)
                {
                    dgv.Rows[indexDown].Selected = false;
                    dgv.Rows[indexDown + 1].Selected = true;
                }
            } 
        }
        public static object GetSelectRow(this DataGridView dgv,int columIndex, string columName)
        {
            return dgv.SelectedRows[columIndex].Cells[columName].Value.ToString();
        }
    }
}
