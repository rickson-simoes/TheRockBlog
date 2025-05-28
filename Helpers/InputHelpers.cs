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
            Console.WriteLine($"{field}:");
            var name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine($"The {field} can't be null");
                Console.WriteLine($"Please try again by providing the {field}:");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine($"{field} can't be empty or white space, pelase try again.");
                }
            }
            return name;
        }
    }
}
