using System;
using System.Collections.Generic;
using System.Text;

namespace FileWriter
{
    class StringBuffer
    {
        string[] str;
        public int current = 0;
        public StringBuffer(string[] str)
        {
            this.str = str;
        }

        public void pos(int pos)
        {
            current = pos;
        }

        public int pos()
        {
            return current;
        }

    public string get()
        {
            string s = str[current];
            if (current >= str.Length) return null;
            current++;
            return s;
        }

    }
}
