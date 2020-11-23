using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Byte_Array_im_File_sichern_V1_WOd
{
    public class Beispiel1
    {

        static void test()
        {
            // define path and file name
            string fileName = @"Z:\Daten\M226B\byteArray.bin";
            // define and initialize arrays
            byte[] byteArrayWrite = { 200, 201, 202, 203, 204, 205, 206, 207 };
            byte[] byteArrayRead = new byte[byteArrayWrite.Length];

            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    // write array to file
                    fs.Write(byteArrayWrite, 0, byteArrayWrite.Length);
                    //read from file
                    fs.Position = 0; // set start position
                    fs.Read(byteArrayRead, 0, byteArrayRead.Length); // read file values
                                                                     // output: values of byte array
                    for (int count = 0; count < byteArrayRead.Length; count++)
                    {
                        Console.Write(byteArrayRead[count] + ", ");
                    }
                }
                // delete file
                File.Delete(fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }



            /*
            // define path and file name
            string fileName = @"Z:\Daten\M226B\byteArray.bin";
            // define and initialize arrays
            byte[] byteArrayWrite = { 200, 201, 202, 203, 204, 205, 206, 207 };
            byte[] byteArrayRead = new byte[byteArrayWrite.Length];
            //create file stream
            FileStream fs = new FileStream(fileName, FileMode.Create);
            // write array to file
            fs.Write(byteArrayWrite, 0, byteArrayWrite.Length); // array name,
                                                                // start index,
                                                                // length of array
                                                                //read from file
            fs.Position = 0; // set start position
            fs.Read(byteArrayRead, 0, byteArrayRead.Length); // read file values
                                                             // output: values of byte array
            for (int count = 0; count < byteArrayRead.Length; count++)
            {
                Console.Write(byteArrayRead[count] + ", ");
            }
            // close filestream
            fs.Close();
            // delete file
            File.Delete(fileName);*/
        }
    }
}