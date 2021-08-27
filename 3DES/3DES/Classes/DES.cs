using System;
using System.Collections.Generic;
using System.Linq;

namespace _3DES.Classes
{
    class DES
    {
        private int sizeOfKey = 56;
        private int sizeOfBlock = 64;
        private int sizeOfSym = 8;

        public string Encrypt(string text, string key)
        {
            List<string> binaryBlocks = StringIntoBinaryBlocks(text);
            string binaryKey = CorrectKey(key);
            binaryKey = InitialKeyPermutation(binaryKey);
            for (int i = 0; i < binaryBlocks.Count(); i++)
            {
                binaryBlocks[i] = EncodingBlock(binaryBlocks[i], binaryKey, true);
            }
            string message = BinaryBlockInStringFormat(binaryBlocks);
            return message;
        }

        public string Decrypt(string text, string key)
        {
            List<string> binaryBlocks = StringIntoBinaryBlocks(text);
            string binaryKey = CorrectKey(key);
            binaryKey = InitialKeyPermutation(binaryKey);
            for (int i = 0; i < binaryBlocks.Count(); i++)
            {
                binaryBlocks[i] = DecodingBlock(binaryBlocks[i], binaryKey, false);
            }
            string message = BinaryBlockInStringFormat(binaryBlocks);
            return message;
        }

        List<string> StringIntoBinaryBlocks(string text)
        {
            int countOfSym = sizeOfBlock / sizeOfSym;
            int countOfBlocks;
            List<string> blocks = new List<string>();
            //заполнение блока до нужной длины
            if (text.Length % countOfSym != 0)
            {
                text = FillInBlock(text, countOfSym);
            }
            countOfBlocks = text.Length / countOfSym;
            for (int i = 0, j = 0; i < countOfBlocks; i++, j += countOfSym)
            {
                blocks.Add(StringInBinaryFormat(text.Substring(j, countOfSym)));
            }
            return blocks;
        }

        string FillInBlock(string text, int size)
        {
            int count = size - text.Length % size;
            for (int i = 0; i < count; i++)
            {
                text += (char)181;
            }
            return text;
        }

        //перевод строки символов в двоичный формат
        string StringInBinaryFormat(string text)
        {
            string inBinForm = "";
            foreach (byte symbol in text)
            {
                inBinForm += Convert.ToString(symbol, 2).PadLeft(8, '0');
            }
            int len = inBinForm.Length;
            return inBinForm;
        }

        //корректировка ключа
        string CorrectKey(string key)
        {
            string message = "";
            int countOfSym = sizeOfKey / sizeOfSym;
            //приведение ключа к нужно длине
            if (key.Length < countOfSym)
            {
                key = FillInBlock(key, countOfSym);
            }
            else if (key.Length > countOfSym)
            {
                key = key.Substring(0, countOfSym);
            }
            key = StringInBinaryFormat(key);
            //добавление битов четности
            int countOfIndex = sizeOfSym - 1;
            int countOfOnes;
            for (int i = 0; i < key.Length; i += countOfIndex)
            {
                countOfOnes = 0;
                for (int j = i, k = 0; k < countOfIndex; j++, k++)
                {
                    if ((key[j] - '0') == 1)
                    {
                        countOfOnes++;
                    }
                    message += key[j];
                }
                if (countOfOnes % 2 == 0)
                {
                    message += "1";
                }
                else
                {
                    message += "0";
                }
            }
            return message;
        }

        //шифрование отдельного блока
        string EncodingBlock(string text, string inputKey, bool flag)
        {
            int round = 16;
            string message;
            string key = inputKey;
            string roundKey;
            message = InitialBlockPermutation(text);
            for (int i = 1; i <= round; i++)
            {
                roundKey = GetNextRoundKey(key, i);
                message = EncEncryptionRound(message, roundKey, flag);
            }
            message = FinalBlockPermutation(message);
            return message;
        }

        //дешифрование отдельного блока
        string DecodingBlock(string text, string inputKey, bool flag)
        {
            int round = 16;
            string message;
            string key = inputKey;
            string roundKey;
            message = InitialBlockPermutation(text);
            for (int i = round; i > 0; i--)
            {
                roundKey = GetNextRoundKey(key, i);
                message = DecEncryptionRound(message, roundKey, flag);
            }
            message = FinalBlockPermutation(message);
            return message;
        }

        //получение ключа следующего раунда
        string GetNextRoundKey(string key, int round)
        {
            string str;
            for (int i = 0; i < round; i++)
            {
                string C = key.Substring(0, key.Length / 2);
                string D = key.Substring(key.Length / 2, key.Length / 2);
                C = ShiftKey(C, i + 1);
                D = ShiftKey(D, i + 1);
                key = C + D;
            }
            str = KeyPermutationH(key);
            return str;
        }

        //циклический сдвиг блока ключа
        string ShiftKey(string key, int round)
        {
            int shift;
            //если шифрование
            if ((round == 1) || (round == 2) || (round == 9) || (round == 16))
            {
                shift = 1;
            }
            else
            {
                shift = 2;
            }
            for (int i = 0; i < shift; i++)
            {
                key = key + key[0];
                key = key.Substring(1);
            }
            return key;
        }

        //раунд шифрования
        string EncEncryptionRound(string text, string key, bool flag)
        {
            string L = text.Substring(0, text.Length / 2);
            string R = text.Substring(text.Length / 2, text.Length / 2);
            string result = R;
            R = ExtensionE(R);
            R = XOR(R, key);
            R = BlockS(R);
            R = BlockPermutationP(R);
            R = XOR(L, R);
            result += R;
            return result;
        }

        //раунд дешифрования
        string DecEncryptionRound(string text, string key, bool flag)
        {
            string L = text.Substring(0, text.Length / 2);
            string R = text.Substring(text.Length / 2, text.Length / 2);
            string result = L;
            L = ExtensionE(L);
            L = XOR(L, key);
            L = BlockS(L);
            L = BlockPermutationP(L);
            L = XOR(L, R);
            result = L + result;
            return result;
        }

        //функция расширения блока Е
        string ExtensionE(string text)
        {
            string message = "";
            int index = 4;
            for (int i = 0; i < text.Length; i++)
            {
                message += text[i];
                if (i == index)
                {
                    message += text[index - 1];
                    message += text[index];
                    index += 4;
                }
            }
            message = text[text.Length - 1] + message;
            message += text[0];
            return message;
        }

        string XOR(string text1, string text2)
        {
            string message = "";
            List<int> t1 = new List<int>();
            List<int> t2 = new List<int>();
            List<int> msg = new List<int>();
            for (int i = 0; i < text1.Length; i += 8)
            {
                int tmp = Convert.ToInt32(text1.Substring(i, 8), 2);
                t1.Add(tmp);
            }

            for (int i = 0; i < text2.Length; i += 8)
            {
                int tmp = Convert.ToInt32(text2.Substring(i, 8), 2);
                t2.Add(tmp);
            }


            for (int i = 0; i < t1.Count(); i++)
            {
                msg.Add(t1[i] ^ t2[i]);
            }

            for (int i = 0; i < msg.Count(); i++)
            {
                message += Convert.ToString(msg[i], 2).PadLeft(8, '0');
            }
            return message;
        }

        string BlockS(string text)
        {
            int[,,] tables = {
                {{14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7},
                {0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8},
                {4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0},
                {15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13}},

                {{15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10},
                {3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5},
                {0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15},
                {13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9}},

                {{10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8},
                {13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1},
                {13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7},
                {1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12}},

                {{7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15},
                {13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9},
                {10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4},
                {3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14}},

                {{2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9},
                {14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6},
                {4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14},
                {11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3}},

                {{12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11},
                {10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8},
                {9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6},
                {4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13}},

                {{4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1},
                {13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6},
                {1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2},
                {6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12}},

                {{13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7},
                {1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2},
                {7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8},
                {2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11}}
                };

            string message = "";
            int size = 6;
            string coordinate1 = "";
            string coordinate2 = "";
            int num1;
            int num2;
            int num;
            for (int i = 0, count = 0; i < text.Length; i += size, count++)
            {
                coordinate1 += text[i];
                coordinate1 += text[i + size - 1];
                for (int j = 0, pos = i + 1; j < 4; j++, pos++)
                {
                    coordinate2 += text[pos];
                }
                num1 = BinaryToDecimal(coordinate1);
                num2 = BinaryToDecimal(coordinate2);
                num = tables[count, num1, num2];
                message += DecimalToBinary(num);
                coordinate1 = "";
                coordinate2 = "";
            }

            return message;
        }

        //перевод числа из десятичной системы в двоичную
        string DecimalToBinary(int num)
        {
            string str = Convert.ToString(num, 2).PadLeft(4, '0');
            return str;
        }

        //перевод из двоичной системы в десятичную
        int BinaryToDecimal(string text)
        {
            int num = Convert.ToByte(text, 2);
            return num;
        }

        //перестановка P
        string BlockPermutationP(string text)
        {
            string str = "";
            int[,] table =
            {
                {16, 7, 20, 21, 29, 12, 28, 17},
                {1, 15, 23, 26, 5, 18, 31, 10},
                {2, 8, 24, 14, 32, 27, 3, 9},
                {19, 13, 30, 6, 22, 11, 4, 25}
            };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    str += text[table[i, j] - 1];
                }
            }
            return str;
        }

        //начальная перестановка блока
        string InitialBlockPermutation(string text)
        {
            string str = "";
            int[,] table =
            {
                {58, 50, 42, 34, 26, 18, 10, 2},
                {60, 52, 44, 36, 28, 20, 12, 4},
                {62, 54, 46, 38, 30, 22, 14, 6},
                {64, 56, 48, 40, 32, 24, 16, 8},
                {57, 49, 41, 33, 25, 17, 9, 1},
                {59, 51, 43, 35, 27, 19, 11, 3},
                {61, 53, 45, 37, 29, 21, 13, 5},
                {63, 55, 47, 39, 31, 23, 15, 7}
            };
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    str += text[table[i, j] - 1];
                }
            }
            return str;
        }

        //конечная перестановка блока
        string FinalBlockPermutation(string text)
        {
            string str = "";
            int[,] table =
            {
                {40, 8, 48, 16, 56, 24, 64, 32},
                {39, 7, 47, 15, 55, 23, 63, 31},
                {38, 6, 46, 14, 54, 22, 62, 30},
                {37, 5, 45, 13, 53, 21, 61, 29},
                {36, 4, 44, 12, 52, 20, 60, 28},
                {35, 3, 43, 11, 51, 19, 59, 27},
                {34, 2, 42, 10, 50, 18, 58, 26},
                {33, 1, 41, 9, 49, 17, 57, 25}
            };

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    str += text[table[i, j] - 1];
                }
            }
            return str;
        }

        //начальная перестановка ключа
        string InitialKeyPermutation(string text)
        {
            string str = "";
            int[,] table =
            {
                {57, 49, 41, 33, 25, 17, 9},
                {1, 58, 50, 42, 34, 26, 18},
                {10, 2, 59, 51, 43, 35, 27},
                {19, 11, 3, 60, 52, 44, 36},
                {63, 55, 47, 39, 31, 23, 15},
                {7, 62, 54, 46, 38, 30, 22},
                {14, 6, 61, 53, 45, 37, 29},
                {21, 13, 5, 28, 20, 12, 4}
            };

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    str += text[table[i, j] - 1];
                }
            }
            return str;
        }

        //перестановка ключа H
        string KeyPermutationH(string text)
        {
            int num = text.Length;
            string str = "";
            int[,] table =
            {
                {14, 17, 11, 24, 1, 5},
                {3, 28, 15, 6, 21, 10},
                {23, 19, 12, 4, 26, 8},
                {16, 7, 27, 20, 13, 2},
                {41, 52, 31, 37, 47, 55},
                {30, 40, 51, 45, 33, 48},
                {44, 49, 39, 56, 34, 53},
                {46, 42, 50, 36, 29, 32}
            };

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    str += text[table[i, j] - 1];
                }
            }
            return str;
        }

        //перевод двоичных блоков в строку
        string BinaryBlockInStringFormat(List<string> binaryBlocks)
        {
            string str = "";
            for (int i = 0; i < binaryBlocks.Count(); i++)
            {
                for (int j = 0; j < sizeOfBlock; j += sizeOfSym)
                {
                    str += Convert.ToChar(BinaryToDecimal(binaryBlocks[i].Substring(j, sizeOfSym)));
                }
            }
            return str;
        }
    }
}