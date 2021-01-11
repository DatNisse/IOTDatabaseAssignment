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

            //Console.WriteLine(GetLocalIP().ToString());
            //Console.WriteLine(DateTime.Now.ToString());
            //connectDb();
            IOTunitList = new List<IOTunit>();
            //ListenTCP();            
            ListenTCPPB();
            //GetData();
            Console.ReadLine();
        }
        static void ListenTCPPB()
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

                    if (clientRequest.RequestType == "W")
                    {
                        Console.WriteLine("was going to write data...");
                        //WriteData(clientRequest.List);
                    }
                    else if (clientRequest.RequestType == "R")
                    {
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

        static void ListenTCP()
        {
            try
            {
                TcpListener tcpListener = new TcpListener(GetLocalIP(), 11000);
                tcpListener.Start();
                // Byte[] bytes = new Byte[256];
                // string msgR = null;

                while (true)
                {
                    Console.Write("Waiting for a connection... ");

                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    //msgR = null;

                    NetworkStream stream = tcpClient.GetStream();

                    GetData();
                    SoapFormatter formatter = new SoapFormatter();
                    MemoryStream mStream = new MemoryStream();
                    formatter.Serialize(mStream, IOTunitList[0]);

                    Byte[] bytes = mStream.GetBuffer();
                    int bytes_size = (int)mStream.Length;
                    Byte[] size = BitConverter.GetBytes(bytes_size);
                    //stream.Write(size, 0, 4);
                    stream.Write(bytes, 0, bytes_size);
                    stream.Flush();

                    mStream.Close();
                    stream.Close();
                    tcpClient.Close();

                    /*
                    int i;
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        msgR = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Recived: {0}", msgR);

                        if (msgR[0].Equals('W'))
                        {
                            msgR.Remove(0);
                            WriteData(msgR);
                        }
                        else if(msgR[0].Equals('R'))
                        {
                            GetData();
                            SoapFormatter formatter = new SoapFormatter();

                            formatter.Serialize(stream, IOTunitList[0]);
                            //byte[] msg ;
                            //stream.Write(msg, 0, msg.Length);
                        }
                        else
                        {
                            Console.WriteLine("Unknown intent with message command: {0}", msgR[0]);
                            byte[] msg = Encoding.ASCII.GetBytes("F");
                            stream.Write(msg, 0, msg.Length);
                        }
                        


                    }
                    tcpClient.Close();
                    */
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
            }
        }

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
                while (reader.Read())
                {

                }
                conn.Close();
                //DisplayData(table);
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
