using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net; //added
using System.Net.Sockets; //added
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
        public static void ConnectBackend(String server, String message)
        {
            int port = 11000;
            Request request = new Request();
            request.RequestType = message;
            if (IOTSendUnit != null)
            {
                Console.WriteLine(IOTSendUnit.ToString());
            }
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
    }
    [Serializable()]
    public class IOTunit
    {
        // Example of information to store:
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
