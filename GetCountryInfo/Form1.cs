using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GetCountryInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tbCountryTitle.Text = "Russia";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SendCntryNameButton_Click(object sender, EventArgs e)
        {
            try
            {
                CountryResponse.GetInfoCountryByName(tbCountryTitle.Text);
                tbCountryInfo.Text =
                    $"Название: {CountryResponse.GetCountry.name} {Environment.NewLine}" +
                    $"Код страны: {CountryResponse.GetCountry.callingCodes[0]} {Environment.NewLine}" +
                    $"Столица: {CountryResponse.GetCountry.capital} {Environment.NewLine}" +
                    $"Площадь: {CountryResponse.GetCountry.area} {Environment.NewLine}" +
                    $"Население: {CountryResponse.GetCountry.population} {Environment.NewLine}" +
                    $"Регион: {CountryResponse.GetCountry.region}";

                AddToBdButton.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        private void AddToBDbutton_Click(object sender, EventArgs e)
        {

            Country country = CountryResponse.GetCountry;
            DataBase.OpenConnection();

            string city_id = $"IF EXISTS(SELECT  city_id FROM cities WHERE city_name = '{country.capital}' ) " +
                $"SELECT city_id FROM cities WHERE city_name = '{country.capital}'";
            SqlCommand command = new SqlCommand(city_id, DataBase.GetConnection());
            if (command.ExecuteScalar() != null)
            { country.capitalId = (int)command.ExecuteScalar(); }

            else
            {
                command = new SqlCommand($"IF NOT EXISTS(SELECT  city_id FROM cities WHERE city_name = '{country.capital}' ) " +
                       $"INSERT INTO cities (city_name) VALUES ('{country.capital}')", DataBase.GetConnection());
                command.ExecuteNonQuery();
                command = new SqlCommand($"SELECT city_id FROM cities WHERE city_name = '{country.capital}'", DataBase.GetConnection());

                country.capitalId = (int)command.ExecuteScalar();
            }


            string region_id = $"IF EXISTS(SELECT region FROM regions WHERE region = '{country.region}') " +
                $"SELECT region_id FROM regions WHERE region = '{country.region}'";
            command = new SqlCommand(region_id, DataBase.GetConnection());
            if (command.ExecuteScalar() != null)
            {
                country.regionId = (int)command.ExecuteScalar();
            }
            else
            {

                command = new SqlCommand($"INSERT INTO regions (region) VALUES ('{country.region}')", DataBase.GetConnection());
                command.ExecuteNonQuery();
                command = new SqlCommand($"SELECT region_id FROM regions WHERE region = '{country.region}'", DataBase.GetConnection());

                country.regionId = (int)command.ExecuteScalar();
            }



            string countryExist = $"IF EXISTS(SELECT country_name FROM countries WHERE country_code ='{country.callingCodes[0]}' )" +
                $"SELECT country_name FROM countries WHERE country_code ='{country.callingCodes[0]}'";
            command = new SqlCommand(countryExist, DataBase.GetConnection());
            if (command.ExecuteScalar() != null)
            {
                string updateCountry = $"UPDATE countries " +
                    $"SET country_name ='{country.name}' , country_code = '{country.callingCodes[0]}', country_capital = '{country.capitalId}', country_area= '{country.area}', country_population ='{country.population}', country_region = '{country.regionId}' WHERE country_code = '{country.callingCodes[0]}'";
                command = new SqlCommand(updateCountry, DataBase.GetConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Страна обновлена!");
            }
            else
            {
                string insertCountries = $"INSERT INTO countries (country_name, country_code, country_capital, country_area, country_population, country_region) VALUES ('{country.name}', '{country.callingCodes[0]}', '{country.capitalId}', '{country.area}', '{country.population}', '{country.regionId}')";
                command = new SqlCommand(insertCountries, DataBase.GetConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Страна успешно добавлена!");
            }

            DataBase.CloseConnection();
        }

        private void GetAllFromDBbutton_Click(object sender, EventArgs e)
        {
            AddToBdButton.Visible = false;
            tbCountryInfo.Text = "";
            DataBase.OpenConnection();
            string getAll = "SELECT country_name, country_code, city_name,country_area,country_population, region FROM regions " +
                "JOIN countries ON regions.region_id = countries.country_region " +
                "JOIN cities ON countries.country_capital = cities.city_id";
            SqlCommand command = new SqlCommand(getAll, DataBase.GetConnection());
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    tbCountryInfo.Text +=
                 $"Название: {reader["country_name"].ToString()} {Environment.NewLine}" +
                 $"Код страны: {reader["country_code"].ToString()} {Environment.NewLine}" +
                 $"Столица: {reader["city_name"].ToString()} {Environment.NewLine}" +
                 $"Площадь: {reader["country_area"].ToString()} {Environment.NewLine}" +
                 $"Население:{reader["country_population"].ToString()} {Environment.NewLine}" +
                 $"Регион:{reader["region"].ToString()}{Environment.NewLine} {Environment.NewLine}";

                }
            }
            DataBase.CloseConnection();
        }
    }
}
