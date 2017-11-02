using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HammingCoding
{
    public class HammingCode
    {
        private static int codeLength = 15;
        private static int codeInfoLength = 11;

        //Метод построения кода Хэмминга из введённого текста
        public String EncodeFromText(String text)
        {
            String encodedWindows1251String = "";

            //Посимвольный перевод введённых символов в кодировке Windows-1251 в байты
            foreach (var symbol in text)
            {
                char sym = (char)Encoding.GetEncoding("windows-1251").GetBytes(symbol.ToString())[0];  
                encodedWindows1251String += Convert.ToString(sym, 2).PadLeft(8, '0');
            }

            //Построение массива битов и вычисление его размера
            bool[] bits = encodedWindows1251String.Select(chr => chr == '1').ToArray();
            int bitsSize = bits.Length;

            //Построение одной порции информации
            bool[] infoPortion = Helpers.createEmptyZeroBitArray(codeInfoLength);

            int j = 0;
            String encodedString = "";
            //Цикл по всем битам символов исходного текста
            for (int i = 0; i < bitsSize; i++)
            {
                infoPortion[j] = bits[i];
                //Построение кода для 1 порции текста
                if (j == codeInfoLength - 1 || i == bitsSize - 1)
                {
                    //Получение закодированных битов, построение результирующей бинарной строки
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
                    //Очистка порции
                    infoPortion = Helpers.createEmptyZeroBitArray(codeInfoLength);
                    j = 0;
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
            //Получение массива битов закодированного текста и вычисление его размера
            bool[] bits = text.Select(chr => chr == '1').ToArray();
            int bitsSize = bits.Length;

            //Построение одной порции информации
            bool[] infoPortion = Helpers.createEmptyZeroBitArray(codeLength);

            int j = 0;
            int multiplier = 0; //Счётчик порций информации
            String decodedString = "";
            for (int i = 0; i < bitsSize; i++)
            {
                infoPortion[j] = bits[i];
                //Декодирование 1 порции закодированного текста
                if (j == codeLength - 1 || i == bitsSize - 1)
                {
                    //Поиск и выдача ошибок в порции
                    int errorIndex = ErrorSyndrome(infoPortion);
                    if (errorIndex != 0)
                    {
                        MessageBox.Show("Обнаружена ошибка в коде\nНомер символа: " + (15 * multiplier + errorIndex) + ". Блок " + (multiplier+1) + ", символ " + errorIndex, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        infoPortion[errorIndex - 1] = !infoPortion[errorIndex - 1];
                    }
                    //Получение декодированных битов, построение результирующей бинарной строки
                    bool[] decodedBits = Decode(infoPortion);
                    for (int k = 0; k < codeInfoLength; k++)
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
                    //Очистка порции
                    infoPortion = Helpers.createEmptyZeroBitArray(codeLength);
                    j = 0;
                    multiplier++;
                }
                else
                {
                    j++;
                }
            }

            //Получение байтов из результирующей бинарной строки
            var data = Helpers.GetBytesFromBinaryString(decodedString);
            //Получение результирующей текстовой строки
            var result = Encoding.GetEncoding("windows-1251").GetString(data);
            return result;
        }

        //Метод кодирования одной порции массива битов
        private bool[] Encode(bool[] code)
        {
            var encoded = new bool[codeLength];

            //Первый символ закодированной строки кладём в encoded[2]
            int i = 2, j = 0;
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

        //Метод декодирования одной порции массива битов
        private bool[] Decode(bool[] encoded)
        {
            var decoded = new bool[codeInfoLength];

            //Первый символ закодированной строки лежит в encoded[2]
            int i = 2, j = 0;
            while (i < codeLength)
            {
                if (i == 3 || i == 7) i++;
                decoded[j] = encoded[i];

                i++;
                j++;
            }

            return decoded;
        }

        //Метод поиска ошибок в одной порции массива битов, закодированном алгоритмом Хэмминга
        private int ErrorSyndrome(bool[] encoded)
        {
            int syndrome =
                (Convert.ToInt32(Helpers.doXoringForPosition(encoded, codeLength, 1) ^ encoded[0])) +
                (Convert.ToInt32(Helpers.doXoringForPosition(encoded, codeLength, 2) ^ encoded[1]) << 1) +
                (Convert.ToInt32(Helpers.doXoringForPosition(encoded, codeLength, 4) ^ encoded[3]) << 2);
            if (codeLength > 7) syndrome +=
               (Convert.ToInt32(Helpers.doXoringForPosition(encoded, codeLength, 8) ^ encoded[7]) << 3);

            return syndrome;
        }
    }
}
