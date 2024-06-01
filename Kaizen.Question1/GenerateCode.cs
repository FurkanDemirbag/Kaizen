namespace Kaizen.Question1
{
    public class GenerateCode
    {
        public List<string> codeList = new List<string>();
        private readonly char[] acceptableCharacters = "ACDEFGHIKLMNPRTXYZ234579".ToCharArray();
        private const int codeLength = 8;
        private const int codeCount = 1000;

        public void GenerateCodes()
        {
            var code = new char[codeLength - 1]; //7 haneli kod üretilecek, kalan 1 hane doğrulama için kullanılacak.

            var random = new Random();

            for (int i = 0; i < codeCount; i++)
            {
                for (int j = 0; j < code.Length; j++)
                {
                    code[j] = acceptableCharacters[random.Next(acceptableCharacters.Length)];
                }

                var codeWithoutCheckCharacter = new string(code);
                var uniqueCode = string.Join("", codeWithoutCheckCharacter, GenerateCheckCharacter(codeWithoutCheckCharacter));

                if (!codeList.Contains(uniqueCode))
                {
                    codeList.Add(uniqueCode);
                }
                else
                {
                    i--;
                }
            }
        }

        public char GenerateCheckCharacter(string code)
        {
            //Karakterlerin ASCII değerlerinin toplamını kullanarak son karakter elde edilir.
            return acceptableCharacters[code.Sum(a => a) % acceptableCharacters.Length];
        }

        public bool CheckCode(string code)
        {
            //Kod uzunluğu 8 hane değilse kod yanlıştır.
            if (code.Length != codeLength)
            {
                return false;
            }

            var expectedCheckCharacter = GenerateCheckCharacter(code.Substring(0, 7));

            //Oluşan kodun ilk 7 karakterinden oluşan check karakter ile kodun son karakteri uyuşuyor mu bakılır.
            return expectedCheckCharacter == code[7];
        }
    }
}
