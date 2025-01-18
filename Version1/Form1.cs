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
            double totalCost = 0;
            List<string> unpairedItems = new List<string>(); // To hold single items that can't form a combo
            List<string> comboItems = new List<string>(); // To hold combo items
            List<string> receiptLines = new List<string>(); // For generating receipt content
            int comboCount = 0;

            // Read all lines from RichTextBox
            string[] lines = rtfReceipt.Lines;

            // Process items in sequence
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
                                // Try to pair with previous unpaired item
                                if (unpairedItems.Count > 0)
                                {
                                    // Check if we can form a combo based on the last item in the unpairedItems list
                                    string lastItem = unpairedItems[unpairedItems.Count - 1];
                                    double lastItemPrice = double.Parse(lastItem.Split('-')[1].Replace("php", "").Trim());

                                    if (price == 45 && lastItemPrice == 45)
                                    {
                                        double comboPrice = 80; // Combo price for two 45 php items
                                        comboItems.Add($"Combo ({lastItem} + {itemName} - {price} php) = {comboPrice:C}");
                                        totalCost += comboPrice;
                                        unpairedItems.RemoveAt(unpairedItems.Count - 1); // Remove the paired item
                                        comboCount++;
                                        continue; // Skip the single item addition
                                    }

                                    if ((price == 40 && lastItemPrice == 40) || (price == 40 && lastItemPrice == 45) || (price == 45 && lastItemPrice == 40))
                                    {
                                        double comboPrice = (price == 40 && lastItemPrice == 40) ? 70 : 80;
                                        comboItems.Add($"Combo ({lastItem} + {itemName} - {price} php) = {comboPrice:C}");
                                        totalCost += comboPrice;
                                        unpairedItems.RemoveAt(unpairedItems.Count - 1); // Remove the paired item
                                        comboCount++;
                                        continue; // Skip the single item addition
                                    }

                                }

                                // If no combo is found, add it to unpaired list
                                unpairedItems.Add($"{itemName} - {price} php");
                            }
                            else
                            {
                                // Item price is not eligible for a combo, just add as single
                                receiptLines.Add($"{itemName} - {price:C} (Single)");
                                totalCost += price; // Add the correct price for the single item
                            }
                        }
                    }
                }
            }

            // Add combo items first, then unpaired items
            foreach (string comboItem in comboItems)
            {
                receiptLines.Add(comboItem);
            }

            // Process remaining unpaired items
            foreach (string item in unpairedItems)
            {
                receiptLines.Add($"{item} (Single)");
                // Add the correct price for the unpaired items
                string pricePart = item.Split('-')[1].Replace("php", "").Trim();
                if (double.TryParse(pricePart, out double price))
                {
                    totalCost += price;
                }
            }

            // Clear the RichTextBox for the new receipt
            rtfReceipt.Clear();

            // Add receipt header
            rtfReceipt.AppendText("=========================================" + Environment.NewLine);
            rtfReceipt.AppendText("                                            ChaoFan" + Environment.NewLine);
            rtfReceipt.AppendText("=========================================" + Environment.NewLine);
            rtfReceipt.AppendText($"Order Number: {orderNumber}" + Environment.NewLine);
            rtfReceipt.AppendText("=========================================" + Environment.NewLine);

            // Add receipt content (combo items first, then single items)
            foreach (string receiptLine in receiptLines)
            {
                rtfReceipt.AppendText(receiptLine + Environment.NewLine);
            }

            // Add total cost to the receipt
            rtfReceipt.AppendText("=========================================" + Environment.NewLine);
            rtfReceipt.AppendText($"Total Cost               ₱{totalCost:F2}" + Environment.NewLine);
            rtfReceipt.AppendText("=========================================" + Environment.NewLine);
            rtfReceipt.AppendText($"Payment Method: {paymentMethod}" + Environment.NewLine);
            // Add footer with date and time
            rtfReceipt.AppendText($"Time: {DateTime.Now:hh:mm tt}" + Environment.NewLine);
            rtfReceipt.AppendText($"Date: {DateTime.Now:MM/dd/yyyy}" + Environment.NewLine);
            rtfReceipt.AppendText("=========================================" + Environment.NewLine);

            // Increment the order number for the next order
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
            rtfReceipt.Clear();
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
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
    }
}
