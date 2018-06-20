using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTestConsoleApp
{
    class Program
    {
        static void TestStringWithEmbeddedNull()
        {
            // A C# string can contain embedded NULL characters.
            // The length of the string is an internally stored value
            // in the string object.
            string strWithEmbeddedNull = "ABC\0DEF\0GHI\0";

            Console.WriteLine("String : {0:S}", strWithEmbeddedNull);
            Console.WriteLine("Length : {0:D}", strWithEmbeddedNull.Length);
        }

        static void TestConvertStringToCharArray()
        {
            // A character array can be produced from a C# string.
            // But the resulting array is completely separate from
            // the original string and cannot be used to change the
            // contents of the string.
            string strTest = "ABCDEFGHI";
            char[] chArray = strTest.ToCharArray();

            // Change the 3rd element of the array.
            chArray[2] = 'J';
            // The original string is unchanged.
            Console.WriteLine("String : {0:S}", strTest);
            // The array is changed as will be seen in the output.
            for (int i = 0; i < chArray.Length; i++)
            {
                Console.WriteLine("chArray[{0:D}] : {1}", i, chArray[i]);
            }
        }

        static void TestChangeStringContents01()
        {
            // Both str1 and str2 contain the string "ABC". 
            // They will each reference one single system string object
            // in memory.
            string str1 = "ABC";
            string str2 = "ABC";

            Console.WriteLine("str1 : {0}.", str1);
            Console.WriteLine("str2 : {0}.", str2);
            Console.WriteLine("str1 == str2 : {0}", Object.ReferenceEquals(str1, str2));

            // The Replace() method will replace characters in a string
            // but will return another string object. The original
            // string variable will not be affected.
            string str3 = str2.Replace('B', 'D');

            Console.WriteLine("str1 : {0}.", str1);
            Console.WriteLine("str2 : {0}.", str2);
            Console.WriteLine("str3 : {0}.", str3);
            Console.WriteLine("str1 == str2 : {0}", Object.ReferenceEquals(str1, str2));
            Console.WriteLine("str2 == str3 : {0}", Object.ReferenceEquals(str2, str3));
        }

        static void TestChangeStringContents02()
        {
            // Both str1 and str2 contain the string "ABC". 
            // They will each reference one single string object
            // in memory.
            string str1 = "ABC";
            string str2 = "ABC";

            Console.WriteLine("str1 : {0}.", str1);
            Console.WriteLine("str2 : {0}.", str2);
            Console.WriteLine("str1 == str2 : {0}", Object.ReferenceEquals(str1, str2));

            // The += method will add more characters to a string variable .
            // The original string variable will be affected.
            // Another string object will be created and referenced by
            // the string variable.
            str2 += "DEF";

            Console.WriteLine("str1 : {0}.", str1);
            Console.WriteLine("str2 : {0}.", str2);
            Console.WriteLine("str1 == str2 : {0}", Object.ReferenceEquals(str1, str2));
        }

        static void TestStringReference01()
        {
            string str1 = "XYZ";
            string str2 = "XYZ";

            // str1 and str2 both contain the same string literal "XYZ"
            // which has been assigned to them directly. Hence str1 and str2
            // are referencing the same string object.
            Console.WriteLine("str1 == str2 : {0}", Object.ReferenceEquals(str1, str2));
        }

        static void TestStringReference02()
        {
            string str1 = "XYZ";
            string str2;

            str2 = "X";
            str2 += "Y";
            str2 += "Z";

            // At this time, str1 and str2 both contain the same string value "XYZ".
            // However, str1 was assigned "XYZ" directly whereas str2 had "XYZ" assigned
            // to it indirectly (by being built-up at runtime).
            //
            // In this situation, str1 and str2 each references different string objects
            // in memory.
            Console.WriteLine("str1 == str2 : {0}", Object.ReferenceEquals(str1, str2));
        }

        static void TestStringReference03()
        {
            string str1 = "XYZ";
            string str2 = "XYZ";

            // str1 and str2 both reference the same string object in memory.
            // The console will print out true.
            Console.WriteLine("str1 == str2 : {0}", Object.ReferenceEquals(str1, str2));

            str2 = "A";
            str2 += "B";
            str2 += "C";

            // str2 has been re-assigned a new string value "ABC".
            // The console will print out false.
            Console.WriteLine("str1 == str2 : {0}", Object.ReferenceEquals(str1, str2));

            str2 = "X";
            str2 += "Y";
            str2 += "Z";

            // str2 has now been re-assigned a new string "XYZ", albeit indirectly and gradually.
            // However, str1 and str2 will still reference different string objects in memory.
            // The console will print out false.
            Console.WriteLine("str1 == str2 : {0}", Object.ReferenceEquals(str1, str2));

            str2 = "XYZ";

            // str2 has now been re-assigned the string "XYZ" directly.
            // str1 and str2 both reference the same string object in memory.
            // The console will print out true.
            Console.WriteLine("str1 == str2 : {0}", Object.ReferenceEquals(str1, str2));

            str2 = "XYZABC";

            // The Remove() method will remove characters from string,
            // starting from a certain position onwards. Like Replace(),
            // it returns another string object without affecting the original
            // string variable.
            string str3 = str2.Remove(3);

            // str3 has been assigned the string value "XYZ".
            // However, str1 and str3 both reference different string objects in memory.
            // The console will print out false.
            Console.WriteLine("str1 == str3 : {0}", Object.ReferenceEquals(str1, str3));
        }

        static void TestStringInternment01()
        {
            string str1 = "XYZ";
            string str2 = "XY";

            str2 += "Z";
            Console.WriteLine("str1 == str2 : {0}", Object.ReferenceEquals(str1, str2));

            string strTestIntern1 = string.IsInterned(str1);
            string strTestIntern2 = string.IsInterned(str2);
            Console.WriteLine("strTestIntern1 == strTestIntern2 : {0}", Object.ReferenceEquals(strTestIntern1, strTestIntern2));
        }

        static void TestStringInternment02()
        {
            string str = "XYZ";
            StringBuilder sb = new StringBuilder("XY");

            sb.Append('Z');

            Console.WriteLine("str == sb.ToString() : {0}", Object.ReferenceEquals(str, sb.ToString()));

            string strTestIntern1 = string.IsInterned(str);
            string strTestIntern2 = string.IsInterned(sb.ToString());
            Console.WriteLine("strTestIntern1 == strTestIntern2 : {0}", Object.ReferenceEquals(strTestIntern1, strTestIntern2));
        }

        static void TestStringInternment03()
        {
            string str = "XYZ";
            StringBuilder sb = new StringBuilder("XY");

            sb.Append('Z');

            string str2 = sb.ToString();
            Console.WriteLine("str == str2 : {0}", Object.ReferenceEquals(str, str2));

            string strTestIntern1 = string.IsInterned(str);
            string strTestIntern2 = string.IsInterned(str2);
            Console.WriteLine("strTestIntern1 == strTestIntern2 : {0}", Object.ReferenceEquals(strTestIntern1, strTestIntern2));
        }

        static void TestStringInternment04()
        {
            string str = "XYZ";
            StringBuilder sb = new StringBuilder("XY");

            sb.Append('K');

            string str2 = sb.ToString();
            Console.WriteLine("str == str2 : {0}", Object.ReferenceEquals(str, str2));

            string strTestIntern1 = string.IsInterned(str);
            string strTestIntern2 = string.IsInterned(str2);
            Console.WriteLine("strTestIntern1 == strTestIntern2 : {0}", Object.ReferenceEquals(strTestIntern1, strTestIntern2));
        }

        static void TestStringInternment05()
        {
            string str1 = "AA";
            str1 += "BB";

            if (string.IsInterned(str1) == null)
            {
                // As "AABB" has not been explicitly declared within
                // the program, strTestIntern1 will be null.
                Console.WriteLine("str is not interned.");
            }
            else
            {
                Console.WriteLine("str is interned.");
            }

            String.Intern(str1);

            if (string.IsInterned(str1) == null)
            {
                Console.WriteLine("str is not interned.");
            }
            else
            {
                // strTestIntern1 will now be assigned "AABB" as
                // "AABB" is now interned.
                Console.WriteLine("str is interned.");
            }

            // At runtime, "AABB" will be in the intern pool.
            // But at compile time, "AABB" will not end up in
            // the User String Metadata.
        }

        static void Main(string[] args)
        {
            TestStringWithEmbeddedNull();
            TestConvertStringToCharArray();
            TestChangeStringContents01();
            TestChangeStringContents02();
            TestStringReference01();
            TestStringReference02();
            TestStringReference03();
            TestStringInternment01();
            TestStringInternment02();
            TestStringInternment03();
            TestStringInternment04();
            TestStringInternment05();
        }
    }
}