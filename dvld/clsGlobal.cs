using BussinesLayer;
using System;
using System.Collections.Generic;
//using System.IO;
using Microsoft.Win32;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dvld
{
    internal class clsGlobal
    {
        public static clsPerson.clsUser CurrentUser;
        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            try
            {
                ////this will get the current project directory folder.
                //string currentDirectory = System.IO.Directory.GetCurrentDirectory();
                //// Define the path to the text file where you want to save the data
                //string filePath = currentDirectory + "\\data.txt";
                ////incase the username is empty, delete the file
                //if (Username == "" && File.Exists(filePath))
                //{
                //    File.Delete(filePath);
                //    return true;
                //}
                //// concatonate username and passwrod withe seperator.
                //string dataToSave = Username + "#//#" + Password;
                //// Create a StreamWriter to write to the file
                //using (StreamWriter Writer = new StreamWriter(filePath))
                //{
                //    // Write the data to the file
                //    Writer.WriteLine(dataToSave);
                //    return true;
                //}
                try
                {
                    string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DvlD";
                    string valueName = "usarnaam";
                    string valueData = Username;
                    Registry.SetValue(keyPath, valueName, valueData, RegistryValueKind.String);

                    string keyPath2 = @"HKEY_CURRENT_USER\SOFTWARE\DvlD";
                    string valueName2 = "Passaward";
                    string valueData2 = Password;
                    Registry.SetValue(keyPath2, valueName2, valueData2, RegistryValueKind.String);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }
        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            try
            {
                //string currentDirectory = System.IO.Directory.GetCurrentDirectory();
                //string filePath = currentDirectory + "\\data.txt";
                //if (File.Exists(filePath))
                //{
                //    using (StreamReader reader = new StreamReader(filePath))
                //    {
                //        string Line;
                //        while ((Line = reader.ReadLine()) != null)
                //        {
                //            Console.WriteLine(Line); // Output each line of data to the console
                //            string[] result = Line.Split(new string[] { "#//#" }, StringSplitOptions.None);
                //            Username = result[0];
                //            Password = result[1];
                //        }
                //        return true;
                //    }
                //}
                //else
                //    return false;
                string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DvlD";
                string valueName = "usarnaam";
                string valueforUsername = Registry.GetValue(keyPath, valueName, null) as string;
                if (valueforUsername != null)
                {
                    Username = valueforUsername;
                }
                //else
                //    MessageBox.Show($"Value {valueName} not found in the Registry.");

                string keyPath2 = @"HKEY_CURRENT_USER\SOFTWARE\DvlD";
                string valueName2 = "Passaward";
                string valueforPassword = Registry.GetValue(keyPath2, valueName2, null) as string;
                if (valueforPassword != null)
                {
                    Password = valueforPassword;
                    return true;
                }
                //else
                //    MessageBox.Show($"Value {valueName} not found in the Registry.");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
