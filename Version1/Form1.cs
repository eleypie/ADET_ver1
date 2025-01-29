using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrbVideoManager.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Version1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static int orderNumber = 1;
        string paymentMethod;
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
            // Check if any radio button in groupBox1 is selected
            bool isSelected = false;

            foreach (Control control in groupBox1.Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    isSelected = true;
                    break;
                }
            }

         
            if (!isSelected)
            {
               // MessageBox.Show("Please select an option in the group box before proceeding.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Error_Payment error_Payment = new Error_Payment();
                error_Payment.Show();
                return; 
            }

            double totalCost = 0;
            List<string> unpairedItems = new List<string>(); 
            List<string> comboItems = new List<string>(); 
            List<string> receiptLines = new List<string>(); 
            int comboCount = 0;

            
            string[] lines = rtfReceipt.Lines;

          
            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();
                if (trimmedLine.Contains("-") && trimmedLine.Contains("php"))
                {
                    string[] parts = trimmedLine.Split('-');
                    if (parts.Length == 2)
                    {
                        string itemName = parts[0].Trim();
                        string pricePart = parts[1].Replace("php", "").Trim();

                        if (double.TryParse(pricePart, out double price))
                        {
                            if (price == 40 || price == 45)
                            {
                                
                                if (unpairedItems.Count > 0)
                                {
                                   
                                    string lastItem = unpairedItems[unpairedItems.Count - 1];
                                    double lastItemPrice = double.Parse(lastItem.Split('-')[1].Replace("php", "").Trim());

                                    if (price == 45 && lastItemPrice == 45)
                                    {
                                        double comboPrice = 80;
                                        comboItems.Add($"Combo ({lastItem} + {itemName} - {price} php) = {comboPrice:C}");
                                        totalCost += comboPrice;
                                        unpairedItems.RemoveAt(unpairedItems.Count - 1); 
                                        comboCount++;
                                        continue; 
                                    }

                                    if ((price == 40 && lastItemPrice == 40) || (price == 40 && lastItemPrice == 45) || (price == 45 && lastItemPrice == 40))
                                    {
                                        double comboPrice = (price == 40 && lastItemPrice == 40) ? 70 : 80;
                                        comboItems.Add($"Combo ({lastItem} + {itemName} - {price} php) = {comboPrice:C}");
                                        totalCost += comboPrice;
                                        unpairedItems.RemoveAt(unpairedItems.Count - 1); 
                                        comboCount++;
                                        continue; 
                                    }

                                }

                              
                                unpairedItems.Add($"{itemName} - {price} php");
                            }
                            else
                            {
                               
                                receiptLines.Add($"{itemName} - {price:C} (Single)");
                                totalCost += price; 
                            }
                        }
                    }
                }
            }

           
            foreach (string comboItem in comboItems)
            {
                receiptLines.Add(comboItem);
            }

         
            foreach (string item in unpairedItems)
            {
                receiptLines.Add($"{item} (Single)");
                string pricePart = item.Split('-')[1].Replace("php", "").Trim();
                if (double.TryParse(pricePart, out double price))
                {
                    totalCost += price;
                }
            }

          
            rtfReceipt.Clear();

           
            
            rtfReceipt.AppendText("\t\tCuadro De J" + Environment.NewLine);
            rtfReceipt.AppendText("    Polytechnic University of the Philippines" + Environment.NewLine);
            rtfReceipt.AppendText("\t\tLagoon, Stall 11" + Environment.NewLine);
            rtfReceipt.AppendText("\t\t09778420921" + Environment.NewLine);
            rtfReceipt.AppendText(Environment.NewLine);


            rtfReceipt.AppendText($"Time: {DateTime.Now:hh:mm tt}" + Environment.NewLine);
            rtfReceipt.AppendText($"Date: {DateTime.Now:MM/dd/yyyy}" + Environment.NewLine);
            rtfReceipt.AppendText($"Order Number: {orderNumber}" + Environment.NewLine);

            rtfReceipt.AppendText(Environment.NewLine);
          

            foreach (string receiptLine in receiptLines)
            {
                rtfReceipt.AppendText(receiptLine + Environment.NewLine);
            }

            rtfReceipt.AppendText(Environment.NewLine);

            rtfReceipt.AppendText($"Total Cost:               ₱{totalCost:F2}" + Environment.NewLine);

            rtfReceipt.AppendText($"Payment Method: {paymentMethod}" + Environment.NewLine);
        
          


            label5.Text = $"Order #: {orderNumber}";
            label6.Text = $"Time: {DateTime.Now:hh:mm tt}";
            label7.Text = $"Date: {DateTime.Now:MM/dd/yyyy}";

            orderNumber++;

           

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
                "Cuadro De J",
                "Polytechnic University of the Philippines",
                "09778420921",
                "Time:",
                "Date:",
                "Total Cost"
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
                "Cuadro De J",
                "Polytechnic University of the Philippines",
                "09778420921",
                "Time:",
                "Date:",
                "Total Cost"
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
                "Cuadro De J",
                "Polytechnic University of the Philippines",
                "09778420921",
                "Time:",
                "Date:",
                "Total Cost"
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
                "Cuadro De J",
                "Polytechnic University of the Philippines",
                "09778420921",
                "Time:",
                "Date:",
                "Total Cost"
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
                "Cuadro De J",
                "Polytechnic University of the Philippines",
                "09778420921",
                "Time:",
                "Date:",
                "Total Cost"
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
                "Cuadro De J",
                "Polytechnic University of the Philippines",
                "09778420921",
                "Time:",
                "Date:",
                "Total Cost"
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
                "Cuadro De J",
                "Polytechnic University of the Philippines",
                "09778420921",
                "Time:",
                "Date:",
                "Total Cost"
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
                "Cuadro De J",
                "Polytechnic University of the Philippines",
                "09778420921",
                "Time:",
                "Date:",
                "Total Cost"
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
                 "Cuadro De J",
                "Polytechnic University of the Philippines",
                "09778420921",
                "Time:",
                "Date:",
                "Total Cost"
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
                "Cuadro De J",
                "Polytechnic University of the Philippines",
                "09778420921",
                "Time:",
                "Date:",
                "Total Cost"
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
                "Cuadro De J",
                "Polytechnic University of the Philippines",
                "09778420921",
                "Time:",
                "Date:",
                "Total Cost"
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
                "Cuadro De J",
                "Polytechnic University of the Philippines",
                "09778420921",
                "Time:",
                "Date:",
                "Total Cost"
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
                "Cuadro De J",
                "Polytechnic University of the Philippines",
                "09778420921",
                "Time:",
                "Date:",
                "Total Cost"
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
                "Cuadro De J",
                "Polytechnic University of the Philippines",
                "09778420921",
                "Time:",
                "Date:",
                "Total Cost"
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
                "Cuadro De J",
                "Polytechnic University of the Philippines",
                "09778420921",
                "Time:",
                "Date:",
                "Total Cost"
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
                 "Cuadro De J",
                "Polytechnic University of the Philippines",
                "09778420921",
                "Time:",
                "Date:",
                "Total Cost"
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

        private void newOrderBtn_Click(object sender, EventArgs e)
        {
            rtfReceipt.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            paymentMethod = "Cash";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            paymentMethod = "Paymaya";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            paymentMethod = "Gcash";
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
           
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(rtfReceipt.Text, new Font("Barlow", 15, FontStyle.Regular), Brushes.Black, new PointF(100, 100));
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            string[] receiptMarkers = new string[]
            {
                "Cuadro De J",
                "Polytechnic University of the Philippines",
                "09778420921",
                "Time:",
                "Date:",
                "Total Cost"
            };

            foreach (string marker in receiptMarkers)
            {
                if (!rtfReceipt.Text.Contains(marker))
                {
                    MessageBox.Show($"Place your order first.",
                                    "Incomplete Receipt",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return; 
                }
            }

           
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
