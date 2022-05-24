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
        private List<string> _genderOptions = new List<string>();

        public static string url = "https://autodb.work/alimente.json";

        private string _json = string.Empty;

        private List<Aliment> _breakfastAliments = new List<Aliment>();
        private List<Aliment> _lunchAliments = new List<Aliment>();
        private List<Aliment> _dinnerAliments = new List<Aliment>();

        public void InitializeDatabase()
        {
            // TODO: Initialize database
        }

        public DatabaseService()
        {
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

            JObject data = JObject.Parse(_json);
            foreach (var item in data["mic_dejun"][0])
            {
                Aliment aliment = new Aliment();

                aliment.Nume = item["nume"].ToString();
                aliment.Greutate = int.Parse(item["greutate"].ToString());
                aliment.Calorii = double.Parse(item["calorii"].ToString());

                _breakfastAliments.Add(aliment);
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
            return _breakfastAliments;
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
