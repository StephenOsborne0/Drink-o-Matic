﻿namespace DrinksLib.Helpers
{
    internal interface ISerializer
    {
        void Serialize<T>(string filepath, object obj) where T : class;

        T Deserialize<T>(string filePath) where T : class;
    }
}