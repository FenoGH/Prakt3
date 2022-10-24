using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libmas2
{
    public class Libmas3
    {
        /// <summary>
        /// Поиск максимального значения в каждом столбце матрицы
        /// </summary>
        /// <param name="mas">передаваемый массив</param>
        /// <param name="nums">Вывод значение в строчку</param>
        public static void Reshenie( ref int[,] mas,out string nums)
        {
            int max;
            nums = "";
            for( int j=0; j<mas.GetLength(1); j++)
            {
                max = 0;
                for(int i=0; i<mas.GetLength(0); i++)
                {
                    if (mas[i,j] > max)
                    {
                        max = mas[i,j];
                    }

                }
                nums += Convert.ToString(max)+" ";                
            }
        }
    }
}
