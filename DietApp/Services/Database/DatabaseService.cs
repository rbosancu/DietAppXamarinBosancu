using DietApp.Models;
using Newtonsoft.Json.Linq;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.Services.Database
{
    public class DatabaseService : IDatabaseService
    {
        private DateTime _currentDay;

        private List<string> _genderOptions = new List<string>();

        public static string url = "https://autodb.work/alimente.json";

        private string _json = string.Empty;

        private List<Breakfast> _breakfasts = new List<Breakfast>();
        private List<Aliment> _lunchAliments = new List<Aliment>();
        private List<Aliment> _dinnerAliments = new List<Aliment>();

        public void InitializeDatabase()
        {
            // TODO: Initialize database
        }

        public DatabaseService()
        {
            _currentDay = DateTime.Now.Date;

            _genderOptions.Add("Barbat");
            _genderOptions.Add("Femeie");
        }

        public async Task GetRemoteData()
        {
            using (var w = new WebClient())
            {
                string json_data = string.Empty;
                
                try
                {
                    json_data =  w.DownloadString(url);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

                _json = json_data;
            }

            await Task.FromResult(true);
        }

        public async Task SetBreakfastAliments()
        {
            if (string.IsNullOrEmpty(_json))
            {
                await GetRemoteData();
            }

            int index = 0;

            JObject data = JObject.Parse(_json);
            foreach (JToken _breakfast in data["mic_dejun"])
            {
                Breakfast breakfast = new Breakfast();

                if (index == 0)
                {
                    breakfast.Day = _currentDay.Date;
                }
                else
                {
                    breakfast.Day = _currentDay.AddDays(index);
                }

                foreach(JToken _aliment in data["mic_dejun"][index])
                {
                    Aliment aliment = new Aliment();

                    aliment.Nume = _aliment["nume"].ToString();
                    aliment.Greutate = int.Parse(_aliment["greutate"].ToString());
                    aliment.Calorii = double.Parse(_aliment["calorii"].ToString());

                    breakfast.Foods.Add(aliment);
                }

                _breakfasts.Add(breakfast);

                index++;
            }
        }

        public async Task SetLunchAliments()
        {
            if (string.IsNullOrEmpty(_json))
            {
                await GetRemoteData();
            }

            JObject data = JObject.Parse(_json);
            foreach (var item in data["pranz"])
            {
                Aliment aliment = new Aliment();

                aliment.Nume = item["nume"].ToString();
                aliment.Greutate = int.Parse(item["greutate"].ToString());
                aliment.Calorii = double.Parse(item["calorii"].ToString());
                aliment.Carbohidrati = int.Parse(item["carbohidrati"].ToString());
                aliment.Proteine = int.Parse(item["proteine"].ToString());

                _lunchAliments.Add(aliment);
            }
        }

        public async Task SetDinnerAliments()
        {
            if (string.IsNullOrEmpty(_json))
            {
                await GetRemoteData();
            }

            JObject data = JObject.Parse(_json);
            foreach (var item in data["cina"])
            {
                Aliment aliment = new Aliment();

                aliment.Nume = item["nume"].ToString();
                aliment.Greutate = int.Parse(item["greutate"].ToString());
                aliment.Calorii = double.Parse(item["calorii"].ToString());
                aliment.Carbohidrati = int.Parse(item["carbohidrati"].ToString());
                aliment.Proteine = int.Parse(item["proteine"].ToString());

                _dinnerAliments.Add(aliment);
            }
        }


        public List<string> GetGenderOptions()
        {
            return _genderOptions;
        }

        public List<Aliment> GetBreakfasts()
        {
            DateTime day = DateTime.Now.Date;
            day = day.AddDays(1);

            List<Aliment> aliments = new List<Aliment>();

            foreach (Breakfast breakfast in _breakfasts)
            {
                if (breakfast.Day == day)
                {
                    aliments = breakfast.Foods;
                }
            }

            return aliments;
        }

        public List<Aliment> GetLunches()
        {
            return _lunchAliments;
        }

        public List<Aliment> GetDinners()
        {
            return _dinnerAliments;
        }

        //string _databaseName = "dietApp.db3";
        //private SQLiteConnection _db;
        //public void initializeDatabase()
        //{
        //    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), _databaseName);
        //    _db = new SQLiteConnection(dbPath);
        //}
    }
}
