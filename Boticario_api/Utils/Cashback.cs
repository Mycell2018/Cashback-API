using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boticario_api.Utils
{
    public class Cashback
    {
        public static Double getPercentual(Double valor)
        {
            Double percent = 0;

            switch (valor)
            {
                case Double n when n <= 1000:
                    percent = .10;
                    break;
                case Double n when n > 1000 && n <= 1500:
                    percent = .15;
                    break;
                case Double n when n > 1500:
                    percent = .20;
                    break;
            }

            return percent;
        }

        public static Double getValor(Double valor)
        {
            return valor * getPercentual(valor);
        }
    }
 }
