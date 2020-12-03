using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Model
{
    class DoanhThu
    {
        private int thang;
        private int nam;
        private float doanhThu;

        public DoanhThu() { }
        public DoanhThu(int thang, int nam, float doanhThu)
        {
            this.Thang = thang;
            this.Nam = nam;
            this.doanhThu = doanhThu;
        }

        public int Thang { get => thang; set => thang = value; }
        public int Nam { get => nam; set => nam = value; }
        public float _DoanhThu { get => doanhThu; set => doanhThu = value; }
    }
}
