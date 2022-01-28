<Query Kind="Program" />

void Main()
{
	
}

// You can define other methods, fields, classes and namespaces here

bool CanConstruct(string ransom, string magazine)
{
	Dictionary<char, int> counts = new Dictionary<char, int>();
	var ransomChars = ransom.ToCharArray();
	var magazineChars = magazine.ToCharArray();
	
	for (int i = 0; i < ransomChars.Length; i++) 
	{
		if (counts.ContainsKey(ransomChars[i]))
		{
			counts[ransomChars[i]]++;
		}
		else
		{
			counts[ransomChars[i]] = 1;
		}
	}
	
	for (int i = 0; i < magazineChars.Length; i++) 
	{
		if (counts.ContainsKey(magazineChars[i]) && magazineChars[i] > 0)
		{
			counts[ransomChars[i]]--;
		}
	}
	
	return !counts.Any(kv => kv.Value > 0);
}