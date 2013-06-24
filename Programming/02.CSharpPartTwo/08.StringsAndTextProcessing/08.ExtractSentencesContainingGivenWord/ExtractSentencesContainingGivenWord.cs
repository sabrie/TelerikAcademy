using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ExtractSentencesContainingGivenWord
{
    static void Main()
    {
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

        string word = "in";

        // ignore case
        text.ToUpper();
        word.ToUpper();

        int start = 0;
        int dotIndex = text.IndexOf('.', start);
        string sentence = text.Substring(start, dotIndex - start);
        string[] words = sentence.Split(' ', ',');

        //string[] sentences = text.Split('.');
        while (start != -1)
        {
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == word)
                {
                    Console.WriteLine(sentence + ".");
                }
            }
            dotIndex = text.IndexOf('.', start);
            text = text.Substring(start, dotIndex - start);
            words = sentence.Split(' ', ',');
        }  
      


        // reshenie na kolega
        string text2 = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string[] sentences = text2.Split('.');
        string key = "in";
        string keyWord = " " + key + " ";
        List<string> neededSentences = new List<string>();

        for (int i = 0; i < sentences.Length; i++)
        {
            int indexKeyWord = sentences[i].IndexOf(keyWord, 0);
            if (indexKeyWord != -1)
            {
                neededSentences.Add(sentences[i]);
            }
        }

        foreach (var sen in neededSentences)
        {
            Console.WriteLine(sen);
        }


        // reshenie na drug kolega

        //Console.WriteLine("Paste selected text, Pls!\nOnly sentences, including given word would be returned");
        //string str = Console.ReadLine();
        ////string str = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        //string[] sentence = str.Split('.');
        //Console.WriteLine("Enter your word, Pls:");
        //string target = Console.ReadLine();
        ////string target = "in";

        //foreach (var item in sentence)
        //{
        //    string[] words = item.Split(' ');
        //    foreach (var word in words)
        //    {
        //        if (word.ToLower().Trim(new char[] { ' ', ';', ',' }) == target.ToLower())
        //        {
        //            Console.WriteLine("{0}.", item.Trim());
        //            break;
        //        }
        //    }
        //}


        // reshenie na drug kolega
        //string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        //string word = "in";
        //string[] sentences = text.Split('.');

        //for (int i = 0; i < sentences.Length; i++)
        //{
        //    if (Regex.Matches(sentences[i], @"\b" + word + @"\b").Count > 0)
        //    {
        //        Console.WriteLine((sentences[i] + ".").Trim());
        //    }
        //}
    }
}
