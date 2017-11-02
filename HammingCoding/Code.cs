using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HammingCoding
{
    //TODO: if можно убрать - код всегда (15, 11)
    public class Code
    {
        public const int startWith = 2;
        static int codeLength = 15;
        static int codeInfoLength = 11;

        public String ConstructCodeFromText(String text)
        {
            String result = "";

            foreach (var symbol in text)
            {
                char sym = (char)Encoding.GetEncoding("windows-1251").GetBytes(symbol.ToString())[0];
                result += Convert.ToString(sym, 2).PadLeft(8, '0');
            }

            bool[] bits = result.Select(chr => chr == '1').ToArray();
            int bitsSize = bits.Length;

            //Делаем порцию информации
            int j = 0;
            bool[] infoPortion = new bool[11];
            //зануление
            for (int p = 0; p < 11; p++) infoPortion[p] = false;

            String encodedString = "";
            for (int i = 0; i < bitsSize; i++)
            {
                infoPortion[j] = bits[i];
                if (j == 10 || i == bitsSize - 1)
                {
                    j = 0;
                    bool[] encodedBits = Encode(infoPortion);
                    for (int k = 0; k < codeLength; k++) {
                        if (encodedBits[k] == true)
                        {
                            encodedString += "1";
                        }
                        else
                        {
                            encodedString += "0";
                        }
                    }
                    //зануление
                    for (int p = 0; p < 11; p++) infoPortion[p] = false;
                }
                else
                {
                    j++;
                }
            }

            return encodedString;
        }

        public String DecodeFromText(String text)
        {
            //Закодированные биты
            bool[] bits = text.Select(chr => chr == '1').ToArray();
            int bitsSize = bits.Length;

            //Делаем порцию информации
            int j = 0;
            int multiplier = 0;
            bool[] infoPortion = new bool[15];
            //зануление
            for (int p = 0; p < 15; p++) infoPortion[p] = false;

            String decodedString = "";

            for (int i = 0; i < bitsSize; i++)
            {
                infoPortion[j] = bits[i];
                if (j == 14 || i == bitsSize - 1)
                {
                    j = 0;
                    int errorIndex = ErrorSyndrome(infoPortion);
                    if (errorIndex != 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Обнаружена ошибка. Номер символа: " + (15 * multiplier + errorIndex) + ". Блок " + (multiplier+1) + ", символ " + errorIndex);
                        infoPortion[errorIndex - 1] = !infoPortion[errorIndex - 1];
                    }
                    bool[] decodedBits = Decode(infoPortion);
                    for (int k = 0; k < 11; k++)
                    {
                        if (decodedBits[k] == true)
                        {
                            decodedString += "1";
                        }
                        else
                        {
                            decodedString += "0";
                        }
                    }
                    //зануление
                    for (int p = 0; p < 15; p++) infoPortion[p] = false;
                    multiplier++;
                }
                else
                {
                    j++;
                }
            }

            var data = GetBytesFromBinaryString(decodedString);
            var result = Encoding.GetEncoding("windows-1251").GetString(data);


            Encoding srcEncodingFormat = Encoding.GetEncoding("windows-1251");
            Encoding dstEncodingFormat = Encoding.ASCII;
            byte[] originalByteString = srcEncodingFormat.GetBytes(result);
            byte[] convertedByteString = Encoding.Convert(srcEncodingFormat,
            dstEncodingFormat, originalByteString);
            string finalString = dstEncodingFormat.GetString(convertedByteString);

            return result;
        }

        public Byte[] GetBytesFromBinaryString(String binary)
        {
            var list = new List<Byte>();
            for (int i = 0; i < binary.Length; i += 8)
            {
                if (binary.Length - i < 8) break;

                String t = binary.Substring(i, 8);
                list.Add(Convert.ToByte(t, 2));
            }

            return list.ToArray();
        }

        //1 порция
        public bool[] Encode(bool[] code)
        {
            var encoded = new bool[codeLength];

            int i = startWith, j = 0;
            while (i < codeLength)
            {
                if (i == 3 || i == 7) i++;
                encoded[i] = code[j];

                i++;
                j++;
            }

            encoded[0] = Helpers.doXoringForPosition(encoded, codeLength, 1);
            encoded[1] = Helpers.doXoringForPosition(encoded, codeLength, 2);
            encoded[3] = Helpers.doXoringForPosition(encoded, codeLength, 4);
            if (codeLength > 7)
                encoded[7] = Helpers.doXoringForPosition(encoded, codeLength, 8);

            return encoded;
        }

        public bool[] Decode(bool[] encoded)
        {
            var decoded = new bool[codeInfoLength];

            int i = startWith, j = 0;
            while (i < codeLength)
            {
                if (i == 3 || i == 7) i++;
                decoded[j] = encoded[i];

                i++;
                j++;
            }

            return decoded;
        }

        public int ErrorSyndrome(bool[] encoded)
        {
            int syndrome =
                (Convert.ToInt32(Helpers.doXoringForPosition(encoded, codeLength, 1) ^ encoded[0])) +
                (Convert.ToInt32(Helpers.doXoringForPosition(encoded, codeLength, 2) ^ encoded[1]) << 1) +
                (Convert.ToInt32(Helpers.doXoringForPosition(encoded, codeLength, 4) ^ encoded[3]) << 2);
            if (codeLength > 7) syndrome +=
               (Convert.ToInt32(Helpers.doXoringForPosition(encoded, codeLength, 8) ^ encoded[7]) << 3);

            return syndrome;
        }

        public void MixinSingleError(bool[] encoded, int pos)
        {
            encoded[pos - 1] = !encoded[pos - 1];
        }
    }
}
