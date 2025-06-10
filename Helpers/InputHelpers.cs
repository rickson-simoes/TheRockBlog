namespace Blog.Helpers
{
    public static class InputHelpers
    {
        /// <summary>
        /// <para> - This function assures that the user can't type an empty value or white space.</para>
        /// </summary>
        /// <param name="field">Name of the param to show on the user screen.</param>
        /// <returns>A valid string that is not null or with only white spaces.</returns>
        public static string NotNullOrWhiteSpace(string field)
        {
            Console.Write($"\n{field}: ");
            var name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine($"{field} can't be empty or white space.");
                Console.Write($"\n{field}: ");
                name = Console.ReadLine();
            }
            return name;
        }

        /// <summary>
        /// Generates a random math number
        /// </summary>
        /// <param name="initialNum"> The initial value</param>
        /// <param name="finalNum"> The final value</param>
        /// <returns> Generates a random number between the numbers provided </returns>
        public static int MathRandomNumber(int initialNum, int finalNum) 
        {
            var random = new Random();
            var num = random.Next(initialNum, finalNum);

            return num;
        }
    }
}
