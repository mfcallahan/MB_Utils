using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;

namespace MbUtils
{
	class StringUtils
	{
		public static void _SplitString(string stringToSplit, string delimiter, ref string[] splitStrings, ref string errStr)
		{
			try
			{
				char[] c = delimiter.ToCharArray();
				splitStrings = stringToSplit.Split(c[0]);
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}
		}

		public static int _CountDelimiterOccurances(string stringToSearch, string delimiter, ref string errStr)
		{
			int count = 0;

			try
			{
				char[] c = delimiter.ToCharArray();
				count = stringToSearch.Split(c[0]).Length - 1;
			}
			catch(Exception ex)
			{
				errStr = ex.ToString();
			}

			return count;
		}

		public static int _CountWordsInString(string stringToSearch, string findString, ref string errStr)
		{
			int count = 0;

			try
			{
				count = Regex.Matches(stringToSearch, findString).Count;
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}

			return count;
		}

		public static bool _StringContainsNumericValue(string stringToSearch, ref string errStr)
		{
			bool result = false;

			try
			{
				result = Regex.IsMatch(stringToSearch, @"^\d+$");
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}

			return result;
		}

		public static bool _IsStringNumericValue(string stringToSearch, ref string errStr)
		{
			bool result = false;

			try
			{
				double num;
				result = double.TryParse(stringToSearch, out num);
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}

			return result;
		}

		public static bool _StringStartsWith(string stringToSearch, string findSring, bool ignoreCase, ref string errStr)
		{
			bool result = false;

			try
			{
				result = stringToSearch.StartsWith(findSring, ignoreCase, null);
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}

			return result;
		}

		public static bool _StringEndsWith(string stringToSearch, string findSring, bool ignoreCase, ref string errStr)
		{
			bool result = false;

			try
			{
				result = stringToSearch.EndsWith(findSring, ignoreCase, null);
			}
			catch (Exception ex)
			{
				errStr = ex.ToString();
			}

			return result;
		}
	}
}
