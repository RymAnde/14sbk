using System;

namespace elevator_control_system
{
    public class Cabin
    {
        private int CurrentFloor = 1;   // Этаж, на котором находится кабина в данный момент

        public int GetFloor() // Подъем кабины на один этаж вверх
        {
            return CurrentFloor;
        }

        public void MoveUp()            // Подъем кабины на один этаж вверх
        {
            if (CurrentFloor < 3)
                CurrentFloor++;
        }

        public void MoveDown()          // Спуск кабины на один этаж вниз
        {
            if (CurrentFloor > 1)
                CurrentFloor--;
        }

        private bool IsBusy = false;    // Статус занятости кабины

        public void Use()               // Занять кабину
        {
            IsBusy = true;
        }

        public void Free()              // Освободить кабину
        {
            IsBusy = false;
        }

        public bool CabinCallOnFloor_1 = false; // Внутренняя очередь вызова кабины
        public bool CabinCallOnFloor_2 = false;
        public bool CabinCallOnFloor_3 = false;

        public void CabinCall(int Input)     // Добавить этаж в очередь кабины
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
        }
        public int CabinReset()             // Удалить текущий этаж из очереди вызова кабины
        {
            switch (CurrentFloor)
            {
                case 1:
                    CabinCallOnFloor_1 = false;
                    break;
                case 2:
                    CabinCallOnFloor_2 = false;
                    break;
                case 3:
                    CabinCallOnFloor_3 = false;
                    break;
            }
            return CurrentFloor;
        }
    }
}




if CurrentFloor 