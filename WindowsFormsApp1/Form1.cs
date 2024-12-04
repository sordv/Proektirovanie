using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private UserController _controller;

        public Form1()
        {
            InitializeComponent();

            Panel header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.DarkBlue
            };

            Label headerLabel = new Label
            {
                Text = "Получение патента",
                ForeColor = Color.White,
                Font = new Font("Arial", 20, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            _controller = new UserController();

            Label countryLabel = new Label
            {
                Text = "Выберите страну вашего гражданства:",
                AutoSize = true,
                Location = new Point(20, 70)
            };

            ComboBox countryComboBox = new ComboBox
            {
                Name = "countryComboBox",
                Location = new Point(20, 90),
                Size = new Size(200, 30)
            };

            Label checkBoxLabel = new Label
            {
                Text = "Отметьте удтверждения, которые соответствуют вам:",
                AutoSize = true,
                Location = new Point(20, 130)
            };

            CheckBox checkBox1 = new CheckBox
            {
                Text = "Являюсь высококвалифицированным специалистом или членом его семьи",
                AutoSize = true,
                Location = new Point(20, 155)
            };

            CheckBox checkBox2 = new CheckBox
            {
                Text = "Являюсь участником государственной программы переселения соотечественников или членом его семьи",
                AutoSize = true,
                Location = new Point(20, 180)
            };

            Button generateButton = new Button
            {
                Text = "Сгенерировать\nдорожную карту",
                Location = new Point(20, 230),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };

            generateButton.Click += (s, e) =>
            {
                string selectedCountry = countryComboBox.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedCountry))
                {
                    MessageBox.Show("Укажите страну!");
                    return;
                }

                var roadmap = _controller.GenerateRoadmap(selectedCountry, checkBox1.Checked, checkBox2.Checked);
                string message = string.Join("\n", roadmap.Steps);
                MessageBox.Show(message, "Дорожная карта");
            };

            header.Controls.Add(headerLabel);
            this.Controls.Add(header);
            this.Controls.Add(countryLabel);
            countryComboBox.Items.AddRange(_controller.GetCountries().ToArray());
            this.Controls.Add(countryComboBox);
            this.Controls.Add(checkBoxLabel);
            this.Controls.Add(checkBox1);
            this.Controls.Add(checkBox2);
            this.Controls.Add(generateButton);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
