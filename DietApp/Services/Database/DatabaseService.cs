using DietApp.Models;
using DietApp.Services.Diet;
using DietApp.Services.Profile;
using Newtonsoft.Json.Linq;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DietApp.Services.Database
{
    public class DatabaseService : IDatabaseService
    {
        private List<string> _genderOptions = new List<string>();

        public static string url = "https://autodb.work/alimente.json";

        private string _json = string.Empty;

        private List<Breakfast> _breakfasts = new List<Breakfast>();
        private List<Lunch> _lunches = new List<Lunch>();
        private List<Dinner> _dinners = new List<Dinner>();

        public DatabaseService()
        {
            _genderOptions.Add("Barbat");
            _genderOptions.Add("Femeie");
        }

        public async Task InitRemoteData()
        {
            await SetBreakfastAliments();
            await SetLunchAliments();
            await SetDinnerAliments();

            await Task.FromResult(true);
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
                    breakfast.Day = 1;
                }
                else
                {
                    breakfast.Day = index + 1;
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

            int index = 0;

            JObject data = JObject.Parse(_json);
            foreach (var _day in data["pranz"])
            {
                Lunch lunch = new Lunch();

                if (index == 0)
                {
                    lunch.Day = 1;
                }
                else
                {
                    lunch.Day = index + 1;
                }


                foreach (var _recipe in _day)
                {
                    Recipe recipe = new Recipe();

                    recipe.Name = (string)_recipe["nume"];

                    foreach (var _aliment in _recipe["alimente"])
                    {
                        Aliment aliment = new Aliment();

                        aliment.Nume = _aliment["nume"].ToString();
                        aliment.Greutate = int.Parse(_aliment["greutate"].ToString());
                        aliment.Calorii = double.Parse(_aliment["calorii"].ToString());

                        recipe.Ingredients.Add(aliment);

                    }

                    lunch.Foods.Add(recipe);
                }

                _lunches.Add(lunch);

                ++index;
            }
        }

        public async Task SetDinnerAliments()
        {
            if (string.IsNullOrEmpty(_json))
            {
                await GetRemoteData();
            }

            int index = 0;

            JObject data = JObject.Parse(_json);
            foreach (var _day in data["cina"])
            {
                
                Dinner dinner = new Dinner();

                if (index == 0)
                {
                    dinner.Day = 1;
                }
                else
                {
                    dinner.Day = index + 1;
                }


                foreach (var _recipe in _day)
                {
                    Recipe recipe = new Recipe();

                    recipe.Name = (string)_recipe["nume"];

                    foreach (var _aliment in _recipe["alimente"])
                    {
                        Aliment aliment = new Aliment();

                        aliment.Nume = _aliment["nume"].ToString();
                        aliment.Greutate = int.Parse(_aliment["greutate"].ToString());
                        aliment.Calorii = double.Parse(_aliment["calorii"].ToString());

                        recipe.Ingredients.Add(aliment);

                    }

                    dinner.Foods.Add(recipe);
                }

                _dinners.Add(dinner);

                ++index;
            }
        }


        public List<string> GetGenderOptions()
        {
            return _genderOptions;
        }

        public List<Aliment> GetBreakfasts()
        {
            List<Aliment> aliments = new List<Aliment>();

            foreach (Breakfast breakfast in _breakfasts)
            {
                if (breakfast.Day == GetCurrentDietDay())
                {
                    aliments = breakfast.Foods;
                }
            }

            return aliments;
        }

        public List<Recipe> GetLunches()
        {
            List<Recipe> recipes = new List<Recipe>();

            foreach (Lunch lunch in _lunches)
            {
                if (lunch.Day == GetCurrentDietDay())
                {
                    foreach (Recipe recipe in lunch.Foods)
                    {
                        recipes.Add(recipe);
                    }
                }
            }

            return recipes;
        }

        public List<Recipe> GetDinners()
        {
            List<Recipe> recipes = new List<Recipe>();

            foreach (Dinner dinner in _dinners)
            {
                if (dinner.Day == GetCurrentDietDay())
                {
                    foreach (Recipe recipe in dinner.Foods)
                    {
                        recipes.Add(recipe);
                    }
                }
            }

            return recipes;
        }

        public async Task SetDietStartDate()
        {
            Application.Current.Properties["DietStartDate"] = DateTime.Now;

            await Task.FromResult(true);
        }

        public DateTime GetDietStartDate()
        {
            if (Application.Current.Properties.ContainsKey("DietStartDate"))
            {
                var startDate = (DateTime)Application.Current.Properties["DietStartDate"];

                return startDate;
            }

            return DateTime.Now;
        }

        public bool SetCurrentDietDay()
        {
            DateTime startDay = GetDietStartDate();
            DateTime currentDay = DateTime.Now;
            //currentDay = currentDay.AddDays(14);

            if (startDay.Date == currentDay.Date)
            {
                Application.Current.Properties["DietCurrentDay"] = 1;
                return true;
            }

            if ((currentDay - startDay).TotalDays <= 16)
            {
                Application.Current.Properties["DietCurrentDay"] = (int)(currentDay - startDay).TotalDays + 1;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetCurrentDietDay()
        {
            return (int)Application.Current.Properties["DietCurrentDay"];
        }
    }
}
