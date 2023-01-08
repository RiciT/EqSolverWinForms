namespace EqSolverWinForms
{
    public partial class Form1 : Form
    {
        List<TextBox> textBoxes = new List<TextBox>();

        public Form1()
        {
            InitializeComponent();
        }

        private void confirmnouButton_Click(object sender, EventArgs e)
        {
            if (nouTextBox.Text != null)
            {
                Controller.SetNOU(int.Parse(nouTextBox.Text));
                nouTextBox.Hide();
                nouTextBox.Enabled = false;
                confirmnouButton.Hide();
                confirmnouButton.Enabled = false;
                int nou = Controller.GetNOU();
                for (int i = 0; i < nou; i++)
                {
                    for (int j = 0; j < nou + 1; j++)
                    {
                        textBoxes.Add(new TextBox());
                        int count = panel1.Controls.OfType<TextBox>().ToList().Count;
                        textBoxes[i * (nou + 1) + j].Location = new System.Drawing.Point(10 + 85 * j, 30 * i);
                        textBoxes[i * (nou + 1) + j].Size = new System.Drawing.Size(80, 20);
                        textBoxes[i * (nou + 1) + j].Name = "txt_" + (i * (nou + 1) + j);
                        textBoxes[i * (nou + 1) + j].Text = j < Controller.GetNOU() ? "a" + (i + 1) + (j + 1) : "solution" + (i + 1);
                        panel1.Controls.Add(textBoxes[i * (nou + 1) + j]);
                    }
                }
                Button goButton = new Button();
                goButton.Location = new System.Drawing.Point(10, 250);
                goButton.Name = "GoButton";
                goButton.Text = "Go";
                goButton.Size = new System.Drawing.Size(60, 40);
                goButton.Click += new EventHandler(this.GoButton_Click);
                panel1.Controls.Add(goButton);
            }
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            double[] solutions; 

            for (int i = 0; i < Controller.GetNOU(); i++)
            {
                for (int j = 0; j < Controller.GetNOU() + 1; j++)
                {
                    if (j == Controller.GetNOU())
                    {
                        Controller.SetSol(i, int.Parse(textBoxes[i * (Controller.GetNOU() + 1) + j].Text));
                    }
                    else
                    {
                        Controller.SetEq(i, j, int.Parse(textBoxes[i * (Controller.GetNOU() + 1) + j].Text));
                    }
                }
            }
            solutions = Controller.Solve(Controller.GetEq(), Controller.GetSol());
            string solString = "";
            for (int i = 0; i < solutions.Length; i++)
            {
                solString += "x" + (i + 1) + " = " + Math.Round(solutions[i], 3) + "\n";
            }
            
            Label label = new Label();
            label.Location = new Point(50, 150);
            label.Size = new Size(250, 200);
            label.Text = solString;
            label.Name = "solutionLabel";
            panel1.Controls.Add(label);
            Button button = (sender as Button);

            button.Text = "Redo";
            button.Click -= new EventHandler(this.GoButton_Click);
            button.Click += new EventHandler(this.Redo);
        }

        private void Redo(object sender, EventArgs e)
        {
            nouTextBox.Show();
            nouTextBox.Enabled = true;
            confirmnouButton.Show();
            confirmnouButton.Enabled = true;

            panel1.Controls.Clear();
        }
    }
}