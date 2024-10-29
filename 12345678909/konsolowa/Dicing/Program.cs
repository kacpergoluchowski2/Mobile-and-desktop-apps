void dicing()
{
    bool continuation = true;
    int cubeAmount = 1;

    while (cubeAmount < 3 || cubeAmount > 10)
    {
        Console.WriteLine("Ile kostek chcesz rzucić?(3 - 10)");
        string cubeAmountStr = Console.ReadLine();
        cubeAmount = Int32.Parse(cubeAmountStr);
    }

    while (continuation)
    {        
        int[] randomNumbers = new int[cubeAmount];

        generateNumbers(randomNumbers);

        for (int i = 0; i < cubeAmount; i++)
        {
            int currentIndex = i + 1;
            Console.WriteLine("Kostka " + currentIndex + ": " + randomNumbers[i]);
        }

        Console.WriteLine("Suma uzyskanych punktów: " + sumOfNumbers(randomNumbers));

        Console.WriteLine("Jeszcze raz?(t/n)");
        string choice = Console.ReadLine();
        if (choice == "t")
            continuation = true;
        else
            continuation = false;
    }
}

void generateNumbers(int[] numbers)
{
    Random random = new Random();
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = random.Next(1, 7);
    }
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
    {
        if (value.Value > 1)
        {
            sumOfNumbers += value.Key * value.Value;
        }
    }
        
    return sumOfNumbers;
}

dicing();