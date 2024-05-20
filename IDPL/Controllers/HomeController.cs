using Core.Entity.Common;
using Core.Entity.Enums;
using IDPL.Models;
using IDPL.Resources;
using Microsoft.AspNetCore.Mvc;
using NModbus;

using System.Timers;
using NModbus.Device;
using System.Diagnostics;
using System.Net.Sockets;
using Timer = System.Timers.Timer;

namespace IDPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //public static ModbusClient modbus = null;
        public static System.Timers.Timer tmr_Read;
        public static System.Timers.Timer tmr_Manipulation;
        private static System.Timers.Timer aTimer;
        public static bool allowToRead = true;

        public static ushort[] Values1, Values2, Values3;
        static int i = 0, j = 0, value;
        public static int[,] a = new int[60, 16];
        public static double[] analogValue = new double[60];
        public static double[] analogValue1 = new double[70];
        public static double[] analogValue2 = new double[70];
        public static double[] analogValue3 = new double[70];
        public static double[] analogValue4 = new double[70];
        public static float myFloat;


        public static bool conn = false;
        public static bool turnSDT = false, turnSDF = false, turnco = false, turntemp40 = false, turntemp60 = false, PoorVis = false, GenerateLog = false, StalledTrain = false, sirenON = false, PowerfailedSouth = false, PowerfailedNorth = false, PowerfailedlogSouth = false, PowerfailedlogNorth = false, PowerfailedSouthN = false, PowerfailedNorthN = false, trainat1 = false, trainat12 = false, trainentryexit = false, GenerateLogTC = false, DG1250KVA = false, DG1250KVAStatus = false, DG2250KVA = false, DG2250KVAStatus = false, localTroubleStatus = false, localFireStatus = false, localN = false, remoteTroubleStatus = false, remoteFireStatus = false, remoteN = false, trainLog = false, tc1 = false, tc12 = false, sirnImg = false, btc = false, pageRefresh = false;

        public static DateTime Powerfailedtime = DateTime.Now;
        public static DateTime PowerfailedNtime = DateTime.Now;

        public static string tr_no = null;
        public static int cact = 0, pact = 0;

        public static int[,] aa = new int[8, 16];
        public static int[,] b = new int[8, 16];
        public static int[,] c = new int[8, 16];
        static double analog_value;

        //public static bool conn = false;



        private static Timer _timer;

        public async Task<IActionResult> Index()
        {
            // Initial page load
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetModbusValue()
        {
            int modbusValue = await GetModbusValueAsync();
            return Json(new { value = modbusValue });
        }



        [HttpGet]
        public JsonResult UpdateStatus()
        {
            bool isConnected = false;
            try
            {
                isConnected = CheckModbusConnection("122.169.112.64", 502);
            }
            catch (Exception ex)
            {
                return Json(new { IsConnected = false });
            }

            return Json(new { IsConnected = isConnected });
        }


        private bool CheckModbusConnection(string ipAddress, int port)
        {
            TcpClient tcpClient = new TcpClient();
            try
            {
                

               
               
                    tcpClient.BeginConnect(ipAddress, port, null, null);
                return true;
                //using (TcpClient tcpClient = new TcpClient(ipAddress, port))
                //{
                //    ModbusFactory modbusFactory = new ModbusFactory();
                //    IModbusMaster modbusMaster = modbusFactory.CreateMaster(tcpClient);
                //    modbusMaster.Transport.Retries = 3; // Set number of retries

                //    // Attempt to connect
                //    modbusMaster.Transport.ReadTimeout = 1000; // Set read timeout
                //    modbusMaster.Transport.WriteTimeout = 1000; // Set write timeout
                //    modbusMaster.Transport.WaitToRetryMilliseconds = 1000; // Set wait time between retries
                //    modbusMaster.ReadCoils(1, 0, 1);

                //    // Connection successful
                //    Console.WriteLine("Modbus connection is established.");
                //    // You can proceed with your Modbus operations here

                //    // Connection failed

                //    // Handle the failure scenario here

                //    // Add any additional checks or commands to validate the connection
                //    return true; // Connection successful
                //}
            }
            catch
            {
                Console.WriteLine("Failed to establish Modbus connection.");
                return false; // Connection failed
            }
        }
        private async Task<int> GetModbusValueAsync()
        {
            int modbusValue = 0;

            try
            {
                using (TcpClient tcpClient = new TcpClient("122.169.112.64", 502))
                {
                    ModbusFactory modbusFactory = new ModbusFactory();
                    IModbusMaster modbus = modbusFactory.CreateMaster(tcpClient);

                    byte slaveAddress1 = 1;
                    ushort startAddress1 = 1;
                    ushort startAddress2 = 200;
                    ushort startAddress3 = 300;
                    ushort numberOfPoints1 = 60;
                    ushort numberOfPoints2 = 70;

                    ushort[] ushortArray1 = modbus.ReadHoldingRegisters(slaveAddress1, startAddress1, numberOfPoints1);
                    ushort[] ushortArray2 = modbus.ReadHoldingRegisters(slaveAddress1, startAddress2, numberOfPoints2);
                    ushort[] ushortArray3 = modbus.ReadHoldingRegisters(slaveAddress1, startAddress3, numberOfPoints2);

                    byte[] byteArray1 = new byte[ushortArray1.Length * 2];
                    Buffer.BlockCopy(ushortArray1, 0, byteArray1, 0, byteArray1.Length);
                    byte[] byteArray2 = new byte[ushortArray2.Length * 2];
                    Buffer.BlockCopy(ushortArray2, 0, byteArray2, 0, byteArray2.Length);
                    byte[] byteArray3 = new byte[ushortArray3.Length * 2];
                    Buffer.BlockCopy(ushortArray3, 0, byteArray3, 0, byteArray3.Length);

                    modbusValue = ushortArray1[11];
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Error: " + ex.Message);
            }

            return modbusValue;
        }

        [HttpPost]
        public async Task<IActionResult> ToggleBit([FromBody] BitToggleRequest request)
        {
            try
            {
                using (TcpClient client = new TcpClient("122.169.112.64", 502))
                {
                    var factory = new ModbusFactory();
                    var master = factory.CreateMaster(client);

                    // Read current value
                    ushort[] registers = await master.ReadHoldingRegistersAsync(1, (ushort)(request.Address - 40001), 1);
                    ushort currentValue = registers[0];

                    // Determine the current state of the bit before toggling
                    int bitStateBeforeToggle = (currentValue >> request.BitIndex) & 1;

                    // Toggle the specified bit
                    ushort mask = (ushort)(1 << request.BitIndex);
                    ushort newValue = (ushort)(currentValue ^ mask);

                    // Write the new value
                    await master.WriteSingleRegisterAsync(1, (ushort)(request.Address - 40001), newValue);

                    return Json(new { success = true, bitStateBeforeToggle });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }



    }
    public class BitToggleRequest
    {
        public int Address { get; set; }
        public int BitIndex { get; set; }
    }

    //private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    //{

    //    ReadCheck();
    //}

    //private static void YourMethod()
    //{
    //    // Your method logic here
    //    Console.WriteLine("YourMethod was called.");
    //}




    //public IActionResult Index()
    //{
    //    _timer = new Timer(10000); // 10000 milliseconds = 10 seconds

    //    // Hook up the Elapsed event for the timer
    //    _timer.Elapsed += OnTimedEvent;

    //    // Start the timer in the background
    //    Task.Run(() => _timer.Start());
    //    // bool issuccess = ReadCheck();
    //    bool issuccess = true;
    //    if (issuccess)
    //    {
    //        ViewBag.AddLevel = "true";
    //    }
    //    else
    //    {
    //        ViewBag.AddLevel = "false";
    //    }
    //    return View();
    //}

    //public IActionResult Privacy()
    //{
    //    return View();
    //}

    //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //public IActionResult Error()
    //{
    //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //}

    //public static bool ReadCheck()
    //{
    //    bool issuccess = false;
    //    if (allowToRead)
    //    {
    //        try
    //        {
    //            using (TcpClient tcpClient = new TcpClient())
    //            {
    //                // tcpClient.Connect("192.168.1.200", 502);122.169.112.64
    //                tcpClient.Connect("122.169.112.64", 502); 
    //                if (tcpClient.Connected)
    //                {
    //                    // The socket is connected
    //                    Console.WriteLine("Connected to the Modbus server.");

    //                    // Perform Modbus operations here
    //                }
    //                ModbusFactory modbusFactory = new ModbusFactory();
    //                IModbusMaster modbus = modbusFactory.CreateMaster(tcpClient);

    //                //IModbusMaster modbus = null;



    //                byte slaveAddress1 = 1;
    //                ushort startAddress1 = 1;
    //                ushort startAddress2 = 200;
    //                ushort startAddress3 = 300;
    //                ushort numberOfPoints1 = 60;
    //                ushort numberOfPoints2 = 70;

    //                ushort[] ushortArray1 = modbus.ReadHoldingRegisters(slaveAddress1, startAddress1, numberOfPoints1);
    //                ushort[] ushortArray2 = modbus.ReadHoldingRegisters(slaveAddress1, startAddress2, numberOfPoints2);
    //                ushort[] ushortArray3 = modbus.ReadHoldingRegisters(slaveAddress1, startAddress3, numberOfPoints2);

    //                byte[] byteArray1 = new byte[ushortArray1.Length * 2];
    //                Buffer.BlockCopy(ushortArray1, 0, byteArray1, 0, byteArray1.Length);
    //                byte[] byteArray2 = new byte[ushortArray2.Length * 2];
    //                Buffer.BlockCopy(ushortArray2, 0, byteArray2, 0, byteArray2.Length);
    //                byte[] byteArray3 = new byte[ushortArray3.Length * 2];
    //                Buffer.BlockCopy(ushortArray3, 0, byteArray3, 0, byteArray3.Length);

    //                int index = 11 * 2;

    //                // Access the bytes
    //                byte lowerByte = byteArray1[index]; // byteArray1[22]
    //                byte higherByte = byteArray1[index + 1]; // byteArray1[23]

    //                // Combine the bytes to get back the ushort value
    //                ushort reconstructedValue = (ushort)(lowerByte | (higherByte << 8));



    //                if ((double)ushortArray1[11] > 4999)
    //                {
    //                    issuccess = true;
    //                }
    //                else
    //                {
    //                    issuccess = false;
    //                }

    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            conn = false;
    //        }

    //    }
    //    return issuccess;


    //}
    //// public static void write_single_reg(byte slave_no, string coil_No, short state)
    //public IActionResult TurnOnOffLed(  int id = 0)
    //{
    //    //IModbusMaster modbus = null;



    //    //using (TcpClient tcpClient = new TcpClient())
    //    //{
    //    //    tcpClient.Connect("192.168.1.200", 502);
    //    //    if (tcpClient.Connected)
    //    //    {
    //    //        // The socket is connected
    //    //        Console.WriteLine("Connected to the Modbus server.");

    //    //        // Perform Modbus operations here
    //    //    }
    //    //    ModbusFactory modbusFactory = new ModbusFactory();
    //    //    IModbusMaster modbus = modbusFactory.CreateMaster(tcpClient);
    //    //    //modbus = new ModbusTCPMaster(plcIpAddress, 502);
    //    //    //modbus.Connection();

    //    //    if (modbus != null)
    //    //    {
    //    //        byte slaveAdd = slave_no;
    //    //        string startCoilAdd = coil_No;
    //    //        short on_off_state = state;

    //    //        modbus.WriteSingleRegister(slaveAdd, startCoilAdd, on_off_state);
    //    //    }
    //    //}
    //    JsonMessage _jsonMessage = null;
    //    string plcIpAddress = "192.168.1.200";
    //    ushort port = 502;
    //    byte slaveNo = 1; // Replace with your PLC's slave address
    //    ushort coilAddress = 1; // Replace with your coil address
    //    bool coilValue = true; // Replace with the state you want to write (true or false)

    //    if(id == 1)
    //    {
    //        coilValue = true;
    //    }
    //    else if(id == 0)
    //    {
    //        coilValue = false;
    //    }

    //    try
    //    {
    //        using (TcpClient tcpClient = new TcpClient(plcIpAddress, port))
    //        {
    //            ModbusFactory modbusFactory = new ModbusFactory();
    //            IModbusMaster modbus = modbusFactory.CreateMaster(tcpClient);

    //            if (modbus != null && tcpClient.Connected)
    //            {
    //                modbus.WriteSingleCoil(slaveNo, coilAddress, coilValue);
    //                Console.WriteLine("Write operation successful.");
    //                _jsonMessage = new JsonMessage(true, @Resource.lbl_success, "Led Operation Successful", KeyEnums.JsonMessageType.SUCCESS);
    //                //return true;
    //            }
    //            else
    //            {
    //                Console.WriteLine("Failed to create Modbus master or establish connection.");
    //                _jsonMessage = new JsonMessage(false, @Resource.lbl_error, "Led Operation Failed", KeyEnums.JsonMessageType.ERROR);
    //                // return false;
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine("An error occurred: " + ex.Message);
    //    }
    //    return Json(_jsonMessage);

    //}
}