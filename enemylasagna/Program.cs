// enemylasagna
// Matto58, 2024
//
// purpose: sorting every word in enemylasagna.txt in alphabetical order
// licensed under CC BY-SA 4.0, https://creativecommons.org/licenses/by-sa/4.0/

string file = File.ReadAllText("enemylasagna.txt");

Console.WriteLine("== BEFORE ==\n" + file);

List<string> words = [""];

for (int i = 0; i < file.Length; i++)
{
	char c = file[i];
	if (!char.IsLetter(c))
		if (char.IsWhiteSpace(c) && !string.IsNullOrWhiteSpace(words[^1]))
			words.Add("");
		else; // this is such a fucking hack
	else words[^1] += c;
}

Console.WriteLine("== WORDS ==\n" + string.Join(' ', words));

words.Sort((a, b) =>
{
	a = a.ToLower();
	b = b.ToLower();
	// this is such a fucking hack 2: electric boogaloo (now with 100% more compatibility with other locales (fucking czech having ch as a letter))
	for (int i = 0; i < Math.Min(a.Length, b.Length); i++)
	{
		if (a[i] == b[i]) continue;
		if (a[i] > b[i]) return 1;
		else return -1;
	}
	return 0;
});
Console.WriteLine("== SORTED ==\n" + string.Join(' ', words));