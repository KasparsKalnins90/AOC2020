namespace AdventOfCode2020.PasswordPuzzles
{
    public class PasswordInfo
    {
        public int RangeFrom { get; set; }
        public int RangeTo { get; set; }
        public char RepeatingLetter { get; set; }
        public string StoredPassword { get; set; }

        public PasswordInfo(string passwordInfoLine)
        {
            var passwordInfoParts = passwordInfoLine.Split(' ');
            var passwordRange = passwordInfoParts[0].Split('-');
            RangeFrom = int.Parse(passwordRange[0]);
            RangeTo = int.Parse(passwordRange[1]);
            RepeatingLetter =
                char.Parse(passwordInfoParts[1]
                .Substring(0, 1));
            StoredPassword = passwordInfoParts[2];
        }
    }
}
