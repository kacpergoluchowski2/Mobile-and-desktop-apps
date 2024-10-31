using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dicing
{
    public class ExamVievModel : BindableObject
    {
        public ExamVievModel()
        {
            DrawCommand = new Command(Draw);
            ResetCommand = new Command(Reset);
            ThisDrawResult = "Wynik tego losowania: ";
            GameResult = "Wynik gry: ";
            CubeOne = "question.jpg";
            CubeTwo = "question.jpg";
            CubeThree = "question.jpg";
            CubeFour = "question.jpg";
            CubeFive = "question.jpg";
        }

        int[] randomNumbers = new int[5];
        string[] imagesNames = new string[5];
        int totalResult = 0;

        private string thisDrawResult;
        public string ThisDrawResult
        {
            get { return thisDrawResult; }
            set { thisDrawResult = value; OnPropertyChanged(nameof(ThisDrawResult)); }
        }

        private string gameResult;
        public string GameResult
        {
            get { return gameResult; }
            set { gameResult = value; OnPropertyChanged(); }
        }
        private string cubeOne;

        public string CubeOne
        {
            get { return cubeOne; }
            set { cubeOne = value; OnPropertyChanged(); }
        }

        private string cubeTwo;
        public string CubeTwo
        {
            get { return cubeTwo; }
            set { cubeTwo = value; OnPropertyChanged(); }
        }

        private string cubeThree;
        public string CubeThree
        {
            get { return cubeThree; }
            set { cubeThree = value; OnPropertyChanged(); }
        }

        private string cubeFour;
        public string CubeFour
        {
            get { return cubeFour; }
            set { cubeFour = value; OnPropertyChanged(); }
        }

        private string cubeFive;
        public string CubeFive
        {
            get { return cubeFive; }
            set { cubeFive = value; OnPropertyChanged(); }
        }

        private Command drawCommand;

        public Command DrawCommand
        {
            get { return drawCommand; }
            set { drawCommand = value; OnPropertyChanged(); }
        }

        private Command resetCommand;

        public Command ResetCommand
        {
            get { return resetCommand; }
            set { resetCommand = value; OnPropertyChanged(); }
        }


        // nazwa: sumOfNumbers
        // opis: funkcja sumuje liczby, które występują dwa lub więcej razy w tablicy
        // parametry: numbers - tablica wygenerowanych liczb 
        // zwracany typ i opis: sumOfNumbers - suma wszystkich liczb, które występują dwa lub więcej razy w tablicy
        // autor: kacperus
        int sumOfNumbers(int[] numbers)
        {
            int sumOfNumbers = 0;
            Dictionary<int, int> countMap = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (countMap.ContainsKey(numbers[i]))
                {
                    countMap[numbers[i]]++;
                }
                else
                {
                    countMap[numbers[i]] = 1;
                }
            }

            foreach (var value in countMap)
                if (value.Value > 1)
                    sumOfNumbers += value.Key * value.Value;

            return sumOfNumbers;
        }

        // nazwa: draw
        // opis: generuje liczby ktre sa zapisywane do tablicy, oraz wyswietla na layoucie odpowiednie zdjecia kostek
        // parametry: brak
        // zwracany brak
        // autor: kacperus
        public void Draw()
        {
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                randomNumbers[i] = random.Next(1, 7);
                imagesNames[i] = "k" + randomNumbers[i] + ".jpg";
            }

            CubeOne = imagesNames[0];
            CubeTwo = imagesNames[1];
            CubeThree = imagesNames[2];
            CubeFour = imagesNames[3];
            CubeFive = imagesNames[4];

            ThisDrawResult = "Wynik tego losowania: " + sumOfNumbers(randomNumbers);
            totalResult += sumOfNumbers(randomNumbers);
            GameResult = "Wynik gry: " + totalResult;
        }

        // nazwa: Reset
        // opis: po aktywowaniu funkcji zmienne totalResult, thisDrawResult sa resetowane i zdj
        // parametry: brak
        // zwracany typ i opis: brak
        // autor: kacperus
        private void Reset()
        {
            totalResult = 0;
            ThisDrawResult = "Wynik tego losowania: " + 0;
            GameResult = "Wynik gry: " + totalResult;

            CubeOne = "question.jpg";
            CubeTwo = "question.jpg";
            CubeThree = "question.jpg";
            CubeFour = "question.jpg";
            CubeFive = "question.jpg";
        }
    }
}
