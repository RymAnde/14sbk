using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace elevator_control_system
{
    public class Cabin
    {
        private int CabinColumn = 0;          // Номер лифта
        public void SetColumn(int Input)
        {
            CabinColumn = Input;
        }
        public int GetColumn()
        {
            return CabinColumn;
        }
        private int CurrentFloor = 1;         // Этаж, на котором находится кабина в данный момент

        public int GetFloor()           
        {
            return CurrentFloor;
        }

        public bool GetStatus()
        {
            IsBusy = (CabinCallOnFloor_1 && CabinCallOnFloor_2 && CabinCallOnFloor_3);
            return IsBusy;
        }
        
        private bool IsBusy = false;      // false - Free; true - Busy
        public bool Doors = false;        // false - Closed; true - Open
        public bool IsMoving = false;     // false - Stopped; true - Moving
        private bool Direction = false;   // false - Up; true - Down      

        public void Move()                ////// Подъем кабины на один этаж вверх
        {
            if (GetStatus())
            {
                Doors = false;            // Кабина закрывает двери
                IsMoving = true;          // Кабина начинает движение (Лампочка загорелась красным)
                
                if (Direction)
                {
                    if (CurrentFloor < 3)
                        CurrentFloor++;   // Кабина поднимается на один этаж
                    else
                    {
                        Direction = false;
                        Move();
                    }
                }
                else
                {
                    if (CurrentFloor > 1)
                        CurrentFloor--;   // Кабина опускается на один этаж
                    else
                    {
                        Direction = true;
                        Move();
                    }
                }
                IsMoving = false;        // Кабина остановилась (Лампочка загорелась зелёным)
                CabinReset();
            }
        }
        
        public bool CabinCallOnFloor_1 = false; // Внутренняя очередь вызова кабины
        public bool CabinCallOnFloor_2 = false;
        public bool CabinCallOnFloor_3 = false;

        public void CabinCall(int Input)        // Добавить этаж в очередь кабины
        {
            switch (Input)
            {
                case 1:
                    CabinCallOnFloor_1 = true;
                    break;
                case 2:
                    CabinCallOnFloor_2 = true;
                    break;
                case 3:
                    CabinCallOnFloor_3 = true;
                    break;
            }
            IsBusy = true;
        }

        public bool GetQueue(int Input)         // Получить статус очереди кабины
        {
            switch (Input)
            {
                case 1:
                    return CabinCallOnFloor_1;                   
                case 2:
                    return CabinCallOnFloor_2;
                case 3:
                    return CabinCallOnFloor_3;
                default:
                    return IsBusy;
            }           
        }

        public void CabinReset()                // Удалить текущий этаж из очереди вызова кабины
        {
            switch (CurrentFloor)
            {
                case 1:
                    CabinCallOnFloor_1 = false;
                    if (!CabinCallOnFloor_2 && !CabinCallOnFloor_3)
                        IsBusy = false;
                    break;
                case 2:
                    CabinCallOnFloor_2 = false;
                    if (!CabinCallOnFloor_1 && !CabinCallOnFloor_3)
                        IsBusy = false;
                    else
                    {
                        if (CabinCallOnFloor_1)
                            Direction = true;
                        else
                            Direction = false;
                    }
                    break;
                case 3:
                    CabinCallOnFloor_3 = false;
                    if (!CabinCallOnFloor_1 && !CabinCallOnFloor_2)
                        IsBusy = false;
                    break;
            }
            Move();
        }
    }
}