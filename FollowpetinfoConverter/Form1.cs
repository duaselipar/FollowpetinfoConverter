using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace FollowpetinfoConverter
{
    public partial class Form1 : Form
    {
        private readonly byte[] password = Encoding.ASCII.GetBytes("hfydbeir");

        public Form1()
        {
            InitializeComponent();
        }

        // DAT ➔ INI + Sort
        private void btnDatToIni_Click(object sender, EventArgs e)
        {
            try
            {
                string datPath = "./FollowPetInfo.dat";
                string iniPath = "./FollowPetInfo.ini";
                DatToIni(datPath, iniPath);
                IniSorter.SortFollowPetInfoIni(iniPath);  // <-- Auto sort selepas convert
                MessageBox.Show("Convert DAT ➔ INI done!\r\n(Reordered sections)", "OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // INI ➔ DAT
        private void btnIniToDat_Click(object sender, EventArgs e)
        {
            try
            {
                IniToDat("./FollowPetInfo.ini", "./FollowPetInfo.dat");
                MessageBox.Show("Convert INI ➔ DAT done!", "OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private byte[] DecryptStoreText(byte[] cipher)
        {
            int length = cipher.Length;
            var plain = new byte[length];
            for (int i = 0; i < length; i++)
            {
                int pwdIndex = i % 8;
                plain[i] = (byte)(cipher[i] ^ password[pwdIndex]);
            }
            return plain;
        }

        private byte[] EncryptStoreText(byte[] plain)
        {
            int length = plain.Length;
            var cipher = new byte[length];
            for (int i = 0; i < length; i++)
            {
                int pwdIndex = i % 8;
                cipher[i] = (byte)(plain[i] ^ password[pwdIndex]);
            }
            return cipher;
        }

        // DAT ➔ INI
        private void DatToIni(string datPath, string iniPath)
        {
            byte[] fileBytes = File.ReadAllBytes(datPath);
            int pos = 0;
            int totalLen = fileBytes.Length;

            using (var fs = new FileStream(iniPath, FileMode.Create, FileAccess.Write))
            using (var writer = new StreamWriter(fs, Encoding.UTF8))
            {
                while (pos < totalLen)
                {
                    if (pos + 4 > totalLen) break;
                    int lineLen = BitConverter.ToInt32(fileBytes, pos);
                    pos += 4;

                    if (pos + lineLen > totalLen) break;
                    byte[] cipher = new byte[lineLen];
                    Array.Copy(fileBytes, pos, cipher, 0, lineLen);
                    pos += lineLen;

                    byte[] plain = DecryptStoreText(cipher);
                    string line = Encoding.UTF8.GetString(plain);
                    writer.WriteLine(line);
                }
            }
        }

        // INI ➔ DAT
        private void IniToDat(string iniPath, string datPath)
        {
            var lines = File.ReadAllLines(iniPath, Encoding.UTF8);
            using (var fs = new FileStream(datPath, FileMode.Create, FileAccess.Write))
            {
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    byte[] plain = Encoding.UTF8.GetBytes(line);
                    byte[] cipher = EncryptStoreText(plain);
                    byte[] lenBytes = BitConverter.GetBytes(cipher.Length);
                    fs.Write(lenBytes, 0, 4);
                    fs.Write(cipher, 0, cipher.Length);
                }
            }
        }
    }

    // STATIC CLASS UNTUK SUSUN BALIK INI
    public static class IniSorter
    {
        public static void SortFollowPetInfoIni(string iniPath)
        {
            var lines = File.ReadAllLines(iniPath);
            var sections = new List<(int? Number, List<string> Lines)>();
            List<string> vipSection = null;
            List<string> currentSection = null;
            int? currentNumber = null;
            var sectionHeaderPattern = new Regex(@"^\[(\d+|VIP)\]\s*$", RegexOptions.IgnoreCase);

            foreach (var line in lines)
            {
                var match = sectionHeaderPattern.Match(line);
                if (match.Success)
                {
                    // Store previous section
                    if (currentSection != null)
                    {
                        if (currentNumber == null)
                            vipSection = currentSection;
                        else
                            sections.Add((currentNumber, currentSection));
                    }
                    // Start new section
                    currentSection = new List<string>();
                    currentSection.Add(line);
                    if (match.Groups[1].Value.ToUpper() == "VIP")
                        currentNumber = null;
                    else
                        currentNumber = int.Parse(match.Groups[1].Value);
                }
                else if (currentSection != null)
                {
                    currentSection.Add(line);
                }
            }
            // Store last section
            if (currentSection != null)
            {
                if (currentNumber == null)
                    vipSection = currentSection;
                else
                    sections.Add((currentNumber, currentSection));
            }

            // Sort by number
            var sortedSections = sections.OrderBy(s => s.Number).Select(s => s.Lines);

            // Combine all back, append [VIP] at last if exist
            var result = new List<string>();
            foreach (var section in sortedSections)
                result.AddRange(section);
            if (vipSection != null)
            {
                // Remove blank lines before [VIP] section
                while (vipSection.Count > 0 && string.IsNullOrWhiteSpace(vipSection[0]))
                    vipSection.RemoveAt(0);
                result.Add(""); // Blank line before [VIP]
                result.AddRange(vipSection);
            }

            // Save back
            File.WriteAllLines(iniPath, result);
        }


    }
}
