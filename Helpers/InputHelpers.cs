namespace Blog.Helpers
{
    public static class InputHelpers
    {
        /// <summary>
        /// <para> - This function assures that the user can't type an empty value or white space.</para>
        /// <para> - On the param is the field name that will pop up for the user.</para>
        /// </summary>
        /// <param name="field">Name of the param to pop on the screens.</param>
        /// <returns>A valid string that is not null or with white spaces.</returns>
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
    }
}
