using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GuessTheNumber
{
    class AppSettings
    {
        public int maxValue { get; set; }
        public int minValue { get; set; }

    }

    public class GuessGame
    {
        private int hiddenNumber;
        Random rand = new Random();
        string jsonData;
        private int randomMinValue;
        private int randomMaxValue;

        public GuessGame()
        {
            StreamReader reader = new StreamReader("..\\..\\..\\appSettings.json");
            this.jsonData = reader.ReadToEnd();
            AppSettings settings = JsonConvert.DeserializeObject<AppSettings>(jsonData);
            this.randomMinValue = settings.minValue;
            this.randomMaxValue = settings.maxValue + 1;
            this.hiddenNumber = rand.Next(randomMinValue, randomMaxValue);
        }

        public GuessGame(int value)
        {
            this.hiddenNumber = value;
        }

        public bool AreYouWin(int value)
        {
            if (value == this.hiddenNumber)
            {
                this.hiddenNumber = rand.Next(randomMinValue, randomMaxValue);
                return true;
            }
            return false;
        }

        public string GetHint(int value)
        {
            if (value < this.hiddenNumber)
            {
                return "Try to take a bigger number";
            }
            return "Try to take a smaller number";
        }

    }
}
