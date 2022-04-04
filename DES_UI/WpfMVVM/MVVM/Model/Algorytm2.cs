using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVM.MVVM.Model
{
    internal class Algorytm2
    {
        
        public Algorytm2()
        {

        }

        public string Encrypt(string text) 
        {
            string result = "";
            for (int i = 0; i < text.Length; i += 5) 
            {
                int k1 = i + 2;
                if(k1<text.Length)
                    result += text[k1];

                int k2 = i + 3;
                if(k2<text.Length)
                    result += text[k2];

                int k3 = i;
                if(k3<text.Length)
                    result += text[k3];

                int k4 = i + 4;
                if(k4<text.Length)
                    result += text[k4];

                int k5 = i + 1;
                if(k5<text.Length)
                    result += text[k5];
            }
            return result;
        }

        public string Decrypt(string text)
        {
            Dictionary<int,char> dictionary = new Dictionary<int,char>();
            int textLength = text.Length;
            int position = 0;
            string result = "";
            for (int i = 0; i < text.Length; i += 5)
            {
                int k1 = i + 2;
                if (k1 < textLength)
                {
                    dictionary.Add(k1, text[position]);
                    position++;
                }
                int k2 = i + 3;
                if (k2 < textLength)
                {
                    dictionary.Add(k2, text[position]);
                    position++;
                }
                int k3 = i;
                if (k3 < textLength)
                {
                    dictionary.Add(k3, text[position]);
                    position++;
                }

                int k4 = i + 4;
                if (k4 < textLength)
                {
                    dictionary.Add(k4, text[position]);
                    position++;
                }

                int k5 = i + 1;
                if (k5 < textLength)
                {
                    dictionary.Add(k5, text[position]);
                    position++;
                }
            }
            for (int i = 0;i< textLength; i++) 
            {
                result += dictionary[i];
            }
            return result;
        }
    }

    
}
