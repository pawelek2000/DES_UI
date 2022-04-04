using System;
using System.Collections.Generic;
using System.Text;

namespace BSK4 {

    public static class SzyfrStrumieniowy {

        public static string Encrypt(string text, string polynomial, string khalid) {
            LFSR.Init(polynomial, khalid);

            string text_binary = StringToBinary(text);
            var result = XOR_with_LFSR(text_binary);

            return result;
        }

        public static string Decrypt(string binary_text, string polynomial, string khalid) {
            LFSR.Init(polynomial, khalid);

            var text_string = XOR_with_LFSR(binary_text);
            var result = BinaryToString(text_string);

            return result;
        }


        private static string XOR_with_LFSR(string binary_text) {
            var result = "";

            for (int i = 0; i < binary_text.Length; i++) {
                var lsfr_bit = LFSR.GenerateBit();

                if (lsfr_bit == 1 && binary_text[i] == '1' || lsfr_bit == 0 && binary_text[i] == '0') {
                    result += '0';
                }
                else {
                    result += '1';
                }
            }

            return result;
        }


        private static string StringToBinary(string data) {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray()) {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }

            return sb.ToString();
        }

        private static string BinaryToString(string data) {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < data.Length; i += 8) {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }

            return Encoding.ASCII.GetString(byteList.ToArray());
        }
    }

}