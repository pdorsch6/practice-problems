<Query Kind="Program" />

void Main()
{
	var coins = new List<int> { 1, 2, 3 };
	var n = 4;
	
	//Console.WriteLine(this.CoinChangeDP(coins, n));
	Console.WriteLine(countOptimal(coins, n));
	
	coins = new List<int> { 2, 5, 3, 6 };
	n = 10;
	
	//Console.WriteLine(this.CoinChangeDP(coins, n));
	
	Console.WriteLine(countOptimal(coins, n));
}

// You can define other methods, fields, classes and namespaces here

// dynamic programming attempt
int CoinChangeDP(List<int> coins, int targetValue)
{
	int[,] coinSolutions = new int[targetValue + 1, coins.Count + 1];
	for (var value = 0; value < targetValue + 1; value++)
	{
		Console.WriteLine("----");
		for (var coin = 0; coin < coins.Count + 1; coin++)
		{
			if(value == 0 || coin == 0) 
			{
				coinSolutions[value, coin] = 0;
			}
			else 
			{
				// get the number of solutions for the set of coins before this one is added
				// that equals the current value
				var previousCoinsThatEqualValue = coinSolutions[value, coin - 1];
				
				// get the number of solutions for the set of coins before this one is added
				// that equals the current value - current coin value
				var previousCoinsThatEqualValueMinusCurrentCoinValue = value - coins[coin-1] > 0
					? coinSolutions[value - coins[coin-1], coin - 1]
					: 0;
				Console.WriteLine($"Coin: {coins[coin-1]} Value: {value}");
				Console.WriteLine($"EV: {previousCoinsThatEqualValue} EVMCCV: {previousCoinsThatEqualValueMinusCurrentCoinValue} D: {(value % coins[coin-1] == 0 ? 1 : 0)}");
				coinSolutions[value, coin] = previousCoinsThatEqualValue 
					+ previousCoinsThatEqualValueMinusCurrentCoinValue 
					+ (value % coins[coin-1] == 0 ? 1 : 0); // add 1 if value is divisible by coin value
			}
		}
	}
	return coinSolutions[targetValue, coins.Count];
}

// actual DP solution
int countOptimal(List<int> coins, int amt) {

    // solutions[i] contains the no. of solutions for value i.
    // We build from bottom up using the base case (n = 0)
    int[] solutions = new int[amt + 1];
    solutions[0] = 1;
  
    foreach (var i in coins)
      for (int j = i; j <= amt; j++)
        solutions[j] += solutions[j - i];

    return solutions[amt];
}





// bad method because does not account for order of coins
int CoinChange(List<int> coins, int value, int currentVal)
{
	if (currentVal > value)
	{
		return 0;
	}
	if (currentVal == value)
	{
		return 1;
	}
	return coins.Select(c => CoinChange(coins, value, currentVal + c)).Sum();
}