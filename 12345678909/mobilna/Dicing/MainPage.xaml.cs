namespace Dicing
{
    public partial class MainPage : ContentPage
    {
        int[] randomNumbers = new int[5];
        string[] imagesNames = new string[5];
        int totalResult = 0;

        public MainPage()
        {
            InitializeComponent();
        }

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

        private void Button_Clicked(object sender, EventArgs e)
        {
            Random random = new Random();
            int result = 0; 
            for(int i = 0; i < 5; i++)
            {
                randomNumbers[i] = random.Next(1, 7);
                for(int j = 0; j < i; j++)
                {
                    if (i == j)
                        break;
                    else if (randomNumbers[i] == randomNumbers[j])
                        result += randomNumbers[i];
                }
                imagesNames[i] = "k" + randomNumbers[i] + ".jpg"; 
            }

            cubeOne.Source = imagesNames[0];
            cubeTwo.Source = imagesNames[1];
            cubeThree.Source = imagesNames[2];
            cubeFour.Source = imagesNames[3];
            cubeFive.Source = imagesNames[4];

            thisDrawResult.Text = "Wynik tego losowania: " + sumOfNumbers(randomNumbers);
            totalResult += sumOfNumbers(randomNumbers);
            gameResult.Text = "Wynik gry: " + totalResult;
        }

        private void Reset(object sender, EventArgs e)
        {
            totalResult = 0;
            thisDrawResult.Text = "Wynik tego losowania: " + 0;
            gameResult.Text = "Wynik gry: " + totalResult;

            cubeOne.Source = "question.jpg";
            cubeTwo.Source = "question.jpg";
            cubeThree.Source = "question.jpg";
            cubeFour.Source = "question.jpg";
            cubeFive.Source = "question.jpg";
        }
    }

}
