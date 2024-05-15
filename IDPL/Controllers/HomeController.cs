using Core.Entity.Common;
using Core.Entity.Enums;
using IDPL.Models;
using IDPL.Resources;
using Microsoft.AspNetCore.Mvc;
using NModbus;


using NModbus.Device;
using System.Diagnostics;
using System.Net.Sockets;

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

        public IActionResult Index()
        {
            bool issuccess = ReadCheck();
            if (issuccess)
            {
                ViewBag.AddLevel = "true";
            }
            else
            {
                ViewBag.AddLevel = "false";
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static bool ReadCheck()
        {
            bool issuccess = false;
            if (allowToRead)
            {
                try
                {
                    using (TcpClient tcpClient = new TcpClient())
                    {
                        tcpClient.Connect("192.168.1.200", 502);
                        if (tcpClient.Connected)
                        {
                            // The socket is connected
                            Console.WriteLine("Connected to the Modbus server.");

                            // Perform Modbus operations here
                        }
                        ModbusFactory modbusFactory = new ModbusFactory();
                        IModbusMaster modbus = modbusFactory.CreateMaster(tcpClient);

                        //IModbusMaster modbus = null;



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


                        if ((double)ushortArray1[11] > 4999)
                        {
                            issuccess = true;
                        }
                        else
                        {
                            issuccess = false;
                        }
                        //CO2 Value In Slave 4
                        //for (i = 11; i < 12; i++)
                        //{
                        //    if (ScadaWindow.co2 == 250)
                        //    {
                        //        analogValue[i] = (double)(Values1[i] * 0.0625);
                        //    }

                        //    if (ScadaWindow.co2 == 500)
                        //    {
                        //        analogValue[i] = (double)(Values1[i] * 0.125);
                        //    }
                        //}

                        //Values1 = byteArray1;
                        //Values2 = byteArray2;
                        //Values3 = byteArray3;
                    }
                }
                catch (Exception ex)
                {
                    conn = false;
                }
                
            }
            return issuccess;


        }
        // public static void write_single_reg(byte slave_no, string coil_No, short state)
        public IActionResult TurnOnOffLed(  int id = 0)
        {
            //IModbusMaster modbus = null;



            //using (TcpClient tcpClient = new TcpClient())
            //{
            //    tcpClient.Connect("192.168.1.200", 502);
            //    if (tcpClient.Connected)
            //    {
            //        // The socket is connected
            //        Console.WriteLine("Connected to the Modbus server.");

            //        // Perform Modbus operations here
            //    }
            //    ModbusFactory modbusFactory = new ModbusFactory();
            //    IModbusMaster modbus = modbusFactory.CreateMaster(tcpClient);
            //    //modbus = new ModbusTCPMaster(plcIpAddress, 502);
            //    //modbus.Connection();

            //    if (modbus != null)
            //    {
            //        byte slaveAdd = slave_no;
            //        string startCoilAdd = coil_No;
            //        short on_off_state = state;

            //        modbus.WriteSingleRegister(slaveAdd, startCoilAdd, on_off_state);
            //    }
            //}
            JsonMessage _jsonMessage = null;
            string plcIpAddress = "192.168.1.200";
            ushort port = 502;
            byte slaveNo = 1; // Replace with your PLC's slave address
            ushort coilAddress = 1; // Replace with your coil address
            bool coilValue = true; // Replace with the state you want to write (true or false)

            if(id == 1)
            {
                coilValue = true;
            }
            else if(id == 0)
            {
                coilValue = false;
            }

            try
            {
                using (TcpClient tcpClient = new TcpClient(plcIpAddress, port))
                {
                    ModbusFactory modbusFactory = new ModbusFactory();
                    IModbusMaster modbus = modbusFactory.CreateMaster(tcpClient);

                    if (modbus != null && tcpClient.Connected)
                    {
                        modbus.WriteSingleCoil(slaveNo, coilAddress, coilValue);
                        Console.WriteLine("Write operation successful.");
                        _jsonMessage = new JsonMessage(true, @Resource.lbl_success, "Led Operation Successful", KeyEnums.JsonMessageType.SUCCESS);
                        //return true;
                    }
                    else
                    {
                        Console.WriteLine("Failed to create Modbus master or establish connection.");
                        _jsonMessage = new JsonMessage(false, @Resource.lbl_error, "Led Operation Failed", KeyEnums.JsonMessageType.ERROR);
                        // return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return Json(_jsonMessage);

        }

    }
    public class ScadaWindow
    {
        public int co2 { get; set; }
    }
}