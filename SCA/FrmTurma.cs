﻿using DAL;
using SCA_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FittSistema.View
{
    public partial class FrmTurma : Form
    {
        public FrmTurma()
        {
            InitializeComponent();
        }
        ProfessorBLL professorBLL = new ProfessorBLL();
        TurmaBLL turmaBLL = new TurmaBLL();
        private void btnFecharTela_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMenu menu = new FrmMenu();
            menu.ShowDialog();
            this.Close();
        }


        private void btnCadastrarProfessor_Click(object sender, EventArgs e)
        {
            if (tabSemanas.Visible == true)
            {
                tabSemanas.Hide();
                LimpaCampos();
                btnCadastrar.Show();
                btnVoltar.Show();
            }
            else if (ValidaCampos() != "")
            {
                MessageBox.Show(ValidaCampos(), "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var turma = new Turma
                {
                    CPF = cmbProfessor.SelectedValue.ToString(),
                    DiaSemana = cmbDiaSemana.SelectedItem.ToString(),
                    Horario = cmbHorario.SelectedItem.ToString()
                };
                MessageBox.Show(turmaBLL.Adicionar(turma));
                tabSemanas.Show();
                btnVoltar.Hide();
                ListaTurmas();
                LimpaCampos();

            }
        }

        private void ListaTurmas()
        {
            var turmaSegunda = turmaBLL.LerTurma("Segunda");
            grpSegunda.DataSource = turmaSegunda;

            var turmaTerca = turmaBLL.LerTurma("Terça");
            grpTerca.DataSource = turmaTerca.ToList();


            var turmaQuarta = turmaBLL.LerTurma("Quarta");
            grpQuarta.DataSource = turmaQuarta.ToList();


            var turmaQuinta = turmaBLL.LerTurma("Quinta");
            grpQuinta.DataSource = turmaQuinta.ToList();


            var turmaSexta = turmaBLL.LerTurma("Sexta");
            grpSexta.DataSource = turmaSexta.ToList();
        }

        private string ValidaCampos()
        {
            string erro = "";
            if (cmbProfessor.SelectedIndex == -1)
            {
                erro = "Selecione um Professor";
            }
            else if (cmbDiaSemana.SelectedIndex == -1)
            {
                erro = "Selecione um dia da semana";
            }
            else if (cmbHorario.SelectedIndex == -1)
            {
                erro = "Selciona um Horário";
            }
            return erro;
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Alterar esses dados?", "Alterar Turma", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (ValidaCampos() != "")
                {
                    MessageBox.Show(ValidaCampos(), "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                      var turma = new Turma
                    {
                        idTurma = Convert.ToInt32(txtId.Text),
                        CPF = cmbProfessor.SelectedValue.ToString(),
                        DiaSemana = cmbDiaSemana.SelectedItem.ToString(),
                        Horario = cmbHorario.SelectedItem.ToString()
                    };
                    MessageBox.Show(turmaBLL.Alterar(turma));
                    ListaTurmas();
                    tabSemanas.Show();
                    btnCadastrar.Show();
                    btnEditar.Hide();
                    btnExcluir.Hide();
                    btnVoltar.Hide();
                }
            }
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Deletar esses dados?", "Deletar Turma", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var turma = new Turma
                {
                    idTurma = Convert.ToInt32(txtId.Text),
                };
                MessageBox.Show(turmaBLL.Deletar(turma));
                ListaTurmas();
                tabSemanas.Show();
                btnCadastrar.Show();
                btnEditar.Hide();
                btnExcluir.Hide();
                btnVoltar.Hide();
            }
        }

        private void FrmTurma_Load_1(object sender, EventArgs e)
        {
            cmbProfessor.DataSource = professorBLL.ListarProfessores().ToList();
            cmbProfessor.ValueMember = "CPF";
            cmbProfessor.SelectedValue = "CPF";
            cmbProfessor.DisplayMember = "Nome"; 

            cmbDiaSemana.Items.Add("Segunda");
            cmbDiaSemana.Items.Add("Terça");
            cmbDiaSemana.Items.Add("Quarta");
            cmbDiaSemana.Items.Add("Quinta");
            cmbDiaSemana.Items.Add("Sexta");

            cmbHorario.Items.Add("08h-10h");
            cmbHorario.Items.Add("10h-12h");
            cmbHorario.Items.Add("14h-15h");
            cmbHorario.Items.Add("15h-16h");
            cmbHorario.Items.Add("16h-18h");

            ListaTurmas();
        }

        private void LimpaCampos()
        {
            cmbDiaSemana.SelectedIndex = -1;
            cmbHorario.SelectedIndex = -1;
            cmbProfessor.SelectedIndex = -1;
        }


        private void cliqueDataGrid(DataGridView dt)
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dt.SelectedRows)
                {
                    txtId.Text = row.Cells[0].Value.ToString();
                    cmbProfessor.Text = row.Cells[1].Value.ToString();
                    cmbDiaSemana.SelectedItem = row.Cells[2].Value.ToString();
                    cmbHorario.SelectedItem = row.Cells[3].Value.ToString();

                }
                tabSemanas.Hide();
                btnCadastrar.Hide();
                btnEditar.Show();
                btnExcluir.Show();
                btnVoltar.Show();
            }
        }

        private void grpSegunda_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            cliqueDataGrid(grpSegunda);
        }

        private void grpTerca_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cliqueDataGrid(grpTerca);
        }

        private void grpQuarta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cliqueDataGrid(grpQuarta);
        }

        private void grpQuinta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cliqueDataGrid(grpQuinta);
        }

        private void grpSexta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cliqueDataGrid(grpSexta);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            tabSemanas.Show();
            btnCadastrar.Show();
            btnEditar.Hide();
            btnExcluir.Hide();
            btnVoltar.Hide();
        }
    }
}
