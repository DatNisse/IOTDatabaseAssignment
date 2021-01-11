using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //added
using MySql.Data.MySqlClient; //added
using System.Net; //added
using System.Net.Sockets; //added
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using Google.Protobuf;



namespace IOTdbBackend
{
    class Program
    {
        public static List<IOTunit> IOTunitList;
        static void Main(string[] args)
        {
            IOTunitList = new List<IOTunit>();
            ListenTCP(); //Begins listening for TCP clients to serve
            Console.ReadLine();
        }
        static void ListenTCP()
        {
            try
            {
                TcpListener tcpListener = new TcpListener(GetLocalIP(), 11000);
                tcpListener.Start();
                while (true)
                {
                    Console.Write("Waiting for a connection... ");
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    NetworkStream stream = tcpClient.GetStream();

                    Request clientRequest = new Request();
                    clientRequest = Request.Parser.ParseFrom(stream);
                    
                    //Checks if client wants to write to db
                    if (clientRequest.RequestType == "W")
                    {
                        WriteData(clientRequest.List);
                    }

                    //Checks if client wants to read from db
                    else if (clientRequest.RequestType == "R")
                    {
                        // Waits for new stream from client for transfer
                        tcpClient = tcpListener.AcceptTcpClient();
                        Console.WriteLine("Connected for transfer!");
                        stream = tcpClient.GetStream();
                        GetData();
                        IotUnitList sendList = new IotUnitList();
                        foreach (IOTunit dbUnit in IOTunitList)
                        {
                            IotUnit sendUnit = new IotUnit();
                            sendUnit.DeviceID = dbUnit.GetDeviceId();
                            sendUnit.IPadress = dbUnit.GetIPAddress().ToString();
                            sendUnit.Timestamp = dbUnit.GetTimeStamp().Ticks;
                            sendUnit.DeviceType = dbUnit.GetDeviceType();
                            sendUnit.DeviceCategory = dbUnit.GetDeviceCatagory();
                            sendUnit.Value = dbUnit.GetValue();
                            sendUnit.Unit = dbUnit.GetUnit().ToString();
                            sendList.List.Add(sendUnit);
                        }
                        sendList.WriteTo(tcpClient.GetStream());
                        tcpClient.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Retrives data from DB
        static void GetData()
        {
            string connString = "server=127.0.0.1;uid=root;" + "pwd=P@55w.rd;database=iotunits";
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                string sql = "SELECT * FROM iotunits.iotunit";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                DataTable table = conn.GetSchema("Databases");
                string tName = table.TableName;
                IOTunitList = new List<IOTunit>();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //Console.WriteLine("id = {0} marke = {1} modell = {2} year = {3} pris = {4}", reader.GetInt32("idbilar"), reader.GetString("Bilmärke"), reader.GetString("Modell"), reader.GetString("Årsmodell"), reader.GetDouble("pris"));
                    IOTunit iOTunit = new IOTunit(reader.GetString("DeviceID"), reader.GetString("IPAdress"), reader.GetDateTime("Timestamp"), reader.GetString("DeviceType"), reader.GetString("DeviceCategory"), reader.GetDouble("Value"), reader.GetChar("Unit"));
                    IOTunitList.Add(iOTunit);
                }
                conn.Close();
                //DisplayData(table);
                return;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return;
        }

        //Writes data to DB
        static void WriteData(IotUnit unit)
        {
            string connString = "server=127.0.0.1;uid=root;" + "pwd=P@55w.rd;database=bilar";
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                string sql = "INSERT INTO `iotunits`.`iotunit` (`DeviceID`, `IPAdress`, `Timestamp`, `DeviceType`, `DeviceCategory`, `Value`, `Unit`) VALUES ('" + unit.DeviceID + "', '" + unit.IPadress + "', '" + DateTime.Now + "', '" + unit.DeviceType + "', '" + unit.DeviceCategory + "', '" + unit.Value + "', '" + unit.Unit + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                DataTable table = conn.GetSchema("Databases");
                string tName = table.TableName;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) { }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static private IPAddress GetLocalIP()
        {
            //Retrives the local computers IP from the DNS
            IPAddress[] iPAddresses = Dns.GetHostAddresses(Dns.GetHostName());
            return iPAddresses[3];
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

        public IOTunit(string deviceId, string iPAddress, DateTime timeStamp, string deviceType, string deviceCatagory, double value, char unit)
        {
            this.deviceId = deviceId;
            this.iPAddress = IPAddress.Parse(iPAddress);
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
