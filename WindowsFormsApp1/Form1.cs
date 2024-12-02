using System;
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

            _controller = new UserController();

            // Компоненты UI
            ComboBox countryComboBox = new ComboBox
            {
                Name = "countryComboBox",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(200, 30)
            };
            countryComboBox.Items.AddRange(_controller.GetCountries().ToArray());
            this.Controls.Add(countryComboBox);

            CheckBox checkBox1 = new CheckBox
            {
                Text = "Являюсь высококвалифицированным специалистом или членом его семьи",
                AutoSize = true,
                Location = new System.Drawing.Point(20, 60)
            };

            CheckBox checkBox2 = new CheckBox
            {
                Text = "Являюсь участником государственной программы переселения соотечественников или членом его семьи",
                AutoSize = true,
                Location = new System.Drawing.Point(20, 90)
            };

            Button generateButton = new Button
            {
                Text = "Сгенерировать",
                Location = new System.Drawing.Point(20, 130),
                Size = new System.Drawing.Size(100, 30)
            };
            generateButton.Click += (s, e) =>
            {
                string selectedCountry = countryComboBox.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedCountry))
                {
                    MessageBox.Show("Выберите страну!");
                    return;
                }

                var roadmap = _controller.GenerateRoadmap(selectedCountry, checkBox1.Checked, checkBox2.Checked);
                string message = string.Join("\n", roadmap.Steps);
                MessageBox.Show(message, "Дорожная карта");
            };

            this.Controls.Add(checkBox1);
            this.Controls.Add(checkBox2);
            this.Controls.Add(generateButton);
        }
    }
}
