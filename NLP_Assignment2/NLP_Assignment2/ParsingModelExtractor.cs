﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLP_Assignment2
{
	class ParsingModelExtractor
	{
		internal void Run(string file)
		{
			DataManager dm = new DataManager();
			Processor proc = new Processor();
			
			string[] filename_array = file.Split('/');
			string filename = filename_array[filename_array.Length-1];

			// load the phrase structure trees
			Console.WriteLine("Loading the phrase structure tree from "+filename);
			string data = dm.LoadFile(file);
			string[] sentences = data.Split('\n');
			sentences = sentences.Take(sentences.Count()-1).ToArray();	// getting rid of the last empty row in the data file

			// extract rules from the structure trees
			Console.WriteLine("Extracting rules from phrase structure trees...");
			proc.ExtractRules(sentences, dm.grammarRules, ExtractMode.GRAMMAR);
			proc.ExtractRules(sentences, dm.lexiconRules, ExtractMode.LEXICON);

			// format grammar and lexicon
			Console.WriteLine("Formatting grammar and lexicon lists...");
            dm.formattedGrammarRules = proc.FormatRules(dm.grammarRules, ExtractMode.GRAMMAR, Separator.TAB);
            dm.formattedLexiconRules = proc.FormatRules(dm.lexiconRules, ExtractMode.LEXICON, Separator.TAB);

			// save the grammar and lexicon rules to text files
			if (file.Contains("pos"))
			{
				dm.SaveFile("../../out/grammar-pos.txt", dm.formattedGrammarRules);
				dm.SaveFile("../../out/lexicon-pos.txt", dm.formattedLexiconRules);
			}
			else if (file.Contains("dep"))
			{
				dm.SaveFile("../../out/grammar-dep.txt", dm.formattedGrammarRules);
				dm.SaveFile("../../out/lexicon-dep.txt", dm.formattedLexiconRules);
			}
			Console.WriteLine("The grammar and lexicon files have been successfully created for "+filename+"\n");
			
		}
	}
}