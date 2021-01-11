using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net; //added
using System.Net.Sockets; //added
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using Google.Protobuf;

namespace IOTdbFrontend
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static List<IOTunit> IOTunitList;
        public static IotUnitList IOTunitListPB;
        public static IotUnit IOTSendUnit;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static void ConnectBackendPB(String server, String message)
        {
            int port = 11000;
            Request request = new Request();
            request.RequestType = message;
            if (IOTSendUnit != null)
            {
                Console.WriteLine(IOTSendUnit.ToString());
            }
            //request.List = new IotUnit();

            if (message == "R")
            {
                //Sends request for data
                TcpClient client = new TcpClient(server, port);
                NetworkStream stream = client.GetStream();
                request.WriteTo(stream);
                stream.Close();

                //Opens new socket for reciving data
                client = new TcpClient(server, port);
                stream = client.GetStream();
                IOTunitListPB = new IotUnitList();
                IOTunitListPB = IotUnitList.Parser.ParseFrom(stream);
                stream.Close();
            }

            else if (message == "W")
            {
                //Sends request for adding data to db
                TcpClient client = new TcpClient(server, port);
                NetworkStream stream = client.GetStream();
                request.WriteTo(stream);
                client.Close();
            }
        }
        public static void ConnectBackend(String server, String message)
        {
            try
            {
                int port = 11000;

                TcpClient client = new TcpClient(server, port);
                // if no connection could be established an exception will be thrown
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);



                String responseData = String.Empty;

                int bytes = stream.Read(data, 0, data.Length);
                data = new byte[bytes];
                //responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Recived: {0}", responseData);
                SoapFormatter formatter = new SoapFormatter();


                MemoryStream mStream = new MemoryStream();
                //formatter.Serialize(mStream, IOTunitList[0]);

                //Byte[] mbytes = mStream.GetBuffer();
                //int bytes_size = (int)mStream.Length;
                //Byte[] size = BitConverter.GetBytes(bytes_size);


                IOTunitList = new List<IOTunit>();
                IOTunit iOTunit;
                iOTunit = (IOTunit)formatter.Deserialize(stream);
                IOTunitList.Add(iOTunit);
                if (responseData[0].Equals('R'))
                {
                    //BinaryFormatter formatter = new BinaryFormatter();

                    responseData.Remove(0);
                    IOTunitList = null;
                    //int i = 0;
                    //int j = 0;
                    //int counter = 0;
                    //IOTunit iOTunit;
                    //string tempDevID = "", tempDevType = "", tempDevCate = "";
                    //IPAddress tempIPAdd = null;
                    //DateTime tempTimeStamp = DateTime.MinValue;
                    //double tempValue = double.NaN;
                    //char tempUnit = char.MinValue;
                    iOTunit = (IOTunit)formatter.Deserialize(stream);
                    IOTunitList.Add(iOTunit);
                    /*
                    while (i < responseData.Length)
                    {


                        
                        if (responseData[i].Equals(';'))
                        {
                            if (i + 1 < responseData.Length)
                            {
                                if (responseData[i + 1].Equals(';'))
                                {
                                    counter = 0;
                                    iOTunit = new IOTunit(tempDevID, tempIPAdd, tempTimeStamp, tempDevType, tempDevCate, tempValue, tempUnit);
                                }
                            }
                            else if (counter == 0)
                            {
                                tempDevID = responseData.Substring(j, i);
                                tempDevID = tempDevID.Trim(';');
                            }
                            else if (counter == 1)
                            {
                                string tempstring = responseData.Substring(j, i);
                                tempIPAdd = IPAddress.Parse(tempstring.Trim(';'));
                            }
                            else if (counter == 2)
                            {
                                string tempstring = responseData.Substring(j, i);
                                tempTimeStamp = DateTime.Parse(tempstring.Trim(';'));
                            }
                            else if (counter == 3)
                            {
                                tempDevType = responseData.Substring(j, i);
                                tempDevType = tempDevType.Trim(';');
                            }
                            else if (counter == 4)
                            {
                                tempDevCate = responseData.Substring(j, i);
                                tempDevCate = tempDevCate.Trim(';');
                            }
                            else if (counter == 5)
                            {
                                string tempstring = responseData.Substring(j, i);
                                tempValue = double.Parse(tempstring.Trim(';'));
                            }
                            else if (counter == 6)
                            {
                                string tempstring = responseData.Substring(j, i);
                                tempstring = tempstring.Trim(';');
                                tempUnit = tempstring.ToCharArray(j, i)[1];
                            }
                            j = i;


                        }
                        


                        i++;
                    }
                    */
                }
                else if (responseData[0].Equals('D'))
                {

                }
                else if (responseData[0].Equals('F'))
                {
                    Console.WriteLine("Got an F");
                }
                stream.Close();
                client.Close();
            }

            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

    }
    [Serializable()]
    public class IOTunit
    {
        //Device-ID: ade43572-r5764
        //IP-adress: 192.168.0.45
        //Timestamp: 20200115CET21:37:23:462
        //Device-Type: Sensor
        //Device-Category: Temperature
        //Value: 23.4
        //Unit: C

        private string deviceId;
        private IPAddress iPAddress;
        private DateTime timeStamp;
        private string deviceType;
        private string deviceCatagory;
        private double value;
        private char unit;

        public IOTunit(string deviceId, IPAddress iPAddress, DateTime timeStamp, string deviceType, string deviceCatagory, double value, char unit)
        {
            this.deviceId = deviceId;
            this.iPAddress = iPAddress;
            this.timeStamp = timeStamp;
            this.deviceType = deviceType;
            this.deviceCatagory = deviceCatagory;
            this.value = value;
            this.unit = unit;
        }

        public string GetDeviceId()
        {
            return deviceId;
        }
        public IPAddress GetIPAddress()
        {
            return iPAddress;
        }
        public DateTime GetTimeStamp()
        {
            return timeStamp;
        }
        public string GetDeviceType()
        {
            return deviceType;
        }
        public string GetDeviceCatagory()
        {
            return deviceCatagory;
        }
        public double GetValue()
        {
            return value;
        }
        public char GetUnit()
        {
            return unit;
        }
    }
}
