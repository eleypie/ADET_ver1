using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrbVideoManager.Controls;

namespace Version1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rtfReceipt != null)
            {
                string[] receiptMarkers = new string[]
                {
            "ChaoFan",
            "Order Number",
            "Total Cost",
            "Time:",
            "Date:"
                };

                bool isReceipt = false;
                foreach (string marker in receiptMarkers)
                {
                    if (rtfReceipt.Text.Contains(marker))
                    {
                        isReceipt = true;
                        break;
                    }
                }
                if (isReceipt)
                {
                    rtfReceipt.Clear();
                }
                rtfReceipt.AppendText("Maling - 40 php\n");
            }
            else
            {
                MessageBox.Show("RichTextBox not found!");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rtfReceipt != null)
            {
                string[] receiptMarkers = new string[]
                {
            "ChaoFan",
            "Order Number",
            "Total Cost",
            "Time:",
            "Date:"
                };

                bool isReceipt = false;
                foreach (string marker in receiptMarkers)
                {
                    if (rtfReceipt.Text.Contains(marker))
                    {
                        isReceipt = true;
                        break;
                    }
                }
                if (isReceipt)
                {
                    rtfReceipt.Clear();
                }
                rtfReceipt.AppendText("Hotdog - 40 php\n");
            }
            else
            {
                MessageBox.Show("RichTextBox not found!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (rtfReceipt != null)
            {
                string[] receiptMarkers = new string[]
                {
            "ChaoFan",
            "Order Number",
            "Total Cost",
            "Time:",
            "Date:"
                };

                bool isReceipt = false;
                foreach (string marker in receiptMarkers)
                {
                    if (rtfReceipt.Text.Contains(marker))
                    {
                        isReceipt = true;
                        break;
                    }
                }
                if (isReceipt)
                {
                    rtfReceipt.Clear();
                }
                rtfReceipt.AppendText("Shanghai - 40 php\n");
            }
            else
            {
                MessageBox.Show("RichTextBox not found!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (rtfReceipt != null)
            {
                string[] receiptMarkers = new string[]
                {
            "ChaoFan",
            "Order Number",
            "Total Cost",
            "Time:",
            "Date:"
                };

                bool isReceipt = false;
                foreach (string marker in receiptMarkers)
                {
                    if (rtfReceipt.Text.Contains(marker))
                    {
                        isReceipt = true;
                        break;
                    }
                }
                if (isReceipt)
                {
                    rtfReceipt.Clear();
                }
                rtfReceipt.AppendText("Embotido - 40 php\n");
            }
            else
            {
                MessageBox.Show("RichTextBox not found!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (rtfReceipt != null)
            {
                string[] receiptMarkers = new string[]
                {
            "ChaoFan",
            "Order Number",
            "Total Cost",
            "Time:",
            "Date:"
                };

                bool isReceipt = false;
                foreach (string marker in receiptMarkers)
                {
                    if (rtfReceipt.Text.Contains(marker))
                    {
                        isReceipt = true;
                        break;
                    }
                }
                if (isReceipt)
                {
                    rtfReceipt.Clear();
                }
                rtfReceipt.AppendText("Meatballs - 40 php\n");
            }
            else
            {
                MessageBox.Show("RichTextBox not found!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (rtfReceipt != null)
            {
                string[] receiptMarkers = new string[]
                {
            "ChaoFan",
            "Order Number",
            "Total Cost",
            "Time:",
            "Date:"
                };

                bool isReceipt = false;
                foreach (string marker in receiptMarkers)
                {
                    if (rtfReceipt.Text.Contains(marker))
                    {
                        isReceipt = true;
                        break;
                    }
                }
                if (isReceipt)
                {
                    rtfReceipt.Clear();
                }
                rtfReceipt.AppendText("Longannisa - 40 php\n");
            }
            else
            {
                MessageBox.Show("RichTextBox not found!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (rtfReceipt != null)
            {
                string[] receiptMarkers = new string[]
                {
            "ChaoFan",
            "Order Number",
            "Total Cost",
            "Time:",
            "Date:"
                };

                bool isReceipt = false;
                foreach (string marker in receiptMarkers)
                {
                    if (rtfReceipt.Text.Contains(marker))
                    {
                        isReceipt = true;
                        break;
                    }
                }
                if (isReceipt)
                {
                    rtfReceipt.Clear();
                }
                rtfReceipt.AppendText("Siomai - 40 php\n");
            }
            else
            {
                MessageBox.Show("RichTextBox not found!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (rtfReceipt != null)
            {
                string[] receiptMarkers = new string[]
                {
            "ChaoFan",
            "Order Number",
            "Total Cost",
            "Time:",
            "Date:"
                };

                bool isReceipt = false;
                foreach (string marker in receiptMarkers)
                {
                    if (rtfReceipt.Text.Contains(marker))
                    {
                        isReceipt = true;
                        break;
                    }
                }
                if (isReceipt)
                {
                    rtfReceipt.Clear();
                }
                rtfReceipt.AppendText("Tofu Sisig - 45 php\n");
            }
            else
            {
                MessageBox.Show("RichTextBox not found!");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (rtfReceipt != null)
            {
                string[] receiptMarkers = new string[]
                {
            "ChaoFan",
            "Order Number",
            "Total Cost",
            "Time:",
            "Date:"
                };

                bool isReceipt = false;
                foreach (string marker in receiptMarkers)
                {
                    if (rtfReceipt.Text.Contains(marker))
                    {
                        isReceipt = true;
                        break;
                    }
                }
                if (isReceipt)
                {
                    rtfReceipt.Clear();
                }
                rtfReceipt.AppendText("Burger Steak - 45 php\n");
            }
            else
            {
                MessageBox.Show("RichTextBox not found!");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (rtfReceipt != null)
            {
                string[] receiptMarkers = new string[]
                {
            "ChaoFan",
            "Order Number",
            "Total Cost",
            "Time:",
            "Date:"
                };

                bool isReceipt = false;
                foreach (string marker in receiptMarkers)
                {
                    if (rtfReceipt.Text.Contains(marker))
                    {
                        isReceipt = true;
                        break;
                    }
                }
                if (isReceipt)
                {
                    rtfReceipt.Clear();
                }
                rtfReceipt.AppendText("Extra Rice - 15 php\n");
            }
            else
            {
                MessageBox.Show("RichTextBox not found!");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (rtfReceipt != null)
            {
                string[] receiptMarkers = new string[]
                {
            "ChaoFan",
            "Order Number",
            "Total Cost",
            "Time:",
            "Date:"
                };

                bool isReceipt = false;
                foreach (string marker in receiptMarkers)
                {
                    if (rtfReceipt.Text.Contains(marker))
                    {
                        isReceipt = true;
                        break;
                    }
                }
                if (isReceipt)
                {
                    rtfReceipt.Clear();
                }
                rtfReceipt.AppendText("Bottled Water - 15 php\n");
            }
            else
            {
                MessageBox.Show("RichTextBox not found!");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (rtfReceipt != null)
            {
                string[] receiptMarkers = new string[]
                {
            "ChaoFan",
            "Order Number",
            "Total Cost",
            "Time:",
            "Date:"
                };

                bool isReceipt = false;
                foreach (string marker in receiptMarkers)
                {
                    if (rtfReceipt.Text.Contains(marker))
                    {
                        isReceipt = true;
                        break;
                    }
                }
                if (isReceipt)
                {
                    rtfReceipt.Clear();
                }
                rtfReceipt.AppendText("Tempura - 8 php\n");
            }
            else
            {
                MessageBox.Show("RichTextBox not found!");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (rtfReceipt != null)
            {
                string[] receiptMarkers = new string[]
                {
            "ChaoFan",
            "Order Number",
            "Total Cost",
            "Time:",
            "Date:"
                };

                bool isReceipt = false;
                foreach (string marker in receiptMarkers)
                {
                    if (rtfReceipt.Text.Contains(marker))
                    {
                        isReceipt = true;
                        break;
                    }
                }
                if (isReceipt)
                {
                    rtfReceipt.Clear();
                }
                rtfReceipt.AppendText("Gulaman - 15 php\n");
            }
            else
            {
                MessageBox.Show("RichTextBox not found!");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (rtfReceipt != null)
            {
                string[] receiptMarkers = new string[]
                {
            "ChaoFan",
            "Order Number",
            "Total Cost",
            "Time:",
            "Date:"
                };

                bool isReceipt = false;
                foreach (string marker in receiptMarkers)
                {
                    if (rtfReceipt.Text.Contains(marker))
                    {
                        isReceipt = true;
                        break;
                    }
                }
                if (isReceipt)
                {
                    rtfReceipt.Clear();
                }
                rtfReceipt.AppendText("Kikiam - 10 php\n");
            }
            else
            {
                MessageBox.Show("RichTextBox not found!");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (rtfReceipt != null)
            {
                string[] receiptMarkers = new string[]
                {
            "ChaoFan",
            "Order Number",
            "Total Cost",
            "Time:",
            "Date:"
                };

                bool isReceipt = false;
                foreach (string marker in receiptMarkers)
                {
                    if (rtfReceipt.Text.Contains(marker))
                    {
                        isReceipt = true;
                        break;
                    }
                }
                if (isReceipt)
                {
                    rtfReceipt.Clear();
                }
                rtfReceipt.AppendText("Lemonade - 15 php\n");
            }
            else
            {
                MessageBox.Show("RichTextBox not found!");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (rtfReceipt != null)
            {
                string[] receiptMarkers = new string[]
                {
            "ChaoFan",
            "Order Number",
            "Total Cost",
            "Time:",
            "Date:"
                };

                bool isReceipt = false;
                foreach (string marker in receiptMarkers)
                {
                    if (rtfReceipt.Text.Contains(marker))
                    {
                        isReceipt = true;
                        break;
                    }
                }
                if (isReceipt)
                {
                    rtfReceipt.Clear();
                }
                rtfReceipt.AppendText("Egg - 7 php\n");
            }
            else
            {
                MessageBox.Show("RichTextBox not found!");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (rtfReceipt != null)
            {
                string[] receiptMarkers = new string[]
                {
            "ChaoFan",
            "Order Number",
            "Total Cost",
            "Time:",
            "Date:"
                };

                bool isReceipt = false;
                foreach (string marker in receiptMarkers)
                {
                    if (rtfReceipt.Text.Contains(marker))
                    {
                        isReceipt = true;
                        break;
                    }
                }
                if (isReceipt)
                {
                    rtfReceipt.Clear();
                }
                rtfReceipt.AppendText("Ice Tea - 15 php\n");
            }
            else
            {
                MessageBox.Show("RichTextBox not found!");
            }
        }
    }
}
