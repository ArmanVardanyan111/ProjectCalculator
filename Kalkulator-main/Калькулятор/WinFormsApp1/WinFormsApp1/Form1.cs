using System;
using System.Linq.Expressions;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        string[] history = new string[10];

        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            lblInfo.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            lblInfo.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            lblInfo.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            lblInfo.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            lblInfo.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            lblInfo.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            lblInfo.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            lblInfo.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            lblInfo.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            lblInfo.Text += "0";
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            lblInfo.Text += ".";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            HistoryWriter(lblInfo.Text);
            lblInfo.Text = "";
        }

        private void btnDelenye_Click(object sender, EventArgs e)
        {
            lblInfo.Text += " / ";
        }

        private void btnMulty_Click(object sender, EventArgs e)
        {
            lblInfo.Text += " * ";
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            lblInfo.Text += " - ";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            lblInfo.Text += " + ";
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            lblInfo.Text += "^(";
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                double result = EvaluateExpression(lblInfo.Text);
                string resultStr = result.ToString();
                string resultStr_ = "";
                for (int i = 0; i < resultStr.Length; i++)
                {
                    if (resultStr[i] == ',')
                    {
                        resultStr_ += '.';
                    }
                    else
                    {
                        resultStr_ += resultStr[i];
                    }
                }
                lblInfo.Text = resultStr_;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private double EvaluateExpression(string expression)
        {
            var dataTable = new System.Data.DataTable();
            var dataview = new System.Data.DataView();
            try
            {
                HistoryWriter(expression);
                var result = dataTable.Compute(expression, "");

                return Convert.ToDouble(result);
            }
            catch
            {
                throw new Exception("Ошибка в выражении.");
            }
        }

        private void btnSkobkaL_Click(object sender, EventArgs e)
        {
            lblInfo.Text += "(";
        }

        private void btnSkobkaR_Click(object sender, EventArgs e)
        {
            lblInfo.Text += ")";
        }

        private void HistoryWriter(string historyNew)
        {
            if (string.IsNullOrEmpty(history[0]))
            {
                history[0] = historyNew;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i != 9 && string.IsNullOrEmpty(history[i + 1]))
                    {
                        for (int j = i + 1; j > 0; j--)
                        {
                            history[j] = history[j - 1];
                        }

                        break;
                    }
                    else if (i == 9)
                    {
                        for (int j = i; j > 0; j--)
                        {
                            history[j] = history[j - 1];
                        }
                    }
                }

                history[0] = historyNew;
            }
            lbHistory.Items.Clear();
            for (int i = 0; i < 10; i++)
            {
                if (!string.IsNullOrEmpty(history[i]))
                {
                    lbHistory.Items.Add(history[i]);
                }
                else
                {
                    break;
                }
            }
        }

        private void lbHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblInfo.Text = lbHistory.SelectedItem.ToString();
        }
    }
}