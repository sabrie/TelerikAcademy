﻿/// rmandvikar.Trie
///https://code.google.com/p/csharptrie/source/browse/#git

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Trie factory to create Trie instances.
/// </summary>
class TrieFactory
{
    /// <summary>
    /// Get a new Trie instance.
    /// </summary>
    public static ITrie GetTrie()
    {
        return new Trie(
            GetTrieNode(' ')
            );
    }
    /// <summary>
    /// Get a new TrieNode instance.
    /// </summary>
    /// <param name="character">Character of the TrieNode.</param>
    internal static TrieNode GetTrieNode(char character)
    {
        return new TrieNode(character,
            new Dictionary<char, TrieNode>(),
            false,
            0)
            ;
    }
}

