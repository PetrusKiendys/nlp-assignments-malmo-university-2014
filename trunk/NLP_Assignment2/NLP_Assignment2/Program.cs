﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLP_Assignment2
{
	class Program
	{
		static void Main(string[] args)
		{
//			ParsingModelExtractor pme = new ParsingModelExtractor();
//			pme.Run();
            ParsingModelExtractor2 pme2 = new ParsingModelExtractor2();
            pme2.Run();

            // the console window is not closed when the application is done running
            Console.Read();


			// Petrus TreeNode testkod
//			TreeNode rootNode = new TreeNode();
            
//            			string example_sentence = "(SENT (RTP (ATP (AT Individuell))(RT beskattning)(ETP (ET av)(PAP (PA arbetsinkomster)))))";
//			string[] nodes_string = { "SENT", "RTP", "ATP", "AT", "individuell", "RT", "beskattning", "ETP", "ET", "av", "PAP", "PA", "arbetsinkomster" };

//			rootNode.Value = nodes_string[0];
		}
	}
}
