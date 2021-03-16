using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTSensorMonApp
{
   internal class SensorData
    {   //속성 값
        
        public DateTime Current { get; set; } //현재 시간
        public int Vlaue { get; set; } //센서값
        public bool SimulFlag { get; set; } //시뮬레이션 여부

        //생성자 만듦 : 속성값 + art+Enter
        public SensorData(DateTime current, int vlaue, bool simulFlag)
        {
            Current = current;
            Vlaue = vlaue;
            SimulFlag = simulFlag;
        }




    }
}
