using System;
using System.Collections;
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
            this.tbKey.TextChanged += new EventHandler(onInputKeyChange);
            this.btnEncryp.Click += new EventHandler(btnEncryp_Click);
            this.btnDecryp.Click += new EventHandler(btnDecryp_Click);
        }
        char[,] matrix = new char[5, 5];

        private void onInputKeyChange(object sender, EventArgs e)
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
            /*if (plaintext == String.Empty || key == String.Empty)
            {
                MessageBox.Show("Message: Plaintext or key is empty!!!");
            }*/
            if (string.IsNullOrEmpty(rtbPlaintext.Text) || string.IsNullOrEmpty(tbKey.Text))
            {
                //MessageBox.Show("Message: Plaintext or key is empty!!!");
                String defaultKey = new string(alpa);
                tbKey.Text = defaultKey;
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


            // chèn key và bảng chữ cái vào trong ma trận + hiển thị ma trận 


            int k = 0;
            KeyAddAlpa(_stringKey, alpa);
            var keyShow = "";
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    var index = i * 5 + j;
                    matrix[i, j] = _stringKey[k++];
                    keyShow += _stringKey[index] + " ";
                }
                keyShow += "\r\n";
            }
            this.rtbMatrix.Text = keyShow;




        }

        private void Form1_Load(object sender, EventArgs e, List<char> arrPlaintext, KeyEventArgs key)
        {

        }



        public void KeyAddAlpa(StringBuilder _stringKey, char[] alpa)
        {
            foreach (var i in alpa)
            {
                int flag = 0;
                for (int j = 0; j < _stringKey.Length; j++)
                {
                    if (i == _stringKey[j])
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                {
                    _stringKey.Append(i);
                }

            }

        }
        public void isCharacter(StringBuilder _stringPlaintext, char[,] matrix, List<int> arr)
        {
            var list = new List<char>();
            for (int i = 0; i < _stringPlaintext.Length; i++)
            {
                list.Add(_stringPlaintext[i]);
            }
            foreach (var item in list)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (item == matrix[i, j])
                        {
                            arr.Add(i);
                            arr.Add(j);
                        }
                    }

                }
            }
        }
        private void btnEncryp_Click(object sender, EventArgs e)
        {
            onInputKeyChange(sender, e);
            var plaintext = rtbPlaintext.Text;

            plaintext = plaintext.ToUpper();
            var charsToRemove = new string[] { "@", ",", ".", ";", "'", " " };
            foreach (var c in charsToRemove)
            {

                plaintext = plaintext.Replace(c, string.Empty);
            }

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
            if (_stringPlaintext.Length % 2 == 1)
            {
                _stringPlaintext.Append("X");
            }

            var arr = new List<int>(_stringPlaintext.Length * 2);
            // chỉ số của các phần tử
            for (int i = 0; i < _stringPlaintext.Length * 2; i++)
            {
                isCharacter(_stringPlaintext, matrix, arr);

            }



            StringBuilder result = new StringBuilder();
            // mã hoá 
            for (int i = 0; i < _stringPlaintext.Length * 2 - 1; i += 4)
            {
                // nếu tạo thành hình chữ nhật
                if ((arr[i] != arr[i + 2]) && (arr[i + 1] != arr[i + 3]))
                {

                    result.Append(matrix[arr[i], arr[i + 3]]);
                    result.Append(matrix[arr[i + 2], arr[i + 1]]);
                    result.Append(' ');
                }
                // nếu tạo thành 1 dòng. 

                if (arr[i] == arr[i + 2])
                {
                    // nếu từ thứ nhất ở cột cuối
                    if (arr[i + 1] == 4)
                    {
                        result.Append(matrix[arr[i], 0]);
                    }
                    else
                    {
                        result.Append(matrix[arr[i], arr[i + 1] + 1]);
                    }
                    if (arr[i + 3] == 4)
                    {
                        result.Append(matrix[arr[i + 2], 0]);

                    }
                    else
                    {
                        result.Append(matrix[arr[i + 2], arr[i + 3] + 1]);
                    }
                    result.Append(' ');
                }

                // nếu tạo thành cột
                if (arr[i + 1] == arr[i + 3])
                {
                    if (arr[i] == 4)
                    {
                        result.Append(matrix[0, arr[i + 1]]);
                    }
                    else
                    {
                        result.Append(matrix[arr[i] + 1, arr[i + 1]]);
                    }
                    if (arr[i + 2] == 4)
                    {
                        result.Append(matrix[0, arr[i + 3]]);
                    }
                    else
                    {
                        result.Append(matrix[arr[i + 2] + 1, arr[i + 3]]);
                    }
                    result.Append(' ');
                }

            }


            rtbCiphtertext.Text = result.ToString();


        }

        //=====================================
        //=====================================



        public void getTextDecryp(char[,] matrix, String plaintext, List<int> listIndexPlaintext)
        {
            for (int i = 0; i < plaintext.Length; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        if (plaintext[i] == matrix[j, k])
                        {
                            listIndexPlaintext.Add(j);
                            listIndexPlaintext.Add(k);
                        }
                    }
                }
            }
        }





        private void btnDecryp_Click(object sender, EventArgs e)
        {

            var plaintext = rtbPlaintext.Text;
            plaintext = plaintext.ToUpper();
            var charsToRemove = new string[] { "@", ",", ".", ";", "'", " " };
            foreach (var c in charsToRemove)
            {

                plaintext = plaintext.Replace(c, string.Empty);
            }
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


            var arr = new List<int>(_stringPlaintext.Length * 2);
            // chỉ số của các phần tử
            for (int i = 0; i < _stringPlaintext.Length * 2; i++)
            {
                isCharacter(_stringPlaintext, matrix, arr);

            }


            StringBuilder result = new StringBuilder();
            // mã hoá 
            for (int i = 0; i < _stringPlaintext.Length * 2; i += 4)
            {
                // nếu tạo thành hình chữ nhật
                if ((arr[i] != arr[i + 2]) && (arr[i + 1] != arr[i + 3]))
                {

                    result.Append(matrix[arr[i], arr[i + 3]]);
                    result.Append(matrix[arr[i + 2], arr[i + 1]]);
                    result.Append(' ');
                }
                // nếu tạo thành 1 dòng. 


                if (arr[i] == arr[i + 2])
                {
                    // nếu từ thứ nhất ở cột cuối
                    if (arr[i + 1] == 4)
                    {
                        result.Append(matrix[arr[i], 0]);
                    }
                    else
                    {
                        result.Append(matrix[arr[i], arr[i + 1]]);
                    }
                    if (arr[i + 3] == 4)
                    {
                        result.Append(matrix[arr[i + 2], 0]);

                    }
                    else
                    {
                        result.Append(matrix[arr[i + 2], arr[i + 3] + 1]);
                    }
                    result.Append(' ');
                }
                // nếu tạo thành cột
                if (arr[i + 1] == arr[i + 3])
                {
                    if (arr[i] == 4)
                    {
                        result.Append(matrix[0, arr[i + 1]]);
                    }
                    else
                    {
                        result.Append(matrix[arr[i] - 1, arr[i + 1]]);
                    }
                    if (arr[i + 2] == 4)
                    {
                        result.Append(matrix[0, arr[i + 3]]);
                    }
                    else
                    {
                        result.Append(matrix[arr[i + 2] - 1, arr[i + 3]]);
                    }
                    result.Append(' ');
                }

            }

            /* foreach (var c in charsToRemove)
             {
                 result = result.Replace(c, string.Empty);

             }
             k = result.Length;
             if (result[k - 1].ToString() == "X") 
             {
                 result.Replace("X", string.Empty);
             }*/


            rtbCiphtertext.Text = result.ToString();

        }

        private void tbKey_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
