﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NLP_Assignment2
{
	class DataManager
	{
		// TODO_LOW: global variables should be instantiated through a constructor (or in another way)?
		internal Dictionary<string, int> grammarRules = new Dictionary<string, int>();
		internal Dictionary<string, int> lexiconRules = new Dictionary<string, int>();
		internal List<string> formattedGrammarRules;
		internal List<string> formattedLexiconRules;
		internal int grammarRulesCounter, lexiconRulesCounter;

		internal string LoadFile(string path)
		{
			FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
			StreamReader reader = new StreamReader(file);
			string res = reader.ReadToEnd();
			reader.Close();
			file.Close();

			return res;
		}

		// NOTE: When printUniqueRules is set to true, the number of unique grammar/lexicon rules will be written in the output file
		//		 this should only be used for debug reasons as BitPar will crash when parsing these lines.
		internal void SaveFile(string path, List<string> content, ExtractMode extractmode, bool printUniqueRules)
		{
			FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);
			StreamWriter writer = new StreamWriter(file);

			foreach (string entry in content)
			{
				writer.WriteLine(entry);
			}

			if (printUniqueRules)
			{
				writer.WriteLine("============================================================================");
				if (extractmode.Equals(ExtractMode.GRAMMAR))
				{
					writer.WriteLine("Number of unique grammar rules: " + grammarRulesCounter);
				}
				else if (extractmode.Equals(ExtractMode.LEXICON))
				{
					writer.WriteLine("Number of unique lexicon rules: " + lexiconRulesCounter);
				}
				else
					throw new ArgumentException("Illegal ExtractMode enumerator was passed");
			}
			
			writer.Close();
			file.Close();
		}

	}
}
