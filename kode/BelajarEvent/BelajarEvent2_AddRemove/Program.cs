using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarEvent2_AddRemove
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Press any key to run device...");

            Console.ReadKey();
            Console.WriteLine();

            IDevice device = new Device();

            device.RunDevice();

            Console.ReadKey();
        }
    }

    public class CoolingMechanism : ICoolingMechanism
    {
        void ICoolingMechanism.Off()
        {
            Console.WriteLine();
            Console.WriteLine("Setting cooling mechanism off...");
            Console.WriteLine();
        }

        void ICoolingMechanism.On()
        {
            Console.WriteLine();
            Console.WriteLine("Setting cooling mechanism on...");
            Console.WriteLine();
        }
    }

    public class Thermostat : IThermostat
    {
        private ICoolingMechanism _coolingMechanism = null;
        private IHeatSensor _heatSensor = null;
        private IDevice _device = null;

        public Thermostat(IDevice device, IHeatSensor heatSensor, ICoolingMechanism coolingMechanism)
        {
            _coolingMechanism = coolingMechanism;
            _heatSensor = heatSensor;
            _device = device;
        }

        private void WireUpEventsToEventHandler()
        {
            _heatSensor.TemperatureBelowWarningLevelEventHandler += HeatSensor_TemperatureBelowWarningLevelEventHandler;
            _heatSensor.TemperatureReachesWarningLevelEventHandler += HeatSensor_TemperatureReachesWarningLevelEventHandler;
            _heatSensor.TemperatureReachesEmergencyLevelEventHandler += HeatSensor_TemperatureReachesEmergencyLevelEventHandler;
        }

        private void HeatSensor_TemperatureReachesEmergencyLevelEventHandler(object sender, TemperatureEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine($"Warning Alert!! (Temperature level is equals {_device.EmergencyLevelTemperature} or above )");
            _device.HandleEmergency();
            Console.ResetColor();
        }

        private void HeatSensor_TemperatureReachesWarningLevelEventHandler(object sender, TemperatureEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine($"Warning Alert!! (Temperature level is between {_device.WarningLevelTemperature} and {_device.EmergencyLevelTemperature} )");
            _coolingMechanism.On();
            Console.ResetColor();
        }

        private void HeatSensor_TemperatureBelowWarningLevelEventHandler(object sender, TemperatureEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine($"Information Alert!! (Temperature level is under {_device.WarningLevelTemperature} )");
            _coolingMechanism.Off();
            Console.ResetColor();
        }

        void IThermostat.RunThermostat()
        {
            Console.WriteLine("Thermostat is running");
            WireUpEventsToEventHandler();
            _heatSensor.RunHeatSensor();
        }
    }

    public interface IThermostat
    {
        void RunThermostat();
    }

    public class Device : IDevice
    {
        const double warningLevelTemp = 40;
        const double emergencyLevelTemp = 95;

        double IDevice.WarningLevelTemperature => warningLevelTemp;

        double IDevice.EmergencyLevelTemperature => emergencyLevelTemp;

        void IDevice.HandleEmergency()
        {
            Console.WriteLine();
            Console.WriteLine("Sending out notification to emergency service personal...");
            ShutdownDevice();
            Console.WriteLine();
        }

        private void ShutdownDevice()
        {
            Console.WriteLine("Shutting down device...");
        }

        void IDevice.RunDevice()
        {
            Console.WriteLine("Device is running...");

            ICoolingMechanism cooling = new CoolingMechanism();
            IHeatSensor heat = new HeatSensor(warningLevelTemp, emergencyLevelTemp);
            IThermostat thermos = new Thermostat(this, heat, cooling);

            thermos.RunThermostat();
        }
    }

    public interface IDevice
    {
        double WarningLevelTemperature { get; }
        double EmergencyLevelTemperature { get; }
        void RunDevice();
        void HandleEmergency();
    }

    public interface ICoolingMechanism
    {
        void On();
        void Off();
    }

    public class HeatSensor : IHeatSensor
    {
        double _warningLevelTemp = 0;
        double _emergencyLevelTemp = 0;

        bool _hasReachedWarningLevel = false;

        protected EventHandlerList _eventHandlerList = new EventHandlerList();

        static readonly object _tempReachesEmergencyLevel = new object();
        static readonly object _tempReachesWarningLevel = new object();
        static readonly object _tempBelowWarningLevel = new object();

        private double[] _tempData = null;

        public HeatSensor(double warningLevel, double emergencyLevel)
        {
            _warningLevelTemp = warningLevel;
            _emergencyLevelTemp = emergencyLevel;

            SeedData();
        }

        private void SeedData()
        {
            _tempData = new double[] { 18, 20, 14, 16, 17, 15, 13.4, 20, 25, 28, 60, 40, 30, 27.9, 70, 89, 100.4 };
        }

        private void MonitorTemperature()
        {
            foreach (double temp in _tempData)
            {
                Console.ResetColor();
                Console.WriteLine($"Datetime : {DateTime.Now}, Temperature : {temp}");

                if (temp >= _emergencyLevelTemp)
                {
                    TemperatureEventArgs t = new TemperatureEventArgs
                    {
                        temperature = temp,
                        currentDateTime = DateTime.Now
                    };
                    OnTemperatureReachesEmergencyLevel(t);
                }
                else if(temp >= _warningLevelTemp)
                {
                    _hasReachedWarningLevel = true;
                    
                    TemperatureEventArgs t = new TemperatureEventArgs
                    {
                        temperature = temp,
                        currentDateTime = DateTime.Now
                    };
                    OnTemperatureReachesWarningLevel(t);
                }
                else if(temp < _warningLevelTemp && _hasReachedWarningLevel)
                {
                    _hasReachedWarningLevel = false;

                    TemperatureEventArgs t = new TemperatureEventArgs
                    {
                        temperature = temp,
                        currentDateTime = DateTime.Now
                    };
                    OnTemperatureBelowWarningLevel(t);
                }

                System.Threading.Thread.Sleep(1500);
            }
        }

        public void RunHeatSensor()
        {
            Console.WriteLine("Heat Sensor is running");
            MonitorTemperature();
        }

        protected void OnTemperatureReachesEmergencyLevel(TemperatureEventArgs e)
        {
            EventHandler<TemperatureEventArgs> eventHandler = (EventHandler<TemperatureEventArgs>)_eventHandlerList[_tempReachesEmergencyLevel];

            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }

        protected void OnTemperatureReachesWarningLevel(TemperatureEventArgs e)
        {
            EventHandler<TemperatureEventArgs> eventHandler = (EventHandler<TemperatureEventArgs>)_eventHandlerList[_tempReachesWarningLevel];

            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }

        protected void OnTemperatureBelowWarningLevel(TemperatureEventArgs e)
        {
            EventHandler<TemperatureEventArgs> eventHandler = (EventHandler<TemperatureEventArgs>)_eventHandlerList[_tempBelowWarningLevel];

            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }

        event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureReachesEmergencyLevelEventHandler
        {
            add
            {
                _eventHandlerList.AddHandler(_tempReachesEmergencyLevel, value);
            }

            remove
            {
                _eventHandlerList.RemoveHandler(_tempReachesEmergencyLevel, value);
            }
        }

        event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureReachesWarningLevelEventHandler
        {
            add
            {
                _eventHandlerList.AddHandler(_tempReachesWarningLevel, value);
            }

            remove
            {
                _eventHandlerList.RemoveHandler(_tempReachesWarningLevel, value);
            }
        }

        event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureBelowWarningLevelEventHandler
        {
            add
            {
                _eventHandlerList.AddHandler(_tempBelowWarningLevel, value);
            }

            remove
            {
                _eventHandlerList.RemoveHandler(_tempBelowWarningLevel, value);
            }
        }
    }

    public interface IHeatSensor
    {
        event EventHandler<TemperatureEventArgs> TemperatureReachesEmergencyLevelEventHandler;
        event EventHandler<TemperatureEventArgs> TemperatureReachesWarningLevelEventHandler;
        event EventHandler<TemperatureEventArgs> TemperatureBelowWarningLevelEventHandler;

        void RunHeatSensor();
    }

    public class TemperatureEventArgs : EventArgs
    {
        public double temperature { get; set; }
        public DateTime currentDateTime { get; set; }
    }
}
