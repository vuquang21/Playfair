using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Playfair
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }




        private void Form1_Load(object sender, EventArgs e, List<char> arrPlaintext, KeyEventArgs key)
        {

        }

        public void KeyAddAlpa(StringBuilder _stringKey, char[] alpa)
        {
            int flag = 0;
            for (int i = 0; i < alpa.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (_stringKey[j] == alpa[i])
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                {
                    _stringKey.Append(alpa[i]);
                }
                else
                {
                    flag = 0;
                }
            }

        }
        public void isCharacter(StringBuilder _stringPlaintext, int ElementOfPlaintext, char[,] matrix, List<int> arr)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (ElementOfPlaintext < _stringPlaintext.Length)
                    {
                        if (_stringPlaintext[ElementOfPlaintext] == matrix[i, j])
                        {
                            arr.Add(i);
                            arr.Add(j);
                            break;
                        }
                    }
                }
            }
        }
        private void btnEncryp_Click(object sender, EventArgs e)
        {

            var alpa = new char[25] {
                    'A',
                    'B',
                    'C',
                    'D',
                    'E',
                    'F',
                    'G',
                    'H',
                    'I',
                    'K',
                    'L',
                    'M',
                    'N',
                    'O',
                    'P',
                    'Q',
                    'R',
                    'S',
                    'T',
                    'U',
                    'V',
                    'W',
                    'X',
                    'Y',
                    'Z'
            };
            var plaintext = rtbPlaintext.Text.Trim();
            var key = tbKey.Text.Trim();
            plaintext = plaintext.ToUpper();
            key = key.ToUpper();


            // kiểm tra plaintext và key rỗng
            if (plaintext == String.Empty || key == String.Empty)
            {
                MessageBox.Show("Message: Plaintext or key is empty!!!");
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder(key.ToLower());
                for (int i = 0; i < key.Length; i++)
                {
                    if (key[i] == 'J')
                    {
                        MessageBox.Show("Message: Please do not enter character 'J'!!!");
                        stringBuilder.Remove(i, 1);
                        break;
                    }
                }
                tbKey.Text = stringBuilder.ToString();
            }

            // xoá những kí tự và khoảng trắng trong key và thay j thành i
            var charsToRemove = new string[] { "@", ",", ".", ";", "'", " " };
            foreach (var c in charsToRemove)
            {
                key = key.Replace(c, string.Empty);
                plaintext = plaintext.Replace(c, string.Empty);
            }


            // một cặp có 2 kí tự giống nhau thì thay kí tự sau bằng x
            StringBuilder _stringPlaintext = new StringBuilder(plaintext);
            if (plaintext.Length % 2 == 0)
            {
                for (int i = 0; ((i < _stringPlaintext.Length) && ((i + 1) < _stringPlaintext.Length)); i += 2)
                {

                    if (_stringPlaintext[i] == _stringPlaintext[i + 1])
                    {
                        _stringPlaintext.Insert(i + 1, "X");
                    }

                }
            }

            // độ dài plaintext là lẻ thì thêm x ở cuối 
            else
            {
                _stringPlaintext.Append("X");
            }

            // xoá kí tự trùng trong key
            StringBuilder _stringKey = new StringBuilder(key);

            for (int i = 0; i < _stringKey.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (_stringKey[i] == _stringKey[j])
                    {
                        _stringKey = _stringKey.Remove(i, 1);
                        i--;
                        break;
                    }
                }
            }


            // chèn key và bảng chữ cái vào trong ma trận.

            char[,] matrix = new char[5, 5];
            int k = 0;
            KeyAddAlpa(_stringKey, alpa);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = _stringKey[k++];
                }
            }

            // mã hoá 
            k = 0;
            StringBuilder result = new StringBuilder();
            var arr = new List<int>(_stringPlaintext.Length * 2);
            for (int i = 0; i < _stringPlaintext.Length * 2; i++)
            {   
                isCharacter(_stringPlaintext, i, matrix, arr);
                
            }


            StringBuilder tmp = new StringBuilder();
            for (int i = 0; i < _stringPlaintext.Length; i++)
            {
                tmp.Append(arr[i].ToString());
                
            }
            rtbCiphtertext.Text = tmp.ToString();


        }
    }
}
