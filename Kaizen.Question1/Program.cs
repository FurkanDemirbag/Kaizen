using Kaizen.Question1;

var generateCode = new GenerateCode();

//Kodları üretir
generateCode.GenerateCodes();

//Örnek bir kontrol
string testCode = generateCode.codeList.First();
bool isValid = generateCode.CheckCode(testCode);

Console.WriteLine(isValid);