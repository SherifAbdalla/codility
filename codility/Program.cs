using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codility
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[] { "S" };
            EnumeratorConfig config = new EnumeratorConfig
            {
                MaxLength = 1,
                StartWithCapitalLetter = true
            };
            CustomStringEnumerator d = new CustomStringEnumerator(names, config);
            foreach (var item in d)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }

        static int solution(int N)
        {
            string stringValu = N.ToString();
            StringBuilder s = new StringBuilder();
            int max = int.MinValue;
            for (int i = 0; i < stringValu.Length; i++)
            {
                int testValue;
                if (N < 0)
                {
                    testValue = int.Parse(stringValu.Insert(i + 1, "5").ToString());
                }
                else
                {
                    testValue = int.Parse(stringValu.Insert(i, "5").ToString());
                }
                if(max < testValue)
                {
                    max = testValue;
                }
            }
            return max;
        }



    }

    public class CustomStringEnumerator : IEnumerable<string>
    {
        private readonly ICollection<string> _collection;
        /// <summary> Constructor </summary>
        /// <exception cref="System.ArgumentNullException">If a collection is null</exception>
        /// <exception cref="System.ArgumentNullException">If an config is null</exception>
        public CustomStringEnumerator(IEnumerable<string> collection, EnumeratorConfig config)
        {
            try
            {
                _collection = new List<string>();
                if (collection != null && config != null)
                {
                    foreach (var item in collection)
                    {
                        //if ((item.Length >= config.MinLength || config.MinLength == -1) && (item.Length <= config.MaxLength || config.MaxLength == -1) && (char.IsDigit(item.FirstOrDefault()) == config.StartWithDigit || config.StartWithDigit == null) && (char.IsLower(item.FirstOrDefault()) != config.StartWithCapitalLetter) || config.StartWithCapitalLetter == null)
                        //{
                        //    _collection.Add(item);
                        //}

                        string s = string.Empty;

                        if(config.MaxLength != -1)
                        {
                            if (item.Length <= config.MaxLength) s = item;
                        }

                        if (config.MinLength != -1)
                        {
                            if (item.Length >= config.MaxLength) s = item;
                        }

                        if(config.StartWithCapitalLetter != null)
                        {
                            if (char.IsLower(item.FirstOrDefault()) != config.StartWithCapitalLetter) s = item;
                        }

                        if (string.IsNullOrEmpty(s)) _collection.Add(item);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _collection.GetEnumerator();
        }
    }

    public class EnumeratorConfig
    {
        // Specifies the minimal length of strings that should be returned by a custom enumerator.
        // If it is set to negative value then this option is ignored.
        public int MinLength { get; set; } = -1;

        // Specifies the maximum length of strings that should be returned by a custom enumerator.
        // If it is set to negative value then this option is ignored.
        public int MaxLength { get; set; } = -1;

        // Specifies that only strings that start with a capital letter should be returned by a custom enumerator.
        // Please note that empty or null strings do not meet this condition.
        public bool StartWithCapitalLetter { get; set; }

        // Specifies that only strings that start with a digit should be returned by a custom enumerator.
        // Please note that empty or null strings do not meet this condition.
        public bool StartWithDigit { get; set; }
    }
}
