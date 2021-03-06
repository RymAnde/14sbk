﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace elevator_control_system
{
    public class Cabin
    {
        int LongDelay = 3;
        int MediumDelay = 2;
        int ShortDelay = 1;

        public void Delay(int Time)
        {

            /*
            DateTime start = DateTime.Now;
            while ((DateTime.Now - start).TotalMilliseconds < Time)
                Application.DoEvents();
            */
            ///////////////////////////////////////////////////////
            
            if (Time < 1) return;
            DateTime _desired = DateTime.Now.AddSeconds(Time);
            while (DateTime.Now < _desired)
            {
                System.Windows.Forms.Application.DoEvents();
            }
            
        }

        private int CabinColumn = 0;          // Номер лифта
        private int CurrentFloor = 1;         // Этаж, на котором находится кабина в данный момент

        private bool IsBusy = false;          // false - Free; true - Busy
        private bool Doors = true;            // false - Closed; true - Open
        private bool IsMoving = false;        // false - Stopped; true - Moving
        private bool Direction = false;       // false - Up; true - Down

        public bool CabinCallOnFloor_1 = false; // Внутренняя очередь вызова кабины
        public bool CabinCallOnFloor_2 = false;
        public bool CabinCallOnFloor_3 = false;

        public bool RefreshColumn(int Input)
        {
          if (Form1.MainWindow != null)
           {
            Form1.MainWindow.Refresh(Input);
            return true;
           }
            return false;
        }

        public void SetColumn(int Input)
        {
            CabinColumn = Input;
        }
        public int GetColumn()
        {
            return CabinColumn;
        }

        public int GetFloor()
        {
            return CurrentFloor;
        }

        public void CloseDoors()
        {
            Doors = false;
            RefreshColumn(CabinColumn);
        }
        public void OpenDoors()
        {
            Doors = true;
            RefreshColumn(CabinColumn);
        }
        public bool GetDoors()
        {
            return Doors;
        }

        public void StartMoving()
        {
            IsMoving = true;
            RefreshColumn(CabinColumn);
        }
        public void StopMoving()
        {
            IsMoving = false;
            RefreshColumn(CabinColumn);
        }
        public bool GetMovement()
        {
            return IsMoving;
        }


        public bool GetDirection()
        {
            switch (CurrentFloor)
            {
                case 1:
                    if (CabinCallOnFloor_2 || CabinCallOnFloor_3)
                        Direction = false;                          // false - вверх
                    return Direction;
                case 2:
                    if (CabinCallOnFloor_3)
                        Direction = false;
                    return Direction;
                case 3:
                    if (CabinCallOnFloor_1 || CabinCallOnFloor_2)
                        Direction = true;                          // true - вниз 
                    return Direction;
                default:
                    return Direction;
            }
        }

        public bool GetStatus()
        {
            if (CabinCallOnFloor_1 || CabinCallOnFloor_2 || CabinCallOnFloor_3)
                IsBusy = true;
            else
                IsBusy = false;
            return IsBusy;
        }

        public void CheckFirstCabin()
        {
            if ((CabinColumn == 1) && (CurrentFloor != 1))
            {
                CabinCallOnFloor_1 = true;
                Move();
            }
        }

        public void Move()                      ////// Движение кабины
        {
            if (GetQueue(CurrentFloor))
            {
                Stop();
            }
            if (GetStatus())
            {
                CloseDoors();                   // Кабина закрывает двери
                Delay(ShortDelay);
                StartMoving();                  // Кабина начинает движение (Лампочка загорелась красным)
                if (!GetDirection())
                {
                    if (CurrentFloor < 3)
                        CurrentFloor++;         // Кабина поднимается на один этаж
                    else
                        Direction = true;
                }
                else
                {
                    if (CurrentFloor > 1)
                        CurrentFloor--;         // Кабина опускается на один этаж
                    else
                        Direction = false;
                }
                Delay(MediumDelay);
                Stop();
            }
        }

        public void Stop()
        {
            StopMoving();                       // Кабина остановилась (Лампочка загорелась зелёным)
            Delay(ShortDelay);
            if (GetQueue(CurrentFloor))
            {
                OpenDoors();
                CabinReset();
                Delay(LongDelay);
                CloseDoors();
                if (!IsBusy)
                {
                    Delay(LongDelay);
                    CheckFirstCabin();
                }
            else
                Move();
        }
            else
            {
                Move();
            }
        }

        public void CabinCall(int Input)        // Добавить этаж в очередь кабины
        {
            switch (Input)
            {
                case 1:
                    CabinCallOnFloor_1 = true;
                    Move();
                    break;
                case 2:
                    CabinCallOnFloor_2 = true;
                    Move();
                    break;
                case 3:
                    CabinCallOnFloor_3 = true;
                    Move();
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
                    return GetStatus();
            }           
        }

        public bool CabinReset()                // Удалить текущий этаж из очереди вызова кабины
        {
            switch (CurrentFloor)
            {
                case 1:
                    CabinCallOnFloor_1 = false;
                    return GetStatus();
                case 2:
                    CabinCallOnFloor_2 = false;
                    return GetStatus();
                case 3:
                    CabinCallOnFloor_3 = false;
                    return GetStatus();
                default:
                    return GetStatus();
            }
        }
    }
}
 
 